
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace PhotoStudio.DAL
{
	/// <summary>
	/// 数据访问类:Goods
	/// </summary>
	public partial class Goods
	{
		public Goods()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return SqlHelper.GetMaxID("ID", "tb_Goods"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Goods");
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
		public int Add(PhotoStudio.Model.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into tb_Goods(");
            strSql.Append("Name,Type,Cost,Spend,Stock,Photo)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Type,@Cost,@Spend,@Stock,@Photo)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@Type", SqlDbType.NVarChar,50),
                    new SqlParameter("@Cost", SqlDbType.Decimal,9),
                    new SqlParameter("@Spend", SqlDbType.Decimal,9),
                    new SqlParameter("@Stock", SqlDbType.Int,4),
                    new SqlParameter("@Photo", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.Cost;
            parameters[3].Value = model.Spend;
            parameters[4].Value = model.Stock;
            parameters[5].Value = model.Photo;

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
		public bool Update(PhotoStudio.Model.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update tb_Goods set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Type=@Type,");
            strSql.Append("Cost=@Cost,");
            strSql.Append("Spend=@Spend,");
            strSql.Append("Stock=@Stock,");
            strSql.Append("Photo=@Photo");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,50),
                    new SqlParameter("@Type", SqlDbType.NVarChar,50),
                    new SqlParameter("@Cost", SqlDbType.Decimal,9),
                    new SqlParameter("@Spend", SqlDbType.Decimal,9),
                    new SqlParameter("@Stock", SqlDbType.Int,4),
                    new SqlParameter("@Photo", SqlDbType.NVarChar,-1),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.Cost;
            parameters[3].Value = model.Spend;
            parameters[4].Value = model.Stock;
            parameters[5].Value = model.Photo;
            parameters[6].Value = model.ID;

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
		/// 商品入库
		/// </summary>
		public void Update(int id, int num,decimal price)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Goods set ");
            strSql.Append("Cost=@Cost,");
            strSql.Append("Stock=Stock+@Stock");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@Cost", SqlDbType.Decimal,9),
                    new SqlParameter("@Stock", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = price;
            parameters[1].Value = num;
            parameters[2].Value = id;
    SqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Goods ");
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
			strSql.Append("delete from tb_Goods ");
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
		public PhotoStudio.Model.Goods GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 ID,Name,Type,Cost,Spend,Stock,Photo from tb_Goods ");
            strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			PhotoStudio.Model.Goods model=new PhotoStudio.Model.Goods();
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
        public PhotoStudio.Model.Goods GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,Type,Cost,Spend,Stock,Photo from tb_Goods ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            PhotoStudio.Model.Goods model = new PhotoStudio.Model.Goods();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public PhotoStudio.Model.Goods DataRowToModel(DataRow row)
		{
			PhotoStudio.Model.Goods model=new PhotoStudio.Model.Goods();
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
				if(row["Cost"]!=null && row["Cost"].ToString()!="")
				{
					model.Cost=decimal.Parse(row["Cost"].ToString());
				}
				if(row["Spend"]!=null && row["Spend"].ToString()!="")
				{
					model.Spend=decimal.Parse(row["Spend"].ToString());
				}
				if(row["Stock"]!=null && row["Stock"].ToString()!="")
				{
					model.Stock=int.Parse(row["Stock"].ToString());
				}
                if (row["Photo"] != null)
                {
                    model.Photo = row["Photo"].ToString();
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
            strSql.Append("select ID,Name,Type,Cost,Spend,Stock,Photo ");
            strSql.Append(" FROM tb_Goods ");
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
            strSql.Append(" ID,Name,Type,Cost,Spend,Stock,Photo ");
            strSql.Append(" FROM tb_Goods ");
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
			strSql.Append("select count(1) FROM tb_Goods ");
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
			strSql.Append(")AS Row, T.*  from tb_Goods T ");
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

		#endregion  ExtensionMethod
	}
}

