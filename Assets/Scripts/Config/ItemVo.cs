// ******************************************************************************************************/
// 这个是工具自动生成的表代码，这个里面的任何更改在下次生成之后会变得无效，请注意！
// 文件名：     ItemVo.cs
// Copyright(c) 2012-2100 上海恺英网络科技有限公司，All rights reserved.
// ******************************************************************************************************/


namespace GameCFG
{
	using System;
	public sealed class ItemVo
	{
		/**
		道具ID
		**/
		public UInt32 id;

		/**
		道具名称
		**/
		public string name;

		/**
		道具图标
		**/
		public string icon;

		/**
		道具大类
		**/
		public UInt16 type;

		/**
		道具小类
		**/
		public UInt16 subtype;

		/**
		道具使用等级
		**/
		public UInt16 needlevel;

		/**
		物品等级
		**/
		public UInt16 itemlevel;

		/**
		道具品质（初始品质）
		**/
		public UInt16 color;

		/**
		是否绑定
		**/
		public Byte bind;

		/**
		最大可堆叠数量
		**/
		public UInt16 maxnum;

		/**
		合成所需数量
		**/
		public Byte demand;

		/**
		合成产物
		**/
		public UInt32 composition;

		/**
		分解产物ID
		**/
		public string takeapartID;

		/**
		分解产物数量
		**/
		public string takeapartNum;

		/**
		道具连接
		**/
		public string Model;

		/**
		模型特效(对应Model表)
		**/
		public string modelEffect;

		/**
		道具描述
		**/
		public string description;

		/**
		描述辅助
		**/
		public string desc2;

		/**
		来源
		**/
		public string desc3;

		/**
		作用
		**/
		public string desc4;

		/**
		使用后触发的脚本ID
		**/
		public string script;

		/**
		套装ID
		**/
		public UInt16 suiteid;

		/**
		套装位置
		**/
		public UInt16 suitepos;

		/**
		出售价格
		**/
		public UInt16 sellprice;

		/**
		有效时间
		**/
		public UInt16 activetime;

		/**
		使用后是否消耗
		**/
		public Boolean usetype;

		/**
		是否批量使用
		**/
		public UInt16 batch;

		/**
		冷却时间(秒)
		**/
		public UInt16 cd;

		/**
		冷却组
		**/
		public UInt16 shellgroup;

		/**
		组冷却时间
		**/
		public UInt16 shellcd;

		/**
		参数1
		**/
		public UInt16 p1;

		/**
		参数2
		**/
		public UInt16 p2;

		/**
		参数3
		**/
		public UInt16 p3;

		/**
		参数4
		**/
		public UInt16 p4;

		/**
		参数5
		**/
		public UInt16 p5;

		/**
		参数6
		**/
		public UInt16 p6;

		/**
		道具掉落图标
		**/
		public string dropicon;

		/**
		道具掉落时的音效
		**/
		public string dropsound;

		/**
		装备外观
		**/
		public string battlemode;

		/**
		推荐职业
		**/
		public Byte occuadvice;

		/**
		职业加成
		**/
		public string occurate;

		/**
		装备缘分名称
		**/
		public string fateName;

		/**
		产出
		**/
		public string productID;

		/**
		价格区间
		**/
		public string limitprice;
	}
}
