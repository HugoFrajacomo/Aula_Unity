using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonagem : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(horizontal, 0f, vertical) * velocidade * Time.deltaTime;

        transform.Translate(movimento);
    }
}
