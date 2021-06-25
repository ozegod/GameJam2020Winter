using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Text Text;

    float latitude;
    float longitude;
    float latitude0;
    float longitude0;
    //playerの原点からの距離=地球の半径 
    //float r = 50f;

    float cameraSensitivityX;
    float walkSpeed;
    public GameObject cameraT;
    float verticalLookRotation;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    int a;
    public GameObject Dice;
    public GameObject DiceController;
    Rigidbody rigid;
    bool Moving;
    int step;
    int max_step;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        cameraSensitivityX = 150f;
        walkSpeed = 3f;
        a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //左スティックでカメラの操作
        this.transform.Rotate(Vector3.up * OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).x * Time.deltaTime * cameraSensitivityX);

        #region
        //Playerの座標を求めるプログラム
        float Car_X = this.GetComponent<Rigidbody>().position.x;
        float Car_Y = this.GetComponent<Rigidbody>().position.y;
        float Car_Z = this.GetComponent<Rigidbody>().position.z;

        //緯度(latitude)に値するもの（南半球の場合-0度から-90度まで）、longitudeは-180から180まで
        latitude = Mathf.Rad2Deg * Mathf.Atan(Car_Y / Mathf.Sqrt(Mathf.Pow(Car_X, 2) + Mathf.Pow(Car_Z, 2)));
        if (Car_Z == 0)
        {
            longitude = 0;
        }
        else
        {
            longitude = Mathf.Rad2Deg * Mathf.Atan(Car_X / Car_Z);
        }

        #endregion

        int D = int.Parse(Dice.GetComponent<Text>().text);
        Text.text = latitude.ToString() + " : " + longitude.ToString() + " : " + Moving.ToString() + " : " + D.ToString() + " : " + a.ToString();

        if (((D == 0) || a % 3 == 1) && OVRInput.GetDown(OVRInput.Button.One))
        {
            step = 0;
            a = DiceController.GetComponent<DiceController>().a += 1;
            DiceController.GetComponent<DiceController>().DiceRoll();
            latitude0 = latitude;
            longitude0 = longitude;
        }

        if (a % 3 == 2)
        {
            if (D > 0)
            {
                if ((latitude == latitude0) && (longitude == longitude0))
                {
                    max_step = D;
                }
                Moving = true;
            }
            else
            {
                Moving = false;
                rigid.velocity = Vector3.zero;
                rigid.angularVelocity = Vector3.zero;
                rigid.isKinematic = true;
                DiceController.GetComponent<DiceController>().a = a + 1;
            }
        }

        if (Moving)
        {
            Vector3 moveDir = new Vector3(OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).x, 0, OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).y).normalized;
            Vector3 targetMoveAmount = moveDir * walkSpeed;
            moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
            rigid.isKinematic = false;

            float la = Math.Abs(latitude0 - latitude);
            float lo = Math.Abs(longitude0 - longitude);

            step = (int)(Math.Min(la, 360f - la) / 10f + Math.Min(lo, 360f - lo) / 10f);
            Dice.GetComponent<Text>().text = (max_step - step).ToString();
        }

    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    //OculusQuestにおけるボタンやキー入力のコードのメモ
    //(OVRInput.GetDown(OVRInput.RawButton.LThumbstickRight) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight) || OVRInput.GetDown(OVRInput.RawButton.LThumbstickLeft) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft) || OVRInput.GetDown(OVRInput.RawButton.LThumbstickUp) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickUp) || OVRInput.GetDown(OVRInput.RawButton.LThumbstickDown) || OVRInput.GetDown(OVRInput.RawButton.RThumbstickDown))

}

