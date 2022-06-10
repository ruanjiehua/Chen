using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    Player player;
    Enemy enemy;
    public bool playerTurn = true;
    public bool enemyTurn = false;

    void Start()
    {   
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();
    }

   
    void Update()
    {

    }

    public void GiveTurnToPlayer()
    {
       playerTurn = true;
    }

    public void EndTurnPlayerTurn()
    {
        playerTurn = false;
    }
    public void GiveTurnToEnemy()
    {
        enemyTurn = true; 
    }

    
}