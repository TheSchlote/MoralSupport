using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattelStation;
    public Transform enemyBattelStation;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    private float WaitTime = 2f;

    public GameObject EndBattlePanel;
    public Text txtWinOrLose;
    public Text txtEXP;
    private int EXPGained = 10;

    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        EndBattlePanel.SetActive(false);
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }


    IEnumerator SetupBattle()
    {
        GameObject PlayerGO = Instantiate(playerPrefab, playerBattelStation);
        playerUnit = PlayerGO.GetComponent<Unit>();

        GameObject EnemyGO = Instantiate(enemyPrefab, enemyBattelStation);
        enemyUnit = EnemyGO.GetComponent<Unit>();

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        //Make this have the highest Speed Stat Unit go first
        //Go to the highest speed turn.

        state = BattleState.PLAYERTURN;
        yield return new WaitForSeconds(WaitTime);
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.SetHP(enemyUnit.currHP);

        yield return new WaitForSeconds(WaitTime);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        //change state

    }
    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            Debug.Log("Won!");
            EndBattlePanel.SetActive(true);
            txtWinOrLose.text = "You Won!";
            txtEXP.text = "EXP Gained: " + EXPGained;
            GlobalVariables.PlayerXP += EXPGained;
        }
        else if (state == BattleState.LOST)
        {
            Debug.Log("Lost!");
            EndBattlePanel.SetActive(true);
            txtWinOrLose.text = "You Won!";
            txtEXP.text = "";
        }
    }

    IEnumerator EnemyTurn()
    {
        Debug.Log(enemyUnit.UnitName + "Attacks!");

        yield return new WaitForSeconds(WaitTime);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currHP);

        yield return new WaitForSeconds(WaitTime);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }


    void PlayerTurn()
    {
        Debug.Log("Player Attacks");
        StartCoroutine(PlayerAttack());
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHomeButton()
    {
        SceneManager.LoadScene(1);
    }
    public void OnBackButton()
    {
        SceneManager.LoadScene(1);
    }
    public void OnNextButton()
    {
        SceneManager.LoadScene(1);
    }
}
