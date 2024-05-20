using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WorldGenerator
{
    private byte[] heightMap = new byte[Chunk.largura*Chunk.largura];
    private ushort[] blocos = new ushort[Chunk.largura*Chunk.largura*Chunk.altura];
    public Chunk GenerateChunk(ChunkPos pos, Material material)
    {
        GenerateTerrain(pos);
        //GenerateDecoration();
        //GenerateCaves();

        Chunk chunk = new Chunk(pos, material);
        chunk.SetBlocks(this.blocos);

        return chunk;
    }

    private void GenerateTerrain(ChunkPos pos)
    {
        GenerateHeighmaps(pos);
        Generate3DMap();
    }

    private void GenerateHeighmaps(ChunkPos pos)
    {
        float noiseInputX, noiseInputY;
        byte maxHeight = 90;
        byte minHeight = 1;
        for (int x = 0; x < Chunk.largura; x++)
        {
            for (int y = 0; y < Chunk.largura; y++)
            {
                noiseInputX = (pos.x * Chunk.largura + x) * 0.00353f;
                noiseInputY = (pos.z * Chunk.largura + y) * 0.00489f;

                heightMap[x * Chunk.largura + y] = (byte)(Mathf.FloorToInt(Perlin.Noise(noiseInputX, noiseInputY, NoiseFieldGenerator.baseNoise) * maxHeight) + minHeight); 
            }
        }
    }

    private void Generate3DMap()
    {
        for (int x = 0; x < Chunk.largura; x++)
        {
            for (int z = 0; z < Chunk.largura; z++)
            {
                for (int y = 0; y < Chunk.altura; y++)
                {
                    int height = heightMap[x * Chunk.largura + z];
                    blocos[x * Chunk.largura * Chunk.altura + y * Chunk.largura + z] = y < height ? (ushort)1 : (ushort)0;
                }
            }
        }
    }
}
