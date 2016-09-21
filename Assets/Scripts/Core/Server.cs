using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

//  Created by CaoChunYang 

public class CServer : MonoBehaviour {

	public static string userId = "1";
	public static string version = "1.0";
	public static string platformId = "1";
	public static ServerVo currServerVo;
	public static List<ServerVo> serverList = new List<ServerVo>();
	
	static public void Pasre(string str)
	{
		serverList.Clear();
		List<object> lst = Json.Deserialize(str) as List<object>;
		if(lst == null || lst.Count == 0)return;
		for(int i = 0 ; i < lst.Count ; i ++)
		{
			ServerVo vo = ServerVo.Create(lst[i]);
			if(vo.serverStatus == "2")
			{
				serverList.Add(vo);
			}
		}
		currServerVo = serverList[serverList.Count - 1];
	}
}

public class ServerVo
{
	public string serverId;
	public string serverName;
	public string serverHost;
	public int serverPort;
	public string serverStatus;
	
	static public ServerVo Create(object o)
	{
		ServerVo vo = new ServerVo();
		Dictionary<string , object> dic = o as Dictionary<string , object>;
		vo.serverId = dic["server_id"].ToString();
		vo.serverName = dic["server_name"].ToString();
		vo.serverHost = dic["server_host"].ToString();
		vo.serverPort = int.Parse(dic["server_port"].ToString());
		vo.serverStatus = dic["server_status"].ToString();
		return vo;
	}
}
