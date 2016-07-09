
using System;
namespace PhotoStudio.Model
{
	/// <summary>
	/// Message:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Message
	{
		public Message()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _text;
		private int? _toid;
		private int? _fromid;
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
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
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
		public int? ToID
		{
			set{ _toid=value;}
			get{return _toid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FromID
		{
			set{ _fromid=value;}
			get{return _fromid;}
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

