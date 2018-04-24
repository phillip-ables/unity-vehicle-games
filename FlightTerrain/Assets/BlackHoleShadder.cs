using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// when we are attaching this to an object their is a camera there
[RequireComponent(typeof(Camera))]
public class BlackHoleShadder : MonoBehaviour {
    //public settings
    public Shader shader;
    public Transform blackhole;
    public float ratio;  // aspect ratio of the screen;
    public float radius;

    //private settings
    Camera cam;
    Material _material;  // this isnt something that exist means underscore



}
