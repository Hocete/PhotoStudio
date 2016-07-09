
using System;
namespace PhotoStudio.Model
{
	/// <summary>
	/// Order:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Order
	{
		public Order()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _type;
		private string _phone;
		private string _email;
		private string _place;
		private DateTime? _time;
		private int? _putid;
		private string _state;
		private DateTime? _changetime;
        private decimal? _money;
        /// <summary>
        /// 订单ID
        ///
        /// </summary>
        public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 客户姓名
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 所选套系
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 电话号码
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string Place
		{
			set{ _place=value;}
			get{return _place;}
		}
		/// <summary>
		/// 下单时间
		/// </summary>
		public DateTime? Time
		{
			set{ _time=value;}
			get{return _time;}
		}
		/// <summary>
		/// 下单ID
		/// </summary>
		public int? PutID
		{
			set{ _putid=value;}
			get{return _putid;}
		}
		/// <summary>
		/// 订单状态
		/// </summary>
		public string State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ChangeTime
		{
			set{ _changetime=value;}
			get{return _changetime;}
		}
        /// <summary>
		/// 
		/// </summary>
		public decimal? Money
        {
            set { _money = value; }
            get { return _money; }
        }
        #endregion Model

    }
}

