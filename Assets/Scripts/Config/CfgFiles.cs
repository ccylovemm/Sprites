// ******************************************************************************************************/
// 这个是工具自动生成的表代码，这个里面的任何更改在下次生成之后会变得无效，请注意！
// 文件名：     CfgFiles.cs
// Copyright(c) 2012-2100 上海恺英网络科技有限公司，All rights reserved.
// ******************************************************************************************************/


namespace GameCFG
{
	using System;
	using System.Collections.Generic;
	public class CfgFiles
	{
		public Dictionary<String,BaseCFG> infos = null;
		private static CfgFiles _instance = new CfgFiles();

		public static CfgFiles Instance
		{
			get
			{
				if(_instance.infos == null)
				{
					_instance.infos = new Dictionary<String,BaseCFG>();
					_instance.Init();
				}
				return _instance;
			}
		}

	protected void Init(){

			infos["Item.dat"] = ItemCFG.Instance;
		}
	}
}
