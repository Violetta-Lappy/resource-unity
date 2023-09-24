public class GUIElementText : UnityEngine.MonoBehaviour {
    public ENUM_GUIELEMENT_TEXT_TYPE type;
    private TMPro.TextMeshProUGUI tmpro_text;    

    public void Setup() {
        tmpro_text = this.GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void SetText(string input) {
        tmpro_text.text = input;
    }
}
