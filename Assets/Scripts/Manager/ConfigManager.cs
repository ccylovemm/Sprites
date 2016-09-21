using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using GameCFG;

public class ConfigManager
{
	static private string cfgPath = "Config/";

	static public bool LoadCFG()
    {
        Dictionary<String, GameCFG.BaseCFG> infos = GameCFG.CfgFiles.Instance.infos;
        foreach (string key in infos.Keys)
        {
            var path = cfgPath + key;
            byte[] bytes = ReadFile.ReadByte(path);
            FileReadStream fileRS = new FileReadStream(bytes);
            BaseCFG cfg;
            if (infos.TryGetValue(key, out cfg))
            {
				cfg.LoadData(fileRS);
            }
        }
        return true;
    }
}


