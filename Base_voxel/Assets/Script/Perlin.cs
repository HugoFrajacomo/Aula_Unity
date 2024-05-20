//
// Perlin noise generator for Unity
// Keijiro Takahashi, 2013, 2015
// https://github.com/keijiro/PerlinNoise
//
// Based on the original implementation by Ken Perlin
// http://mrl.nyu.edu/~perlin/noise/
//
using UnityEngine;

public static class Perlin
{

    public static float NormalizeOutput(float output){
        return (float)(0.5 * output + 0.5);
    }

    public static float Noise(float x, byte[] noiseField)
    {
        int X = Mathf.FloorToInt(x) & 0xff;
        x -= Mathf.Floor(x);
        float u = Fade(x);
        return NormalizeOutput(Lerp(u, Grad(noiseField[X], x), Grad(noiseField[X+1], x-1)) * 2);
    }

    public static float Noise(float x, float y, byte[] noiseField)
    {
        int X = Mathf.FloorToInt(x) & 0xff;
        int Y = Mathf.FloorToInt(y) & 0xff;
        x -= Mathf.Floor(x);
        y -= Mathf.Floor(y);
        float u = Fade(x);
        float v = Fade(y);
        int A = (noiseField[X  ] + Y) & 0xff;
        int B = (noiseField[X+1] + Y) & 0xff;
        return NormalizeOutput(Lerp(v, Lerp(u, Grad(noiseField[A  ], x, y  ), Grad(noiseField[B  ], x-1, y  )),
                       Lerp(u, Grad(noiseField[A+1], x, y-1), Grad(noiseField[B+1], x-1, y-1))));
    }

    // New addition to turbulance generation
    public static float RidgedMultiFractal(float x, float y, float z, byte[] noiseField)
    {
        int X = Mathf.FloorToInt(x) & 0xff;
        int Y = Mathf.FloorToInt(y) & 0xff;
        int Z = Mathf.FloorToInt(z) & 0xff;
        x -= Mathf.Floor(x);
        y -= Mathf.Floor(y);
        z -= Mathf.Floor(z);
        float u = Fade(x);
        float v = Fade(y);
        float w = Fade(z);
        int A  = (noiseField[X  ] + Y) & 0xff;
        int B  = (noiseField[X+1] + Y) & 0xff;
        int AA = (noiseField[A  ] + Z) & 0xff;
        int BA = (noiseField[B  ] + Z) & 0xff;
        int AB = (noiseField[A+1] + Z) & 0xff;
        int BB = (noiseField[B+1] + Z) & 0xff;
        return Mathf.Abs(Lerp(w, Lerp(v, Lerp(u, Grad(noiseField[AA  ], x, y  , z  ), Grad(noiseField[BA  ], x-1, y  , z  )),
                               Lerp(u, Grad(noiseField[AB  ], x, y-1, z  ), Grad(noiseField[BB  ], x-1, y-1, z  ))),
                       Lerp(v, Lerp(u, Grad(noiseField[AA+1], x, y  , z-1), Grad(noiseField[BA+1], x-1, y  , z-1)),
                               Lerp(u, Grad(noiseField[AB+1], x, y-1, z-1), Grad(noiseField[BB+1], x-1, y-1, z-1)))));
    }

    public static float Noise(float x, float y, float z, byte[] noiseField)
    {
        int X = Mathf.FloorToInt(x) & 0xff;
        int Y = Mathf.FloorToInt(y) & 0xff;
        int Z = Mathf.FloorToInt(z) & 0xff;
        x -= Mathf.Floor(x);
        y -= Mathf.Floor(y);
        z -= Mathf.Floor(z);
        float u = Fade(x);
        float v = Fade(y);
        float w = Fade(z);
        int A  = (noiseField[X  ] + Y) & 0xff;
        int B  = (noiseField[X+1] + Y) & 0xff;
        int AA = (noiseField[A  ] + Z) & 0xff;
        int BA = (noiseField[B  ] + Z) & 0xff;
        int AB = (noiseField[A+1] + Z) & 0xff;
        int BB = (noiseField[B+1] + Z) & 0xff;
        return NormalizeOutput(Lerp(w, Lerp(v, Lerp(u, Grad(noiseField[AA  ], x, y  , z  ), Grad(noiseField[BA  ], x-1, y  , z  )),
                               Lerp(u, Grad(noiseField[AB  ], x, y-1, z  ), Grad(noiseField[BB  ], x-1, y-1, z  ))),
                       Lerp(v, Lerp(u, Grad(noiseField[AA+1], x, y  , z-1), Grad(noiseField[BA+1], x-1, y  , z-1)),
                               Lerp(u, Grad(noiseField[AB+1], x, y-1, z-1), Grad(noiseField[BB+1], x-1, y-1, z-1)))));
    }

    static float Fade(float t)
    {
        return t * t * t * (t * (t * 6 - 15) + 10);
    }

    static float Lerp(float t, float a, float b)
    {
        return a + t * (b - a);
    }

    static float Grad(int hash, float x)
    {
        return (hash & 1) == 0 ? x : -x;
    }

    static float Grad(int hash, float x, float y)
    {
        return ((hash & 1) == 0 ? x : -x) + ((hash & 2) == 0 ? y : -y);
    }

    static float Grad(int hash, float x, float y, float z)
    {
        int h = hash & 15;
        float u = h < 8 ? x : y;
        float v = h < 4 ? y : (h == 12 || h == 14 ? x : z);
        return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
    }
}