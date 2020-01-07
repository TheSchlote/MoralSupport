using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{

    public Text nameText;
    public Text playerHP;
    public Slider hpBar;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.UnitName;
        
        playerHP.text = "HP: " + unit.currHP + "/" + unit.maxHP;
        hpBar.maxValue = unit.maxHP;
        hpBar.value = unit.currHP;
    }

    public void SetHP(int hp)
    {
        hpBar.value = hp;
    }

}
