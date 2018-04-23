﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePilot : MonoBehaviour {

    public float flightSpeed;

    private void Start()
    {
        Debug.Log("Plane Pilot Script added to:" + gameObject.name);
    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * flightSpeed;

        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));
    }
}
