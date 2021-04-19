 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{

    private Color m_oldColor = Color.white;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player1")
        {
            Renderer render = GetComponent<Renderer>();

            m_oldColor = render.material.color;
            render.material.color = Color.green;   

        }

    }
    
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "Player1")
        {
            Renderer render = GetComponent<Renderer>();
            render.material.color = m_oldColor;

        }       
    }
}
