using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{

    public float mouseSensitivityX = 250f;
    public float mouseSensitivityY = 250f;
    public float walkSpeed = 2f;
    public float jumpForce = 2;
    public LayerMask groundedMask;

    bool grounded;


    Transform cameraT;
    float verticalLookRotation;

    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        cameraT = GameObject.Find("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") *Time.deltaTime * mouseSensitivityX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivityY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 90);
        cameraT.localEulerAngles = Vector3.left * verticalLookRotation;

        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount,targetMoveAmount, ref smoothMoveVelocity, .15f);
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
}
