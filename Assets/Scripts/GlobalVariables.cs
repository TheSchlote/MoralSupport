using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GlobalVariables : MonoBehaviour
{
    public static int PlayerXP;
    public static int PlayerLevel;
    public static string PlayerName;
    public GameObject PlayerIconDisplay;
    public GameObject PlayerNameDisplay;
    public GameObject PlayerXPDisplay;
    public static Sprite PlayerImage;

    

    void Update()
    {
        PlayerNameDisplay.GetComponent<Text>().text = PlayerName;
        PlayerXPDisplay.GetComponent<Text>().text = "Level: " + PlayerLevel;
        PlayerIconDisplay.GetComponent<Image>().sprite = PlayerImage;
    }


}
