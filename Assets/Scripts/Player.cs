using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<string> moveSet = new()
    {
        "Punch", 
        "Kick", 
        "Bite", 
        "Game"
    };
    
    public float brainCells; //health
    public float mental; //mana
    public float ferocity; //phy atk
    public float brainDamage; //magic atk
    public float endurance; //phy def
    public float IQ; //magic def
    public float judgment; //crit chance
    
    public float destruction; //crit dmg modifier
    public float resolve; //accuracy
    public float moveSpeed; //ms
   
    void Start()
    {
        StartCoroutine(myDelayFunction());
        print("hee hee ha");
    }

    void Update()
    {
        IsDead();
    }
 
    private IEnumerator myDelayFunction()
    {
        yield return new WaitForSeconds(5);
        print(":)");
    }

    private void IsDead()
    {
        if (brainCells <= 0)
        {
            Destroy(gameObject, 100f);
        }
    }

    // private void movement()
    // {
    //     Input.GetAxis(X)
    // }
}
