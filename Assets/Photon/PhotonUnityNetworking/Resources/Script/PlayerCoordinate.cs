using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoordinate : MonoBehaviour
{
    private GameObject playerObj;
    public Rigidbody rb;

    public float latitude;
    public float longitude;

    //CartesiamのCar

    void Start()
    {
        //Playerのオブジェクトを探す
        playerObj = GameObject.Find("Player1");
    }

    void Update()
    {
        //CartesiamのCar
        float Car_X = playerObj.GetComponent<Rigidbody>().position.x;
        float Car_Y = playerObj.GetComponent<Rigidbody>().position.y;
        float Car_Z = playerObj.GetComponent<Rigidbody>().position.z;



        //緯度(latitude)に値するもの（南半球の場合-0度から-90度まで）、longitudeは0から360まで
        latitude = Mathf.Rad2Deg * Mathf.Atan(Car_Y/Mathf.Sqrt(Mathf.Pow(Car_X,2)+Mathf.Pow(Car_Z,2)));
        longitude = Mathf.Rad2Deg * Mathf.Atan(Car_X/Car_Z);

        //playerの原点からの距離
        float r = Mathf.Sqrt(Mathf.Pow(Car_X,2) + Mathf.Pow(Car_Y,2) + Mathf.Pow(Car_Z,2));

        //Debug.Log("Player Position: X = " + Car_X + " --- Y = " + Car_Y + " --- Z = " + Car_Z);
        
        if(Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("緯度：" + latitude + "緯度：" + longitude);  
        }    
    }
}