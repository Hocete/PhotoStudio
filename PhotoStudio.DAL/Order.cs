
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PhotoStudio.DAL
{
	/// <summary>
	/// 数据访问类:Order
	/// </summary>
	public partial class Order
	{
		public Order()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return SqlHelper.GetMaxID("ID", "tb_Order"); 
		}
        /// <summary>
        /// 存在几条记录 
        /// </summary>
        public int Count(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Order");
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
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Order");
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
		public int Add(PhotoStudio.Model.Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_Order(");
            strSql.Append("Name,Type,Phone,Email,Place,Time,PutID,State,ChangeTime,Money)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Type,@Phone,@Email,@Place,@Time,@PutID,@State,@ChangeTime,@Money)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@Type", SqlDbType.NVarChar,50),
                    new SqlParameter("@Phone", SqlDbType.NVarChar,20),
                    new SqlParameter("@Email", SqlDbType.NVarChar,50),
                    new SqlParameter("@Place", SqlDbType.NVarChar,-1),
                    new SqlParameter("@Time", SqlDbType.DateTime),
                    new SqlParameter("@PutID", SqlDbType.Int,4),
                    new SqlParameter("@State", SqlDbType.NChar,10),
                    new SqlParameter("@ChangeTime", SqlDbType.DateTime),
                    new SqlParameter("@Money", SqlDbType.Decimal,9)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.Phone;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.Place;
            parameters[5].Value = model.Time;
            parameters[6].Value = model.PutID;
            parameters[7].Value = model.State;
            parameters[8].Value = model.ChangeTime;
            parameters[9].Value = model.Money;
            object obj = SqlHelper.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(PhotoStudio.Model.Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Order set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Type=@Type,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Email=@Email,");
			strSql.Append("Place=@Place,");
			strSql.Append("Time=@Time,");
			strSql.Append("PutID=@PutID,");
			strSql.Append("State=@State,");
			strSql.Append("ChangeTime=@ChangeTime,");
            strSql.Append("Money=@Money");
            strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Place", SqlDbType.NVarChar,-1),
					new SqlParameter("@Time", SqlDbType.DateTime),
					new SqlParameter("@PutID", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.NChar,10),
					new SqlParameter("@ChangeTime", SqlDbType.DateTime),
                    new SqlParameter("@Money", SqlDbType.Decimal,9),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.Phone;
			parameters[3].Value = model.Email;
			parameters[4].Value = model.Place;
			parameters[5].Value = model.Time;
			parameters[6].Value = model.PutID;
			parameters[7].Value = model.State;
			parameters[8].Value = model.ChangeTime;
            parameters[9].Value = model.Money;
            parameters[10].Value = model.ID;

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
        /// 更新一条数据BYID
        /// </summary>
        public bool Update(int id,string state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Order set ");
            strSql.Append("State=@State,");
            strSql.Append("ChangeTime=@ChangeTime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@State", SqlDbType.NChar,10),
                    new SqlParameter("@ChangeTime", SqlDbType.DateTime),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = state;
            parameters[1].Value = DateTime.Now;
            parameters[2].Value = id;

            int rows = SqlHelper.ExecuteSql(strSql.ToString(), parameters);
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
			strSql.Append("delete from tb_Order ");
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
			strSql.Append("delete from tb_Order ");
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
		public PhotoStudio.Model.Order GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Name,Type,Phone,Email,Place,Time,PutID,State,ChangeTime,Money  from tb_Order ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			PhotoStudio.Model.Order model=new PhotoStudio.Model.Order();
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
		public PhotoStudio.Model.Order DataRowToModel(DataRow row)
		{
			PhotoStudio.Model.Order model=new PhotoStudio.Model.Order();
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
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=row["Type"].ToString();
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
				if(row["Time"]!=null && row["Time"].ToString()!="")
				{
					model.Time=DateTime.Parse(row["Time"].ToString());
				}
				if(row["PutID"]!=null && row["PutID"].ToString()!="")
				{
					model.PutID=int.Parse(row["PutID"].ToString());
				}
				if(row["State"]!=null)
				{
					model.State=row["State"].ToString();
				}
				if(row["ChangeTime"]!=null && row["ChangeTime"].ToString()!="")
				{
					model.ChangeTime=DateTime.Parse(row["ChangeTime"].ToString());
				}
                if (row["Money"] != null && row["Money"].ToString() != "")
                {
                    model.Money = decimal.Parse(row["Money"].ToString());
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
			strSql.Append("select ID,Name,Type,Phone,Email,Place,Time,PutID,State,ChangeTime,Money ");
			strSql.Append(" FROM tb_Order ");
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
			strSql.Append(" ID,Name,Type,Phone,Email,Place,Time,PutID,State,ChangeTime,Money ");
			strSql.Append(" FROM tb_Order ");
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
			strSql.Append("select count(1) FROM tb_Order ");
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
			strSql.Append(")AS Row, T.*  from tb_Order T ");
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
        public IList<PhotoStudio.Model.Order> GetListByPage(int p_pageIndex, int p_pageSize, string strWhere, out int p_recordCount)
        {
            IList<PhotoStudio.Model.Order> listPhoto = new List<PhotoStudio.Model.Order>();
            string sTable = "tb_Order";
            string sPkey = "ID";
            string sField = "ID,Name,Type,Phone,Email,Place,Time,PutID,State,Money";
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
                    PhotoStudio.Model.Order objPhoto = new PhotoStudio.Model.Order();
                    objPhoto.ID = reader.GetInt32(0);
                    objPhoto.Name = reader.GetString(1);
                    objPhoto.Type = reader.GetString(2);
                    objPhoto.Phone = reader.GetString(3);
                    objPhoto.Email = reader.GetString(4);
                    objPhoto.Place = reader.GetString(5);
                    objPhoto.Time = reader.GetDateTime(6);
                    objPhoto.PutID = reader.GetInt32(7);
                    objPhoto.State = reader.GetString(8);
                    objPhoto.Money = reader.GetDecimal(9);
                    listPhoto.Add(objPhoto);
                }
            }
            return listPhoto;
        }
        #endregion  ExtensionMethod
    }
}

