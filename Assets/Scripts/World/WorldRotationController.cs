﻿using UnityEngine;
using System.Collections;

public class WorldRotationController : MonoBehaviour {

    [SerializeField]
    private float rotationSpeed;

    void Update()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }
}
