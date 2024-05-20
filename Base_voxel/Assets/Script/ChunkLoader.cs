using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoader : MonoBehaviour
{
    public PosicaoPersonagem personagem;
    private ChunkPos chunkAntiga;
    public Material texturas;
    public WorldGenerator worldGen = new WorldGenerator();

    public int renderDistance = 1;
    public Queue<ChunkPos> chunksToUnload = new Queue<ChunkPos>();
    public Queue<ChunkPos> chunksToLoad = new Queue<ChunkPos>();
    public Dictionary<ChunkPos, Chunk> chunks = new Dictionary<ChunkPos, Chunk>();

    // Start is called before the first frame update
    void Start()
    {
        this.chunkAntiga = this.personagem.GetCurrentChunk();
        LoadInitialChunks(new ChunkPos(0,0));
    }

    // Update is called once per frame
    void Update()
    {
        GetChunk();
        LoadChunk();
        UnloadChunk();
    }

    public void LoadInitialChunks(ChunkPos inicial)
    {
        Chunk chunk;
        for (int i = -renderDistance; i <= renderDistance; i++)
        {
            for(int j = -renderDistance; j <= renderDistance; j++)
            {
                chunk = this.worldGen.GenerateChunk(new ChunkPos(inicial.x + i, inicial.z + j), texturas);
                chunk.Construir();
                chunks.Add(new ChunkPos(inicial.x + i, inicial.z + j), chunk);
            }
        }

    }

    public void GetChunk()
    {
        ChunkPos chunkAutal = this.personagem.GetCurrentChunk();
        Direction d;
        d = ChunkPos.Direcao(chunkAutal, this.chunkAntiga);

        if (chunkAutal != this.chunkAntiga)
        {
            this.chunkAntiga = chunkAutal;
        }
        else
        {
            return;
        }

        switch (d)
        {
            case Direction.Direita:
                for (int i = -renderDistance; i <= renderDistance; i++)
                {
                    chunksToLoad.Enqueue(new ChunkPos(chunkAutal.x + renderDistance, chunkAutal.z + i));
                    chunksToUnload.Enqueue(new ChunkPos(chunkAutal.x - renderDistance -1, chunkAutal.z + i));  
                }
                break;
            case Direction.Esquerda:
                for (int i = -renderDistance; i <= renderDistance; i++)
                {
                    chunksToLoad.Enqueue(new ChunkPos(chunkAutal.x - renderDistance, chunkAutal.z + i));
                    chunksToUnload.Enqueue(new ChunkPos(chunkAutal.x + renderDistance +1, chunkAutal.z + i));
                }
                break;
            case Direction.Cima:
                for (int i = -renderDistance; i <= renderDistance; i++)
                {
                    chunksToLoad.Enqueue(new ChunkPos(chunkAutal.x + i, chunkAutal.z + renderDistance));
                    chunksToUnload.Enqueue(new ChunkPos(chunkAutal.x + i, chunkAutal.z - renderDistance -1));
                }
                break;
            case Direction.Baixo:
                for (int i = -renderDistance; i <= renderDistance; i++)
                {
                    chunksToLoad.Enqueue(new ChunkPos(chunkAutal.x + i, chunkAutal.z - renderDistance));
                    chunksToUnload.Enqueue(new ChunkPos(chunkAutal.x + i, chunkAutal.z + renderDistance +1));
                }
                break;
            case Direction.CimaDireita:
                for (int i = -renderDistance; i <= renderDistance; i++)
                {
                    chunksToLoad.Enqueue(new ChunkPos(chunkAutal.x + renderDistance, chunkAutal.z + i));
                    chunksToUnload.Enqueue(new ChunkPos(chunkAutal.x - renderDistance -1, chunkAutal.z + i));
                }
                for (int i = -renderDistance; i <= renderDistance; i++)
                {
                    chunksToLoad.Enqueue(new ChunkPos(chunkAutal.x + i, chunkAutal.z + renderDistance));
                    chunksToUnload.Enqueue(new ChunkPos(chunkAutal.x + i, chunkAutal.z - renderDistance -1));
                }
                break;
            case Direction.CimaEsquerda:
                for (int i = -renderDistance; i <= renderDistance; i++)
                {
                    chunksToLoad.Enqueue(new ChunkPos(chunkAutal.x - renderDistance, chunkAutal.z + i));
                    chunksToUnload.Enqueue(new ChunkPos(chunkAutal.x + renderDistance +1, chunkAutal.z + i));
                }
                for (int i = -renderDistance; i <= renderDistance; i++)
                {
                    chunksToLoad.Enqueue(new ChunkPos(chunkAutal.x + i, chunkAutal.z + renderDistance));
                    chunksToUnload.Enqueue(new ChunkPos(chunkAutal.x + i, chunkAutal.z - renderDistance -1));
                }
                break;
            case Direction.BaixoDireita:
                for (int i = -renderDistance; i <= renderDistance; i++)
                {
                    chunksToLoad.Enqueue(new ChunkPos(chunkAutal.x + renderDistance, chunkAutal.z + i));
                    chunksToUnload.Enqueue(new ChunkPos(chunkAutal.x - renderDistance -1, chunkAutal.z + i));
                }
                for (int i = -renderDistance; i <= renderDistance; i++)
                {
                    chunksToLoad.Enqueue(new ChunkPos(chunkAutal.x + i, chunkAutal.z - renderDistance));
                    chunksToUnload.Enqueue(new ChunkPos(chunkAutal.x + i, chunkAutal.z + renderDistance +1));
                }
                break;
            case Direction.BaixoEsquerda:
                for (int i = -renderDistance; i <= renderDistance; i++)
                {
                    chunksToLoad.Enqueue(new ChunkPos(chunkAutal.x - renderDistance, chunkAutal.z + i));
                    chunksToUnload.Enqueue(new ChunkPos(chunkAutal.x + renderDistance +1, chunkAutal.z + i));
                }
                for (int i = -renderDistance; i <= renderDistance; i++)
                {
                    chunksToLoad.Enqueue(new ChunkPos(chunkAutal.x + i, chunkAutal.z - renderDistance));
                    chunksToUnload.Enqueue(new ChunkPos(chunkAutal.x + i, chunkAutal.z + renderDistance +1));
                }
                break;
            default:
                break;
        }
    }

    public void LoadChunk()
    {
        if (chunksToLoad.Count == 0)
        {
            return;
        }
        ChunkPos chunkToLoad = chunksToLoad.Dequeue();

        Chunk chunk = this.worldGen.GenerateChunk(chunkToLoad, texturas);
        chunk.Construir();

        chunks.Add(chunkToLoad, chunk);
    }

    public void UnloadChunk()
    {
        if (chunksToUnload.Count == 0)
        {
            return;
        }
        ChunkPos chunkToUnload = chunksToUnload.Dequeue();

        if (chunks.ContainsKey(chunkToUnload))
        {

            Debug.Log(chunkToUnload);
            GameObject.Destroy(chunks[chunkToUnload].go);
            chunks.Remove(chunkToUnload);
        }
    }

}
