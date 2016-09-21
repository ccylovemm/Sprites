// ******************************************************************************************************/
// 这个是工具自动生成的表代码，这个里面的任何更改在下次生成之后会变得无效，请注意！
// 文件名：     ItemCFG.cs
// Copyright(c) 2012-2100 上海恺英网络科技有限公司，All rights reserved.
// ******************************************************************************************************/


namespace GameCFG
{
	using System;
	using System.Collections.Generic;
	using System.IO;

	public sealed class ItemCFG : BaseCFG
	{

		public Dictionary<UInt32, ItemVo> items;

		private static ItemCFG _instance = new ItemCFG();

		public static ItemCFG Instance
		{
			get
			{
				return _instance;
			}
		}

		public ItemCFG()
		{
			if(_instance != null)
			{
				return;
			}
		}

		public override bool LoadData(FileReadStream bytes)
		{
			items = new Dictionary<UInt32, ItemVo>();
			while(bytes.bytesAvailable)
			{
				ItemVo obj = new ItemVo();
				obj.id = bytes.ReadUInt32();
				obj.name = bytes.ReadString();
				obj.icon = bytes.ReadString();
				obj.type = bytes.ReadUInt16();
				obj.subtype = bytes.ReadUInt16();
				obj.needlevel = bytes.ReadUInt16();
				obj.itemlevel = bytes.ReadUInt16();
				obj.color = bytes.ReadUInt16();
				obj.bind = bytes.ReadUInt8();
				obj.maxnum = bytes.ReadUInt16();
				obj.demand = bytes.ReadUInt8();
				obj.composition = bytes.ReadUInt32();
				obj.takeapartID = bytes.ReadString();
				obj.takeapartNum = bytes.ReadString();
				obj.Model = bytes.ReadString();
				obj.modelEffect = bytes.ReadString();
				obj.description = bytes.ReadString();
				obj.desc2 = bytes.ReadString();
				obj.desc3 = bytes.ReadString();
				obj.desc4 = bytes.ReadString();
				obj.script = bytes.ReadString();
				obj.suiteid = bytes.ReadUInt16();
				obj.suitepos = bytes.ReadUInt16();
				obj.sellprice = bytes.ReadUInt16();
				obj.activetime = bytes.ReadUInt16();
				obj.usetype = bytes.ReadBool();
				obj.batch = bytes.ReadUInt16();
				obj.cd = bytes.ReadUInt16();
				obj.shellgroup = bytes.ReadUInt16();
				obj.shellcd = bytes.ReadUInt16();
				obj.p1 = bytes.ReadUInt16();
				obj.p2 = bytes.ReadUInt16();
				obj.p3 = bytes.ReadUInt16();
				obj.p4 = bytes.ReadUInt16();
				obj.p5 = bytes.ReadUInt16();
				obj.p6 = bytes.ReadUInt16();
				obj.dropicon = bytes.ReadString();
				obj.dropsound = bytes.ReadString();
				obj.battlemode = bytes.ReadString();
				obj.occuadvice = bytes.ReadUInt8();
				obj.occurate = bytes.ReadString();
				obj.fateName = bytes.ReadString();
				obj.productID = bytes.ReadString();
				obj.limitprice = bytes.ReadString();
				items[obj.id] = obj;
			}
			return true;
		}
	}
}
