using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIManager : SingletonBlank<GUIManager> {
    public TextMeshProUGUI m_score;
    public void UpdateTextScore(float value) { m_score.SetText("Score: " + value); }
}
