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

}