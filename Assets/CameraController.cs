using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;

    void Start()
    {
        camera1 = GameObject.Find("Camera1").GetComponent<Camera>();
        camera2 = GameObject.Find("Camera2").GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        // Call this function to disable FPS camera,
        // and enable overhead camera.
        if (TurnManager.currentPlayer == 0)
        {
            camera1.enabled = true;
            camera2.enabled = false;
        }
        // Call this function to enable FPS camera,
        // and disable overhead camera.
        else
        {
            camera1.enabled = false;
            camera2.enabled = true;
        }
    }
}
