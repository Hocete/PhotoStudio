
using System;
using System.Data;
using System.Collections.Generic;

using PhotoStudio.Model;
namespace PhotoStudio.BLL
{
	/// <summary>
	/// Order
	/// </summary>
	public partial class Order
	{
		private readonly PhotoStudio.DAL.Order dal=new PhotoStudio.DAL.Order();
		public Order()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}
        /// <summary>
        /// 存在几条记录 
        /// </summary>
        public int Count(string where)
        {
            return dal.Count(where);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int  Add(PhotoStudio.Model.Order model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PhotoStudio.Model.Order model)
		{
			return dal.Update(model);
		}
        /// <summary>
        /// 更新一条数据BYID
        /// </summary>
        public bool Update(int id,string state)
        {
            return dal.Update(id,state);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PhotoStudio.Model.Order GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PhotoStudio.Model.Order> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PhotoStudio.Model.Order> DataTableToList(DataTable dt)
		{
			List<PhotoStudio.Model.Order> modelList = new List<PhotoStudio.Model.Order>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PhotoStudio.Model.Order model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public IList<PhotoStudio.Model.Order> GetListByPage(int p_pageIndex, int p_pageSize, string strWhere, out int p_recordCount)
        {

            return dal.GetListByPage(p_pageIndex,p_pageSize,strWhere, out p_recordCount);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

