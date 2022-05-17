//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class DiseaseCrud {
		///<summary>Gets one Disease object from the database using the primary key.  Returns null if not found.</summary>
		public static Disease SelectOne(long diseaseNum) {
			string command="SELECT * FROM disease "
				+"WHERE DiseaseNum = "+POut.Long(diseaseNum);
			List<Disease> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Disease object from the database using a query.</summary>
		public static Disease SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Disease> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Disease objects from the database using a query.</summary>
		public static List<Disease> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Disease> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Disease> TableToList(DataTable table) {
			List<Disease> retVal=new List<Disease>();
			Disease disease;
			foreach(DataRow row in table.Rows) {
				disease=new Disease();
				disease.DiseaseNum       = PIn.Long  (row["DiseaseNum"].ToString());
				disease.PatNum           = PIn.Long  (row["PatNum"].ToString());
				disease.DiseaseDefNum    = PIn.Long  (row["DiseaseDefNum"].ToString());
				disease.PatNote          = PIn.String(row["PatNote"].ToString());
				disease.DateTStamp       = PIn.DateT (row["DateTStamp"].ToString());
				disease.ProbStatus       = (OpenDentBusiness.ProblemStatus)PIn.Int(row["ProbStatus"].ToString());
				disease.DateStart        = PIn.Date  (row["DateStart"].ToString());
				disease.DateStop         = PIn.Date  (row["DateStop"].ToString());
				disease.SnomedProblemType= PIn.String(row["SnomedProblemType"].ToString());
				disease.FunctionStatus   = (OpenDentBusiness.FunctionalStatus)PIn.Int(row["FunctionStatus"].ToString());
				retVal.Add(disease);
			}
			return retVal;
		}

		///<summary>Converts a list of Disease into a DataTable.</summary>
		public static DataTable ListToTable(List<Disease> listDiseases,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Disease";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("DiseaseNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("DiseaseDefNum");
			table.Columns.Add("PatNote");
			table.Columns.Add("DateTStamp");
			table.Columns.Add("ProbStatus");
			table.Columns.Add("DateStart");
			table.Columns.Add("DateStop");
			table.Columns.Add("SnomedProblemType");
			table.Columns.Add("FunctionStatus");
			foreach(Disease disease in listDiseases) {
				table.Rows.Add(new object[] {
					POut.Long  (disease.DiseaseNum),
					POut.Long  (disease.PatNum),
					POut.Long  (disease.DiseaseDefNum),
					            disease.PatNote,
					POut.DateT (disease.DateTStamp,false),
					POut.Int   ((int)disease.ProbStatus),
					POut.DateT (disease.DateStart,false),
					POut.DateT (disease.DateStop,false),
					            disease.SnomedProblemType,
					POut.Int   ((int)disease.FunctionStatus),
				});
			}
			return table;
		}

		///<summary>Inserts one Disease into the database.  Returns the new priKey.</summary>
		public static long Insert(Disease disease) {
			return Insert(disease,false);
		}

		///<summary>Inserts one Disease into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Disease disease,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				disease.DiseaseNum=ReplicationServers.GetKey("disease","DiseaseNum");
			}
			string command="INSERT INTO disease (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="DiseaseNum,";
			}
			command+="PatNum,DiseaseDefNum,PatNote,ProbStatus,DateStart,DateStop,SnomedProblemType,FunctionStatus) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(disease.DiseaseNum)+",";
			}
			command+=
				     POut.Long  (disease.PatNum)+","
				+    POut.Long  (disease.DiseaseDefNum)+","
				+    DbHelper.ParamChar+"paramPatNote,"
				//DateTStamp can only be set by MySQL
				+    POut.Int   ((int)disease.ProbStatus)+","
				+    POut.Date  (disease.DateStart)+","
				+    POut.Date  (disease.DateStop)+","
				+"'"+POut.String(disease.SnomedProblemType)+"',"
				+    POut.Int   ((int)disease.FunctionStatus)+")";
			if(disease.PatNote==null) {
				disease.PatNote="";
			}
			OdSqlParameter paramPatNote=new OdSqlParameter("paramPatNote",OdDbType.Text,POut.StringParam(disease.PatNote));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramPatNote);
			}
			else {
				disease.DiseaseNum=Db.NonQ(command,true,"DiseaseNum","disease",paramPatNote);
			}
			return disease.DiseaseNum;
		}

		///<summary>Inserts one Disease into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Disease disease) {
			return InsertNoCache(disease,false);
		}

		///<summary>Inserts one Disease into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Disease disease,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO disease (";
			if(!useExistingPK && isRandomKeys) {
				disease.DiseaseNum=ReplicationServers.GetKeyNoCache("disease","DiseaseNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="DiseaseNum,";
			}
			command+="PatNum,DiseaseDefNum,PatNote,ProbStatus,DateStart,DateStop,SnomedProblemType,FunctionStatus) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(disease.DiseaseNum)+",";
			}
			command+=
				     POut.Long  (disease.PatNum)+","
				+    POut.Long  (disease.DiseaseDefNum)+","
				+    DbHelper.ParamChar+"paramPatNote,"
				//DateTStamp can only be set by MySQL
				+    POut.Int   ((int)disease.ProbStatus)+","
				+    POut.Date  (disease.DateStart)+","
				+    POut.Date  (disease.DateStop)+","
				+"'"+POut.String(disease.SnomedProblemType)+"',"
				+    POut.Int   ((int)disease.FunctionStatus)+")";
			if(disease.PatNote==null) {
				disease.PatNote="";
			}
			OdSqlParameter paramPatNote=new OdSqlParameter("paramPatNote",OdDbType.Text,POut.StringParam(disease.PatNote));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramPatNote);
			}
			else {
				disease.DiseaseNum=Db.NonQ(command,true,"DiseaseNum","disease",paramPatNote);
			}
			return disease.DiseaseNum;
		}

		///<summary>Updates one Disease in the database.</summary>
		public static void Update(Disease disease) {
			string command="UPDATE disease SET "
				+"PatNum           =  "+POut.Long  (disease.PatNum)+", "
				+"DiseaseDefNum    =  "+POut.Long  (disease.DiseaseDefNum)+", "
				+"PatNote          =  "+DbHelper.ParamChar+"paramPatNote, "
				//DateTStamp can only be set by MySQL
				+"ProbStatus       =  "+POut.Int   ((int)disease.ProbStatus)+", "
				+"DateStart        =  "+POut.Date  (disease.DateStart)+", "
				+"DateStop         =  "+POut.Date  (disease.DateStop)+", "
				+"SnomedProblemType= '"+POut.String(disease.SnomedProblemType)+"', "
				+"FunctionStatus   =  "+POut.Int   ((int)disease.FunctionStatus)+" "
				+"WHERE DiseaseNum = "+POut.Long(disease.DiseaseNum);
			if(disease.PatNote==null) {
				disease.PatNote="";
			}
			OdSqlParameter paramPatNote=new OdSqlParameter("paramPatNote",OdDbType.Text,POut.StringParam(disease.PatNote));
			Db.NonQ(command,paramPatNote);
		}

		///<summary>Updates one Disease in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Disease disease,Disease oldDisease) {
			string command="";
			if(disease.PatNum != oldDisease.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(disease.PatNum)+"";
			}
			if(disease.DiseaseDefNum != oldDisease.DiseaseDefNum) {
				if(command!="") { command+=",";}
				command+="DiseaseDefNum = "+POut.Long(disease.DiseaseDefNum)+"";
			}
			if(disease.PatNote != oldDisease.PatNote) {
				if(command!="") { command+=",";}
				command+="PatNote = "+DbHelper.ParamChar+"paramPatNote";
			}
			//DateTStamp can only be set by MySQL
			if(disease.ProbStatus != oldDisease.ProbStatus) {
				if(command!="") { command+=",";}
				command+="ProbStatus = "+POut.Int   ((int)disease.ProbStatus)+"";
			}
			if(disease.DateStart.Date != oldDisease.DateStart.Date) {
				if(command!="") { command+=",";}
				command+="DateStart = "+POut.Date(disease.DateStart)+"";
			}
			if(disease.DateStop.Date != oldDisease.DateStop.Date) {
				if(command!="") { command+=",";}
				command+="DateStop = "+POut.Date(disease.DateStop)+"";
			}
			if(disease.SnomedProblemType != oldDisease.SnomedProblemType) {
				if(command!="") { command+=",";}
				command+="SnomedProblemType = '"+POut.String(disease.SnomedProblemType)+"'";
			}
			if(disease.FunctionStatus != oldDisease.FunctionStatus) {
				if(command!="") { command+=",";}
				command+="FunctionStatus = "+POut.Int   ((int)disease.FunctionStatus)+"";
			}
			if(command=="") {
				return false;
			}
			if(disease.PatNote==null) {
				disease.PatNote="";
			}
			OdSqlParameter paramPatNote=new OdSqlParameter("paramPatNote",OdDbType.Text,POut.StringParam(disease.PatNote));
			command="UPDATE disease SET "+command
				+" WHERE DiseaseNum = "+POut.Long(disease.DiseaseNum);
			Db.NonQ(command,paramPatNote);
			return true;
		}

		///<summary>Returns true if Update(Disease,Disease) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Disease disease,Disease oldDisease) {
			if(disease.PatNum != oldDisease.PatNum) {
				return true;
			}
			if(disease.DiseaseDefNum != oldDisease.DiseaseDefNum) {
				return true;
			}
			if(disease.PatNote != oldDisease.PatNote) {
				return true;
			}
			//DateTStamp can only be set by MySQL
			if(disease.ProbStatus != oldDisease.ProbStatus) {
				return true;
			}
			if(disease.DateStart.Date != oldDisease.DateStart.Date) {
				return true;
			}
			if(disease.DateStop.Date != oldDisease.DateStop.Date) {
				return true;
			}
			if(disease.SnomedProblemType != oldDisease.SnomedProblemType) {
				return true;
			}
			if(disease.FunctionStatus != oldDisease.FunctionStatus) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one Disease from the database.</summary>
		public static void Delete(long diseaseNum) {
			string command="DELETE FROM disease "
				+"WHERE DiseaseNum = "+POut.Long(diseaseNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many Diseases from the database.</summary>
		public static void DeleteMany(List<long> listDiseaseNums) {
			if(listDiseaseNums==null || listDiseaseNums.Count==0) {
				return;
			}
			string command="DELETE FROM disease "
				+"WHERE DiseaseNum IN("+string.Join(",",listDiseaseNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}