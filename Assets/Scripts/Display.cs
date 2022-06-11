using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Display: MonoBehaviour
{
    Enemy enemy;
    Player player;
    [SerializeField] GameObject display;
    void Start()
    {
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();
        if (gameObject.tag == "CombatText")
        {
            SlowTextGenerator($"{player.name} faces Enemy!");
        }
    }

    void Update()
    {
        if (gameObject.tag == "Player")
        {
            display.GetComponent<TextMeshProUGUI>().text = $"BC: {player.brainCells}\n M: {player.mental}";
        }
        if (gameObject.tag == "Enemy")
        {
            display.GetComponent<TextMeshProUGUI>().text = $"BC: {enemy.brainCells}\n M: {enemy.mental}";
        }
        
    }

    public void SlowTextGenerator(string message)
    {
        for (int i = 0; i < message.Length - 1; i++)
        {
            DelayFunction();
            display.GetComponent<TextMeshProUGUI>().text += message.Substring(i, 1);
        }
    }

    public IEnumerator DelayFunction()
    {
        yield return new WaitForSeconds(1f);
    }
}