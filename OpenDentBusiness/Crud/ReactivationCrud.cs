//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class ReactivationCrud {
		///<summary>Gets one Reactivation object from the database using the primary key.  Returns null if not found.</summary>
		public static Reactivation SelectOne(long reactivationNum) {
			string command="SELECT * FROM reactivation "
				+"WHERE ReactivationNum = "+POut.Long(reactivationNum);
			List<Reactivation> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Reactivation object from the database using a query.</summary>
		public static Reactivation SelectOne(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Reactivation> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Reactivation objects from the database using a query.</summary>
		public static List<Reactivation> SelectMany(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Reactivation> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Reactivation> TableToList(DataTable table) {
			List<Reactivation> retVal=new List<Reactivation>();
			Reactivation reactivation;
			foreach(DataRow row in table.Rows) {
				reactivation=new Reactivation();
				reactivation.ReactivationNum   = PIn.Long  (row["ReactivationNum"].ToString());
				reactivation.PatNum            = PIn.Long  (row["PatNum"].ToString());
				reactivation.ReactivationStatus= PIn.Long  (row["ReactivationStatus"].ToString());
				reactivation.ReactivationNote  = PIn.String(row["ReactivationNote"].ToString());
				reactivation.DoNotContact      = PIn.Bool  (row["DoNotContact"].ToString());
				retVal.Add(reactivation);
			}
			return retVal;
		}

		///<summary>Converts a list of Reactivation into a DataTable.</summary>
		public static DataTable ListToTable(List<Reactivation> listReactivations,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Reactivation";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ReactivationNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("ReactivationStatus");
			table.Columns.Add("ReactivationNote");
			table.Columns.Add("DoNotContact");
			foreach(Reactivation reactivation in listReactivations) {
				table.Rows.Add(new object[] {
					POut.Long  (reactivation.ReactivationNum),
					POut.Long  (reactivation.PatNum),
					POut.Long  (reactivation.ReactivationStatus),
					            reactivation.ReactivationNote,
					POut.Bool  (reactivation.DoNotContact),
				});
			}
			return table;
		}

		///<summary>Inserts one Reactivation into the database.  Returns the new priKey.</summary>
		public static long Insert(Reactivation reactivation) {
			return Insert(reactivation,false);
		}

		///<summary>Inserts one Reactivation into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Reactivation reactivation,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				reactivation.ReactivationNum=ReplicationServers.GetKey("reactivation","ReactivationNum");
			}
			string command="INSERT INTO reactivation (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ReactivationNum,";
			}
			command+="PatNum,ReactivationStatus,ReactivationNote,DoNotContact) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(reactivation.ReactivationNum)+",";
			}
			command+=
				     POut.Long  (reactivation.PatNum)+","
				+    POut.Long  (reactivation.ReactivationStatus)+","
				+    DbHelper.ParamChar+"paramReactivationNote,"
				+    POut.Bool  (reactivation.DoNotContact)+")";
			if(reactivation.ReactivationNote==null) {
				reactivation.ReactivationNote="";
			}
			OdSqlParameter paramReactivationNote=new OdSqlParameter("paramReactivationNote",OdDbType.Text,POut.StringParam(reactivation.ReactivationNote));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramReactivationNote);
			}
			else {
				reactivation.ReactivationNum=Db.NonQ(command,true,"ReactivationNum","reactivation",paramReactivationNote);
			}
			return reactivation.ReactivationNum;
		}

		///<summary>Inserts one Reactivation into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Reactivation reactivation) {
			return InsertNoCache(reactivation,false);
		}

		///<summary>Inserts one Reactivation into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Reactivation reactivation,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO reactivation (";
			if(!useExistingPK && isRandomKeys) {
				reactivation.ReactivationNum=ReplicationServers.GetKeyNoCache("reactivation","ReactivationNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ReactivationNum,";
			}
			command+="PatNum,ReactivationStatus,ReactivationNote,DoNotContact) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(reactivation.ReactivationNum)+",";
			}
			command+=
				     POut.Long  (reactivation.PatNum)+","
				+    POut.Long  (reactivation.ReactivationStatus)+","
				+    DbHelper.ParamChar+"paramReactivationNote,"
				+    POut.Bool  (reactivation.DoNotContact)+")";
			if(reactivation.ReactivationNote==null) {
				reactivation.ReactivationNote="";
			}
			OdSqlParameter paramReactivationNote=new OdSqlParameter("paramReactivationNote",OdDbType.Text,POut.StringParam(reactivation.ReactivationNote));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramReactivationNote);
			}
			else {
				reactivation.ReactivationNum=Db.NonQ(command,true,"ReactivationNum","reactivation",paramReactivationNote);
			}
			return reactivation.ReactivationNum;
		}

		///<summary>Updates one Reactivation in the database.</summary>
		public static void Update(Reactivation reactivation) {
			string command="UPDATE reactivation SET "
				+"PatNum            =  "+POut.Long  (reactivation.PatNum)+", "
				+"ReactivationStatus=  "+POut.Long  (reactivation.ReactivationStatus)+", "
				+"ReactivationNote  =  "+DbHelper.ParamChar+"paramReactivationNote, "
				+"DoNotContact      =  "+POut.Bool  (reactivation.DoNotContact)+" "
				+"WHERE ReactivationNum = "+POut.Long(reactivation.ReactivationNum);
			if(reactivation.ReactivationNote==null) {
				reactivation.ReactivationNote="";
			}
			OdSqlParameter paramReactivationNote=new OdSqlParameter("paramReactivationNote",OdDbType.Text,POut.StringParam(reactivation.ReactivationNote));
			Db.NonQ(command,paramReactivationNote);
		}

		///<summary>Updates one Reactivation in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Reactivation reactivation,Reactivation oldReactivation) {
			string command="";
			if(reactivation.PatNum != oldReactivation.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(reactivation.PatNum)+"";
			}
			if(reactivation.ReactivationStatus != oldReactivation.ReactivationStatus) {
				if(command!="") { command+=",";}
				command+="ReactivationStatus = "+POut.Long(reactivation.ReactivationStatus)+"";
			}
			if(reactivation.ReactivationNote != oldReactivation.ReactivationNote) {
				if(command!="") { command+=",";}
				command+="ReactivationNote = "+DbHelper.ParamChar+"paramReactivationNote";
			}
			if(reactivation.DoNotContact != oldReactivation.DoNotContact) {
				if(command!="") { command+=",";}
				command+="DoNotContact = "+POut.Bool(reactivation.DoNotContact)+"";
			}
			if(command=="") {
				return false;
			}
			if(reactivation.ReactivationNote==null) {
				reactivation.ReactivationNote="";
			}
			OdSqlParameter paramReactivationNote=new OdSqlParameter("paramReactivationNote",OdDbType.Text,POut.StringParam(reactivation.ReactivationNote));
			command="UPDATE reactivation SET "+command
				+" WHERE ReactivationNum = "+POut.Long(reactivation.ReactivationNum);
			Db.NonQ(command,paramReactivationNote);
			return true;
		}

		///<summary>Returns true if Update(Reactivation,Reactivation) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Reactivation reactivation,Reactivation oldReactivation) {
			if(reactivation.PatNum != oldReactivation.PatNum) {
				return true;
			}
			if(reactivation.ReactivationStatus != oldReactivation.ReactivationStatus) {
				return true;
			}
			if(reactivation.ReactivationNote != oldReactivation.ReactivationNote) {
				return true;
			}
			if(reactivation.DoNotContact != oldReactivation.DoNotContact) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one Reactivation from the database.</summary>
		public static void Delete(long reactivationNum) {
			string command="DELETE FROM reactivation "
				+"WHERE ReactivationNum = "+POut.Long(reactivationNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many Reactivations from the database.</summary>
		public static void DeleteMany(List<long> listReactivationNums) {
			if(listReactivationNums==null || listReactivationNums.Count==0) {
				return;
			}
			string command="DELETE FROM reactivation "
				+"WHERE ReactivationNum IN("+string.Join(",",listReactivationNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}