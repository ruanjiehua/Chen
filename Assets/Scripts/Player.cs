using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public List<string> moveSet = new()
    {
        "Punch", 
        "Kick", 
        "Bite", 
        "Game"
    };
    Player player;
    Enemy enemy;
    Moves moves;
    Display display;
    [SerializeField] GameObject opponent;
    [SerializeField] GameObject combatText;
    public string name = "Chen";
    public float brainCells; //health
    public float mental; //mana
    public float ferocity; //phy atk
    public float brainDamage; //magic atk
    public float endurance; //phy def
    public float IQ; //magic def
    public float judgment; //crit chance
    
    public float destruction; //crit dmg modifier
    public float resolve; //mana regen
    public float moveSpeed; //ms

   
    void Start()
    {
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();
        moves = FindObjectOfType<Moves>();
        display = FindObjectOfType<Display>();
    }

    void Update()
    {
        
    }

    public void PlayerAttack(string attack)
    {
        if (brainCells > 0)
        {
            if (mental >= moves.moveManaCost[attack])
            {
                DamageCalculation(attack);
            } 
            else if (mental < moves.moveManaCost[attack])
            {
                 display.SlowTextGenerator($"Not enough mana! Cannot cast {attack}...");
            }
        }
        if (isEnemyDead())
        {
            enemy.brainCells = 0;
            opponent.GetComponent<SpriteRenderer>().enabled = false;
            combatText.GetComponent<TextMeshProUGUI>().text = $"{enemy.name} has no Brain Cells left!  KO!";
        }
    }

    public bool isEnemyDead()
    {
        if (enemy.brainCells <= 0)
        {
            return true;
        } else return false;
    }

    public void DamageCalculation(string attack)
    {
        if (isCrit())
        {
            if (moves.moveType[attack])
            {
                enemy.brainCells -= ((ferocity + moves.moveDamage[attack]) * destruction) - (enemy.endurance);
            }
            else if (!moves.moveType[attack])
            {
                enemy.brainCells -= (brainDamage * destruction) - (enemy.IQ);
            }
             display.SlowTextGenerator($"{name} used {attack}! Destruction!");
        } 
        else 
        { 
            if (moves.moveType[attack])
            {
                enemy.brainCells -= (ferocity + moves.moveDamage[attack]) - (enemy.endurance);
            } 
            else if (!moves.moveType[attack])
            {
                enemy.brainCells -= (brainDamage - enemy.IQ);
            }
            display.SlowTextGenerator($"{name} used {attack}!");
        }
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