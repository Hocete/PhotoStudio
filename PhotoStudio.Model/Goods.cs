
using System;
namespace PhotoStudio.Model
{
	/// <summary>
	/// Goods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Goods
	{
		public Goods()
		{}
        #region Model
        private int _id;
        private string _name;
        private string _type;
        private decimal? _cost;
        private decimal? _spend;
        private int? _stock;
        private string _photo = "";
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
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Cost
        {
            set { _cost = value; }
            get { return _cost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Spend
        {
            set { _spend = value; }
            get { return _spend; }
        }
        /// <summary>
        /// 库存
        /// </summary>
        public int? Stock
        {
            set { _stock = value; }
            get { return _stock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Photo
        {
            set { _photo = value; }
            get { return _photo; }
        }
    #endregion Model

    }
}

