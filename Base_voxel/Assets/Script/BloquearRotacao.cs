using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloquearRotacao : MonoBehaviour
{
    void Update()
    {
        // Obter a rota��o atual do bloco
        Vector3 rotacaoAtual = transform.eulerAngles;

        rotacaoAtual.y = 0f;
        transform.eulerAngles = rotacaoAtual;
    }
}
