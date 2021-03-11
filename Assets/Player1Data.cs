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
    GameObject player1;

    public Vector3 GetPositionOnSphere(float angleTheta, float anglePhi, int r)
    {
        float x = r * Mathf.Sin(angleTheta * 2 * Mathf.PI / 360) * Mathf.Cos(anglePhi * 2 * Mathf.PI / 360);
        float y = r * Mathf.Cos(angleTheta * 2 * Mathf.PI / 360);
        float z = r * Mathf.Sin(angleTheta * 2 * Mathf.PI / 360) * Mathf.Sin(anglePhi * 2 * Mathf.PI / 360);
        return new Vector3(x, y, z);
    }

    private void Start()
    {
        angleTheta = 0f;
        anglePhi = 0f;
        player1 = GameObject.Find("Player1");
        Vector3 firstposition = GetPositionOnSphere(angleTheta, anglePhi, 5);
        player1.transform.position = firstposition;
    }

    void Update()
    {
        player1.transform.position=GetPositionOnSphere(angleTheta, anglePhi, r);
        player1.transform.rotation = Quaternion.Euler(0, 0, angleTheta);
    }
}




