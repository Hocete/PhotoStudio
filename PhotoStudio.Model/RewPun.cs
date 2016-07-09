
using System;
namespace PhotoStudio.Model
{
	/// <summary>
	/// RewPun:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RewPun
	{
		public RewPun()
		{}
		#region Model
		private int _id;
		private int? _type;
		private string _text;
		private int? _operid;
		private DateTime? _time;
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
		public int? Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Text
		{
			set{ _text=value;}
			get{return _text;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OperID
		{
			set{ _operid=value;}
			get{return _operid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Time
		{
			set{ _time=value;}
			get{return _time;}
		}
		#endregion Model

	}
}

