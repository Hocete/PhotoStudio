
using System;
namespace PhotoStudio.Model
{
	/// <summary>
	/// Staff:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Staff
	{
		public Staff()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _seid;
		private DateTime? _jointime;
		private int? _sex;
		private string _edu;
		private DateTime? _birth;
		private string _place;
		private string _tel;
		private string _email;
		private decimal? _wages;
		private string _idcard;
		private string _password;
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
		public int? SeID
		{
			set{ _seid=value;}
			get{return _seid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? JoinTime
		{
			set{ _jointime=value;}
			get{return _jointime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Edu
		{
			set{ _edu=value;}
			get{return _edu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Birth
		{
			set{ _birth=value;}
			get{return _birth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Place
		{
			set{ _place=value;}
			get{return _place;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
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
		public decimal? Wages
		{
			set{ _wages=value;}
			get{return _wages;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IDCard
		{
			set{ _idcard=value;}
			get{return _idcard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PassWord
		{
			set{ _password=value;}
			get{return _password;}
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

