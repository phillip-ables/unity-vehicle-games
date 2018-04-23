using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePilot : MonoBehaviour {

    public float flightSpeed;
    private float minSpeed = 35.0f;
    private float maxSpeed = 80.0f;

    private void Start()
    {
        Debug.Log("Plane Pilot Script added to:" + gameObject.name);
    }

    private void Update()
    {
        Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;

        float bias = 0.96f;  // spring function -- weighted average
        Camera.main.transform.position = Camera.main.transform.position * bias +
                                        moveCamTo * (1 - bias);
        Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);

        transform.position += transform.forward * Time.deltaTime * flightSpeed;
        flightSpeed -= transform.forward.y * 50.0f * Time.deltaTime;

        if (flightSpeed < minSpeed)
            flightSpeed = minSpeed;
        if(flightSpeed > maxSpeed)
            flightSpeed = maxSpeed;

        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);
        if(terrainHeightWhereWeAre > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,
                                            terrainHeightWhereWeAre,
                                            transform.position.z);
        }
    }
}
