using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UltEvents;
using VLGameProject.VLTime;
using VLGameProject.VLInput;
using VLGameProject.VLGameMode;
using VLGameProject.VLGui;
using VLGameProject.VLLocalization;
using VLGameProject.Tool;
using VLGameProject.VLAudio;
using VLGameProject.VLCamera;
using VLGameProject.VLAdMonetization;

namespace VLGameProject.VLGameProgram {
    [System.Serializable]
    public class GameProgramManager : Singleton<GameProgramManager> {
        [Header("Event")]
        public UltEvent On_GameProgram_Pause;
        public UltEvent On_GameProgram_Resume;

        [Header("Variable")]
        public bool isGameProgramPause;
        public bool IsGameProgramPause() { return isGameProgramPause; }
        public void Set_IsGameProgramPause(bool arg_status) => isGameProgramPause = arg_status;

        [Header("Component Manager")]
        public InputManager m_inputManager;
        public AudioManager m_audioPlayer;
        public TimeManager m_timeManager;
        public GameModeManager m_gameModeManager;
        public GameProgramValueManager m_gameValueManager;
        public GuiManager m_guiManager;
        public CoroutineManager m_coroutineManager;
        public LocalizationManager m_localizationManager;
        public AdManager m_adManager;
        public CameraManager m_cameraManager;

        //[SerializeField] private CursorManager m_cursorManager;
        //[SerializeField] private SceneLevelManager m_sceneLevelManager;

        //TODO CHECK IF HAVE COMPONENT, IF NOT ADD COMPONENT

        public override void Awake() {
            base.Awake();

            m_inputManager = VLGameProject.Tool.NullCheck.Create_GameObject_With_Class<InputManager>(this.transform, nameof(InputManager));
            //m_inputManager = this.gameObject.IsNullAddComponent<InputManager>(this);
            //m_audioPlayer = VLGameProject.Tool.NullCheck.Create_GameObject_With_Class<AudioManager>(this.transform, nameof(AudioManager));
            //m_timeManager = this.gameObject.IsNullAddComponent<TimeManager>(this);
            //m_gameValueManager = this.gameObject.AddComponent<GameProgramValueManager>();
            //Get_GameModeManager().IsNull(this);
            //m_coroutineManager = this.gameObject.AddComponent<CoroutineManager>();
            //m_adManager = this.gameObject.AddComponent<AdManager>();
            //Get_GuiManager().IsNull(this);
        }

        private void Start() {
            //SceneLevelManager.Instance().On_CurrentScene_Load(); //Transfer all the functions to GameStateManager
        }

        public InputManager Get_InputManager() { return m_inputManager; }
        public TimeManager Get_TimeManager() { return m_timeManager; }
        public GameModeManager Get_GameModeManager() { return m_gameModeManager; }
        public GameProgramValueManager Get_GameValueManager() { return m_gameValueManager; }
        public GuiManager Get_GuiManager() { return m_guiManager; }
        public void Set_GuiManager(GuiManager _guiManager) => m_guiManager = _guiManager;
        public CoroutineManager Get_CoroutineManager() { return m_coroutineManager; }

        public bool IsGameProgramTimePause() { return Time.timeScale == 0; }

        public GameProgramManager Set_TimeScale(float arg_value = 0.0f) {
            Time.timeScale = Mathf.Clamp(arg_value, 0.0f, 2.0f);
            return this;
        }
        public GameProgramManager Set_Cursor_LockState(CursorLockMode arg_type = CursorLockMode.None) {
            Cursor.lockState = arg_type;
            return this;
        }

        public void Handle_PauseResume() {
            if (IsGameProgramPause() == false) {
                Do_Pause();
            }
            else if (IsGameProgramPause()) {
                Do_Resume();
            }
        }

        public void Do_Pause() {
            Set_IsGameProgramPause(true);
            Set_TimeScale(0.0f);
            On_GameProgram_Pause?.Invoke();
            Debug.Log("Pause Game");
        }

        public void Do_Resume() {
            Set_IsGameProgramPause(false);
            Set_TimeScale(1.0f);
            On_GameProgram_Resume?.Invoke();
            Debug.Log("Resume Game");
        }
    }
}
