//NAME: HOANG LONG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Singleton<PlayerStat>
{    
    public float _health;
    public float _stamina;
    
    public CharacterStat health;
    public CharacterStat stamina;    

    [Header("Inventory")]
    public int money;
    public int attackRune;
    public int defenseRune;
    public int speedRune;

    [Header("Player Attributes")]   
    public List<PlayerAttribute> attributeList = new List<PlayerAttribute>(); 
    
    [Header("Player Skills Enable")]   
    public List<ShopSkillItem> skillList = new List<ShopSkillItem>(); 
    public bool isDash = false;
    public bool isDefence = false;
    public bool isTimeStop = false;


    void Start()
    {
        health.BaseValue = ProjectConstants.PLAYERSTAT_DEFAULT_HEALTH;
        stamina.BaseValue = ProjectConstants.PLAYERSTAT_DEFAULT_STAMINA;

        //GUIManager.Instance.Update_PlayerStat_Health();
        //GUIManager.Instance.Update_PlayerStat_Stamina();

        //GUIManager.Instance.Update_Runes_Token();

        //Update all attribute of real values
        for(int i = 0; i < attributeList.Count; i++)
        {
            attributeList[i].realValue = attributeList[i].stat.BaseValue;
        }
    }
    
    void Update()
    {
        
    }

    public void DamagePlayer(float value)
    {
        _health -= value;

        //If reach 0 then please die
        if(_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void UpgradeHealth_Flat(float value)
    {        
        health.AddModifier(new StatModifier(value, StatModType.Flat));

        //GUIManager.Instance.Update_PlayerStat_Health();
    }

    public void UpgradeHealth_Percent(float value)
    {
        health.AddModifier(new StatModifier(value, StatModType.PercentAdd));

        //GUIManager.Instance.Update_PlayerStat_Health();
    }    

    public void UpgradeStamina_Flat(float value)
    {        
        stamina.AddModifier(new StatModifier(value, StatModType.Flat));

        //GUIManager.Instance.Update_PlayerStat_Stamina();
    }

    public void UpgradeStamina_Percent(float value)
    {
        stamina.AddModifier(new StatModifier(value, StatModType.PercentAdd));

        //GUIManager.Instance.Update_PlayerStat_Stamina();
    }

    public void BuffTemporary_Extension(BUFF_TYPE buffType, int value, float duration)
    {
        if(buffType == BUFF_TYPE.Health)
        {                
            StartCoroutine(Buff_Temporary_PlayerHealth(value, duration));            
        }
            
        else if(buffType == BUFF_TYPE.Stamina)
        {                
            StartCoroutine(Buff_Temporary_PlayerStamina(value, duration));            
        }            
    }

    //Only allow to run in PlayerStat.cs not outside
    private IEnumerator Buff_Temporary_PlayerHealth(int value, float duration)
    {        
        StatModifier tempStat = new StatModifier(value, StatModType.Flat);

        //Add Stat
        health.AddModifier(tempStat);
        
        //Update UI
        //GUIManager.Instance.Update_PlayerStat_Health();

        yield return new WaitForSeconds(duration);        

        //Remove specific stat
        health.RemoveModifier(tempStat);

        //Update UI
        //GUIManager.Instance.Update_PlayerStat_Health();        
    }    

    //Only allow to run in PlayerStat.cs not outside
    private IEnumerator Buff_Temporary_PlayerStamina(int value, float duration)
    {
        StatModifier tempStat = new StatModifier(value, StatModType.Flat);

        //Add Stat
        stamina.AddModifier(tempStat);
        
        //Update UI
        //GUIManager.Instance.Update_PlayerStat_Stamina();

        yield return new WaitForSeconds(duration);

        //Remove specific stat
        stamina.RemoveModifier(tempStat);

        //Update UI
        //GUIManager.Instance.Update_PlayerStat_Stamina();        
    }

    //RUNE RELATED
    public void IncreaseRune(int value)
    {
        attackRune += value;
        defenseRune += value;
        speedRune += value;
    }


    public void Get_Stat(ShopSkillItem skill)
    {
        if(skill.costType == COST_TYPE.ATTACK_RUNE)
        {
            if(attackRune >= skill.cost)
            {
                attackRune -= skill.cost;   

                //UpgradeStat(skill);                                             

                //GUIManager.Instance.Update_Runes_Token();
            }

            else
                Debug.Log("Not enough rune to activate the skill");
        }

        else if(skill.costType == COST_TYPE.DEFENCE_RUNE)
        {
            if(defenseRune >= skill.cost)
            {
                defenseRune -= skill.cost;       

                //UpgradeStat(skill);                         

                //GUIManager.Instance.Update_Runes_Token();
            }

            else
                Debug.Log("Not enough rune to activate the skill");
        }

        else if(skill.costType == COST_TYPE.SPEED_RUNE)
        {
            if(speedRune >= skill.cost)
            {
                speedRune -= skill.cost;   

                //UpgradeStat(skill);                             

                //GUIManager.Instance.Update_Runes_Token();
            }

            else
                Debug.Log("Not enough rune to activate the skill");
        }       
    } 

    //public void UpgradeStat(ShopSkillItem skill)
    //{        
    //    switch(skill.statName)
    //    {            
    //        case STAT_NAME.Upgrade_Health:                                         
    //        //Upgrade the health
    //        attributeList[0].stat.AddModifier(new StatModifier(skill.statIncreaseValue, StatModType.Flat));                             

    //        //Calculate the real value
    //        attributeList[0].realValue = attributeList[0].stat.Value;
    //        break;     

    //        case STAT_NAME.Upgrade_Stamina:                                         
    //        //Upgrade the Stamina
    //        attributeList[1].stat.AddModifier(new StatModifier(skill.statIncreaseValue, StatModType.Flat));                             

    //        //Calculate the real value
    //        attributeList[1].realValue = attributeList[1].stat.Value;
    //        break;     

    //        case STAT_NAME.Upgrade_Attack:                                         
    //        //Upgrade the Attack
    //        attributeList[2].stat.AddModifier(new StatModifier(skill.statIncreaseValue, StatModType.Flat));                             

    //        //Calculate the real value
    //        attributeList[2].realValue = attributeList[2].stat.Value;
    //        break;            

    //        case STAT_NAME.Upgrade_Defense:                                         
    //        //Upgrade the Defense
    //        attributeList[3].stat.AddModifier(new StatModifier(skill.statIncreaseValue, StatModType.Flat));                             

    //        //Calculate the real value
    //        attributeList[3].realValue = attributeList[3].stat.Value;
    //        break;         

    //        case STAT_NAME.Upgrade_Speed:                                         
    //        //Upgrade the Speed
    //        attributeList[4].stat.AddModifier(new StatModifier(skill.statIncreaseValue, StatModType.Flat));                             

    //        //Calculate the real value
    //        attributeList[4].realValue = attributeList[4].stat.Value;
    //        break;            

    //        default:

    //        break;
    //    }

    //}   

    ////SKILLS RELATED
    //public void Get_Skills(ShopSkillItem skill)
    //{
    //    if(skill.costType == COST_TYPE.ATTACK_RUNE)
    //    {
    //        if(attackRune >= skill.cost)
    //        {
    //            attackRune -= skill.cost;
    //            Enable_Skills(skill);

    //            GUIManager.Instance.Update_Runes_Token();
    //        }

    //        else
    //            Debug.Log("Not enough rune to activate the skill");
    //    }

    //    else if(skill.costType == COST_TYPE.DEFENCE_RUNE)
    //    {
    //        if(defenseRune >= skill.cost)
    //        {
    //            defenseRune -= skill.cost;
    //            Enable_Skills(skill);

    //            GUIManager.Instance.Update_Runes_Token();
    //        }

    //        else
    //            Debug.Log("Not enough rune to activate the skill");
    //    }

    //    else if(skill.costType == COST_TYPE.SPEED_RUNE)
    //    {
    //        if(speedRune >= skill.cost)
    //        {
    //            speedRune -= skill.cost;
    //            Enable_Skills(skill);

    //            GUIManager.Instance.Update_Runes_Token();
    //        }

    //        else
    //            Debug.Log("Not enough rune to activate the skill");
    //    }
    //}        

    //public void Enable_Skills(ShopSkillItem skill)
    //{
    //    skillList.Add(skill);

    //    switch(skill.skillName)
    //    {
    //        //Activate the skill here, by switching boolean
    //        case SKILL_NAME.Dash:         
    //            isDash = true;               
    //        break;

    //        case SKILL_NAME.Defence:
    //            isDefence = true;
    //        break;

    //        case SKILL_NAME.Time_Stop:
    //            isTimeStop = true;
    //        break;

    //        default:

    //        break;
    //    }

    //}
}
