using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacionar : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public bool rotateX;
    public bool rotateY;
    public bool rotateZ;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        x = 0.5f;
        y = 0.0f;
        z = 0.0f;
        rotationSpeed = 0f;
    }

    void Update()
    {
        if (rotateX)
        x += Time.deltaTime * rotationSpeed;
        if (rotateY)
        y += Time.deltaTime * rotationSpeed;
        if (rotateZ)
        z += Time.deltaTime * rotationSpeed;
        transform.localRotation = Quaternion.Euler(x, y, z);
    }
}
