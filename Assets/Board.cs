using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSystem : MonoBehaviour
{
    public GameObject Board;

    private float Board_pos;
    void Start()
    {
        Transform Board_pos = this.transform;
    }

    void Update()
    {
        int q, p;
        float anglePhi;
        while (5 >= Mathf.Abs(p)) {
        q = p * 30 * Mathf.deg2rad;
        float x = r * Mathf.Sin(p * 30 * Mathf.deg2rad) * Mathf.Cos(anglePhi);
        float y = r * Mathf.Cos(angleTheta);
        float z = r * Mathf.Sin(angleTheta) * Mathf.Sin(anglePhi);
        return new Vector3(x, y, z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 Player1_pos_possible=other.GetComponent<Player1Data>().Player1_pos_possible;
        if ( Player1_pos_possible == this.transform)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        if(other.Player.tag == "Player1")
            {
                Debug.Log("Tag=Player1");
                player1data.money = Player1Data.money + amount;
            }
        GetComponent<BoxCollider>().enabled = false;
    }
}