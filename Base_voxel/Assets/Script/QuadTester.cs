using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadTester : MonoBehaviour
{
    public Chunk chunk;
    public ChunkPos chunkPos = new ChunkPos(0, 0);


    // Start is called before the first frame update
    void Start()
    {
        this.chunk = new Chunk(chunkPos);
        this.chunk.Gerar();
        this.chunk.Construir();
    }
}