using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    void Start()
    {
        Debug.Log(Perlin.Noise(0f, NoiseFieldGenerator.baseNoise));
        Debug.Log(Perlin.Noise(0.0345f, NoiseFieldGenerator.baseNoise));
        Debug.Log(Perlin.Noise(0.0373f, NoiseFieldGenerator.baseNoise));
        Debug.Log(Perlin.Noise(0.0382f, NoiseFieldGenerator.baseNoise));
        Debug.Log(Perlin.Noise(0.0479f, NoiseFieldGenerator.baseNoise));
        Debug.Log(Perlin.Noise(0.05722f, NoiseFieldGenerator.baseNoise));
    }
}
