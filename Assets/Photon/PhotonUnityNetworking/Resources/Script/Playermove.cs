using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playermove : MonoBehaviour
{
    Text Dice;
    DiceController diceController;
    [SerializeField]
    bool Moving;
    public PlayerData player;
    public int u;
    public int step;

    // Start is called before the first frame update
    void Start()
    {
        diceController = GameObject.Find("DiceController").GetComponent<DiceController>();
        Dice = GameObject.Find("Dice").GetComponent<Text>(); 
        u = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if ((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.DownArrow)))
        if(Moving)
        {
            PlayerMovement(player.D);
        }
    }

    public void MoveStart()
    {
        Debug.Log("true");
        Moving = true;
    }

    public void MoveStop()
    {
        Debug.Log("false");
        Moving = false;
    }

    public void Movemove()
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            MoveStart();
        }
        else
        {
            MoveStop();
        }
    }

    public void PlayerMovement(int e)
    {
        float angleTheta;
        float anglePhi;

        angleTheta = player.angleTheta;
        anglePhi = player.anglePhi;

        step = 0;
        float angleTheta0 = angleTheta;
        float anglePhi0 = anglePhi;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            angleTheta += 10f;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            angleTheta -= 10f;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anglePhi += 10f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anglePhi -= 10f;
        }
        PlayerPosition(angleTheta, anglePhi);
        step = (int)Mathf.Abs(angleTheta0 - angleTheta) + (int)Mathf.Abs(anglePhi0 - anglePhi);
        Dice.text = (e - step / 10).ToString();

    }

    public void PlayerPosition(float AngleTheta, float AnglePhi)
    {
        player.angleTheta = AngleTheta;
        player.anglePhi = AnglePhi;
    }


}

