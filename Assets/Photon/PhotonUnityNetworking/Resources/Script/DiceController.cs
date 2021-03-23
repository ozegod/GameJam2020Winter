using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    GameObject Dice;
    public int d = 0;
    public int a = 0;

    bool  rolling;

    public void RandomDice()
    {
        Dice.GetComponent<Text>().text = Random.Range(1, 7).ToString();
    }
   
    void DiceStart()
    {
        rolling = true;
    }

    void DiceStop()
    {
        rolling = false;
    }

    void Start()
    {
        Dice = GameObject.Find("Dice");
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
    }


    private void Update()
    {
        if (rolling)
        {
           RandomDice();
        }
    }

}
