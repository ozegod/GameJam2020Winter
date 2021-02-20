using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Data : MonoBehaviour
{
    public static int money;
    public static float x;
    public static float y;
    public static float z;
    public static float angleTheta;
    public static float anglePhi;
    public static int r = 10;


    public Vector3 Player2_pos_possible;
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

        //Playerが行ける場所の計算
            Transform Player2_pos = this.transform;
        float x = Player2_pos.x;
        float y = Player2_pos.y;
        float z = Player2_pos.z;
        int a ;
        int b ;
        while(diceController.d >= Mathf.abs(a))
        {
        Mathf.abs(b) = diceController.d - a;
        Theta1 = a * 30 * Mathf.Deg2Rad;
        Phi1 = b * 30 * Mathf.Deg2Rad;
        Player2_pos_possible.x = x + r * Mathf.Sin(Theta1) * Math.Cos(Phi1);
        Player2_pos_possible.y = y + r * Mathf.Sin(Theta1);
        Player2_pos_possible.z = z + r * Mathf.Sin(Theta1) * Mathf.Sin(Phi1);
        Player2_pos_possible = Vector3 (Player_pos_possible.x, Player_pos_possible.y, Player_pos_possible.z);

            int currentPlayer = TurnManager.currentPlayer;
            PlayerMovement(d, currentPlayer);
    }
}
}

