
using System;
namespace PhotoStudio.Model
{
	/// <summary>
	/// Budget:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Budget
	{
		public Budget()
		{}
		#region Model
		private int _id;
		private int? _type;
		private decimal? _money;
		private string _userfor;
		private DateTime? _time;
		private int? _operid;
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
		public decimal? Money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserFor
		{
			set{ _userfor=value;}
			get{return _userfor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Time
		{
			set{ _time=value;}
			get{return _time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OperID
		{
			set{ _operid=value;}
			get{return _operid;}
		}
		#endregion Model

	}
}

