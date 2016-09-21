using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System;

public class LoginCount : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator RequestServerList()
	{
		uint channelID = 1;
		string sign = "&^%&^%76asdakdjf902384^76234sdfADSDF2034sdf";
		MD5 md5 = new MD5CryptoServiceProvider();
		byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes("channel_id=" + channelID + sign));
		string signStr = BitConverter.ToString(hash).Replace("-", "");

		WWW www = new WWW("http://api.ss3d.kingnet.com/game/getServerData?channel_id=" + channelID + "&sign=" + signStr.ToLower());
		yield return www;

		CServer.Pasre(www.text);

		if (CServer.currServerVo == null)
		{
			StartCoroutine("RequestServerList");
		}
		else
		{

		}
	}
}
