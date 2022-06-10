using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Player player;
    Enemy enemy;
    Moves moves;
    void Start()
    {
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();
        moves = FindObjectOfType<Moves>();
    }

    void Update()
    {
        
    }

    public void NoCritAttack(string attack)
    {
        if (moves.moveType[attack] && player.mental >= moves.moveManaCost[attack])
        {
            enemy.brainCells -= (player.ferocity + moves.moveDamage[attack]) - (enemy.endurance);
        } 
        else if (!moves.moveType[attack])
            {
                enemy.brainCells -= (player.brainDamage) - (enemy.IQ);
            }
    }

}
