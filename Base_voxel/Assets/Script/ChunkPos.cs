using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPos
{
    public int x;
    public int z;

    public ChunkPos(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public override string ToString()
    {
        return $"Valor x: {this.x}, Valor z: {this.z}";
    }

    public override int GetHashCode()
    {
        return this.x ^ this.z;
    }

    public static bool operator ==(ChunkPos a, ChunkPos b)
    {
        return a.x == b.x && a.z == b.z;
    }

    public static bool operator !=(ChunkPos a, ChunkPos b)
    {
        return a.x != b.x || a.z != b.z;
    }
    public static Direction Direcao (ChunkPos a, ChunkPos b)
    {

        if (a.x > b.x && a.z == b.z)
        {
            return Direction.Direita;
        }
        if (a.x > b.x && a.z > b.z)
        {
            return Direction.CimaDireita;
        }
        if (a.x < b.x && a.z > b.z)
        {
            return Direction.CimaEsquerda;
        }
        if (a.x < b.x && a.z == b.z)
        {
            return Direction.Esquerda;
        }
        if (a.x == b.x && a.z > b.z)
        {
            return Direction.Cima;
        }
        if (a.x == b.x && a.z < b.z)
        {
            return Direction.Baixo;
        }
        if (a.x < b.x && a.z < b.z)
        {
            return Direction.BaixoEsquerda;
        }
        if (a.x > b.x && a.z < b.z)
        {
            return Direction.BaixoDireita;
        }
        return Direction.Parado;

    }
}

public enum Direction
{
    Cima,
    CimaEsquerda,
    Esquerda,
    BaixoEsquerda,
    Baixo,
    BaixoDireita,
    Direita,
    CimaDireita,
    Parado
}
