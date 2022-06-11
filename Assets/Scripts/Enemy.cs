using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemy : MonoBehaviour
{
    public string name = "Enemy";
    public float brainCells; //health
    public float mental; //mana
    public float ferocity; //phy atk
    public float brainDamage; //magic atk
    public float endurance; //phy def
    public float IQ; //magic def
    public float judgment; //crit
    public float destruction; //crit dmg modifier
    public float resolve; // mana regen
    public float moveSpeed; //ms
    TurnManager turnManager;
    Player player;
    Moves moves;
    Display display;
    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject combatText;
    List<string> moveSet = new()
    {
        "Punch", 
        "Kick", 
        "Bite", 
        "Game"
    };
    
    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
        player = FindObjectOfType<Player>();
        moves = FindObjectOfType<Moves>();
        display = FindObjectOfType<Display>();
    }

    void Update()
    {
       
    }
    
    public void EnemyAttack()
    {
        if (!turnManager.playerTurn)
        {
            string attack = "";
            if (brainCells > 0)
            {
                if (hasEnoughMana())
                {
                    attack = moveSet[avalibleMoves()[Random.Range(0, avalibleMoves().Count)]];
                    DamageCalculation(attack);
                    turnManager.playerTurn = true;
                }
                else if (!hasEnoughMana())
                {
                    turnManager.playerTurn = true;
                    display.SlowTextGenerator($"{name} has no Mana and it is unable to attack!");
                }
            }
            if (isPlayerDead())
            {
                player.brainCells = 0;
                thePlayer.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    public List<int> avalibleMoves()
    {
        List<int> numOfAvalibleMoves = new() {0, 1, 2, 3};
        for (int i = moveSet.Count - 1; i > -1; i--)
        {
            if (mental < moves.moveManaCost[moveSet[i]])
            {
                numOfAvalibleMoves.RemoveAt(i);
            }
        } return numOfAvalibleMoves;
    }

    public bool isPlayerDead()
    {
        if (player.brainCells <= 0)
        {
            return true;
        }
        else return false;
    }

    public void DamageCalculation(string attack)
    {
        if (isCrit())
        {
            if (moves.moveType[attack])
            {
                player.brainCells -= ((ferocity + moves.moveDamage[attack]) * destruction) - (player.endurance);
            }
            else if (!moves.moveType[attack])
            {
                player.brainCells -= (brainDamage * destruction) - (player.IQ);
            }
            display.SlowTextGenerator($"{name} used {attack}! Destruction!");
        } 
        else
        {
            if (moves.moveType[attack])
            {
                player.brainCells -= (ferocity + moves.moveDamage[attack]) - (player.endurance);
            } 
            else if (!moves.moveType[attack])
            {
                player.brainCells -= (brainDamage - player.IQ);
            }
            display.SlowTextGenerator($"{name} used {attack}!");
        } 
    }
    
    public bool hasEnoughMana()
    {
        if (avalibleMoves() == null)
        {
            return false;
        }
        else return true;
    }

    public bool isCrit()
    {
        if (judgment < Random.Range(0f, 100f))
        {
            return true;
        }
        else return false;
    }
}