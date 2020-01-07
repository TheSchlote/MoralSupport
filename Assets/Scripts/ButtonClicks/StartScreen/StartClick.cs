using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartClick : MonoBehaviour
{

    private Button btnNick;
    private Button btnLogan;
    private Button btnJordan;
    private Button btnRobert;
    private InputField infName;
    private TouchScreenKeyboard keyboard;
    
    // Start is called before the first frame update
    void Start()
    {
        btnNick = GameObject.Find("btnNick").GetComponent<Button>();
        btnLogan = GameObject.Find("btnLogan").GetComponent<Button>();
        btnJordan = GameObject.Find("btnJordan").GetComponent<Button>();
        btnRobert = GameObject.Find("btnRobert").GetComponent<Button>();
        infName = GameObject.Find("InputField").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    public void NickClicked()
    {
        GlobalVariables.PlayerImage = btnNick.GetComponent<Image>().sprite;
    }
    public void LoganClicked()
    {
        GlobalVariables.PlayerImage = btnLogan.GetComponent<Image>().sprite;
    }
    public void JordanClicked()
    {
        GlobalVariables.PlayerImage = btnJordan.GetComponent<Image>().sprite;
    }
    public void RobertClicked()
    {
        GlobalVariables.PlayerImage = btnRobert.GetComponent<Image>().sprite;
    }

    public void ClickStart()
    {
         GlobalVariables.PlayerName = infName.text;
        //if(GlobalVariables.PlayerName != null && GlobalVariables.PlayerImage != null)
        SceneManager.LoadScene(1);
    }



}
