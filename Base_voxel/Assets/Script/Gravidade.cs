using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;


public class Gravidade : MonoBehaviour
{
    private StopWatchstopwatch = new Stopwatch();
    stopWatch.Start();
    private TimeSpan ts;
    private Transform Target;
    //Gravidade
    public float _gravidade;
    //Velocidade
    private float velocidadeInicial; //Velocidade
    private float VelocidadeNoInstante;
    //alturas
    private float h0 = target.localPosition.y;
    private float hm;
    // Start is called before the first frame update
    void Start()
    {
        Target = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        do
        {
            ts = stopWatch.Elapsed;
            //Altura no exato momento
            hm = h0 + (velocidadeInicial * ts) + (((_gravidade * ts) ^ (1 / 2)) / 2);
            //Velocidade no exato momento;
            speed = (2 * _gravidade * hm) ^ (1 / 2);
            //Atualiza posição do objeto

            Target.localPosition = new Vector3(Target.localPosition.x, Target.localPosition.y == hm, Target.localPosition.z);
        }
        while (Target.localPosition.y >= 0.00);
    }
    stopWatch.Stop();
}
