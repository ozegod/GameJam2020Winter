using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light Light1;
    public Light Light2;

    // Start is called before the first frame update
    void Start()
    {
        Light1 = GameObject.Find("Light1").GetComponent<Light>();
        Light2 = GameObject.Find("Light2").GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TurnManager.currentPlayer == 0)
        {
            Light1.enabled = true;
            Light2.enabled = false;
            Vector3 lipos1 = Light1.transform.position;
            lipos1 = new Vector3(0, 1, -4);
        }
        else
        {
            Light1.enabled = true;
            Light2.enabled = false;
            Vector3 lipos2 = Light2.transform.position;
            lipos2 = new Vector3(0, 1, -4);
        }
    }
}
