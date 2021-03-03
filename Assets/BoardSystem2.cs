using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardSystem2 : MonoBehaviour
{
    public GameObject Board;
    public int amount;

    private float Board_pos;
    void Start()
    {
        Transform Board_pos = this.transform;
    }   
    

    void OnTriggerEnter(Collider other)
    {
        Vector3 Player2_pos_possible = other.GetComponent<Player2Data>().Player2_pos_possible;
        if (Player2_pos_possible == this.transform)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        if(other.Player.tag == "Player2")
        {
            Debug.Log("Tag=Player2");
            Player2data.money = Player2Data.money + amount;
        }
            GetComponent<BoxCollider>().enabled = false;
        
    }
    
}
