using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added Library
using TMPro;
using UnityEngine.UI;

public class SkillExtension : MonoBehaviour
{
    //public ShopSkillItem skill;
    //public Image image;
    //public TextMeshProUGUI titleName;    
    //public TextMeshProUGUI cost;
    //public bool isSkillGet = false;    

    //public void SetupUI(ShopSkillItem _skill)
    //{
    //    skill = _skill;
    //    image.sprite = _skill.icon;
    //    titleName.text = "" + (_skill.statName != STAT_NAME.NONE ? _skill.statName.ToString() : _skill.skillName.ToString());                
    //    cost.text = "" + _skill.cost + " " + _skill.costType;
    //}       

    //public void Use()
    //{
    //    //If this is the stat type then
    //    if(skill.statName != STAT_NAME.NONE)
    //    {
    //        PlayerStat.Instance.Get_Stat(skill);
    //    }

    //    else
    //    {
    //        //if not, then begin getting the skill only if player has not get the skill yet
    //        if(isSkillGet == false)
    //        {
    //            PlayerStat.Instance.Get_Skills(skill);

    //            //Not allow the player to get the skill again
    //            isSkillGet = true;
    //        }            
    //    }        
        
    //    //this.GetComponent<Button>().enabled = false;
        
    //    Color tempColor = this.GetComponent<Image>().color;
    //    tempColor.a = 0.5f;
    //    this.GetComponent<Image>().color = tempColor;
    //}
}
