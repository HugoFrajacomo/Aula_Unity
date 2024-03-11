using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{
    public static int tamanhoAtlasX = 8;
    public static int tamanhoAtlasY = 1;
    public static int tamanhoDoBloco = 128;

    public static Vector2[] GetUVs(ushort id)
    {
        id--;
        Vector2[] Uvs = new Vector2[4];

        int posicaoX = id % tamanhoAtlasX;
        int posicaoY = id / tamanhoAtlasX;

        float tamanhoBlocoX = tamanhoDoBloco / (float)(tamanhoAtlasX * tamanhoDoBloco);
        float tamanhoBlocoY = tamanhoDoBloco / (float)(tamanhoAtlasY * tamanhoDoBloco);

        Uvs[0] = new Vector2(posicaoX * tamanhoBlocoX, posicaoY * tamanhoBlocoY);
        Uvs[1] = new Vector2(posicaoX  * tamanhoBlocoX, (posicaoY + 1) * tamanhoBlocoY);
        Uvs[2] = new Vector2((posicaoX + 1) * tamanhoBlocoX, (posicaoY + 1) * tamanhoBlocoY);
        Uvs[3] = new Vector2((posicaoX + 1) * tamanhoBlocoX, posicaoY * tamanhoBlocoY);

        return Uvs;
    }
}
