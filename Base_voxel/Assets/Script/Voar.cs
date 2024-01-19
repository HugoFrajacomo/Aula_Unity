using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voar : MonoBehaviour
{
    private Transform Target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Target = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Target.localPosition = new Vector3(Target.localPosition.x + 0.005f, Target.localPosition.y + 0.005f, Target.localPosition.z);
    }
}
