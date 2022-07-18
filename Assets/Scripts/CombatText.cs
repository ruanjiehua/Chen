using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CombatText: MonoBehaviour
{
    List<string> textQueue;
    public readonly float totalWaitTime = 2.5f;
    public readonly float extraWaitTime = 1.5f;
    [SerializeField] TextMeshProUGUI text;
    void Start()
    {

    }

    public void SlowTextGenerator(string message)
    {
       StartCoroutine(SlowTextGeneratorCoro(message));
    }
    public IEnumerator SlowTextGeneratorCoro(string message)
    {
        float waitTime = (totalWaitTime - extraWaitTime) / message.Length;
        text.text = "";

        for (int i = 0; i < message.Length ; i++)
        {
            yield return new WaitForSeconds(waitTime);
            text.text += message.Substring(i, 1);
        }
        yield return new WaitForSeconds(extraWaitTime);
    }

    // public void StatTextUpdate(int healthUpdate, string identifer)
    // {
    //     StartCoroutine(StatTextUpdateCoro(healthUpdate, identifer));
    // }
    // public IEnumerator StatTextUpdateCoro(int healthUpdate, string identifier)
    // {
    //     TextMeshProUGUI text = null;
    //     if (identifier == "Player") {text = playerStatText;}
    //     else if (identifier == "Enemy") {text = enemyStatText;}
    //     if (text != null && text == playerStatText)
    //     {
    //         text.text = $"BC: {player.brainCells}\n M: {player.mental}";
    //         for (int x = healthUpdate; x == 0; x--)
    //         {
    //             yield return new WaitForSeconds(totalWaitTime / 20f);
    //             text.text = $"BC: {player.brainCells - 1}\n M: {player.mental}";
    //         }
    //     }
    //     if (text != null && text == enemyStatText)
    //     {
    //         text.text = $"BC: {enemy.brainCells}\n M: {enemy.mental}";
    //         for (int x = healthUpdate; x == 0; x--)
    //         {
    //             yield return new WaitForSeconds(totalWaitTime / 20f);
    //             text.text = $"BC: {enemy.brainCells - 1}\n M: {enemy.mental}";
    //         }
    //     }
    // }
   
}