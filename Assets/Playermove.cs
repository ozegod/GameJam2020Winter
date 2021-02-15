using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playermove : MonoBehaviour
{
    static GameObject Dice;
    private DiceController diceController;
    private TurnManager turnManager;
    public static bool Moving;
    public static int u;
    public static int p;

    public static int step;

    // Start is called before the first frame update
    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        diceController = GameObject.Find("DiceController").GetComponent<DiceController>();
        Dice = GameObject.Find("Dice");
        p = 0;
        u = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if ((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.DownArrow)))
        if(Moving)
        {
            PlayerMove();
        }
    }

    public static void MoveStart()
    {
        Moving = true;
    }

    public static void MoveStop()
    {
        Moving = false;
    }

    public static void Movemove()
    {
        //if ((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.DownArrow)))
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            //p = 1;
            //MoveStart();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //p = 2;
            //MoveStart();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //p = 3;
            //MoveStart();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //p = 4;
            //MoveStart();
        }

        if (p > 0)
        {
            MoveStart();
        }
        else
        {
            MoveStop();
        }
    }

    public void PlayerMove()
    {
        Player.D = int.Parse(Dice.GetComponent<Text>().text);
        int currentPlayer = TurnManager.currentPlayer;
        PlayerMovement(Player.D, currentPlayer);
    }

    public static void PlayerMovement(int e, int n)
    {
        float angleTheta;
        float anglePhi;

        if (n == 0)
        {
            angleTheta = Player1Data.angleTheta;
            anglePhi = Player1Data.anglePhi;
        }
        else
        {
            angleTheta = Player2Data.angleTheta;
            anglePhi = Player2Data.anglePhi;
        }

        step = 0;
        float angleTheta0 = angleTheta;
        float anglePhi0 = anglePhi;

        //while (step < e * 30)
        {

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                anglePhi += 30f;
                //u++;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                anglePhi -= 30f;
                //u++;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                angleTheta += 30f;
                //u++;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                angleTheta -= 30f;
                //u++;
            }
            PlayerPosition(angleTheta, anglePhi, n);
            step = (int)Mathf.Abs(angleTheta0 - angleTheta) +(int)Mathf.Abs(anglePhi0 - anglePhi);
            Dice.GetComponent<Text>().text = (e - step/30).ToString();
            //u = 0;
        }

        //myTurn = false;
        //turnManager.CountUp();
    }

    public static void PlayerPosition(float AngleTheta, float AnglePhi, int n)
    {
        if (n == 0)
        {
            Player1Data.angleTheta = AngleTheta;
            Player1Data.anglePhi = AnglePhi;
        }
        else
        {
            Player2Data.angleTheta = AngleTheta;
            Player2Data.anglePhi = AnglePhi;
        }
    }


}

