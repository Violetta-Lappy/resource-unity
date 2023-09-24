using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Advertisements;
using VLGameProject.VLGameProgram;

namespace VLGameProject.VLAdMonetization {
    public class AdManager : GameProgramObject, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener {

        [SerializeField] private const string K_GAMEID_ANDROID = "5298632";
        [SerializeField] private const string K_GAMEID_IOS = "5298633";
        [SerializeField] private string str_gameID;
        [SerializeField] bool isTestMode = true;

        public override void Awake() {
            base.Awake();
            Init_Ad();
        }

        public string Get_GameID_From_Editor(BuildTarget _type) {
            switch (_type) {
                case BuildTarget.Android:
                    return K_GAMEID_ANDROID;
                case BuildTarget.iOS:
                    return K_GAMEID_IOS;
                default:
                    return "NONE - ERROR";
            }
        }

        public string Get_GameID_From_Build(RuntimePlatform _type) {
            switch (_type) {
                case RuntimePlatform.Android:
                    return K_GAMEID_ANDROID;
                case RuntimePlatform.IPhonePlayer:
                    return K_GAMEID_IOS;
                default:
                    return "NONE - ERROR";
            }
        }

        public bool Is_Ad_Compatible_With_CurrentGamePlatform(RuntimePlatform _type) {
            switch (_type) {
                case RuntimePlatform.Android:
                    return true;
                case RuntimePlatform.IPhonePlayer:
                    return true;
                case RuntimePlatform.WebGLPlayer:
                    Debug.Log("No functionality yet, please check !!");
                    return false;
                default:
                    Debug.Log($"Unable to initialize ads on this platform, please check !! {_type}");
                    return false;
            }
        }

        public void Init_Ad() {

            Debug.Log($"Check ads status on this platform, Editor Target Build: {EditorUserBuildSettings.activeBuildTarget} - {Get_GameID_From_Editor(EditorUserBuildSettings.activeBuildTarget)}, Runtime Platform: {Application.platform} - {Get_GameID_From_Build(Application.platform)} ");

#if UNITY_EDITOR
            str_gameID = Get_GameID_From_Editor(EditorUserBuildSettings.activeBuildTarget);
#else
        str_gameID = GetGameIDFromBuild(Application.platform);
#endif

            Advertisement.Initialize(str_gameID, isTestMode, this);
        }

        public void Load_Ad() {

        }

        public void Set_Status_Banner(bool _status) {
            if (_status) { }
        }

        public void DeactivateBanner() {

        }

        public void OnInitializationComplete() => Debug.Log("Unity Ads Initialization Complete !!");

        public void OnInitializationFailed(UnityAdsInitializationError error, string message) {
            Debug.Log($"Ad Initialization Failed: {error.ToString()} - {message}");
        }

        public void OnUnityAdsAdLoaded(string placementId) => Advertisement.Show(placementId, this);

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) {
            Debug.Log($"Error Loading Ad Unit {placementId}: {error.ToString()} - {message}");
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) {
            Debug.Log($"Error Showing Ad Unit {placementId}: {error.ToString()} - {message}");
        }

        public void OnUnityAdsShowStart(string placementId) {
            //TODO - Pause Game
            //Time.timeScale = 0;

            //TODO - STOP BANNER ADS
            //Advertisement.Banner.Hide();
        }

        public void OnUnityAdsShowClick(string placementId) => Advertisement.Show(placementId, this);

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) {
            Debug.Log("OnUnityAdsShowComplete " + showCompletionState);

            if (placementId.Equals("Rewarded_Android") && UnityAdsShowCompletionState.COMPLETED.Equals(showCompletionState)) {
                Debug.Log("rewared Player");
            }

            //TODO - Resume Game
            //Time.timeScale = 1;

            //Reset back to showing Banner Ads
            //Advertisement.Banner.Show("Banner_Android");
        }
    }
}
