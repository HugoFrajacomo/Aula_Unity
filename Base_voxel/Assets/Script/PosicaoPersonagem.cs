using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicaoPersonagem : MonoBehaviour
{
    private Transform personagemPosicao;
    private ChunkPos chunkPos;


    void Awake()
    {
        this.personagemPosicao = this.gameObject.transform;
        chunkPos = new ChunkPos(Mathf.FloorToInt(personagemPosicao.position.x / Chunk.largura), Mathf.FloorToInt(personagemPosicao.position.z / Chunk.largura));
    }

    void Update()
    {
        chunkPos = new ChunkPos(Mathf.FloorToInt(personagemPosicao.position.x / Chunk.largura), Mathf.FloorToInt(personagemPosicao.position.z / Chunk.largura));
        //Debug.Log(chunkPos.ToString());
    }

    public ChunkPos GetCurrentChunk() {
        return this.chunkPos;
    }
}

