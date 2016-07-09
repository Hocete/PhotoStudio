
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PhotoStudio.DAL
{
	/// <summary>
	/// 数据访问类:Staff
	/// </summary>
	public partial class Staff
	{
		public Staff()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return SqlHelper.GetMaxID("ID", "tb_Staff"); 
		}
        

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Staff");
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
		public bool Exists(string swhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Staff");
            strSql.Append(" where "+ swhere);
            return SqlHelper.Exists(strSql.ToString());
        }
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID,string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Staff");
            strSql.Append(" where ID=@ID and PassWord=@PassWord");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                new SqlParameter("@PassWord", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = ID;
            parameters[1].Value = pwd;

            return SqlHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, string name,string Tel,string Email,string IDcard)
        {
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_Staff");
            strSql.Append(" where ID=@ID and Name=@name and Tel=@Tel and Email=@Email and IDCard=@IDCard ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@Tel", SqlDbType.NVarChar,20),
                    new SqlParameter("@Email", SqlDbType.NVarChar,50),
                    new SqlParameter("@IDCard", SqlDbType.NVarChar,20),
        };
            parameters[0].Value = ID;
            parameters[1].Value = name;
            parameters[2].Value = Tel;
            parameters[3].Value = Email;
            parameters[4].Value =IDcard;
            return SqlHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PhotoStudio.Model.Staff model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Staff(");
			strSql.Append("Name,SeID,JoinTime,Sex,Edu,Birth,Place,Tel,Email,Wages,IDCard,PassWord,Power)");
			strSql.Append(" values (");
			strSql.Append("@Name,@SeID,@JoinTime,@Sex,@Edu,@Birth,@Place,@Tel,@Email,@Wages,@IDCard,@PassWord,@Power)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@SeID", SqlDbType.Int,4),
					new SqlParameter("@JoinTime", SqlDbType.DateTime),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Edu", SqlDbType.NVarChar,50),
					new SqlParameter("@Birth", SqlDbType.DateTime),
					new SqlParameter("@Place", SqlDbType.NVarChar,-1),
					new SqlParameter("@Tel", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Wages", SqlDbType.Decimal,9),
					new SqlParameter("@IDCard", SqlDbType.NVarChar,20),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@Power", SqlDbType.NVarChar,-1)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.SeID;
			parameters[2].Value = model.JoinTime;
			parameters[3].Value = model.Sex;
			parameters[4].Value = model.Edu;
			parameters[5].Value = model.Birth;
			parameters[6].Value = model.Place;
			parameters[7].Value = model.Tel;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.Wages;
			parameters[10].Value = model.IDCard;
			parameters[11].Value = model.PassWord;
			parameters[12].Value = model.Power;

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
        /// 更新权限
        /// </summary>
        public void Update(int ID, int Power)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Staff set ");
            strSql.Append("Power=@Power");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@Power", SqlDbType.NVarChar,-1)};
            parameters[0].Value = ID;
            parameters[1].Value = Power.ToString();

            SqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PhotoStudio.Model.Staff model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Staff set ");
			strSql.Append("Name=@Name,");
			strSql.Append("SeID=@SeID,");
			strSql.Append("JoinTime=@JoinTime,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Edu=@Edu,");
			strSql.Append("Birth=@Birth,");
			strSql.Append("Place=@Place,");
			strSql.Append("Tel=@Tel,");
			strSql.Append("Email=@Email,");
			strSql.Append("Wages=@Wages,");
			strSql.Append("IDCard=@IDCard,");
			strSql.Append("PassWord=@PassWord,");
			strSql.Append("Power=@Power");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@SeID", SqlDbType.Int,4),
					new SqlParameter("@JoinTime", SqlDbType.DateTime),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Edu", SqlDbType.NVarChar,50),
					new SqlParameter("@Birth", SqlDbType.DateTime),
					new SqlParameter("@Place", SqlDbType.NVarChar,-1),
					new SqlParameter("@Tel", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Wages", SqlDbType.Decimal,9),
					new SqlParameter("@IDCard", SqlDbType.NVarChar,20),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@Power", SqlDbType.NVarChar,-1),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.SeID;
			parameters[2].Value = model.JoinTime;
			parameters[3].Value = model.Sex;
			parameters[4].Value = model.Edu;
			parameters[5].Value = model.Birth;
			parameters[6].Value = model.Place;
			parameters[7].Value = model.Tel;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.Wages;
			parameters[10].Value = model.IDCard;
			parameters[11].Value = model.PassWord;
			parameters[12].Value = model.Power;
			parameters[13].Value = model.ID;

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
			strSql.Append("delete from tb_Staff ");
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
			strSql.Append("delete from tb_Staff ");
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
		public PhotoStudio.Model.Staff GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Name,SeID,JoinTime,Sex,Edu,Birth,Place,Tel,Email,Wages,IDCard,PassWord,Power from tb_Staff ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			PhotoStudio.Model.Staff model=new PhotoStudio.Model.Staff();
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
		public PhotoStudio.Model.Staff DataRowToModel(DataRow row)
		{
			PhotoStudio.Model.Staff model=new PhotoStudio.Model.Staff();
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
				if(row["SeID"]!=null && row["SeID"].ToString()!="")
				{
					model.SeID=int.Parse(row["SeID"].ToString());
				}
				if(row["JoinTime"]!=null && row["JoinTime"].ToString()!="")
				{
					model.JoinTime=DateTime.Parse(row["JoinTime"].ToString());
				}
				if(row["Sex"]!=null && row["Sex"].ToString()!="")
				{
					model.Sex=int.Parse(row["Sex"].ToString());
				}
				if(row["Edu"]!=null)
				{
					model.Edu=row["Edu"].ToString();
				}
				if(row["Birth"]!=null && row["Birth"].ToString()!="")
				{
					model.Birth=DateTime.Parse(row["Birth"].ToString());
				}
				if(row["Place"]!=null)
				{
					model.Place=row["Place"].ToString();
				}
				if(row["Tel"]!=null && row["Tel"].ToString()!="")
				{
					model.Tel=row["Tel"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Wages"]!=null && row["Wages"].ToString()!="")
				{
					model.Wages=decimal.Parse(row["Wages"].ToString());
				}
				if(row["IDCard"]!=null && row["IDCard"].ToString()!="")
				{
					model.IDCard=row["IDCard"].ToString();
				}
				if(row["PassWord"]!=null)
				{
					model.PassWord=row["PassWord"].ToString();
				}
				if(row["Power"]!=null)
				{
					model.Power=row["Power"].ToString();
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
			strSql.Append("select ID,Name,SeID,JoinTime,Sex,Edu,Birth,Place,Tel,Email,Wages,IDCard,PassWord,Power ");
			strSql.Append(" FROM tb_Staff ");
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
			strSql.Append(" ID,Name,SeID,JoinTime,Sex,Edu,Birth,Place,Tel,Email,Wages,IDCard,PassWord,Power ");
			strSql.Append(" FROM tb_Staff ");
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
			strSql.Append("select count(1) FROM tb_Staff ");
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
			strSql.Append(")AS Row, T.*  from tb_Staff T ");
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
        /// <returns>IList ChatText</returns>
        public IList<PhotoStudio.Model.Staff> GetListByPage(int p_pageIndex, int p_pageSize, string strWhere, out int p_recordCount)
        {
            IList<PhotoStudio.Model.Staff> listBudget = new List<PhotoStudio.Model.Staff>();
            string sTable = "tb_Staff";
            string sPkey = "ID";
            string sField = "*";
            string sCondition = strWhere;
            string sOrder = "ID";
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
                    PhotoStudio.Model.Staff objStaff = new PhotoStudio.Model.Staff();
                    objStaff.ID = reader.GetInt32(0);
                    objStaff.Name = reader.GetString(1);
                    objStaff.SeID = reader.GetInt32(2);
                    objStaff.JoinTime = reader.GetDateTime(3);
                    objStaff.Sex = reader.GetInt32(4);
                    objStaff.Edu = reader.GetString(5);
                    objStaff.Birth = reader.GetDateTime(6);
                    objStaff.Place = reader.GetString(7);
                    objStaff.Tel = reader.GetString(8);
                    objStaff.Email = reader.GetString(9);
                    objStaff.Wages = reader.GetDecimal(10);
                    objStaff.IDCard = reader.GetString(11);
                    objStaff.PassWord = reader.GetString(12);
                    objStaff.Power = reader.GetString(13);
                    listBudget.Add(objStaff);
                }
            }
            return listBudget;
        }
        #endregion  ExtensionMethod
    }
}

