using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour
{
    public Dictionary<string, bool> moveType = new() 
    {
        //true = phy, false = magic
        {"Punch", true},
        {"Kick", true},
        {"Bite", true},
        {"Game", false},
        {"Cum", true},
        {"Dab", false},
        {"Screenshare", false},
        {"Zamn", false},
        {"Pet Rat Gummy", false},
    };
   public Dictionary<string, int> moveDamage = new() 
    {
        {"Punch", 5},
        {"Kick", 10},
        {"Bite", 2},
        {"Game", 3},
        {"Cum", 4},
        {"Dab", 5},
        {"Screenshare", 6},
        {"Zamn", 7},
    };
    public Dictionary<string, int> moveManaCost = new() 
    {
        {"Punch", 20},
        {"Kick", 30},
        {"Bite", 40},
        {"Game", 50},
        {"Cum", 1},
        {"Dab", 40},
        {"Screenshare", 50},
        {"Zamn", 80},
    };
}