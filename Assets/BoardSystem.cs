using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSystem : MonoBehaviour
{
    GameObject Player;
    ScoreSystem scoreScript;
    PlayerCoordinate coordinateScript;

    void Start()
    {
        Player = GameObject.Find ("Player1");
        scoreScript = Player.GetComponent<ScoreSystem>();
        coordinateScript = Player.GetComponent<PlayerCoordinate>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if(coordinateScript.latitude >= 30 && coordinateScript.latitude <= 40)
        {
            if(coordinateScript.latitude >= 138 && coordinateScript.latitude <= 142)
            {
                if(collision.gameObject == GameObject.Find("Player1"))
                    {
                    scoreScript._score += 1;
                    }
            }

        }
    }
}
