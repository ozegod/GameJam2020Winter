using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    GameObject Dice;
    public static int d = 0;
    int a = 0;
    int m = 0;

    bool moving;

    int RandomDice()
    {
        d = Random.Range(1, 7);
        this.Dice.GetComponent<Text>().text = d.ToString();
        return d;
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
            if ( a%2 == 0)
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
