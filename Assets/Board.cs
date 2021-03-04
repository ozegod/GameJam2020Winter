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
        Transform Board_pos = this.transform;
    }

    void Update(float angleTheta,float anglePhi)
    {
        //半径5の球
        int r = 1;

        float x = r * Mathf.Sin(angleTheta) * Mathf.Cos(anglePhi);
        float y = r * Mathf.Cos(angleTheta);
        float z = r * Mathf.Sin(angleTheta) * Mathf.Sin(anglePhi);

        //空間座標の位置
        Vector3 Player_coordinate= new Vector3(x, y, z);
    }

}