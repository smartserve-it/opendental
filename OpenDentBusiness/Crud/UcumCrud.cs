//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class UcumCrud {
		///<summary>Gets one Ucum object from the database using the primary key.  Returns null if not found.</summary>
		public static Ucum SelectOne(long ucumNum) {
			string command="SELECT * FROM ucum "
				+"WHERE UcumNum = "+POut.Long(ucumNum);
			List<Ucum> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Ucum object from the database using a query.</summary>
		public static Ucum SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Ucum> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Ucum objects from the database using a query.</summary>
		public static List<Ucum> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Ucum> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<Ucum> TableToList(DataTable table) {
			List<Ucum> retVal=new List<Ucum>();
			Ucum ucum;
			foreach(DataRow row in table.Rows) {
				ucum=new Ucum();
				ucum.UcumNum    = PIn.Long  (row["UcumNum"].ToString());
				ucum.UcumCode   = PIn.String(row["UcumCode"].ToString());
				ucum.Description= PIn.String(row["Description"].ToString());
				ucum.IsInUse    = PIn.Bool  (row["IsInUse"].ToString());
				retVal.Add(ucum);
			}
			return retVal;
		}

		///<summary>Converts a list of Ucum into a DataTable.</summary>
		public static DataTable ListToTable(List<Ucum> listUcums,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="Ucum";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("UcumNum");
			table.Columns.Add("UcumCode");
			table.Columns.Add("Description");
			table.Columns.Add("IsInUse");
			foreach(Ucum ucum in listUcums) {
				table.Rows.Add(new object[] {
					POut.Long  (ucum.UcumNum),
					            ucum.UcumCode,
					            ucum.Description,
					POut.Bool  (ucum.IsInUse),
				});
			}
			return table;
		}

		///<summary>Inserts one Ucum into the database.  Returns the new priKey.</summary>
		public static long Insert(Ucum ucum) {
			return Insert(ucum,false);
		}

		///<summary>Inserts one Ucum into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(Ucum ucum,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				ucum.UcumNum=ReplicationServers.GetKey("ucum","UcumNum");
			}
			string command="INSERT INTO ucum (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="UcumNum,";
			}
			command+="UcumCode,Description,IsInUse) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(ucum.UcumNum)+",";
			}
			command+=
				 "'"+POut.String(ucum.UcumCode)+"',"
				+"'"+POut.String(ucum.Description)+"',"
				+    POut.Bool  (ucum.IsInUse)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				ucum.UcumNum=Db.NonQ(command,true,"UcumNum","ucum");
			}
			return ucum.UcumNum;
		}

		///<summary>Inserts one Ucum into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Ucum ucum) {
			return InsertNoCache(ucum,false);
		}

		///<summary>Inserts one Ucum into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(Ucum ucum,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO ucum (";
			if(!useExistingPK && isRandomKeys) {
				ucum.UcumNum=ReplicationServers.GetKeyNoCache("ucum","UcumNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="UcumNum,";
			}
			command+="UcumCode,Description,IsInUse) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(ucum.UcumNum)+",";
			}
			command+=
				 "'"+POut.String(ucum.UcumCode)+"',"
				+"'"+POut.String(ucum.Description)+"',"
				+    POut.Bool  (ucum.IsInUse)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				ucum.UcumNum=Db.NonQ(command,true,"UcumNum","ucum");
			}
			return ucum.UcumNum;
		}

		///<summary>Updates one Ucum in the database.</summary>
		public static void Update(Ucum ucum) {
			string command="UPDATE ucum SET "
				+"UcumCode   = '"+POut.String(ucum.UcumCode)+"', "
				+"Description= '"+POut.String(ucum.Description)+"', "
				+"IsInUse    =  "+POut.Bool  (ucum.IsInUse)+" "
				+"WHERE UcumNum = "+POut.Long(ucum.UcumNum);
			Db.NonQ(command);
		}

		///<summary>Updates one Ucum in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(Ucum ucum,Ucum oldUcum) {
			string command="";
			if(ucum.UcumCode != oldUcum.UcumCode) {
				if(command!="") { command+=",";}
				command+="UcumCode = '"+POut.String(ucum.UcumCode)+"'";
			}
			if(ucum.Description != oldUcum.Description) {
				if(command!="") { command+=",";}
				command+="Description = '"+POut.String(ucum.Description)+"'";
			}
			if(ucum.IsInUse != oldUcum.IsInUse) {
				if(command!="") { command+=",";}
				command+="IsInUse = "+POut.Bool(ucum.IsInUse)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE ucum SET "+command
				+" WHERE UcumNum = "+POut.Long(ucum.UcumNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(Ucum,Ucum) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(Ucum ucum,Ucum oldUcum) {
			if(ucum.UcumCode != oldUcum.UcumCode) {
				return true;
			}
			if(ucum.Description != oldUcum.Description) {
				return true;
			}
			if(ucum.IsInUse != oldUcum.IsInUse) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one Ucum from the database.</summary>
		public static void Delete(long ucumNum) {
			string command="DELETE FROM ucum "
				+"WHERE UcumNum = "+POut.Long(ucumNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many Ucums from the database.</summary>
		public static void DeleteMany(List<long> listUcumNums) {
			if(listUcumNums==null || listUcumNums.Count==0) {
				return;
			}
			string command="DELETE FROM ucum "
				+"WHERE UcumNum IN("+string.Join(",",listUcumNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}