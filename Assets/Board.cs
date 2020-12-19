using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        (other.Player.tag == "Player")
            {
                Debug.Log("Tag=Player");
                playerdata.money += amount;
            }
        }

    void Update()
    {
        if 
        
    }
}
