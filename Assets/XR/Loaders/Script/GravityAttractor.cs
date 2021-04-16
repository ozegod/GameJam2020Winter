using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public GameObject[] Objects;

    public float gravity = -10f;

    public void Attract(Transform body)
    {
        Vector3 targetDir = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        body.rotation = Quaternion.FromToRotation(bodyUp, targetDir) * body.rotation;
<<<<<<< HEAD:Assets/GravityAttractor.cs
        GameObject.FindGameObjectWithTag("objects").GetComponent<Rigidbody>().AddForce(targetDir * gravity);
        GameObject.Find("Player1").GetComponent<Rigidbody>().AddForce(targetDir * gravity);
=======
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().AddForce(targetDir * gravity);
>>>>>>> Photon:Assets/XR/Loaders/Script/GravityAttractor.cs
    }

}
