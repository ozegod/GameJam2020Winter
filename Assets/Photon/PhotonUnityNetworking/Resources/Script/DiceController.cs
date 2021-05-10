using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    public GameObject Dice;
    public int a = 0;

    bool moving;

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
        if (a % 3 == 1)
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