using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string UnitName;
    public int UnitLevel;

    public int damage;//Attack Stat
    public int speed;

    public int maxHP;
    public int currHP;

    public bool TakeDamage(int dmg)
    {
        currHP -= dmg;

        if (currHP <= 0)
            return true;
        else
            return false;

    }
}


