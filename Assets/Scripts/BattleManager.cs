using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum BattleStatus { BEGIN, PLAYER, ENEMY, WIN, LOSE };
public class BattleManager : MonoBehaviour
{
    public BattleStatus battleStatus;
    public Transform playerBattlePosition;
    public Transform enemyBattlePosition;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public List<TextMeshProUGUI> abilities;

    public TextMeshProUGUI text;
    public Character playerCharacter;
    public Character enemyCharacter;
    public CombatText combatText;
    Moves moves;
    int myScale = 5000;
    float myWaitTime = 1.75f;
    void Start()
    {
        combatText = FindObjectOfType<CombatText>();
        battleStatus = BattleStatus.BEGIN;
        StartBattle();        
    }

    void StartBattle()
    {
        StartCoroutine(StartBattleCoro());
    }
    IEnumerator StartBattleCoro()
    {
        GameObject player = Instantiate(playerPrefab, playerBattlePosition);
        playerCharacter = player.GetComponent<Character>();
        playerCharacter.transform.localScale = new Vector3(myScale, myScale, myScale);

        GameObject enemy = Instantiate(enemyPrefab, enemyBattlePosition);
        enemyCharacter = enemy.GetComponent<Character>();
        enemyCharacter.transform.localScale = new Vector3(myScale, myScale, myScale);

        for (int x = 0; x < playerCharacter.moveSet.Count; x++)
        {
            abilities[x].name = playerCharacter.moveSet[x];
            abilities[x].text = abilities[x].name;
        }
        combatText.SlowTextGenerator($"{enemyCharacter.characterName} has challenged you!");

        yield return new WaitForSeconds(myWaitTime);

        battleStatus = BattleStatus.PLAYER;
        PlayerTurn();
    }


    void EndBattle()
    {
        if (battleStatus == BattleStatus.WIN)
        {
            combatText.SlowTextGenerator($"You won!");
        }

        if (battleStatus == BattleStatus.LOSE)
        {
            combatText.SlowTextGenerator($"Aw, you lost...");
        }
    }

    void PlayerTurn()
    {
        StartCoroutine(PlayerTurnCoro());
    }
    IEnumerator PlayerTurnCoro()
    {
        combatText.SlowTextGenerator($"What will you do?");
        yield return new WaitForSeconds(myWaitTime);
    }
    public void PlayerAttack(string selectedAttack)
    {
        StartCoroutine(PlayerAttackCoro(selectedAttack));
    }

    IEnumerator PlayerAttackCoro(string selectedAttack)
    {
        battleStatus = BattleStatus.ENEMY;
        combatText.SlowTextGenerator($"You used {selectedAttack}!");
        
        yield return new WaitForSeconds(myWaitTime);
        
        bool isDead = enemyCharacter.takeDamage(playerCharacter.DamageCalculation(selectedAttack));
        if (isDead)
        {
            battleStatus = BattleStatus.WIN;
            enemyCharacter.GetComponent<SpriteRenderer>().enabled = false;
            EndBattle();
        }
        else 
        {
            EnemyTurn();
        }
    }

    void OnEndTurn()
    {
        if (battleStatus != BattleStatus.PLAYER)
        {
            return;
        }
        else
        {
            battleStatus = BattleStatus.ENEMY;
        }
    }
    void EnemyTurn()
    {
    StartCoroutine(EnemyTurnCoro());
    }
    IEnumerator EnemyTurnCoro()
    {
        if (enemyCharacter.EnemyDamageCalculation()[2] == 0)
        {
        combatText.SlowTextGenerator($"{enemyCharacter.characterName} has no mana and couldn't attack!");       
        }
        else
        {
        combatText.SlowTextGenerator($"{enemyCharacter.characterName} used {enemyCharacter.moveSet[enemyCharacter.EnemyDamageCalculation()[2]]}");
        }

        yield return new WaitForSeconds(4f);

        bool isDead = playerCharacter.takeDamage(enemyCharacter.EnemyDamageCalculation()[0]);

        if (isDead)
        {
            battleStatus = BattleStatus.LOSE;
            playerCharacter.GetComponent<SpriteRenderer>().enabled = false;
        }
        else 
        {
            battleStatus = BattleStatus.PLAYER;
            PlayerTurn();
        }
    }
}