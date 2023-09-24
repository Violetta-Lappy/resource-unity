using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attachment Name", menuName = "Project/Database/05. Create an attachment shop item")]
public class ShopAttachItem : ScriptableObject
{    
    public string attachmentName;
    public Sprite icon;        
    [Range(1, 10)] public int cost = 1;
}
