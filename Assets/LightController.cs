﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    GameObject player = GameObject.Find("Player1");

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position+new Vector3(0, 1, -4);
        //transform.rotation = new Quaternion(20, 0, 0,1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position+new Vector3(0, 1, -4);
        //transform.rotation = new Quaternion(20, 0, 0, 1);
    }
}
