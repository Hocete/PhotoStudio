
using System;
using System.Data;
using System.Collections.Generic;

using PhotoStudio.Model;
namespace PhotoStudio.BLL
{
	/// <summary>
	/// Staff
	/// </summary>
	public partial class Staff
	{
		private readonly PhotoStudio.DAL.Staff dal=new PhotoStudio.DAL.Staff();
		public Staff()
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
        public bool Exists(int ID,string pwd)
        {
            return dal.Exists(ID,pwd);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string swhere)
        {
            return dal.Exists(swhere);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, string name, string Tel, string Email, string IDcard)
        {
            return dal.Exists(ID,name,Tel,Email,IDcard);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int  Add(PhotoStudio.Model.Staff model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PhotoStudio.Model.Staff model)
		{
			return dal.Update(model);
		}
        /// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(int ID,int Power)
        {
            dal.Update(ID,Power);
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
		public PhotoStudio.Model.Staff GetModel(int ID)
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
		public List<PhotoStudio.Model.Staff> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PhotoStudio.Model.Staff> DataTableToList(DataTable dt)
		{
			List<PhotoStudio.Model.Staff> modelList = new List<PhotoStudio.Model.Staff>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PhotoStudio.Model.Staff model;
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

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <summary>
        /// 取得每页记录
        /// </summary>
        /// <param name="p_pageIndex">当前页</param>
        /// <param name="p_pageSize">分页大小</param>
        /// <param name="p_recordCount">返回总记录数</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns>IList ChatText</returns>
        public IList<PhotoStudio.Model.Staff> GetListByPage(int p_pageIndex, int p_pageSize, string strWhere, out int p_recordCount)
        {
            return dal.GetListByPage(p_pageIndex, p_pageSize, strWhere, out p_recordCount);
        }
        #endregion  ExtensionMethod
    }
}

