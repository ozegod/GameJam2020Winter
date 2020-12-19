using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Data : MonoBehaviour
{
    public static int money;
    public static float x;
    public static float y;
    public static float z;
    public static float angleTheta;
    public static float anglePhi;
    public static int r = 5;

    public Vector3 GetPositionOnSphere(float angleTheta, float anglePhi, int r)
    {
        float x = r * Mathf.Sin(angleTheta) * Mathf.Cos(anglePhi);
        float y = r * Mathf.Cos(angleTheta);
        float z = r * Mathf.Sin(angleTheta) * Mathf.Sin(anglePhi);
        return new Vector3(x, y, z);
    }

    private void Start()
    {
        Vector3 firstposition = GetPositionOnSphere(0f, 0f, 5);
        transform.position = firstposition;
    }

    void Update()
    {
        GetPositionOnSphere(angleTheta, anglePhi, r);
        transform.rotation = Quaternion.Euler(0, 0, angleTheta);
    }
}




