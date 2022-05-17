//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class PhoneGraphCrud {
		///<summary>Gets one PhoneGraph object from the database using the primary key.  Returns null if not found.</summary>
		public static PhoneGraph SelectOne(long phoneGraphNum) {
			string command="SELECT * FROM phonegraph "
				+"WHERE PhoneGraphNum = "+POut.Long(phoneGraphNum);
			List<PhoneGraph> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one PhoneGraph object from the database using a query.</summary>
		public static PhoneGraph SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<PhoneGraph> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of PhoneGraph objects from the database using a query.</summary>
		public static List<PhoneGraph> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<PhoneGraph> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<PhoneGraph> TableToList(DataTable table) {
			List<PhoneGraph> retVal=new List<PhoneGraph>();
			PhoneGraph phoneGraph;
			foreach(DataRow row in table.Rows) {
				phoneGraph=new PhoneGraph();
				phoneGraph.PhoneGraphNum = PIn.Long  (row["PhoneGraphNum"].ToString());
				phoneGraph.EmployeeNum   = PIn.Long  (row["EmployeeNum"].ToString());
				phoneGraph.IsGraphed     = PIn.Bool  (row["IsGraphed"].ToString());
				phoneGraph.DateEntry     = PIn.Date  (row["DateEntry"].ToString());
				phoneGraph.DateTimeStart1= PIn.DateT (row["DateTimeStart1"].ToString());
				phoneGraph.DateTimeStop1 = PIn.DateT (row["DateTimeStop1"].ToString());
				phoneGraph.DateTimeStart2= PIn.DateT (row["DateTimeStart2"].ToString());
				phoneGraph.DateTimeStop2 = PIn.DateT (row["DateTimeStop2"].ToString());
				phoneGraph.Note          = PIn.String(row["Note"].ToString());
				phoneGraph.PreSchedOff   = PIn.Bool  (row["PreSchedOff"].ToString());
				phoneGraph.Absent        = PIn.Bool  (row["Absent"].ToString());
				phoneGraph.DailyLimit    = PIn.Int   (row["DailyLimit"].ToString());
				phoneGraph.PreSchedTimes = (OpenDentBusiness.EnumPresched)PIn.Int(row["PreSchedTimes"].ToString());
				retVal.Add(phoneGraph);
			}
			return retVal;
		}

		///<summary>Converts a list of PhoneGraph into a DataTable.</summary>
		public static DataTable ListToTable(List<PhoneGraph> listPhoneGraphs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="PhoneGraph";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("PhoneGraphNum");
			table.Columns.Add("EmployeeNum");
			table.Columns.Add("IsGraphed");
			table.Columns.Add("DateEntry");
			table.Columns.Add("DateTimeStart1");
			table.Columns.Add("DateTimeStop1");
			table.Columns.Add("DateTimeStart2");
			table.Columns.Add("DateTimeStop2");
			table.Columns.Add("Note");
			table.Columns.Add("PreSchedOff");
			table.Columns.Add("Absent");
			table.Columns.Add("DailyLimit");
			table.Columns.Add("PreSchedTimes");
			foreach(PhoneGraph phoneGraph in listPhoneGraphs) {
				table.Rows.Add(new object[] {
					POut.Long  (phoneGraph.PhoneGraphNum),
					POut.Long  (phoneGraph.EmployeeNum),
					POut.Bool  (phoneGraph.IsGraphed),
					POut.DateT (phoneGraph.DateEntry,false),
					POut.DateT (phoneGraph.DateTimeStart1,false),
					POut.DateT (phoneGraph.DateTimeStop1,false),
					POut.DateT (phoneGraph.DateTimeStart2,false),
					POut.DateT (phoneGraph.DateTimeStop2,false),
					            phoneGraph.Note,
					POut.Bool  (phoneGraph.PreSchedOff),
					POut.Bool  (phoneGraph.Absent),
					POut.Int   (phoneGraph.DailyLimit),
					POut.Int   ((int)phoneGraph.PreSchedTimes),
				});
			}
			return table;
		}

		///<summary>Inserts one PhoneGraph into the database.  Returns the new priKey.</summary>
		public static long Insert(PhoneGraph phoneGraph) {
			return Insert(phoneGraph,false);
		}

		///<summary>Inserts one PhoneGraph into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(PhoneGraph phoneGraph,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				phoneGraph.PhoneGraphNum=ReplicationServers.GetKey("phonegraph","PhoneGraphNum");
			}
			string command="INSERT INTO phonegraph (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="PhoneGraphNum,";
			}
			command+="EmployeeNum,IsGraphed,DateEntry,DateTimeStart1,DateTimeStop1,DateTimeStart2,DateTimeStop2,Note,PreSchedOff,Absent,DailyLimit,PreSchedTimes) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(phoneGraph.PhoneGraphNum)+",";
			}
			command+=
				     POut.Long  (phoneGraph.EmployeeNum)+","
				+    POut.Bool  (phoneGraph.IsGraphed)+","
				+    POut.Date  (phoneGraph.DateEntry)+","
				+    POut.DateT (phoneGraph.DateTimeStart1)+","
				+    POut.DateT (phoneGraph.DateTimeStop1)+","
				+    POut.DateT (phoneGraph.DateTimeStart2)+","
				+    POut.DateT (phoneGraph.DateTimeStop2)+","
				+"'"+POut.String(phoneGraph.Note)+"',"
				+    POut.Bool  (phoneGraph.PreSchedOff)+","
				+    POut.Bool  (phoneGraph.Absent)+","
				+    POut.Int   (phoneGraph.DailyLimit)+","
				+    POut.Int   ((int)phoneGraph.PreSchedTimes)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				phoneGraph.PhoneGraphNum=Db.NonQ(command,true,"PhoneGraphNum","phoneGraph");
			}
			return phoneGraph.PhoneGraphNum;
		}

		///<summary>Inserts one PhoneGraph into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(PhoneGraph phoneGraph) {
			return InsertNoCache(phoneGraph,false);
		}

		///<summary>Inserts one PhoneGraph into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(PhoneGraph phoneGraph,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO phonegraph (";
			if(!useExistingPK && isRandomKeys) {
				phoneGraph.PhoneGraphNum=ReplicationServers.GetKeyNoCache("phonegraph","PhoneGraphNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="PhoneGraphNum,";
			}
			command+="EmployeeNum,IsGraphed,DateEntry,DateTimeStart1,DateTimeStop1,DateTimeStart2,DateTimeStop2,Note,PreSchedOff,Absent,DailyLimit,PreSchedTimes) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(phoneGraph.PhoneGraphNum)+",";
			}
			command+=
				     POut.Long  (phoneGraph.EmployeeNum)+","
				+    POut.Bool  (phoneGraph.IsGraphed)+","
				+    POut.Date  (phoneGraph.DateEntry)+","
				+    POut.DateT (phoneGraph.DateTimeStart1)+","
				+    POut.DateT (phoneGraph.DateTimeStop1)+","
				+    POut.DateT (phoneGraph.DateTimeStart2)+","
				+    POut.DateT (phoneGraph.DateTimeStop2)+","
				+"'"+POut.String(phoneGraph.Note)+"',"
				+    POut.Bool  (phoneGraph.PreSchedOff)+","
				+    POut.Bool  (phoneGraph.Absent)+","
				+    POut.Int   (phoneGraph.DailyLimit)+","
				+    POut.Int   ((int)phoneGraph.PreSchedTimes)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				phoneGraph.PhoneGraphNum=Db.NonQ(command,true,"PhoneGraphNum","phoneGraph");
			}
			return phoneGraph.PhoneGraphNum;
		}

		///<summary>Updates one PhoneGraph in the database.</summary>
		public static void Update(PhoneGraph phoneGraph) {
			string command="UPDATE phonegraph SET "
				+"EmployeeNum   =  "+POut.Long  (phoneGraph.EmployeeNum)+", "
				+"IsGraphed     =  "+POut.Bool  (phoneGraph.IsGraphed)+", "
				+"DateEntry     =  "+POut.Date  (phoneGraph.DateEntry)+", "
				+"DateTimeStart1=  "+POut.DateT (phoneGraph.DateTimeStart1)+", "
				+"DateTimeStop1 =  "+POut.DateT (phoneGraph.DateTimeStop1)+", "
				+"DateTimeStart2=  "+POut.DateT (phoneGraph.DateTimeStart2)+", "
				+"DateTimeStop2 =  "+POut.DateT (phoneGraph.DateTimeStop2)+", "
				+"Note          = '"+POut.String(phoneGraph.Note)+"', "
				+"PreSchedOff   =  "+POut.Bool  (phoneGraph.PreSchedOff)+", "
				+"Absent        =  "+POut.Bool  (phoneGraph.Absent)+", "
				+"DailyLimit    =  "+POut.Int   (phoneGraph.DailyLimit)+", "
				+"PreSchedTimes =  "+POut.Int   ((int)phoneGraph.PreSchedTimes)+" "
				+"WHERE PhoneGraphNum = "+POut.Long(phoneGraph.PhoneGraphNum);
			Db.NonQ(command);
		}

		///<summary>Updates one PhoneGraph in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(PhoneGraph phoneGraph,PhoneGraph oldPhoneGraph) {
			string command="";
			if(phoneGraph.EmployeeNum != oldPhoneGraph.EmployeeNum) {
				if(command!="") { command+=",";}
				command+="EmployeeNum = "+POut.Long(phoneGraph.EmployeeNum)+"";
			}
			if(phoneGraph.IsGraphed != oldPhoneGraph.IsGraphed) {
				if(command!="") { command+=",";}
				command+="IsGraphed = "+POut.Bool(phoneGraph.IsGraphed)+"";
			}
			if(phoneGraph.DateEntry.Date != oldPhoneGraph.DateEntry.Date) {
				if(command!="") { command+=",";}
				command+="DateEntry = "+POut.Date(phoneGraph.DateEntry)+"";
			}
			if(phoneGraph.DateTimeStart1 != oldPhoneGraph.DateTimeStart1) {
				if(command!="") { command+=",";}
				command+="DateTimeStart1 = "+POut.DateT(phoneGraph.DateTimeStart1)+"";
			}
			if(phoneGraph.DateTimeStop1 != oldPhoneGraph.DateTimeStop1) {
				if(command!="") { command+=",";}
				command+="DateTimeStop1 = "+POut.DateT(phoneGraph.DateTimeStop1)+"";
			}
			if(phoneGraph.DateTimeStart2 != oldPhoneGraph.DateTimeStart2) {
				if(command!="") { command+=",";}
				command+="DateTimeStart2 = "+POut.DateT(phoneGraph.DateTimeStart2)+"";
			}
			if(phoneGraph.DateTimeStop2 != oldPhoneGraph.DateTimeStop2) {
				if(command!="") { command+=",";}
				command+="DateTimeStop2 = "+POut.DateT(phoneGraph.DateTimeStop2)+"";
			}
			if(phoneGraph.Note != oldPhoneGraph.Note) {
				if(command!="") { command+=",";}
				command+="Note = '"+POut.String(phoneGraph.Note)+"'";
			}
			if(phoneGraph.PreSchedOff != oldPhoneGraph.PreSchedOff) {
				if(command!="") { command+=",";}
				command+="PreSchedOff = "+POut.Bool(phoneGraph.PreSchedOff)+"";
			}
			if(phoneGraph.Absent != oldPhoneGraph.Absent) {
				if(command!="") { command+=",";}
				command+="Absent = "+POut.Bool(phoneGraph.Absent)+"";
			}
			if(phoneGraph.DailyLimit != oldPhoneGraph.DailyLimit) {
				if(command!="") { command+=",";}
				command+="DailyLimit = "+POut.Int(phoneGraph.DailyLimit)+"";
			}
			if(phoneGraph.PreSchedTimes != oldPhoneGraph.PreSchedTimes) {
				if(command!="") { command+=",";}
				command+="PreSchedTimes = "+POut.Int   ((int)phoneGraph.PreSchedTimes)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE phonegraph SET "+command
				+" WHERE PhoneGraphNum = "+POut.Long(phoneGraph.PhoneGraphNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(PhoneGraph,PhoneGraph) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(PhoneGraph phoneGraph,PhoneGraph oldPhoneGraph) {
			if(phoneGraph.EmployeeNum != oldPhoneGraph.EmployeeNum) {
				return true;
			}
			if(phoneGraph.IsGraphed != oldPhoneGraph.IsGraphed) {
				return true;
			}
			if(phoneGraph.DateEntry.Date != oldPhoneGraph.DateEntry.Date) {
				return true;
			}
			if(phoneGraph.DateTimeStart1 != oldPhoneGraph.DateTimeStart1) {
				return true;
			}
			if(phoneGraph.DateTimeStop1 != oldPhoneGraph.DateTimeStop1) {
				return true;
			}
			if(phoneGraph.DateTimeStart2 != oldPhoneGraph.DateTimeStart2) {
				return true;
			}
			if(phoneGraph.DateTimeStop2 != oldPhoneGraph.DateTimeStop2) {
				return true;
			}
			if(phoneGraph.Note != oldPhoneGraph.Note) {
				return true;
			}
			if(phoneGraph.PreSchedOff != oldPhoneGraph.PreSchedOff) {
				return true;
			}
			if(phoneGraph.Absent != oldPhoneGraph.Absent) {
				return true;
			}
			if(phoneGraph.DailyLimit != oldPhoneGraph.DailyLimit) {
				return true;
			}
			if(phoneGraph.PreSchedTimes != oldPhoneGraph.PreSchedTimes) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one PhoneGraph from the database.</summary>
		public static void Delete(long phoneGraphNum) {
			string command="DELETE FROM phonegraph "
				+"WHERE PhoneGraphNum = "+POut.Long(phoneGraphNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many PhoneGraphs from the database.</summary>
		public static void DeleteMany(List<long> listPhoneGraphNums) {
			if(listPhoneGraphNums==null || listPhoneGraphNums.Count==0) {
				return;
			}
			string command="DELETE FROM phonegraph "
				+"WHERE PhoneGraphNum IN("+string.Join(",",listPhoneGraphNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}