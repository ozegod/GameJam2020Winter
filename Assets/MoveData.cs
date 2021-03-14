using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveData : MonoBehaviour
{
    public int e;
    GameObject player = GameObject.Find("Player1");
    static GameObject Dice = GameObject.Find("Dice");

    public static void PlayerMovement(int d, int n)
    {
        float angleTheta;
        float anglePhi;
        //if (n == 0)
        {
            angleTheta = Player1Data.angleTheta;
            anglePhi = Player1Data.anglePhi;
        }
        //else
        {
            //angleTheta = Player2Data.angleTheta;
            //anglePhi = Player2Data.anglePhi;
        }

        int step = 0;
        float angleTheta0 = angleTheta;
        float anglePhi0 = anglePhi;

        //while (step < d*30)
        {
            //if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                //anglePhi += 30f;
                Dice.GetComponent<Text>().text = (d - 1).ToString();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //anglePhi -= 30f;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //angleTheta += 30;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //angleTheta -= 30;
            }
            PlayerPosition(angleTheta, anglePhi, n);
            step = (int)Mathf.Abs(angleTheta0 - angleTheta + anglePhi0 - anglePhi);
            //Dice.GetComponent<Text>().text = (d - step).ToString();
        }

        //myTurn = false;
        //turnManager.CountUp();
    }

    static void PlayerPosition(float angleTheta, float anglePhi, int n)
    {
        if (n == 0)
        {
            Player1Data.angleTheta = angleTheta;
            Player1Data.anglePhi = anglePhi;
        }
        else
        {
            //Player2Data.angleTheta = angleTheta;
            //Player2Data.anglePhi = anglePhi;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        e = 0;
    }

    static bool Moving;
    static int b = 0;

    static void MoveStart()
    {
        Moving = true;
    }

    static void MoveStop()
    {
        Moving = false;
    }

    public static void MoveMove()
    {
        b += 1;
        if (b != 0)
        { 
            MoveStart();
        }
        else if (Player.d == 0)
        {
            MoveStop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving)
        {
            PlayerMovement(Player.d, TurnManager.currentPlayer);
        }
        
    }
}
