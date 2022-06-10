using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
  TurnManager turnManager;
  PlayerAttack playerAttack;
  Player player;
  public GameObject ability1;

    void Start()
    {
        player = FindObjectOfType<Player>();
        turnManager = FindObjectOfType<TurnManager>();
        playerAttack = FindObjectOfType<PlayerAttack>();
        ability1 = GameObject.Find("Ability");
        ability1.name = player.moveSet[0];
    }
    

    void Update()
    {
        
    }
    
    private void OnMouseDown() 
    {
        if (turnManager.playerTurn)
        {
            playerAttack.NoCritAttack(gameObject.name);
            turnManager.GiveTurnToEnemy();
            print("I attack !!!!!!!");
        }
    }
}
