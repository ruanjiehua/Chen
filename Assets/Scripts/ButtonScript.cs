using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    TurnManager turnManager;
    Player player;
    Enemy enemy;
    [SerializeField] GameObject[] abilities;

    void Start()
    {
        player = FindObjectOfType<Player>();
        turnManager = FindObjectOfType<TurnManager>();
        enemy = FindObjectOfType<Enemy>();
        for (int i = 0; i < abilities.Length; i++)
        {
            abilities[i].name = player.moveSet[i];
            abilities[i].GetComponent<TextMeshProUGUI>().text = player.moveSet[i];
        }
    }
    
    void Update()
    {
        
    }
    
    private void OnMouseDown() 
    {
        if (turnManager.playerTurn && enemy.brainCells > 0)
        {
            player.PlayerAttack(gameObject.name);
            turnManager.EndPlayerTurn();
            enemy.EnemyAttack();
        }
    }   
}