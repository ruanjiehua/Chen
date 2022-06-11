using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    Player player;
    Enemy enemy;
    [SerializeField] GameObject display;
    public bool playerTurn = true;
    void Start()
    {   
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();
    }

    public void EndPlayerTurn()
    {
        playerTurn = false;
    }
}