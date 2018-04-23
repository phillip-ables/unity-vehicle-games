using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePilot : MonoBehaviour {

    public float flightSpeed;
    private float minSpeed = 35.0f;
    private float maxSpeed = 130.0f;

    private void Start()
    {
        Debug.Log("Plane Pilot Script added to:" + gameObject.name);
    }

    private void Update()
    {
        Vector3 moveCamTo = transform.position - transform.forward * 10.0f + transform.up * 5.0f;
        Camera.main.transform.position = moveCamTo;
        Camera.main.transform.LookAt(transform.position);

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
