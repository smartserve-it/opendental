//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class QuestionDefCrud {
		///<summary>Gets one QuestionDef object from the database using the primary key.  Returns null if not found.</summary>
		public static QuestionDef SelectOne(long questionDefNum) {
			string command="SELECT * FROM questiondef "
				+"WHERE QuestionDefNum = "+POut.Long(questionDefNum);
			List<QuestionDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one QuestionDef object from the database using a query.</summary>
		public static QuestionDef SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<QuestionDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of QuestionDef objects from the database using a query.</summary>
		public static List<QuestionDef> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<QuestionDef> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<QuestionDef> TableToList(DataTable table) {
			List<QuestionDef> retVal=new List<QuestionDef>();
			QuestionDef questionDef;
			foreach(DataRow row in table.Rows) {
				questionDef=new QuestionDef();
				questionDef.QuestionDefNum= PIn.Long  (row["QuestionDefNum"].ToString());
				questionDef.Description   = PIn.String(row["Description"].ToString());
				questionDef.ItemOrder     = PIn.Int   (row["ItemOrder"].ToString());
				questionDef.QuestType     = (OpenDentBusiness.QuestionType)PIn.Int(row["QuestType"].ToString());
				retVal.Add(questionDef);
			}
			return retVal;
		}

		///<summary>Converts a list of QuestionDef into a DataTable.</summary>
		public static DataTable ListToTable(List<QuestionDef> listQuestionDefs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="QuestionDef";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("QuestionDefNum");
			table.Columns.Add("Description");
			table.Columns.Add("ItemOrder");
			table.Columns.Add("QuestType");
			foreach(QuestionDef questionDef in listQuestionDefs) {
				table.Rows.Add(new object[] {
					POut.Long  (questionDef.QuestionDefNum),
					            questionDef.Description,
					POut.Int   (questionDef.ItemOrder),
					POut.Int   ((int)questionDef.QuestType),
				});
			}
			return table;
		}

		///<summary>Inserts one QuestionDef into the database.  Returns the new priKey.</summary>
		public static long Insert(QuestionDef questionDef) {
			return Insert(questionDef,false);
		}

		///<summary>Inserts one QuestionDef into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(QuestionDef questionDef,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				questionDef.QuestionDefNum=ReplicationServers.GetKey("questiondef","QuestionDefNum");
			}
			string command="INSERT INTO questiondef (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="QuestionDefNum,";
			}
			command+="Description,ItemOrder,QuestType) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(questionDef.QuestionDefNum)+",";
			}
			command+=
				     DbHelper.ParamChar+"paramDescription,"
				+    POut.Int   (questionDef.ItemOrder)+","
				+    POut.Int   ((int)questionDef.QuestType)+")";
			if(questionDef.Description==null) {
				questionDef.Description="";
			}
			OdSqlParameter paramDescription=new OdSqlParameter("paramDescription",OdDbType.Text,POut.StringParam(questionDef.Description));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramDescription);
			}
			else {
				questionDef.QuestionDefNum=Db.NonQ(command,true,"QuestionDefNum","questionDef",paramDescription);
			}
			return questionDef.QuestionDefNum;
		}

		///<summary>Inserts one QuestionDef into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(QuestionDef questionDef) {
			return InsertNoCache(questionDef,false);
		}

		///<summary>Inserts one QuestionDef into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(QuestionDef questionDef,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO questiondef (";
			if(!useExistingPK && isRandomKeys) {
				questionDef.QuestionDefNum=ReplicationServers.GetKeyNoCache("questiondef","QuestionDefNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="QuestionDefNum,";
			}
			command+="Description,ItemOrder,QuestType) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(questionDef.QuestionDefNum)+",";
			}
			command+=
				     DbHelper.ParamChar+"paramDescription,"
				+    POut.Int   (questionDef.ItemOrder)+","
				+    POut.Int   ((int)questionDef.QuestType)+")";
			if(questionDef.Description==null) {
				questionDef.Description="";
			}
			OdSqlParameter paramDescription=new OdSqlParameter("paramDescription",OdDbType.Text,POut.StringParam(questionDef.Description));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramDescription);
			}
			else {
				questionDef.QuestionDefNum=Db.NonQ(command,true,"QuestionDefNum","questionDef",paramDescription);
			}
			return questionDef.QuestionDefNum;
		}

		///<summary>Updates one QuestionDef in the database.</summary>
		public static void Update(QuestionDef questionDef) {
			string command="UPDATE questiondef SET "
				+"Description   =  "+DbHelper.ParamChar+"paramDescription, "
				+"ItemOrder     =  "+POut.Int   (questionDef.ItemOrder)+", "
				+"QuestType     =  "+POut.Int   ((int)questionDef.QuestType)+" "
				+"WHERE QuestionDefNum = "+POut.Long(questionDef.QuestionDefNum);
			if(questionDef.Description==null) {
				questionDef.Description="";
			}
			OdSqlParameter paramDescription=new OdSqlParameter("paramDescription",OdDbType.Text,POut.StringParam(questionDef.Description));
			Db.NonQ(command,paramDescription);
		}

		///<summary>Updates one QuestionDef in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(QuestionDef questionDef,QuestionDef oldQuestionDef) {
			string command="";
			if(questionDef.Description != oldQuestionDef.Description) {
				if(command!="") { command+=",";}
				command+="Description = "+DbHelper.ParamChar+"paramDescription";
			}
			if(questionDef.ItemOrder != oldQuestionDef.ItemOrder) {
				if(command!="") { command+=",";}
				command+="ItemOrder = "+POut.Int(questionDef.ItemOrder)+"";
			}
			if(questionDef.QuestType != oldQuestionDef.QuestType) {
				if(command!="") { command+=",";}
				command+="QuestType = "+POut.Int   ((int)questionDef.QuestType)+"";
			}
			if(command=="") {
				return false;
			}
			if(questionDef.Description==null) {
				questionDef.Description="";
			}
			OdSqlParameter paramDescription=new OdSqlParameter("paramDescription",OdDbType.Text,POut.StringParam(questionDef.Description));
			command="UPDATE questiondef SET "+command
				+" WHERE QuestionDefNum = "+POut.Long(questionDef.QuestionDefNum);
			Db.NonQ(command,paramDescription);
			return true;
		}

		///<summary>Returns true if Update(QuestionDef,QuestionDef) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(QuestionDef questionDef,QuestionDef oldQuestionDef) {
			if(questionDef.Description != oldQuestionDef.Description) {
				return true;
			}
			if(questionDef.ItemOrder != oldQuestionDef.ItemOrder) {
				return true;
			}
			if(questionDef.QuestType != oldQuestionDef.QuestType) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one QuestionDef from the database.</summary>
		public static void Delete(long questionDefNum) {
			string command="DELETE FROM questiondef "
				+"WHERE QuestionDefNum = "+POut.Long(questionDefNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many QuestionDefs from the database.</summary>
		public static void DeleteMany(List<long> listQuestionDefNums) {
			if(listQuestionDefNums==null || listQuestionDefNums.Count==0) {
				return;
			}
			string command="DELETE FROM questiondef "
				+"WHERE QuestionDefNum IN("+string.Join(",",listQuestionDefNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}