using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    public GameObject Dice;
    public static int d = 0;
    public int a = 0;

    public bool moving;

    public void RandomDice()
    {
        this.Dice.GetComponent<Text>().text = Random.Range(1, 7).ToString();
    }

    public void DiceStart()
    {
        moving = true;
    }

    public void DiceStop()
    {
        moving = false;
    }

    public void Start()
    {
        this.Dice = GameObject.Find("Dice");
    }

    public void DiceRoll()
    {
        a += 1;
        if (a % 2 != 0)
        {
            DiceStart();
        }
        else
        {
            DiceStop();
        }
        Input.ResetInputAxes();
    }

    private void Update()
    {
        if (moving)
        {
            RandomDice();
        }
    }

}
