using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// when we are attaching this to an object their is a camera there
[RequireComponent(typeof(Camera))]
public class BlackHoleShadder : MonoBehaviour {
    //public settings
    public Shader shader;
    public Transform blackhole;
    public float aspectRatio;  // aspect ratio of the screen;
    public float radius;

    //private settings
    Camera cam;
    Material _material;  // this isnt something that exist means underscore

    Material material
    {
        //way of accessing the material but also making sure its created at any given time
        get
        {
            if (_material == null)
            {
                _material = new Material(shader);
                _material.hideFlags = HideFlags.HideAndDontSave;
            }
            return _material;
        }
    }

    private void OnEnable()
    {
        cam = GetComponent<Camera>();
        aspectRatio = 1f / cam.aspect;
    }

    public void OnDisable()
    {
        if(_material)
        {
            DestroyImmediate(_material);
        }
    }

    Vector3 wtsp;
    Vector2 pos;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if(shader && material && blackhole)
        {
            wtsp = cam.WorldToScreenPoint(blackhole.position);

            //is the blackhole in front of the camera
            if(wtsp.z > 0)
            {
                pos = new Vector2(wtsp.x / cam.pixelWidth, wtsp.y / cam.pixelHeight);
                //apply shader parameters
                _material.SetVector("_Position", pos);
                _material.SetFloat("_Ratio", aspectRatio);
                _material.SetFloat("_Rad", radius);
                _material.SetFloat("_Distance", Vector3.Distance(blackhole.position, transform.position));

                //apply the shader to the image
                Graphics.Blit(source, destination, material);
            }
        }   
    }
}
