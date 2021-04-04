using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSystem : MonoBehaviour
{
    public GameObject Board;

    //boardのポジション
    private float Board_pos;
    void Start()
    {
        float angleTheta = 0, anglePhi = 0;
        //球の半径（1）
        float r = 5f;

        float x = r * Mathf.Sin(angleTheta) * Mathf.Cos(anglePhi);
        float y = r * Mathf.Cos(angleTheta);
        float z = r * Mathf.Sin(angleTheta) * Mathf.Sin(anglePhi);

        //空間座標の位置
        Vector3 Player_coordinate= new Vector3(x, y, z);
        Transform Board_pos = this.transform;
    }

    void Update(float angleTheta,float anglePhi)
    {
        //球の半径（1）
        float r = 5f;

        float x = r * Mathf.Sin(angleTheta) * Mathf.Cos(anglePhi);
        float y = r * Mathf.Cos(angleTheta);
        float z = r * Mathf.Sin(angleTheta) * Mathf.Sin(anglePhi);

        //空間座標の位置
        Vector3 Player_coordinate= new Vector3(x, y, z);

        if(angleTheta%30 == 0 && anglePhi % 30 == 0)
        {
            Debug.Log("score + 1");
        }
    }

}