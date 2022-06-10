using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    TurnManager turnManager;
    Enemy enemy;
    Player player;
    Moves moves;

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
        enemy = FindObjectOfType<Enemy>();
        player = FindObjectOfType<Player>();
        moves = FindObjectOfType<Moves>();
    }

    void Update()
    {
        
    }
    public void enemyAttack()
    {
        if (turnManager.enemyTurn)
        {
            NoCritAttack("Ability1");
            turnManager.GiveTurnToPlayer();
            print("Victory or Death!");
        }
    }
    
    public void NoCritAttack(string attack)
    {
        if (moves.moveType[attack] && enemy.mental >= moves.moveManaCost[attack])
        {
            player.brainCells -= (enemy.ferocity + moves.moveDamage[attack]) - (player.endurance);
        } 
        else if (!moves.moveType[attack])
            {
                player.brainCells -= (enemy.brainDamage) - (player.IQ);
            }   
    }
}