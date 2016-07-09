
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PhotoStudio.DAL
{
	/// <summary>
	/// 数据访问类:Costomer
	/// </summary>
	public partial class Costomer
	{
		public Costomer()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return SqlHelper.GetMaxID("ID", "tb_Costomer"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Costomer");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return SqlHelper.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Phone)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Costomer");
            strSql.Append(" where Phone=@Phone");
            SqlParameter[] parameters = {
                    new SqlParameter("@Phone", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = Phone;

            return SqlHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 存在几条记录 
        /// </summary>
        public int Count(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Costomer");
            if (where.Trim() != "")
            {
                strSql.Append(" where " + where);
            }
            using (SqlDataReader reader = SqlHelper.ExecuteReader(strSql.ToString()))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    if (!reader.IsDBNull(0))
                        return reader.GetInt32(0);
                    else
                        return 0;

                }
                else
                {
                    return 0;
                }

            }
        }
       /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PhotoStudio.Model.Costomer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Costomer(");
			strSql.Append("Name,Phone,Email,Place)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Phone,@Email,@Place)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Place", SqlDbType.NVarChar,-1)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Phone;
			parameters[2].Value = model.Email;
			parameters[3].Value = model.Place;

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
		public bool Update(PhotoStudio.Model.Costomer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Costomer set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Email=@Email,");
			strSql.Append("Place=@Place");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Place", SqlDbType.NVarChar,-1),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Phone;
			parameters[2].Value = model.Email;
			parameters[3].Value = model.Place;
			parameters[4].Value = model.ID;

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
			strSql.Append("delete from tb_Costomer ");
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
			strSql.Append("delete from tb_Costomer ");
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
		public PhotoStudio.Model.Costomer GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Name,Phone,Email,Place from tb_Costomer ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			PhotoStudio.Model.Costomer model=new PhotoStudio.Model.Costomer();
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
		public PhotoStudio.Model.Costomer DataRowToModel(DataRow row)
		{
			PhotoStudio.Model.Costomer model=new PhotoStudio.Model.Costomer();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Phone"]!=null && row["Phone"].ToString()!="")
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Place"]!=null)
				{
					model.Place=row["Place"].ToString();
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
			strSql.Append("select ID,Name,Phone,Email,Place ");
			strSql.Append(" FROM tb_Costomer ");
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
			strSql.Append(" ID,Name,Phone,Email,Place ");
			strSql.Append(" FROM tb_Costomer ");
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
			strSql.Append("select count(1) FROM tb_Costomer ");
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
			strSql.Append(")AS Row, T.*  from tb_Costomer T ");
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
        /// 取得每页记录
        /// </summary>
        /// <param name="p_pageIndex">当前页</param>
        /// <param name="p_pageSize">分页大小</param>
        /// <param name="p_recordCount">返回总记录数</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns>IList VotePay</returns>
        public IList<PhotoStudio.Model.Costomer> GetListByPage(int p_pageIndex, int p_pageSize, string strWhere, out int p_recordCount)
        {
            IList<PhotoStudio.Model.Costomer> listPhoto = new List<PhotoStudio.Model.Costomer>();
            string sTable = "tb_Costomer";
            string sPkey = "ID";
            string sField = "ID,Name,Phone,Email,Place";
            string sCondition = strWhere;
            string sOrder = "ID Desc";
            int iSCounts = 0;
            using (SqlDataReader reader = SqlHelper.RunProcedureMe(sTable, sPkey, sField, p_pageIndex, p_pageSize, sCondition, sOrder, iSCounts, out p_recordCount))
            {
                //计算总页数
                if (p_recordCount > 0)
                {
                    int pageCount = p_recordCount % p_pageSize == 0 ? p_recordCount / p_pageSize : p_recordCount / p_pageSize + 1;
                }
                else
                {
                    return listPhoto;
                }
                while (reader.Read())
                {
                    PhotoStudio.Model.Costomer objcos = new PhotoStudio.Model.Costomer();
                    objcos.ID = reader.GetInt32(0);
                    objcos.Name = reader.GetString(1);
                    objcos.Phone = reader.GetString(2);
                    objcos.Email = reader.GetString(3);
                    objcos.Place = reader.GetString(4);
                    listPhoto.Add(objcos);
                }
            }
            return listPhoto;
        }
        #endregion  ExtensionMethod
    }
}

