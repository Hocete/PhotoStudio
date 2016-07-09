
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PhotoStudio.DAL
{
	/// <summary>
	/// 数据访问类:Budget
	/// </summary>
	public partial class Budget
	{
		public Budget()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return SqlHelper.GetMaxID("ID", "tb_Budget"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Budget");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return SqlHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(PhotoStudio.Model.Budget model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Budget(");
			strSql.Append("Type,Money,UserFor,Time,OperID)");
			strSql.Append(" values (");
			strSql.Append("@Type,@Money,@UserFor,@Time,@OperID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@UserFor", SqlDbType.NVarChar,-1),
					new SqlParameter("@Time", SqlDbType.DateTime),
					new SqlParameter("@OperID", SqlDbType.Int,4)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Money;
			parameters[2].Value = model.UserFor;
			parameters[3].Value = model.Time;
			parameters[4].Value = model.OperID;

			object obj = SqlHelper.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PhotoStudio.Model.Budget model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Budget set ");
			strSql.Append("Type=@Type,");
			strSql.Append("Money=@Money,");
			strSql.Append("UserFor=@UserFor,");
			strSql.Append("Time=@Time,");
			strSql.Append("OperID=@OperID");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@UserFor", SqlDbType.NVarChar,-1),
					new SqlParameter("@Time", SqlDbType.DateTime),
					new SqlParameter("@OperID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Money;
			parameters[2].Value = model.UserFor;
			parameters[3].Value = model.Time;
			parameters[4].Value = model.OperID;
			parameters[5].Value = model.ID;

			int rows=SqlHelper.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Budget ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=SqlHelper.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Budget ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=SqlHelper.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PhotoStudio.Model.Budget GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Type,Money,UserFor,Time,OperID from tb_Budget ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			PhotoStudio.Model.Budget model=new PhotoStudio.Model.Budget();
			DataSet ds=SqlHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PhotoStudio.Model.Budget DataRowToModel(DataRow row)
		{
			PhotoStudio.Model.Budget model=new PhotoStudio.Model.Budget();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["Money"]!=null && row["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(row["Money"].ToString());
				}
				if(row["UserFor"]!=null)
				{
					model.UserFor=row["UserFor"].ToString();
				}
				if(row["Time"]!=null && row["Time"].ToString()!="")
				{
					model.Time=DateTime.Parse(row["Time"].ToString());
				}
				if(row["OperID"]!=null && row["OperID"].ToString()!="")
				{
					model.OperID=int.Parse(row["OperID"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Type,Money,UserFor,Time,OperID ");
			strSql.Append(" FROM tb_Budget ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return SqlHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,Type,Money,UserFor,Time,OperID ");
			strSql.Append(" FROM tb_Budget ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_Budget ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = SqlHelper.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Budget T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return SqlHelper.Query(strSql.ToString());
		}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获取抢总钱数
        /// </summary>
        public long GetAllMoney(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(Money) FROM tb_Budget ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = SqlHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 取得每页记录
        /// </summary>
        /// <param name="p_pageIndex">当前页</param>
        /// <param name="p_pageSize">分页大小</param>
        /// <param name="p_recordCount">返回总记录数</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns>IList ChatText</returns>
        public IList<PhotoStudio.Model.Budget> GetListByPage(int p_pageIndex, int p_pageSize, string strWhere, out int p_recordCount)
        {
            IList<PhotoStudio.Model.Budget> listBudget = new List<PhotoStudio.Model.Budget>();
            string sTable = "tb_Budget";
            string sPkey = "ID";
            string sField = "*";
            string sCondition = strWhere;
            string sOrder = "Time Desc";
            int iSCounts = 0;
            using (SqlDataReader reader = SqlHelper.RunProcedureMe(sTable, sPkey, sField, p_pageIndex, p_pageSize, sCondition, sOrder, iSCounts, out p_recordCount))
            {
                //计算总页数
                if (p_recordCount > 0)
                {
                    int pageCount = (p_recordCount - 1) / p_pageSize + 1;
                }
                else
                {
                    return listBudget;
                }
                while (reader.Read())
                {
                    PhotoStudio.Model.Budget objBudget = new PhotoStudio.Model.Budget();
                    objBudget.ID = reader.GetInt32(0);
                    objBudget.Type = reader.GetInt32(1);
                    objBudget.Money = reader.GetDecimal(2);
                    objBudget.UserFor= reader.GetString(3);
                    objBudget.OperID = reader.GetInt32(5);
                    objBudget.Time = reader.GetDateTime(4);
                    listBudget.Add(objBudget);
                }
            }
            return listBudget;
        }
        #endregion  ExtensionMethod
    }
}

