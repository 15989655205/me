﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Department
	/// </summary>
	public partial class Department
	{
		public Department()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Department(");
			strSql.Append("DepartmentID,DepartmentNo,DepartmentName,DepartmentRemark,Remark,CreatedDate,CreatedGuy,UpdatedDate,Status,CheckDate,DepartmentGroup)");
			strSql.Append(" values (");
			strSql.Append("@DepartmentID,@DepartmentNo,@DepartmentName,@DepartmentRemark,@Remark,@CreatedDate,@CreatedGuy,@UpdatedDate,@Status,@CheckDate,@DepartmentGroup)");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.Int,4),
					new SqlParameter("@DepartmentNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DepartmentName", SqlDbType.NVarChar,255),
					new SqlParameter("@DepartmentRemark", SqlDbType.Text),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedGuy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
					new SqlParameter("@DepartmentGroup", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.DepartmentID;
			parameters[1].Value = model.DepartmentNo;
			parameters[2].Value = model.DepartmentName;
			parameters[3].Value = model.DepartmentRemark;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.CreatedDate;
			parameters[6].Value = model.CreatedGuy;
			parameters[7].Value = model.UpdatedDate;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.CheckDate;
			parameters[10].Value = model.DepartmentGroup;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Department set ");
			strSql.Append("DepartmentID=@DepartmentID,");
			strSql.Append("DepartmentNo=@DepartmentNo,");
			strSql.Append("DepartmentName=@DepartmentName,");
			strSql.Append("DepartmentRemark=@DepartmentRemark,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("CreatedDate=@CreatedDate,");
			strSql.Append("CreatedGuy=@CreatedGuy,");
			strSql.Append("UpdatedDate=@UpdatedDate,");
			strSql.Append("Status=@Status,");
			strSql.Append("CheckDate=@CheckDate,");
			strSql.Append("DepartmentGroup=@DepartmentGroup");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@DepartmentID", SqlDbType.Int,4),
					new SqlParameter("@DepartmentNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DepartmentName", SqlDbType.NVarChar,255),
					new SqlParameter("@DepartmentRemark", SqlDbType.Text),
					new SqlParameter("@Remark", SqlDbType.NText),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedGuy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
					new SqlParameter("@DepartmentGroup", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.DepartmentID;
			parameters[1].Value = model.DepartmentNo;
			parameters[2].Value = model.DepartmentName;
			parameters[3].Value = model.DepartmentRemark;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.CreatedDate;
			parameters[6].Value = model.CreatedGuy;
			parameters[7].Value = model.UpdatedDate;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.CheckDate;
			parameters[10].Value = model.DepartmentGroup;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Department ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public Maticsoft.Model.Department GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DepartmentID,DepartmentNo,DepartmentName,DepartmentRemark,Remark,CreatedDate,CreatedGuy,UpdatedDate,Status,CheckDate,DepartmentGroup from Department ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Maticsoft.Model.Department model=new Maticsoft.Model.Department();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
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
		public Maticsoft.Model.Department DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Department model=new Maticsoft.Model.Department();
			if (row != null)
			{
				if(row["DepartmentID"]!=null && row["DepartmentID"].ToString()!="")
				{
					model.DepartmentID=int.Parse(row["DepartmentID"].ToString());
				}
				if(row["DepartmentNo"]!=null)
				{
					model.DepartmentNo=row["DepartmentNo"].ToString();
				}
				if(row["DepartmentName"]!=null)
				{
					model.DepartmentName=row["DepartmentName"].ToString();
				}
				if(row["DepartmentRemark"]!=null)
				{
					model.DepartmentRemark=row["DepartmentRemark"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["CreatedGuy"]!=null && row["CreatedGuy"].ToString()!="")
				{
					model.CreatedGuy=int.Parse(row["CreatedGuy"].ToString());
				}
				if(row["UpdatedDate"]!=null && row["UpdatedDate"].ToString()!="")
				{
					model.UpdatedDate=DateTime.Parse(row["UpdatedDate"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["CheckDate"]!=null && row["CheckDate"].ToString()!="")
				{
					model.CheckDate=DateTime.Parse(row["CheckDate"].ToString());
				}
				if(row["DepartmentGroup"]!=null)
				{
					model.DepartmentGroup=row["DepartmentGroup"].ToString();
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
			strSql.Append("select DepartmentID,DepartmentNo,DepartmentName,DepartmentRemark,Remark,CreatedDate,CreatedGuy,UpdatedDate,Status,CheckDate,DepartmentGroup ");
			strSql.Append(" FROM Department ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" DepartmentID,DepartmentNo,DepartmentName,DepartmentRemark,Remark,CreatedDate,CreatedGuy,UpdatedDate,Status,CheckDate,DepartmentGroup ");
			strSql.Append(" FROM Department ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Department ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
				strSql.Append("order by T.UserID desc");
			}
			strSql.Append(")AS Row, T.*  from Department T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Department";
			parameters[1].Value = "UserID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

