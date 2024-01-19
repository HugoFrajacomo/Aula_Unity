using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerBloco : MonoBehaviour
{
    //Criar um componente para adicionar um cubo no meio do mapa e injetar os outros scripts nele

    private GameObject cloned;

    // Start is called before the first frame update
    void Start()
    {
        this.cloned = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.cloned.transform.localPosition = new Vector3(0, 0, 0);
        Voar voar = this.cloned.AddComponent<Voar>();
        voar.speed = 0.01f;
        MudarCor mudarcor = this.cloned.AddComponent<color>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
