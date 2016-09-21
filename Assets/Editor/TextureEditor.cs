 using UnityEngine;
using System.IO;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;

public class TextureEditor : Editor
{
	[MenuItem("TextureEditor/TextureForPC")]
	static void TextureForPC()
	{
		foreach (Object o in Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets))
		{
			if (o.GetType() != typeof(Texture2D)) continue;
			Texture2D texture = (Texture2D)o;
			string path = AssetDatabase.GetAssetPath(texture);
			TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
			textureImporter.textureType = TextureImporterType.Advanced;
			textureImporter.isReadable = false;
			textureImporter.generateCubemap = TextureImporterGenerateCubemap.None;
			textureImporter.wrapMode = TextureWrapMode.Clamp;
			textureImporter.mipmapEnabled = false;
			textureImporter.npotScale = TextureImporterNPOTScale.None;
			textureImporter.textureFormat = TextureImporterFormat.RGBA32;
			AssetDatabase.ImportAsset(path);
		}
	}
}