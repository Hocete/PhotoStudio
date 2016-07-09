
using System;
using System.Data;
using System.Collections.Generic;

using PhotoStudio.Model;
namespace PhotoStudio.BLL
{
	/// <summary>
	/// Costomer
	/// </summary>
	public partial class Costomer
	{
		private readonly PhotoStudio.DAL.Costomer dal=new PhotoStudio.DAL.Costomer();
		public Costomer()
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
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Phone)
        {
            return dal.Exists(Phone);
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
        public int  Add(PhotoStudio.Model.Costomer model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PhotoStudio.Model.Costomer model)
		{
			return dal.Update(model);
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
		public PhotoStudio.Model.Costomer GetModel(int ID)
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
		public List<PhotoStudio.Model.Costomer> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PhotoStudio.Model.Costomer> DataTableToList(DataTable dt)
		{
			List<PhotoStudio.Model.Costomer> modelList = new List<PhotoStudio.Model.Costomer>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PhotoStudio.Model.Costomer model;
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
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public IList<PhotoStudio.Model.Costomer> GetListByPage(int p_pageIndex, int p_pageSize, string strWhere, out int p_recordCount)
        {

            return dal.GetListByPage(p_pageIndex, p_pageSize, strWhere, out p_recordCount);
        }
        #endregion  ExtensionMethod
    }
}

