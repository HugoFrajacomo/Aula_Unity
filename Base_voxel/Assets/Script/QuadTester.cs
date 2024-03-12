using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadTester : MonoBehaviour
{
    public Chunk chunk;
    public ChunkPos chunkPos = new ChunkPos(0, 0);
    public Material texturas;


    // Start is called before the first frame update
    void Start()
    {
        this.chunk = new Chunk(new ChunkPos (0,0), texturas);
        this.chunk.Gerar();
        this.chunk.Construir();

        this.chunk = new Chunk(new ChunkPos(1, 0), texturas);
        this.chunk.Gerar();
        this.chunk.Construir();

        this.chunk = new Chunk(new ChunkPos(2, 0), texturas);
        this.chunk.Gerar();
        this.chunk.Construir();

    }
}
