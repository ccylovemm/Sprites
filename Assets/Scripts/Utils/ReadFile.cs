using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;
public class ReadFile
{
    public static string ReadResourcesText(string filename )
    {  
        //Load the text file using Reources.Load
        TextAsset theTextFile = Resources.Load<TextAsset>(filename);

        //There's a text file named filename, lets get it's contents and return it
        if (theTextFile != null)
            return theTextFile.text;

        //There's no file, return an empty string.
        return string.Empty;
    }
    public static byte[] ReadResourcesBytes(string filename)
    {
        //Load the text file using Reources.Load
        TextAsset theTextFile = Resources.Load<TextAsset>(filename); 
        //There's a text file named filename, lets get it's contents and return it
        if (theTextFile != null)
            return theTextFile.bytes;

        //There's no file, return an empty string.
        return null;
    }
    
	public static byte[] ReadByteForPC(string filename)
	{
		string filePath = System.IO.Path.Combine (Application.streamingAssetsPath, filename);
		byte[] result = null;
		using (var read = System.IO.File.OpenRead(filePath)) {
			
			int len = (int)read.Length;
			result = new byte[len];
			read.Read (result, 0, len);
		}
		return result;
	}

    public static byte[] ReadByte(string filePath)
    { 
        byte[] result = null;
        using (var read = System.IO.File.OpenRead(filePath))
        {

            int len = (int)read.Length;
            result = new byte[len];
            read.Read(result, 0, len);

        }
        return result;
    }

    public static string ReadText(string filePath)
    {
        byte[] byteArray = ReadByte(filePath);
        return System.Text.Encoding.UTF8.GetString(byteArray);
    }

}
