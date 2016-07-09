
using System;
namespace PhotoStudio.Model
{
	/// <summary>
	/// Sector:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sector
	{
		public Sector()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _power;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Power
		{
			set{ _power=value;}
			get{return _power;}
		}
		#endregion Model

	}
}

