/*
Copyright 2023 hoanglongplanner

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.IO;
using UnityEditor;
using UnityEngine;

//Based heavily on
//https://www.reddit.com/r/Unity3D/comments/aeh1vd/inheritable_scriptableobjects_with/

namespace VLGameProject.VLEditor {
    public class VLEditorCreateSO {

        //Validate showing menu item
        [MenuItem("Assets/VLEditor/Create Single SOAsset from Script", true)]
        private static bool IsSingleSOScriptAsAssetValid() {
            var h_activeObject = Selection.activeObject;

            // make sure it is a text asset
            if ((h_activeObject == null) || !(h_activeObject is TextAsset)) {
                return false;
            }

            // make sure it is a persistant asset
            var h_assetPath = AssetDatabase.GetAssetPath(h_activeObject);
            if (h_assetPath == null) {
                return false;
            }

            // load the asset as a monoScript
            var h_monoScript = (MonoScript)AssetDatabase.LoadAssetAtPath(h_assetPath, typeof(MonoScript));
            if (h_monoScript == null) {
                return false;
            }

            // get the type and make sure it is a scriptable object
            var h_scriptType = h_monoScript.GetClass();
            if (h_scriptType == null || h_scriptType.IsSubclassOf(typeof(ScriptableObject)) == false) {
                return false;
            }

            return true; //return-outcome
        }

        [MenuItem("Assets/VLEditor/Create Single SOAsset from Script")]
        private static void CreateSingleSOFromScript(MenuCommand arg_command) {
            // we already validated this path from MenuItem, and know these calls are safe
            var activeObject = Selection.activeObject;
            var assetPath = AssetDatabase.GetAssetPath(activeObject);
            var monoScript = (MonoScript)AssetDatabase.LoadAssetAtPath(assetPath, typeof(MonoScript));
            var scriptType = monoScript.GetClass();

            // ask for a path to save the asset
            var path = Path.ChangeExtension(assetPath, "asset");

            // catch all exceptions when playing around with assets and files
            try {
                var h_instance = ScriptableObject.CreateInstance(scriptType);
                AssetDatabase.CreateAsset(h_instance, path);
            }
            catch (Exception e) {
                Debug.LogException(e);
            }
        }

        [MenuItem("Assets/VLEditor/Create Multiple SOAsset from Script", true)]
        private static bool IsMultipleSOScriptAsAssetValid() {
            var h_sz_activeObject = Selection.objects;

            foreach (var h_activeObject in h_sz_activeObject) {
                // make sure it is a text asset
                if ((h_activeObject == null) || (h_activeObject is TextAsset) == false) {
                    return false;
                }

                // make sure it is a persistant asset
                var h_assetPath = AssetDatabase.GetAssetPath(h_activeObject);
                if (h_assetPath == null) {
                    return false;
                }

                // load the asset as a monoScript
                var h_monoScript = (MonoScript)AssetDatabase.LoadAssetAtPath(h_assetPath, typeof(MonoScript));
                if (h_monoScript == null) {
                    return false;
                }

                // get the type and make sure it is a scriptable object
                var h_scriptType = h_monoScript.GetClass();
                if (h_scriptType == null || h_scriptType.IsSubclassOf(typeof(ScriptableObject)) == false) {
                    return false;
                }
            }

            return true; //return-outcome
        }

        [MenuItem("Assets/VLEditor/Create Multiple SOAsset from Script")]
        private static void CreateMultipleSOFromScript(MenuCommand arg_command) {
            // we already validated this path from MenuItem, and know these calls are safe            
            var h_sz_activeObject = Selection.objects;

            foreach (var h_activeObject in h_sz_activeObject) {
                var assetPath = AssetDatabase.GetAssetPath(h_activeObject);
                var monoScript = (MonoScript)AssetDatabase.LoadAssetAtPath(assetPath, typeof(MonoScript));
                var scriptType = monoScript.GetClass();

                // ask for a path to save the asset
                var path = Path.ChangeExtension(assetPath, "asset");

                if(File.Exists(path)) {
                    Debug.LogWarning($"{path} is already exists !! SKIPPING");
                    continue; //early-exit
                }

                // catch all exceptions when playing around with assets and files
                try {
                    var h_instance = ScriptableObject.CreateInstance(scriptType);
                    AssetDatabase.CreateAsset(h_instance, path);
                }
                catch (Exception e) {
                    Debug.LogException(e);
                }
            }
        }
    }
}