using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    GameObject Dice;
    public static int d = 0;
    public int a = 0;

    bool moving;

    void RandomDice()
    {
        Dice.GetComponent<Text>().text = Random.Range(1, 7).ToString();
    }
   
    void DiceStart()
    {
        moving = true;
    }

    void DiceStop()
    {
        moving = false;
    }

    void Start()
    {
        this.Dice = GameObject.Find("Dice");
    }

    public void DiceRoll()
    {
        a += 1;
        if ( a%2 == 1)
        {
            DiceStart();
        }
        else
        {
            DiceStop();
        }
    }

    private void Update()
    {
        if (moving)
        {
            if (TimeManager.t >= 0)
            {
                RandomDice();
            }
        }
    }

}
