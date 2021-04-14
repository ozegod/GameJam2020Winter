using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int goalScore = 10;
    public string labelText = "目標点数: 10";
    public int _score = 0;


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "cube")
        {
            _score += 1;
        }
    }

    public int Score
    {
        get { return _score; }
        set { 
            _score = value; 
 
            if(_score >= goalScore)
            {
                labelText = "You won!";
            }                               
            else
            {
                labelText = "Hint: Find objects" ;
            }
        }
    } 

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Score: " + _score + "/10" );

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height -50, 300, 50), labelText);  
    }      
}
