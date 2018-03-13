using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    [SerializeField] private Texture2D map;
    [SerializeField] private ColorToPrefab[] colorMappings;

    void Start () {
        GenerateLevel();
	}

    void GenerateLevel () {
        for (int x = 0; x < map.width; x++) {
            for (int y = 0; y < map.height; y++) {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile (int x, int y) {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
            return;

        foreach (var colorMapping in colorMappings) {
            if (colorMapping.color.Equals(pixelColor)) {
                Instantiate(colorMapping.prefab, new Vector2(x, y), Quaternion.identity, transform);
            }
        }
    } 
}
