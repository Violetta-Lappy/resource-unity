using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : Singleton_Persist<CustomCursor>
{
    public void UpdateCursor()
    {
        //Only take x and y position of the mouse        
        Vector3 mousePos = Input.mousePosition;
        float mousePosX = Mathf.Clamp(mousePos.x, 0, Screen.width - 1);
        float mousePosY = Mathf.Clamp(mousePos.y, 0, Screen.height - 1);
        
        this.transform.position = new Vector3 (mousePosX, mousePosY, 0);                
    }        
}
