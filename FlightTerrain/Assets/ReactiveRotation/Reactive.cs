using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactive : MonoBehaviour {
    public Vector2 angleRange = new Vector2(4f, 4f);
    public bool inverseX;
    public bool inverseY;

    private Vector2 mousePos;
    private Vector2 baseRotation;

    private void Start()
    {
        baseRotation = new Vector2(transform.rotation.eulerAngles.x - angleRange.x * 0.5f,
                                    transform.rotation.eulerAngles.y - angleRange.y * 0.5f);
    }

    private void Update()
    {
        mousePos = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
        float xRot = (inverseX ? 1 - mousePos.y :  mousePos.y ) * angleRange.x + baseRotation.x;
        float yRot = (inverseY ? 1 - mousePos.x : mousePos.x ) * angleRange.y + baseRotation.y;
        transform.localRotation = Quaternion.Euler(new Vector3(xRot, yRot));
    }
}
