using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 Player_pos_possible=other.GetComponent<Player>().Player_pos_possible;
        if ( Player_pos_possible == this.transform)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        if(other.Player.tag == "Player")
            {
                Debug.Log("Tag=Player");
                playerdata.money = PlayerData.money + amount;
            }
            GetComponent<BoxCollider>().enabled = false;
        }

    void Update()
    {
        
    }
}
