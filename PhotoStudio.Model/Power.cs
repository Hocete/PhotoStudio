
using System;
namespace PhotoStudio.Model
{
	/// <summary>
	/// Power:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Power
	{
		public Power()
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
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Powers
        {
            set { _power = value; }
            get { return _power; }
        }
        #endregion Model

    }
}

