
using System;
namespace PhotoStudio.Model
{
	/// <summary>
	/// Costomer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Costomer
	{
		public Costomer()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _phone;
		private string _email;
		private string _place;
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
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Place
		{
			set{ _place=value;}
			get{return _place;}
		}
		#endregion Model

	}
}

