﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Data : MonoBehaviour
{
    public static int money;
    public static float x;
    public static float y;
    public static float z;
    public static float angleTheta = 180;
    public static float anglePhi = 0;
    public static int r = 5;

    public Vector3 GetPositionOnSphere(float angleTheta, float anglePhi, int r)
    {
        float x = r * Mathf.Sin(angleTheta) * Mathf.Cos(anglePhi);
        float y = r * Mathf.Cos(angleTheta);
        float z = r * Mathf.Sin(angleTheta) * Mathf.Sin(anglePhi);
        return new Vector3(x, y, z);
    }

    void Update()
    {
        GetPositionOnSphere(angleTheta, anglePhi, r);
    }
}

