using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Character : MonoBehaviour
{
    public string characterName;
    public float maxHP;
    public float currentHP;
    public float mana;    
    public float attack;
    public float defense;
    public int critChance;
    public float critDmgModifier;
    public float manaRegen;
    public float moveSpeed;
    protected Moves moves;
    public List<string> moveSet = new()
    {
        "Punch", 
        "Kick", 
        "Bite", 
        "Game"
    };

    void Start()
    {
        moves = FindObjectOfType<Moves>();
    }
    public bool takeDamage(int dmg)
    {
        currentHP -= (dmg - defense);
        if (currentHP <= 0)
        {
            return true;
        } else return false;
    }

     public int DamageCalculation(string selectedAttack)
    {
        int damage = 0;
        if (HasEnoughMana(selectedAttack))
        {
            if (IsCrit())
            {
                if (moves.moveType[selectedAttack])
                {
                    damage = (int) ((attack + moves.moveDamage[selectedAttack]) * critDmgModifier);
                }
                else if (!moves.moveType[selectedAttack])
                {
                    damage = (int) ((attack) * critDmgModifier);
                }
            } 
            else 
            { 
                if (moves.moveType[selectedAttack])
                {
                    damage = (int) ((attack + moves.moveDamage[selectedAttack]));
                } 
                else if (!moves.moveType[selectedAttack])
                {
                    damage = (int) ((attack));
                } 
            }
        }
        return damage;
    }
 
    public bool IsCrit()
    {
        if (critChance > Random.Range(0, 100))
        {
            return true;
        }
        else return false;
    }

    public bool HasEnoughMana(string selectedAttack)
    {
        if (mana >= moves.moveManaCost[selectedAttack])
        {
            return true;
        } else return false;
    }   

       public List<int> availableMoves()
    {
        List<int> numOfAvalibleMoves = new() {0, 1, 2, 3};
        for (int i = moveSet.Count - 1; i > -1; i--)
        {
            if (mana < moves.moveManaCost[moveSet[i]])
            {
                numOfAvalibleMoves.RemoveAt(i);
            }
        } return numOfAvalibleMoves;
    }
    
    public List<int> EnemyDamageCalculation()
    {
        List<int> damageInfo = new List<int>() {0, 0, 0};
        int enemyMove = Random.Range(0, availableMoves().Count);
        damageInfo[1] = enemyMove;
        damageInfo[2] = 1;
        string selectedAttack = moveSet[availableMoves()[enemyMove]];
        if (EnemyHasEnoughMana())
        {
            if (IsCrit())
            {
                if (moves.moveType[selectedAttack])
                {
                    damageInfo[0] = (int) ((attack + moves.moveDamage[selectedAttack]) * critDmgModifier);
                }
                else if (!moves.moveType[selectedAttack])
                {
                    damageInfo[0] = (int) (attack * critDmgModifier);
                }
            } 
            else
            {
                if (moves.moveType[selectedAttack])
                {
                    damageInfo[0] = (int) (attack + moves.moveDamage[selectedAttack]);
                } 
                else if (!moves.moveType[selectedAttack])
                {
                    damageInfo[0] = (int) (attack);
                }
            }
        } 
        else 
        {
            damageInfo[2] = 0;
        }
        return damageInfo;
    }
    
    public bool EnemyHasEnoughMana()
    {
        if (availableMoves() == null)
        {
            return false;
        }
        else return true;
    }
}