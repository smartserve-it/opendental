//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class OrthoHardwareCrud {
		///<summary>Gets one OrthoHardware object from the database using the primary key.  Returns null if not found.</summary>
		public static OrthoHardware SelectOne(long orthoHardwareNum) {
			string command="SELECT * FROM orthohardware "
				+"WHERE OrthoHardwareNum = "+POut.Long(orthoHardwareNum);
			List<OrthoHardware> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one OrthoHardware object from the database using a query.</summary>
		public static OrthoHardware SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<OrthoHardware> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of OrthoHardware objects from the database using a query.</summary>
		public static List<OrthoHardware> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<OrthoHardware> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<OrthoHardware> TableToList(DataTable table) {
			List<OrthoHardware> retVal=new List<OrthoHardware>();
			OrthoHardware orthoHardware;
			foreach(DataRow row in table.Rows) {
				orthoHardware=new OrthoHardware();
				orthoHardware.OrthoHardwareNum    = PIn.Long  (row["OrthoHardwareNum"].ToString());
				orthoHardware.PatNum              = PIn.Long  (row["PatNum"].ToString());
				orthoHardware.DateExam            = PIn.Date  (row["DateExam"].ToString());
				orthoHardware.OrthoHardwareType   = (OpenDentBusiness.EnumOrthoHardwareType)PIn.Int(row["OrthoHardwareType"].ToString());
				orthoHardware.OrthoHardwareSpecNum= PIn.Long  (row["OrthoHardwareSpecNum"].ToString());
				orthoHardware.ToothRange          = PIn.String(row["ToothRange"].ToString());
				orthoHardware.Note                = PIn.String(row["Note"].ToString());
				retVal.Add(orthoHardware);
			}
			return retVal;
		}

		///<summary>Converts a list of OrthoHardware into a DataTable.</summary>
		public static DataTable ListToTable(List<OrthoHardware> listOrthoHardwares,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="OrthoHardware";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("OrthoHardwareNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("DateExam");
			table.Columns.Add("OrthoHardwareType");
			table.Columns.Add("OrthoHardwareSpecNum");
			table.Columns.Add("ToothRange");
			table.Columns.Add("Note");
			foreach(OrthoHardware orthoHardware in listOrthoHardwares) {
				table.Rows.Add(new object[] {
					POut.Long  (orthoHardware.OrthoHardwareNum),
					POut.Long  (orthoHardware.PatNum),
					POut.DateT (orthoHardware.DateExam,false),
					POut.Int   ((int)orthoHardware.OrthoHardwareType),
					POut.Long  (orthoHardware.OrthoHardwareSpecNum),
					            orthoHardware.ToothRange,
					            orthoHardware.Note,
				});
			}
			return table;
		}

		///<summary>Inserts one OrthoHardware into the database.  Returns the new priKey.</summary>
		public static long Insert(OrthoHardware orthoHardware) {
			return Insert(orthoHardware,false);
		}

		///<summary>Inserts one OrthoHardware into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(OrthoHardware orthoHardware,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				orthoHardware.OrthoHardwareNum=ReplicationServers.GetKey("orthohardware","OrthoHardwareNum");
			}
			string command="INSERT INTO orthohardware (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="OrthoHardwareNum,";
			}
			command+="PatNum,DateExam,OrthoHardwareType,OrthoHardwareSpecNum,ToothRange,Note) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(orthoHardware.OrthoHardwareNum)+",";
			}
			command+=
				     POut.Long  (orthoHardware.PatNum)+","
				+    POut.Date  (orthoHardware.DateExam)+","
				+    POut.Int   ((int)orthoHardware.OrthoHardwareType)+","
				+    POut.Long  (orthoHardware.OrthoHardwareSpecNum)+","
				+"'"+POut.String(orthoHardware.ToothRange)+"',"
				+"'"+POut.String(orthoHardware.Note)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				orthoHardware.OrthoHardwareNum=Db.NonQ(command,true,"OrthoHardwareNum","orthoHardware");
			}
			return orthoHardware.OrthoHardwareNum;
		}

		///<summary>Inserts one OrthoHardware into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(OrthoHardware orthoHardware) {
			return InsertNoCache(orthoHardware,false);
		}

		///<summary>Inserts one OrthoHardware into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(OrthoHardware orthoHardware,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO orthohardware (";
			if(!useExistingPK && isRandomKeys) {
				orthoHardware.OrthoHardwareNum=ReplicationServers.GetKeyNoCache("orthohardware","OrthoHardwareNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="OrthoHardwareNum,";
			}
			command+="PatNum,DateExam,OrthoHardwareType,OrthoHardwareSpecNum,ToothRange,Note) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(orthoHardware.OrthoHardwareNum)+",";
			}
			command+=
				     POut.Long  (orthoHardware.PatNum)+","
				+    POut.Date  (orthoHardware.DateExam)+","
				+    POut.Int   ((int)orthoHardware.OrthoHardwareType)+","
				+    POut.Long  (orthoHardware.OrthoHardwareSpecNum)+","
				+"'"+POut.String(orthoHardware.ToothRange)+"',"
				+"'"+POut.String(orthoHardware.Note)+"')";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				orthoHardware.OrthoHardwareNum=Db.NonQ(command,true,"OrthoHardwareNum","orthoHardware");
			}
			return orthoHardware.OrthoHardwareNum;
		}

		///<summary>Updates one OrthoHardware in the database.</summary>
		public static void Update(OrthoHardware orthoHardware) {
			string command="UPDATE orthohardware SET "
				+"PatNum              =  "+POut.Long  (orthoHardware.PatNum)+", "
				+"DateExam            =  "+POut.Date  (orthoHardware.DateExam)+", "
				+"OrthoHardwareType   =  "+POut.Int   ((int)orthoHardware.OrthoHardwareType)+", "
				+"OrthoHardwareSpecNum=  "+POut.Long  (orthoHardware.OrthoHardwareSpecNum)+", "
				+"ToothRange          = '"+POut.String(orthoHardware.ToothRange)+"', "
				+"Note                = '"+POut.String(orthoHardware.Note)+"' "
				+"WHERE OrthoHardwareNum = "+POut.Long(orthoHardware.OrthoHardwareNum);
			Db.NonQ(command);
		}

		///<summary>Updates one OrthoHardware in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(OrthoHardware orthoHardware,OrthoHardware oldOrthoHardware) {
			string command="";
			if(orthoHardware.PatNum != oldOrthoHardware.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(orthoHardware.PatNum)+"";
			}
			if(orthoHardware.DateExam.Date != oldOrthoHardware.DateExam.Date) {
				if(command!="") { command+=",";}
				command+="DateExam = "+POut.Date(orthoHardware.DateExam)+"";
			}
			if(orthoHardware.OrthoHardwareType != oldOrthoHardware.OrthoHardwareType) {
				if(command!="") { command+=",";}
				command+="OrthoHardwareType = "+POut.Int   ((int)orthoHardware.OrthoHardwareType)+"";
			}
			if(orthoHardware.OrthoHardwareSpecNum != oldOrthoHardware.OrthoHardwareSpecNum) {
				if(command!="") { command+=",";}
				command+="OrthoHardwareSpecNum = "+POut.Long(orthoHardware.OrthoHardwareSpecNum)+"";
			}
			if(orthoHardware.ToothRange != oldOrthoHardware.ToothRange) {
				if(command!="") { command+=",";}
				command+="ToothRange = '"+POut.String(orthoHardware.ToothRange)+"'";
			}
			if(orthoHardware.Note != oldOrthoHardware.Note) {
				if(command!="") { command+=",";}
				command+="Note = '"+POut.String(orthoHardware.Note)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE orthohardware SET "+command
				+" WHERE OrthoHardwareNum = "+POut.Long(orthoHardware.OrthoHardwareNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(OrthoHardware,OrthoHardware) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(OrthoHardware orthoHardware,OrthoHardware oldOrthoHardware) {
			if(orthoHardware.PatNum != oldOrthoHardware.PatNum) {
				return true;
			}
			if(orthoHardware.DateExam.Date != oldOrthoHardware.DateExam.Date) {
				return true;
			}
			if(orthoHardware.OrthoHardwareType != oldOrthoHardware.OrthoHardwareType) {
				return true;
			}
			if(orthoHardware.OrthoHardwareSpecNum != oldOrthoHardware.OrthoHardwareSpecNum) {
				return true;
			}
			if(orthoHardware.ToothRange != oldOrthoHardware.ToothRange) {
				return true;
			}
			if(orthoHardware.Note != oldOrthoHardware.Note) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one OrthoHardware from the database.</summary>
		public static void Delete(long orthoHardwareNum) {
			string command="DELETE FROM orthohardware "
				+"WHERE OrthoHardwareNum = "+POut.Long(orthoHardwareNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many OrthoHardwares from the database.</summary>
		public static void DeleteMany(List<long> listOrthoHardwareNums) {
			if(listOrthoHardwareNums==null || listOrthoHardwareNums.Count==0) {
				return;
			}
			string command="DELETE FROM orthohardware "
				+"WHERE OrthoHardwareNum IN("+string.Join(",",listOrthoHardwareNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}