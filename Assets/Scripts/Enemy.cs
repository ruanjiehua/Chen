using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyAI enemyAI;
    public float brainCells; //health
    public float mental; //mana
    public float ferocity; //phy atk
    public float brainDamage; //magic atk
    public float endurance; //phy def
    public float IQ; //magic def
    public float judgment; //crit
    public float resolve; //accuracy
    public float moveSpeed; //ms
   
    void Start()
    {
        
    }

    void Update()
    {
        isDead();
    }
    
    private bool OnMouseDown() 
    {
       return true;
    }
    
    private void isDead()
    {
        if (brainCells <= 0)
        {
            Destroy(gameObject, 100f);
        }
    }

}


    
