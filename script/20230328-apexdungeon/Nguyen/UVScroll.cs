using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVScroll : MonoBehaviour
{
    public float scrollXSpeed = 0.5f;
    public float scrollYSpeed = 0.5f;
    private Renderer mRenderer;

    private void Start() 
    {
        mRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        
    }

    private void LateUpdate() 
    {
        float offsetX = Time.time * scrollXSpeed;
        float offsetY = Time.time * scrollYSpeed;
        mRenderer.material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
