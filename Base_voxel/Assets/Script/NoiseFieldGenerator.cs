using System.Collections;
using System.Collections.Generic;
using System;

public static class NoiseFieldGenerator
{
    public static int seed = 2;
    public static byte[] baseNoise = new byte[512];
    public static byte[] ErosionNoise = new byte[512];
    public static byte[] pikkNoise = new byte[512];
    private static Random rng;

    static NoiseFieldGenerator()
    {
        rng = new Random(seed);
        for (int i = 0; i < 256; i++)
        {
            baseNoise[i] = (byte)rng.Next(256);
        }

        for (int i = 0; i < 256; i++)
        {
            ErosionNoise[i] = (byte)rng.Next(256);
        }

        for (int i = 0; i < 256; i++)
        {
            pikkNoise[i] = (byte)rng.Next(256);
        }
    }
}
