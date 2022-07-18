using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonScript: MonoBehaviour
{
    public BattleManager battleManager;
    public void Start()
    {
        battleManager = FindObjectOfType<BattleManager>();
    }
    public void OnButtonClick()
    { 
        if (battleManager.battleStatus != BattleStatus.PLAYER)
          {
            return;
          }
        battleManager.PlayerAttack(gameObject.name);
    }

}