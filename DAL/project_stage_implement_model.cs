﻿/**  版本信息模板在安装目录下，可自行修改。
* project_stage_implement_model.cs
*
* 功 能： N/A
* 类 名： project_stage_implement_model
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-8-29 14:53:14   N/A    初版
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
using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Collections;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:project_stage_implement_model
	/// </summary>
	public partial class project_stage_implement_model
	{
		public project_stage_implement_model()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("sid", "project_stage_implement_model"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from project_stage_implement_model");
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
		public int Add(Maticsoft.Model.project_stage_implement_model model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into project_stage_implement_model(");
			strSql.Append("implement_name,s_sid,show_column,implementers_sid,implementers,sequence,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date)");
			strSql.Append(" values (");
			strSql.Append("@implement_name,@s_sid,@show_column,@implementers_sid,@implementers,@sequence,@remark,@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@n1,@n2,@n3,@show,@show_name,@status,@create_person,@create_date,@update_person,@update_date)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@implement_name", SqlDbType.NVarChar,100),
					new SqlParameter("@s_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@show_column", SqlDbType.NVarChar,50),
					new SqlParameter("@implementers_sid", SqlDbType.NVarChar,200),
					new SqlParameter("@implementers", SqlDbType.NVarChar,200),
					new SqlParameter("@sequence", SqlDbType.Int,4),
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
			parameters[0].Value = model.implement_name;
			parameters[1].Value = model.s_sid;
			parameters[2].Value = model.show_column;
			parameters[3].Value = model.implementers_sid;
			parameters[4].Value = model.implementers;
			parameters[5].Value = model.sequence;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.v1;
			parameters[8].Value = model.v2;
			parameters[9].Value = model.v3;
			parameters[10].Value = model.v4;
			parameters[11].Value = model.v5;
			parameters[12].Value = model.v6;
			parameters[13].Value = model.v7;
			parameters[14].Value = model.v8;
			parameters[15].Value = model.v9;
			parameters[16].Value = model.v10;
			parameters[17].Value = model.n1;
			parameters[18].Value = model.n2;
			parameters[19].Value = model.n3;
			parameters[20].Value = model.show;
			parameters[21].Value = model.show_name;
			parameters[22].Value = model.status;
			parameters[23].Value = model.create_person;
			parameters[24].Value = model.create_date;
			parameters[25].Value = model.update_person;
			parameters[26].Value = model.update_date;

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
		public bool Update(Maticsoft.Model.project_stage_implement_model model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update project_stage_implement_model set ");
			strSql.Append("implement_name=@implement_name,");
			strSql.Append("s_sid=@s_sid,");
			strSql.Append("show_column=@show_column,");
			strSql.Append("implementers_sid=@implementers_sid,");
			strSql.Append("implementers=@implementers,");
			strSql.Append("sequence=@sequence,");
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
					new SqlParameter("@implement_name", SqlDbType.NVarChar,100),
					new SqlParameter("@s_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@show_column", SqlDbType.NVarChar,50),
					new SqlParameter("@implementers_sid", SqlDbType.NVarChar,200),
					new SqlParameter("@implementers", SqlDbType.NVarChar,200),
					new SqlParameter("@sequence", SqlDbType.Int,4),
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
			parameters[0].Value = model.implement_name;
			parameters[1].Value = model.s_sid;
			parameters[2].Value = model.show_column;
			parameters[3].Value = model.implementers_sid;
			parameters[4].Value = model.implementers;
			parameters[5].Value = model.sequence;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.v1;
			parameters[8].Value = model.v2;
			parameters[9].Value = model.v3;
			parameters[10].Value = model.v4;
			parameters[11].Value = model.v5;
			parameters[12].Value = model.v6;
			parameters[13].Value = model.v7;
			parameters[14].Value = model.v8;
			parameters[15].Value = model.v9;
			parameters[16].Value = model.v10;
			parameters[17].Value = model.n1;
			parameters[18].Value = model.n2;
			parameters[19].Value = model.n3;
			parameters[20].Value = model.show;
			parameters[21].Value = model.show_name;
			parameters[22].Value = model.status;
			parameters[23].Value = model.create_person;
			parameters[24].Value = model.create_date;
			parameters[25].Value = model.update_person;
			parameters[26].Value = model.update_date;
			parameters[27].Value = model.sid;

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
			strSql.Append("delete from project_stage_implement_model ");
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
			strSql.Append("delete from project_stage_implement_model ");
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
		public Maticsoft.Model.project_stage_implement_model GetModel(int sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sid,implement_name,s_sid,show_column,implementers_sid,implementers,sequence,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date from project_stage_implement_model ");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

			Maticsoft.Model.project_stage_implement_model model=new Maticsoft.Model.project_stage_implement_model();
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
		public Maticsoft.Model.project_stage_implement_model DataRowToModel(DataRow row)
		{
			Maticsoft.Model.project_stage_implement_model model=new Maticsoft.Model.project_stage_implement_model();
			if (row != null)
			{
				if(row["sid"]!=null && row["sid"].ToString()!="")
				{
					model.sid=int.Parse(row["sid"].ToString());
				}
				if(row["implement_name"]!=null)
				{
					model.implement_name=row["implement_name"].ToString();
				}
				if(row["s_sid"]!=null)
				{
					model.s_sid=row["s_sid"].ToString();
				}
				if(row["show_column"]!=null)
				{
					model.show_column=row["show_column"].ToString();
				}
				if(row["implementers_sid"]!=null)
				{
					model.implementers_sid=row["implementers_sid"].ToString();
				}
				if(row["implementers"]!=null)
				{
					model.implementers=row["implementers"].ToString();
				}
				if(row["sequence"]!=null && row["sequence"].ToString()!="")
				{
					model.sequence=int.Parse(row["sequence"].ToString());
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
			strSql.Append("select sid,implement_name,s_sid,show_column,implementers_sid,implementers,sequence,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date ");
			strSql.Append(" FROM project_stage_implement_model ");
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
			strSql.Append(" sid,implement_name,s_sid,show_column,implementers_sid,implementers,sequence,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date ");
			strSql.Append(" FROM project_stage_implement_model ");
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
			strSql.Append("select count(1) FROM project_stage_implement_model ");
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
			strSql.Append(")AS Row, T.*  from project_stage_implement_model T ");
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
			parameters[0].Value = "project_stage_implement_model";
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
        public bool Edit(List<Model.project_stage_implement_model> insertList, List<Model.project_stage_implement_model> updateList, List<Model.project_stage_implement_model> delList, List<Model.project_stage_implement_model> sequenceList)
        {
            ArrayList al = new ArrayList();
            StringBuilder sbSql = new StringBuilder();
            //删除
            for (int i = 0; i < delList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.project_stage_implement_model model = delList[i];
                sbSql.Append("delete from project_stage_implement_model where sid=" + model.sid);
                al.Add(sbSql.ToString());
            }
            //修改
            for (int i = 0; i < updateList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.project_stage_implement_model model = updateList[i];
                sbSql.Append("update project_stage_implement_model set implement_name = '" + model.implement_name.Trim() + "',");
                sbSql.Append("remark = '" + model.remark.Trim() + "'");
                sbSql.Append(" where sid = " + model.sid.ToString().Trim() + "");
                al.Add(sbSql.ToString());
            }
            //添加
            for (int i = 0; i < insertList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.project_stage_implement_model model = insertList[i];
                sbSql.Append("insert into project_stage_implement_model(implement_name,remark,s_sid,sequence");
                sbSql.Append(")values(");
                sbSql.Append("'" + model.implement_name.Trim() + "','" + model.remark.Trim() + "','" + model.s_sid + "'," + model.sequence);
                sbSql.Append(")");
                al.Add(sbSql.ToString());
            }

            //排序
            for (int i = 0; i < sequenceList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.project_stage_implement_model model = sequenceList[i];
                if (model.sid != null && model.sid.ToString().Trim() != "0" && model.sid.ToString().Trim() != "")
                {
                    sbSql.Append("update project_stage_implement_model set sequence = " + model.sequence.ToString().Trim());
                    sbSql.Append(" where sid = " + model.sid.ToString().Trim() + "");
                    al.Add(sbSql.ToString());
                }
            }

            DbHelperSQL.ExecuteSqlTran(al);

            return true;
        }

        public DataSet getList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM project_stage_implement_model ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  ExtensionMethod
	}
}

