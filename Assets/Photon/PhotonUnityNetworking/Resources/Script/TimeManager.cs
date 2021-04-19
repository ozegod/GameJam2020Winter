using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static float t;
    GameObject time;

    // Start is called before the first frame update
    void Start()
    {
        time = this.gameObject;
        t = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (t >= 0)
        {
            t -= Time.deltaTime;
        }
        
        time.GetComponent<Text>().text = "残り" + t.ToString("F1") + "秒";
    }
}
