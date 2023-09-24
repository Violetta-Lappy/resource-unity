using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ComponentScrollingTexture : MonoBehaviour {
    public Vector2 ScrollSpeed;
    private void OnEnable() => GetComponent<SpriteRenderer>().material.SetVector("_ScrollSpeed", ScrollSpeed);
    private void Start() => Time.timeScale = 1.0f; //Resume-system
}