using System.Collections.Generic;
using UnityEngine;

namespace VLGameProject.VLGameDatabase {
    //Has to break name convention for this one
    [System.Serializable]
    public class GameDatabaseProgram {
        
        public enum ENUM_MONITOR_RESOLUTION {
            K_PORTRAIT_43_480x640,
            K_PORTRAIT_43_600x800,
            K_PORTRAIT_169_720x1280,
            K_PORTRAIT_169_768x1366,
            K_PORTRAIT_169_1080x1920,
            K_LANDSCAPE_43_640x480,
            K_LANDSCAPE_43_800x600,
            K_LANDSCAPE_169_1280x720,
            K_LANDSCAPE_169_1920x1080,
            K_LANDSCAPE_1610_1600x900,
        }

        public class GameScreenResolution {
            private int i32_width;
            private int i32_height;
            public GameScreenResolution(int arg_width, int arg_height) {
                i32_width = arg_width;
                i32_height = arg_height;
            }
            public int Get_Width() { return i32_width; }
            public int Get_Height() { return i32_height; }
        }

        private readonly static GameScreenResolution[] sz_m_resolution = new GameScreenResolution[] {
            //Portrait Mode        
            new GameScreenResolution(480, 640),
            new GameScreenResolution(600, 800),
            new GameScreenResolution(768, 1024),
            new GameScreenResolution(720, 1280),
            new GameScreenResolution(768, 1366),

            //Landscape Mode
            new GameScreenResolution(640, 480),
            new GameScreenResolution(800, 600),
            new GameScreenResolution(1024, 768),
            new GameScreenResolution(1280, 720),
            new GameScreenResolution(1366, 768),
            new GameScreenResolution(1440, 900),
            new GameScreenResolution(1600, 900), //4:3
            new GameScreenResolution(1600, 1200),
            new GameScreenResolution(1920, 1080),
            new GameScreenResolution(1920, 1200),
            new GameScreenResolution(3840, 2160), //4K, 16:9
        };

        public enum ENUM_MONITOR_REFRESHRATE {
            //MISC
            K_24,
            K_36,
            K_48,
            K_72,
            K_75,
            K_144,
            K_165,
            //COMMON
            K_30,
            K_60,
            K_90,
            K_120,
            K_240,
            K_360,
            K_480,
        }

        //Frame Rate or Frame Per Second
        public enum ENUM_FRAMERATE {
            //COMMON
            K_24,
            K_30,
            K_60,
            K_120,
        }

        private readonly Dictionary<ENUM_MONITOR_REFRESHRATE, int> dict_refreshRate = new Dictionary<ENUM_MONITOR_REFRESHRATE, int>() {
        //MISC
        {ENUM_MONITOR_REFRESHRATE.K_24, 24},
        {ENUM_MONITOR_REFRESHRATE.K_36, 36},
        {ENUM_MONITOR_REFRESHRATE.K_48, 48},
        {ENUM_MONITOR_REFRESHRATE.K_72, 72},
        {ENUM_MONITOR_REFRESHRATE.K_75, 75},
        {ENUM_MONITOR_REFRESHRATE.K_144, 144},
        {ENUM_MONITOR_REFRESHRATE.K_165, 165},
        //COMMON
        {ENUM_MONITOR_REFRESHRATE.K_30, 30},
        {ENUM_MONITOR_REFRESHRATE.K_60, 60},
        {ENUM_MONITOR_REFRESHRATE.K_90, 60},
        {ENUM_MONITOR_REFRESHRATE.K_120, 120},
        {ENUM_MONITOR_REFRESHRATE.K_240, 240},
        {ENUM_MONITOR_REFRESHRATE.K_360, 360},
        {ENUM_MONITOR_REFRESHRATE.K_480, 480},
    };

        public enum ENUM_POSTPROCESSING {
            K_NONE = 0,
            K_MSAA,
            K_MSAA_X2,
            K_MSAA_X4,
            K_MSAA_X8,
            K_MSAA_X16,
            K_AMD_HIGH_FEDILTY,
            K_INTEL_XESS
        }

        public int GetValueRefreshRate(ENUM_MONITOR_REFRESHRATE _type) { return dict_refreshRate[_type]; }        

        //public void ScreenWidth() { }
        //public void ScreenHeight() { }
        //public float GetValueScreenWidth() { return f_fieldOfView; }
        //public float SetValueScreenHeight(float _value) => f_fieldOfView = _value;
        
        public float Get_FieldOfView() { return FieldOfView; }
        public float Set_FieldOfView(float arg_value) => FieldOfView = Mathf.Clamp(arg_value, 0.0f, 360.0f);

        [Header("Engine Setting")]
        public ENUM_FRAMERATE Framerate;

        [Header("Monitor Setting")]
        public ENUM_MONITOR_RESOLUTION MonitorResolution = ENUM_MONITOR_RESOLUTION.K_LANDSCAPE_169_1920x1080;
        public ENUM_MONITOR_REFRESHRATE MonitorRefreshRate;
        public bool isNintendoDsStyle = false;
        public bool isLandscape = false;
        public bool isFullScreen = false;

        [Header("Graphic Setting")]
        public ENUM_POSTPROCESSING PostProcessing;
        public bool isShadow = false;        
        public bool isMotionBlur = false;        

        [Header("Camera Setting")]
        public float FieldOfView = 120;

        [Header("Game Gui Setting")]
        public bool isEnableInGameGui = true;
    }
}
