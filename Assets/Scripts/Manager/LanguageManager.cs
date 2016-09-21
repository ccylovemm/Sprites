using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//  Created by CaoChunYang 

public class LanguageManager
{
	static public SupportedLanguage Language { get; set; }
	static public Dictionary<string, string> languageDict = new Dictionary<string, string>();
	static public Dictionary<SupportedLanguage, string> languageSorted = new Dictionary<SupportedLanguage, string>();
	static public List<EventDelegate> setLanguageAction = new List<EventDelegate>();
	
	static public void Init()
	{
		languageSorted = new Dictionary<SupportedLanguage, string>();
		languageSorted.Add(SupportedLanguage.English, "English");
		languageSorted.Add(SupportedLanguage.German, "Deutsch");
		languageSorted.Add(SupportedLanguage.Spanish, "Espa");
		languageSorted.Add(SupportedLanguage.French, "Fran");
		languageSorted.Add(SupportedLanguage.Italian, "Italiano");
		languageSorted.Add(SupportedLanguage.Russian, "Русский");
		languageSorted.Add(SupportedLanguage.Portuguese, "Portugu");
		languageSorted.Add(SupportedLanguage.Japanese, "日本語");
		languageSorted.Add(SupportedLanguage.Simplified_Chinese, "简体中文");
		languageSorted.Add(SupportedLanguage.Traditional_Chinese, "繁體中文");
		languageSorted.Add(SupportedLanguage.Korean, "한국어");
		languageDict = new Dictionary<string, string>();
		
		if (!PlayerPrefs.HasKey("Language"))
		{
			try
			{
				Language = (SupportedLanguage) ((int) Enum.Parse(typeof(SupportedLanguage), Application.systemLanguage.ToString()));
			}
			catch (Exception)
			{
				Language = SupportedLanguage.English;
			}
			if (Language == SupportedLanguage.Chinese)
			{
				Language = SupportedLanguage.Simplified_Chinese;
			}
			else if (Language != SupportedLanguage.English)
			{
				Language = SupportedLanguage.English;
			}
		}
		else
		{
			Language = (SupportedLanguage) ((int) Enum.Parse(typeof(SupportedLanguage), PlayerPrefs.GetString("Language")));
		}
		LoadLanguage();
	}
	
	static public void ChangeLanguage(SupportedLanguage newLanguage)
	{
		Language = newLanguage;
		PlayerPrefs.SetString("Language", Language.ToString());
		LoadLanguage();
		EventDelegate.Execute(setLanguageAction);
	}
	
	static public string GetValue(string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			return string.Empty;
		}
		if (languageDict.ContainsKey(key))
		{
			return languageDict[key].Replace(@"\n", "\n");
		}
		return key;
	}
	
	static public string GetValue(string key, params object[] values)
	{
		if (string.IsNullOrEmpty(key))
		{
			return string.Empty;
		}
		if (!languageDict.ContainsKey(key))
		{
			return key;
		}
		string str = languageDict[key];
		for (int i = 0; i < values.Length; i++)
		{
			str = str.Replace("{" + i + "}", values[i].ToString());
		}
		return str.Replace(@"\n", "\n");
	}
	
	static private void LoadLanguage()
	{
		byte[] bytes = ReadFile.ReadByte("Language/" + Language.ToString() + ".dat"); 
		FileReadStream fileRS = new FileReadStream(bytes);
		while(fileRS.bytesAvailable)
		{
			languageDict[fileRS.ReadString()] = fileRS.ReadString();
		}
	}
}

public enum SupportedLanguage
{
	Simplified_Chinese,
	Traditional_Chinese,
	English,
	Japanese,
	Korean,
	Russian,
	French,
	German,
	Spanish,
	Portuguese,
	Italian,
	Chinese
}
