//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class LanguageForeignCrud {
		///<summary>Gets one LanguageForeign object from the database using the primary key.  Returns null if not found.</summary>
		public static LanguageForeign SelectOne(long languageForeignNum) {
			string command="SELECT * FROM languageforeign "
				+"WHERE LanguageForeignNum = "+POut.Long(languageForeignNum);
			List<LanguageForeign> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one LanguageForeign object from the database using a query.</summary>
		public static LanguageForeign SelectOne(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<LanguageForeign> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of LanguageForeign objects from the database using a query.</summary>
		public static List<LanguageForeign> SelectMany(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<LanguageForeign> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<LanguageForeign> TableToList(DataTable table) {
			List<LanguageForeign> retVal=new List<LanguageForeign>();
			LanguageForeign languageForeign;
			foreach(DataRow row in table.Rows) {
				languageForeign=new LanguageForeign();
				languageForeign.LanguageForeignNum= PIn.Long  (row["LanguageForeignNum"].ToString());
				languageForeign.ClassType         = PIn.String(row["ClassType"].ToString());
				languageForeign.English           = PIn.String(row["English"].ToString());
				languageForeign.Culture           = PIn.String(row["Culture"].ToString());
				languageForeign.Translation       = PIn.String(row["Translation"].ToString());
				languageForeign.Comments          = PIn.String(row["Comments"].ToString());
				retVal.Add(languageForeign);
			}
			return retVal;
		}

		///<summary>Converts a list of LanguageForeign into a DataTable.</summary>
		public static DataTable ListToTable(List<LanguageForeign> listLanguageForeigns,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="LanguageForeign";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("LanguageForeignNum");
			table.Columns.Add("ClassType");
			table.Columns.Add("English");
			table.Columns.Add("Culture");
			table.Columns.Add("Translation");
			table.Columns.Add("Comments");
			foreach(LanguageForeign languageForeign in listLanguageForeigns) {
				table.Rows.Add(new object[] {
					POut.Long  (languageForeign.LanguageForeignNum),
					            languageForeign.ClassType,
					            languageForeign.English,
					            languageForeign.Culture,
					            languageForeign.Translation,
					            languageForeign.Comments,
				});
			}
			return table;
		}

		///<summary>Inserts one LanguageForeign into the database.  Returns the new priKey.</summary>
		public static long Insert(LanguageForeign languageForeign) {
			return Insert(languageForeign,false);
		}

		///<summary>Inserts one LanguageForeign into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(LanguageForeign languageForeign,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				languageForeign.LanguageForeignNum=ReplicationServers.GetKey("languageforeign","LanguageForeignNum");
			}
			string command="INSERT INTO languageforeign (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="LanguageForeignNum,";
			}
			command+="ClassType,English,Culture,Translation,Comments) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(languageForeign.LanguageForeignNum)+",";
			}
			command+=
				     DbHelper.ParamChar+"paramClassType,"
				+    DbHelper.ParamChar+"paramEnglish,"
				+"'"+POut.String(languageForeign.Culture)+"',"
				+    DbHelper.ParamChar+"paramTranslation,"
				+    DbHelper.ParamChar+"paramComments)";
			if(languageForeign.ClassType==null) {
				languageForeign.ClassType="";
			}
			OdSqlParameter paramClassType=new OdSqlParameter("paramClassType",OdDbType.Text,POut.StringParam(languageForeign.ClassType));
			if(languageForeign.English==null) {
				languageForeign.English="";
			}
			OdSqlParameter paramEnglish=new OdSqlParameter("paramEnglish",OdDbType.Text,POut.StringParam(languageForeign.English));
			if(languageForeign.Translation==null) {
				languageForeign.Translation="";
			}
			OdSqlParameter paramTranslation=new OdSqlParameter("paramTranslation",OdDbType.Text,POut.StringParam(languageForeign.Translation));
			if(languageForeign.Comments==null) {
				languageForeign.Comments="";
			}
			OdSqlParameter paramComments=new OdSqlParameter("paramComments",OdDbType.Text,POut.StringParam(languageForeign.Comments));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramClassType,paramEnglish,paramTranslation,paramComments);
			}
			else {
				languageForeign.LanguageForeignNum=Db.NonQ(command,true,"LanguageForeignNum","languageForeign",paramClassType,paramEnglish,paramTranslation,paramComments);
			}
			return languageForeign.LanguageForeignNum;
		}

		///<summary>Inserts one LanguageForeign into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(LanguageForeign languageForeign) {
			return InsertNoCache(languageForeign,false);
		}

		///<summary>Inserts one LanguageForeign into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(LanguageForeign languageForeign,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO languageforeign (";
			if(!useExistingPK && isRandomKeys) {
				languageForeign.LanguageForeignNum=ReplicationServers.GetKeyNoCache("languageforeign","LanguageForeignNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="LanguageForeignNum,";
			}
			command+="ClassType,English,Culture,Translation,Comments) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(languageForeign.LanguageForeignNum)+",";
			}
			command+=
				     DbHelper.ParamChar+"paramClassType,"
				+    DbHelper.ParamChar+"paramEnglish,"
				+"'"+POut.String(languageForeign.Culture)+"',"
				+    DbHelper.ParamChar+"paramTranslation,"
				+    DbHelper.ParamChar+"paramComments)";
			if(languageForeign.ClassType==null) {
				languageForeign.ClassType="";
			}
			OdSqlParameter paramClassType=new OdSqlParameter("paramClassType",OdDbType.Text,POut.StringParam(languageForeign.ClassType));
			if(languageForeign.English==null) {
				languageForeign.English="";
			}
			OdSqlParameter paramEnglish=new OdSqlParameter("paramEnglish",OdDbType.Text,POut.StringParam(languageForeign.English));
			if(languageForeign.Translation==null) {
				languageForeign.Translation="";
			}
			OdSqlParameter paramTranslation=new OdSqlParameter("paramTranslation",OdDbType.Text,POut.StringParam(languageForeign.Translation));
			if(languageForeign.Comments==null) {
				languageForeign.Comments="";
			}
			OdSqlParameter paramComments=new OdSqlParameter("paramComments",OdDbType.Text,POut.StringParam(languageForeign.Comments));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramClassType,paramEnglish,paramTranslation,paramComments);
			}
			else {
				languageForeign.LanguageForeignNum=Db.NonQ(command,true,"LanguageForeignNum","languageForeign",paramClassType,paramEnglish,paramTranslation,paramComments);
			}
			return languageForeign.LanguageForeignNum;
		}

		///<summary>Updates one LanguageForeign in the database.</summary>
		public static void Update(LanguageForeign languageForeign) {
			string command="UPDATE languageforeign SET "
				+"ClassType         =  "+DbHelper.ParamChar+"paramClassType, "
				+"English           =  "+DbHelper.ParamChar+"paramEnglish, "
				+"Culture           = '"+POut.String(languageForeign.Culture)+"', "
				+"Translation       =  "+DbHelper.ParamChar+"paramTranslation, "
				+"Comments          =  "+DbHelper.ParamChar+"paramComments "
				+"WHERE LanguageForeignNum = "+POut.Long(languageForeign.LanguageForeignNum);
			if(languageForeign.ClassType==null) {
				languageForeign.ClassType="";
			}
			OdSqlParameter paramClassType=new OdSqlParameter("paramClassType",OdDbType.Text,POut.StringParam(languageForeign.ClassType));
			if(languageForeign.English==null) {
				languageForeign.English="";
			}
			OdSqlParameter paramEnglish=new OdSqlParameter("paramEnglish",OdDbType.Text,POut.StringParam(languageForeign.English));
			if(languageForeign.Translation==null) {
				languageForeign.Translation="";
			}
			OdSqlParameter paramTranslation=new OdSqlParameter("paramTranslation",OdDbType.Text,POut.StringParam(languageForeign.Translation));
			if(languageForeign.Comments==null) {
				languageForeign.Comments="";
			}
			OdSqlParameter paramComments=new OdSqlParameter("paramComments",OdDbType.Text,POut.StringParam(languageForeign.Comments));
			Db.NonQ(command,paramClassType,paramEnglish,paramTranslation,paramComments);
		}

		///<summary>Updates one LanguageForeign in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(LanguageForeign languageForeign,LanguageForeign oldLanguageForeign) {
			string command="";
			if(languageForeign.ClassType != oldLanguageForeign.ClassType) {
				if(command!="") { command+=",";}
				command+="ClassType = "+DbHelper.ParamChar+"paramClassType";
			}
			if(languageForeign.English != oldLanguageForeign.English) {
				if(command!="") { command+=",";}
				command+="English = "+DbHelper.ParamChar+"paramEnglish";
			}
			if(languageForeign.Culture != oldLanguageForeign.Culture) {
				if(command!="") { command+=",";}
				command+="Culture = '"+POut.String(languageForeign.Culture)+"'";
			}
			if(languageForeign.Translation != oldLanguageForeign.Translation) {
				if(command!="") { command+=",";}
				command+="Translation = "+DbHelper.ParamChar+"paramTranslation";
			}
			if(languageForeign.Comments != oldLanguageForeign.Comments) {
				if(command!="") { command+=",";}
				command+="Comments = "+DbHelper.ParamChar+"paramComments";
			}
			if(command=="") {
				return false;
			}
			if(languageForeign.ClassType==null) {
				languageForeign.ClassType="";
			}
			OdSqlParameter paramClassType=new OdSqlParameter("paramClassType",OdDbType.Text,POut.StringParam(languageForeign.ClassType));
			if(languageForeign.English==null) {
				languageForeign.English="";
			}
			OdSqlParameter paramEnglish=new OdSqlParameter("paramEnglish",OdDbType.Text,POut.StringParam(languageForeign.English));
			if(languageForeign.Translation==null) {
				languageForeign.Translation="";
			}
			OdSqlParameter paramTranslation=new OdSqlParameter("paramTranslation",OdDbType.Text,POut.StringParam(languageForeign.Translation));
			if(languageForeign.Comments==null) {
				languageForeign.Comments="";
			}
			OdSqlParameter paramComments=new OdSqlParameter("paramComments",OdDbType.Text,POut.StringParam(languageForeign.Comments));
			command="UPDATE languageforeign SET "+command
				+" WHERE LanguageForeignNum = "+POut.Long(languageForeign.LanguageForeignNum);
			Db.NonQ(command,paramClassType,paramEnglish,paramTranslation,paramComments);
			return true;
		}

		///<summary>Returns true if Update(LanguageForeign,LanguageForeign) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(LanguageForeign languageForeign,LanguageForeign oldLanguageForeign) {
			if(languageForeign.ClassType != oldLanguageForeign.ClassType) {
				return true;
			}
			if(languageForeign.English != oldLanguageForeign.English) {
				return true;
			}
			if(languageForeign.Culture != oldLanguageForeign.Culture) {
				return true;
			}
			if(languageForeign.Translation != oldLanguageForeign.Translation) {
				return true;
			}
			if(languageForeign.Comments != oldLanguageForeign.Comments) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one LanguageForeign from the database.</summary>
		public static void Delete(long languageForeignNum) {
			string command="DELETE FROM languageforeign "
				+"WHERE LanguageForeignNum = "+POut.Long(languageForeignNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many LanguageForeigns from the database.</summary>
		public static void DeleteMany(List<long> listLanguageForeignNums) {
			if(listLanguageForeignNums==null || listLanguageForeignNums.Count==0) {
				return;
			}
			string command="DELETE FROM languageforeign "
				+"WHERE LanguageForeignNum IN("+string.Join(",",listLanguageForeignNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}