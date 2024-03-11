using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public static class QuadGeneretor
{

    public static Vector3[] verticesTop =
    {
        new Vector3(0, 1, 0), //010
        new Vector3(0, 1, 1), //110
        new Vector3(1, 1, 1), //111
        new Vector3(1, 1, 0), //111
    };

    public static Vector3[] verticesDown =
{
        new Vector3(0, 0, 1), // 000
        new Vector3(1, 0, 1), // 100
        new Vector3(1, 0, 0), // 101
        new Vector3(0, 0, 0), // 001
    };

    public static Vector3[] verticesLeft =
{
        new Vector3(0, 0, 1), // 000
        new Vector3(0, 1, 1), // 001
        new Vector3(0, 1, 0), // 011
        new Vector3(0, 0, 0), // 010
    };

    public static Vector3[] verticesRight =
{
        new Vector3(1, 0, 0), // 100
        new Vector3(1, 1, 0), // 101
        new Vector3(1, 1, 1), // 111
        new Vector3(1, 0, 1), // 110
    };

    public static Vector3[] verticesFront =
{
        new Vector3(1, 0, 1),
        new Vector3(0, 0, 1),
        new Vector3(0, 1, 1),
        new Vector3(1, 1, 1),

    };

    public static Vector3[] verticesBack =
{
        new Vector3(0, 0, 0),
        new Vector3(0, 1, 0),
        new Vector3(1, 1, 0),
        new Vector3(1, 0, 0),

    };

    public static int[] triangles = new int[] { 0, 1, 2, 2, 3, 0 };

    public static Vector3[] GetVertices(int face, Vector3 vetorPosicao)
    {
        Vector3[] outputArray = new Vector3[4];
        switch (face)
        {
            case 0:
                for (int i = 0; i < 4; i++)
                {
                    outputArray[i] = verticesTop[i] + vetorPosicao;
                }
                return outputArray;
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    outputArray[i] = verticesDown[i] + vetorPosicao;
                }
                return outputArray;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    outputArray[i] = verticesRight[i] + vetorPosicao;
                }
                return outputArray;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    outputArray[i] = verticesLeft[i] + vetorPosicao;
                }
                return outputArray;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    outputArray[i] = verticesFront[i] + vetorPosicao;
                }
                return outputArray;
            case 5:
                for (int i = 0; i < 4; i++)
                {
                    outputArray[i] = verticesBack[i] + vetorPosicao;
                }
                return outputArray;
        }
        return null;
    }

    public static int[] GetTriangles(int num_vertices)
    {
        int[] outputArray = new int[6];

        for (int i = 0; i < 6; i++)
        {
            outputArray[i] = triangles[i] + num_vertices;
        }

        return outputArray;
    }
}

