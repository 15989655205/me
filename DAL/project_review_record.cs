﻿/**  版本信息模板在安装目录下，可自行修改。
* project_review_record.cs
*
* 功 能： N/A
* 类 名： project_review_record
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-8-14 18:29:30   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:project_review_record
	/// </summary>
	public partial class project_review_record
	{
		public project_review_record()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("sid", "project_review_record"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from project_review_record");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.project_review_record model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into project_review_record(");
			strSql.Append("pr_sid,pwi_sid,si_sid,sumbit_content,sumbit_file,sumbit_date,sumbit_user,audit_results,reviewed,review_status,review_content,reviewer,review_date,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date)");
			strSql.Append(" values (");
			strSql.Append("@pr_sid,@pwi_sid,@si_sid,@sumbit_content,@sumbit_file,@sumbit_date,@sumbit_user,@audit_results,@reviewed,@review_status,@review_content,@reviewer,@review_date,@remark,@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@n1,@n2,@n3,@show,@show_name,@status,@create_person,@create_date,@update_person,@update_date)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pr_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@pwi_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@si_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@sumbit_content", SqlDbType.Text),
					new SqlParameter("@sumbit_file", SqlDbType.NVarChar,1000),
					new SqlParameter("@sumbit_date", SqlDbType.DateTime),
					new SqlParameter("@sumbit_user", SqlDbType.NVarChar,50),
					new SqlParameter("@audit_results", SqlDbType.NVarChar,50),
					new SqlParameter("@reviewed", SqlDbType.NVarChar,50),
					new SqlParameter("@review_status", SqlDbType.Int,4),
					new SqlParameter("@review_content", SqlDbType.NVarChar,1000),
					new SqlParameter("@reviewer", SqlDbType.NVarChar,50),
					new SqlParameter("@review_date", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@v1", SqlDbType.NVarChar,255),
					new SqlParameter("@v2", SqlDbType.NVarChar,255),
					new SqlParameter("@v3", SqlDbType.NVarChar,255),
					new SqlParameter("@v4", SqlDbType.NVarChar,255),
					new SqlParameter("@v5", SqlDbType.NVarChar,255),
					new SqlParameter("@v6", SqlDbType.NVarChar,255),
					new SqlParameter("@v7", SqlDbType.NVarChar,255),
					new SqlParameter("@v8", SqlDbType.NVarChar,255),
					new SqlParameter("@v9", SqlDbType.NVarChar,255),
					new SqlParameter("@v10", SqlDbType.NVarChar,255),
					new SqlParameter("@n1", SqlDbType.Int,4),
					new SqlParameter("@n2", SqlDbType.Int,4),
					new SqlParameter("@n3", SqlDbType.Int,4),
					new SqlParameter("@show", SqlDbType.NVarChar,100),
					new SqlParameter("@show_name", SqlDbType.NVarChar,500),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime)};
			parameters[0].Value = model.pr_sid;
			parameters[1].Value = model.pwi_sid;
			parameters[2].Value = model.si_sid;
			parameters[3].Value = model.sumbit_content;
			parameters[4].Value = model.sumbit_file;
			parameters[5].Value = model.sumbit_date;
			parameters[6].Value = model.sumbit_user;
			parameters[7].Value = model.audit_results;
			parameters[8].Value = model.reviewed;
			parameters[9].Value = model.review_status;
			parameters[10].Value = model.review_content;
			parameters[11].Value = model.reviewer;
			parameters[12].Value = model.review_date;
			parameters[13].Value = model.remark;
			parameters[14].Value = model.v1;
			parameters[15].Value = model.v2;
			parameters[16].Value = model.v3;
			parameters[17].Value = model.v4;
			parameters[18].Value = model.v5;
			parameters[19].Value = model.v6;
			parameters[20].Value = model.v7;
			parameters[21].Value = model.v8;
			parameters[22].Value = model.v9;
			parameters[23].Value = model.v10;
			parameters[24].Value = model.n1;
			parameters[25].Value = model.n2;
			parameters[26].Value = model.n3;
			parameters[27].Value = model.show;
			parameters[28].Value = model.show_name;
			parameters[29].Value = model.status;
			parameters[30].Value = model.create_person;
			parameters[31].Value = model.create_date;
			parameters[32].Value = model.update_person;
			parameters[33].Value = model.update_date;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Maticsoft.Model.project_review_record model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update project_review_record set ");
			strSql.Append("pr_sid=@pr_sid,");
			strSql.Append("pwi_sid=@pwi_sid,");
			strSql.Append("si_sid=@si_sid,");
			strSql.Append("sumbit_content=@sumbit_content,");
			strSql.Append("sumbit_file=@sumbit_file,");
			strSql.Append("sumbit_date=@sumbit_date,");
			strSql.Append("sumbit_user=@sumbit_user,");
			strSql.Append("audit_results=@audit_results,");
			strSql.Append("reviewed=@reviewed,");
			strSql.Append("review_status=@review_status,");
			strSql.Append("review_content=@review_content,");
			strSql.Append("reviewer=@reviewer,");
			strSql.Append("review_date=@review_date,");
			strSql.Append("remark=@remark,");
			strSql.Append("v1=@v1,");
			strSql.Append("v2=@v2,");
			strSql.Append("v3=@v3,");
			strSql.Append("v4=@v4,");
			strSql.Append("v5=@v5,");
			strSql.Append("v6=@v6,");
			strSql.Append("v7=@v7,");
			strSql.Append("v8=@v8,");
			strSql.Append("v9=@v9,");
			strSql.Append("v10=@v10,");
			strSql.Append("n1=@n1,");
			strSql.Append("n2=@n2,");
			strSql.Append("n3=@n3,");
			strSql.Append("show=@show,");
			strSql.Append("show_name=@show_name,");
			strSql.Append("status=@status,");
			strSql.Append("create_person=@create_person,");
			strSql.Append("create_date=@create_date,");
			strSql.Append("update_person=@update_person,");
			strSql.Append("update_date=@update_date");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@pr_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@pwi_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@si_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@sumbit_content", SqlDbType.Text),
					new SqlParameter("@sumbit_file", SqlDbType.NVarChar,1000),
					new SqlParameter("@sumbit_date", SqlDbType.DateTime),
					new SqlParameter("@sumbit_user", SqlDbType.NVarChar,50),
					new SqlParameter("@audit_results", SqlDbType.NVarChar,50),
					new SqlParameter("@reviewed", SqlDbType.NVarChar,50),
					new SqlParameter("@review_status", SqlDbType.Int,4),
					new SqlParameter("@review_content", SqlDbType.NVarChar,1000),
					new SqlParameter("@reviewer", SqlDbType.NVarChar,50),
					new SqlParameter("@review_date", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@v1", SqlDbType.NVarChar,255),
					new SqlParameter("@v2", SqlDbType.NVarChar,255),
					new SqlParameter("@v3", SqlDbType.NVarChar,255),
					new SqlParameter("@v4", SqlDbType.NVarChar,255),
					new SqlParameter("@v5", SqlDbType.NVarChar,255),
					new SqlParameter("@v6", SqlDbType.NVarChar,255),
					new SqlParameter("@v7", SqlDbType.NVarChar,255),
					new SqlParameter("@v8", SqlDbType.NVarChar,255),
					new SqlParameter("@v9", SqlDbType.NVarChar,255),
					new SqlParameter("@v10", SqlDbType.NVarChar,255),
					new SqlParameter("@n1", SqlDbType.Int,4),
					new SqlParameter("@n2", SqlDbType.Int,4),
					new SqlParameter("@n3", SqlDbType.Int,4),
					new SqlParameter("@show", SqlDbType.NVarChar,100),
					new SqlParameter("@show_name", SqlDbType.NVarChar,500),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.Int,4)};
			parameters[0].Value = model.pr_sid;
			parameters[1].Value = model.pwi_sid;
			parameters[2].Value = model.si_sid;
			parameters[3].Value = model.sumbit_content;
			parameters[4].Value = model.sumbit_file;
			parameters[5].Value = model.sumbit_date;
			parameters[6].Value = model.sumbit_user;
			parameters[7].Value = model.audit_results;
			parameters[8].Value = model.reviewed;
			parameters[9].Value = model.review_status;
			parameters[10].Value = model.review_content;
			parameters[11].Value = model.reviewer;
			parameters[12].Value = model.review_date;
			parameters[13].Value = model.remark;
			parameters[14].Value = model.v1;
			parameters[15].Value = model.v2;
			parameters[16].Value = model.v3;
			parameters[17].Value = model.v4;
			parameters[18].Value = model.v5;
			parameters[19].Value = model.v6;
			parameters[20].Value = model.v7;
			parameters[21].Value = model.v8;
			parameters[22].Value = model.v9;
			parameters[23].Value = model.v10;
			parameters[24].Value = model.n1;
			parameters[25].Value = model.n2;
			parameters[26].Value = model.n3;
			parameters[27].Value = model.show;
			parameters[28].Value = model.show_name;
			parameters[29].Value = model.status;
			parameters[30].Value = model.create_person;
			parameters[31].Value = model.create_date;
			parameters[32].Value = model.update_person;
			parameters[33].Value = model.update_date;
			parameters[34].Value = model.sid;

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
		public bool Delete(int sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from project_review_record ");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string sidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from project_review_record ");
			strSql.Append(" where sid in ("+sidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Maticsoft.Model.project_review_record GetModel(int sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sid,pr_sid,pwi_sid,si_sid,sumbit_content,sumbit_file,sumbit_date,sumbit_user,audit_results,reviewed,review_status,review_content,reviewer,review_date,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date from project_review_record ");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

			Maticsoft.Model.project_review_record model=new Maticsoft.Model.project_review_record();
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
		public Maticsoft.Model.project_review_record DataRowToModel(DataRow row)
		{
			Maticsoft.Model.project_review_record model=new Maticsoft.Model.project_review_record();
			if (row != null)
			{
				if(row["sid"]!=null && row["sid"].ToString()!="")
				{
					model.sid=int.Parse(row["sid"].ToString());
				}
				if(row["pr_sid"]!=null)
				{
					model.pr_sid=row["pr_sid"].ToString();
				}
				if(row["pwi_sid"]!=null)
				{
					model.pwi_sid=row["pwi_sid"].ToString();
				}
				if(row["si_sid"]!=null)
				{
					model.si_sid=row["si_sid"].ToString();
				}
				if(row["sumbit_content"]!=null)
				{
					model.sumbit_content=row["sumbit_content"].ToString();
				}
				if(row["sumbit_file"]!=null)
				{
					model.sumbit_file=row["sumbit_file"].ToString();
				}
				if(row["sumbit_date"]!=null && row["sumbit_date"].ToString()!="")
				{
					model.sumbit_date=DateTime.Parse(row["sumbit_date"].ToString());
				}
				if(row["sumbit_user"]!=null)
				{
					model.sumbit_user=row["sumbit_user"].ToString();
				}
				if(row["audit_results"]!=null)
				{
					model.audit_results=row["audit_results"].ToString();
				}
				if(row["reviewed"]!=null)
				{
					model.reviewed=row["reviewed"].ToString();
				}
				if(row["review_status"]!=null && row["review_status"].ToString()!="")
				{
					model.review_status=int.Parse(row["review_status"].ToString());
				}
				if(row["review_content"]!=null)
				{
					model.review_content=row["review_content"].ToString();
				}
				if(row["reviewer"]!=null)
				{
					model.reviewer=row["reviewer"].ToString();
				}
				if(row["review_date"]!=null && row["review_date"].ToString()!="")
				{
					model.review_date=DateTime.Parse(row["review_date"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["v1"]!=null)
				{
					model.v1=row["v1"].ToString();
				}
				if(row["v2"]!=null)
				{
					model.v2=row["v2"].ToString();
				}
				if(row["v3"]!=null)
				{
					model.v3=row["v3"].ToString();
				}
				if(row["v4"]!=null)
				{
					model.v4=row["v4"].ToString();
				}
				if(row["v5"]!=null)
				{
					model.v5=row["v5"].ToString();
				}
				if(row["v6"]!=null)
				{
					model.v6=row["v6"].ToString();
				}
				if(row["v7"]!=null)
				{
					model.v7=row["v7"].ToString();
				}
				if(row["v8"]!=null)
				{
					model.v8=row["v8"].ToString();
				}
				if(row["v9"]!=null)
				{
					model.v9=row["v9"].ToString();
				}
				if(row["v10"]!=null)
				{
					model.v10=row["v10"].ToString();
				}
				if(row["n1"]!=null && row["n1"].ToString()!="")
				{
					model.n1=int.Parse(row["n1"].ToString());
				}
				if(row["n2"]!=null && row["n2"].ToString()!="")
				{
					model.n2=int.Parse(row["n2"].ToString());
				}
				if(row["n3"]!=null && row["n3"].ToString()!="")
				{
					model.n3=int.Parse(row["n3"].ToString());
				}
				if(row["show"]!=null)
				{
					model.show=row["show"].ToString();
				}
				if(row["show_name"]!=null)
				{
					model.show_name=row["show_name"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["create_person"]!=null)
				{
					model.create_person=row["create_person"].ToString();
				}
				if(row["create_date"]!=null && row["create_date"].ToString()!="")
				{
					model.create_date=DateTime.Parse(row["create_date"].ToString());
				}
				if(row["update_person"]!=null)
				{
					model.update_person=row["update_person"].ToString();
				}
				if(row["update_date"]!=null && row["update_date"].ToString()!="")
				{
					model.update_date=DateTime.Parse(row["update_date"].ToString());
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
            strSql.Append("select * ,dbo.getUsername_fu(sumbit_user) as suser,dbo.getUsername_fu(reviewer) as rev");
			strSql.Append(" FROM project_review_record ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(
                " select sid, pr_sid, reviewed, review_results, review_status, " +
                "     dbo.getFilesID(review_file)review_file_id, " +
                "     dbo.getFilesName(review_file)review_file_name, " +
                "     dbo.getFilesPath(review_file)review_file_path, " +
                "     dbo.getNameByUserName(reviewer)reviewer, " +
                "     convert(nvarchar,review_date,120)review_date, " +
                "     review_content,reason,solution,result " +
                " FROM project_review_record "
            );           
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by review_date desc ");
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
			strSql.Append(" sid,pr_sid,pwi_sid,si_sid,sumbit_content,sumbit_file,sumbit_date,sumbit_user,audit_results,reviewed,review_status,review_content,reviewer,review_date,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date ");
			strSql.Append(" FROM project_review_record ");
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
			strSql.Append("select count(1) FROM project_review_record ");
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
				strSql.Append("order by T.sid desc");
			}
			strSql.Append(")AS Row, T.*  from project_review_record T ");
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
			parameters[0].Value = "project_review_record";
			parameters[1].Value = "sid";
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

