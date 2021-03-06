﻿using System.Collections;
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
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().AddForce(targetDir * gravity);
    }

}
