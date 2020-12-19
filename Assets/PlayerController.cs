using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    GameObject Dice;
    int m = 0;
    int a = 0;

    private bool moving;

    void RandomDice()
    {
        this.Dice.GetComponent<Text>().text =  Random.Range(1, 7).ToString();
    }

    private void DiceStart()
    {
        moving = true;
    }

    private void DiceStop()
    {
        moving = false;
    }

    void Start()
    {
        this.Dice = GameObject.Find("Dice");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            a += 1;
            if ( a%2 == 0)
            {
                DiceStart();
            }
            else
            {
                DiceStop();
            }
        }
        if (moving)
        {
            RandomDice();
        }
    }
}
