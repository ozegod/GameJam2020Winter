using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// boardのシステム
public class BoardSystem1 : MonoBehaviour
{
    public GameObject Board;
    public int amount;

    private float Board_position;
    void Start()
    {
        Transform Board_position = this.transform;
    }

   void OnTriggerEnter(Collider other)
    {
        Vector3 Player1_pos_possible = other.GetComponent<Player1Data>().Player1_pos_possible;
        if ( Player1_pos_possible == this.transform)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        if(other.Player1Data.tag == "Player1")
        {
            Debug.Log("Tag=Player1");
            Player1data.money = Player1Data.money + amount;
        }
            GetComponent<BoxCollider>().enabled = false;
        
    }
}