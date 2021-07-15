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
        if (Car_X == 0)
        {
            longitude = 90 * Math.Abs(Car_Z) / Car_Z;            
        }
        else if (Car_X < 0)
        {
            if (Car_Z == 0)
            {
                longitude = 180;
            }
            else
            {
                longitude = 180 * Math.Abs(Car_Z) / Car_Z + Mathf.Rad2Deg * Mathf.Atan(Car_Z / Car_X);
            }
        }
        else
        {
            longitude = Mathf.Rad2Deg * Mathf.Atan(Car_Z / Car_X);
        }

        #endregion

        int D = int.Parse(Dice.GetComponent<Text>().text);
        Text.text = latitude.ToString() + " : " + longitude.ToString() + " : " + Moving.ToString() + " : " + D.ToString() + " : " + a.ToString();

        Vector3 moveDir = new Vector3(OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).x, 0, OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).y).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
        rigid.isKinematic = false;
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    void MoveStop()
    {
        Moving = false;
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        rigid.isKinematic = true;
    }
}

