using UnityEngine;

public class GUIElementText : MonoBehaviour {
    [SerializeField] private ENUM_GUIELEMENT_TEXT_TYPE type;
    [SerializeField] private TMPro.TextMeshProUGUI tmpro_text;

    private void Start() => tmpro_text = this.GetComponent<TMPro.TextMeshProUGUI>();    
    public void Setup() => tmpro_text = this.GetComponent<TMPro.TextMeshProUGUI>();

    public bool IsType(ENUM_GUIELEMENT_TEXT_TYPE _type) { return _type == type; }
    public void SetText(string input) => tmpro_text.text = input;
}
