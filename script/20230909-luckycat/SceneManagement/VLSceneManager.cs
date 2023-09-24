using UltEvents;

namespace VLGameProject.VLSceneManagement {
    public class VLSceneManager : Singleton<VLSceneManager> {
        public UltEvent<ENUM_SCENE> OnSceneLoadSuccess;
        public UltEvent<ENUM_SCENE> OnSceneLoadFail;
        public bool isLoad;
        public bool IsLoad() { return isLoad; }
        public void Set_IsLoad(bool arg_status) {
            isLoad = arg_status;
        }        

        private void Start() {
            OnSceneLoadSuccess += On_Scene_Load;
            OnSceneLoadFail += On_Scene_Load;
        }

        public void Load_Scene(ENUM_SCENE arg_type) {

        }

        public void Async_Load_Scene(ENUM_SCENE arg_type) {
            if (IsLoad()) {
                return; //early-exit
            }

            OnSceneLoadSuccess.Invoke(arg_type);

            //After load success, reset all
            SceneManager_Reset();
        }

        private void On_Scene_Load(ENUM_SCENE arg_type) {
            switch (arg_type) {
                case ENUM_SCENE.K_NONE:
                    break;
                case ENUM_SCENE.K_SPLASH_SCREEN:
                    break;
                case ENUM_SCENE.K_LOADING_SCREEN:
                    break;
                case ENUM_SCENE.K_MAIN_MENU:
                    break;
                case ENUM_SCENE.K_GAMEPLAY:
                    break;
                case ENUM_SCENE.K_RESULT:
                    break;
                default:
                    break;
            }
        }

        public void SceneManager_Reset() {
            Set_IsLoad(false);
        }
    }
}
