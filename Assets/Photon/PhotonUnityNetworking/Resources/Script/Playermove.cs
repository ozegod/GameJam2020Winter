using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
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
        Moving = true;
    }

    public void MoveStop()
    {
        Moving = false;
    }

    public void Movemove()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickRight) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight) || OVRInput.GetDown(OVRInput.RawButton.LThumbstickLeft) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft) || OVRInput.GetDown(OVRInput.RawButton.LThumbstickUp) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickUp) || OVRInput.GetDown(OVRInput.RawButton.LThumbstickDown) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickDown))
        {
            MoveStart();
        }
        else if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.LeftArrow))
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

        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickRight) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight)|| Input.GetKey(KeyCode.RightArrow))
        {
            angleTheta += 10f;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickLeft) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft)|| Input.GetKey(KeyCode.LeftArrow))
        {
            angleTheta -= 10f;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickUp) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickUp)|| Input.GetKey(KeyCode.UpArrow))
        {
            anglePhi += 10f;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstickDown) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickDown)|| Input.GetKey(KeyCode.DownArrow))
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

