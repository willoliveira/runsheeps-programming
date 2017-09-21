﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class Noise {
	
	public static float[,] GenerateNoiseMap (int mapWidth, int mapHeight, float scale)
	{
		float[,] noiseMap = new float[mapWidth, mapHeight];

		for (int y = 0; y < mapHeight; y++)
		{
			for (int x = 0; x < mapWidth; x++)
			{
				float sampleX = x / scale;
				float sampleY = y / scale;

				noiseMap[x, y] = Mathf.PerlinNoise(sampleX, sampleY);
			}
		}

		return noiseMap;
	}
}
