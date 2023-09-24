namespace VLGameProject.VLGameComponent {
    [System.Serializable]
    public class PickupSetting {
        public bool isTimeLimit;
        public bool IsTimeLimit() { return isTimeLimit; }
        public PickupSetting Set_IsTimeLimit(bool arg_status) {
            isTimeLimit = arg_status;
            return this;
        }

        public float f_timeLimit;
        public float Get_TimeLimit() { return f_timeLimit; }
        public PickupSetting Set_TimeLimit(float arg_value) {
            f_timeLimit = arg_value;
            return this;
        }
    }
}
