using UnityEngine;
using UnityEditor;

public class MyTextureImporter : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        TextureImporter t = (TextureImporter)assetImporter;
        t.spritePixelsPerUnit = 16;
        t.filterMode = FilterMode.Point;
        t.compressionQuality = 100;
    }
}
