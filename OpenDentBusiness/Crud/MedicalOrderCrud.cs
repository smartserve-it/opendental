//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class MedicalOrderCrud {
		///<summary>Gets one MedicalOrder object from the database using the primary key.  Returns null if not found.</summary>
		public static MedicalOrder SelectOne(long medicalOrderNum) {
			string command="SELECT * FROM medicalorder "
				+"WHERE MedicalOrderNum = "+POut.Long(medicalOrderNum);
			List<MedicalOrder> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one MedicalOrder object from the database using a query.</summary>
		public static MedicalOrder SelectOne(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<MedicalOrder> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of MedicalOrder objects from the database using a query.</summary>
		public static List<MedicalOrder> SelectMany(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<MedicalOrder> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<MedicalOrder> TableToList(DataTable table) {
			List<MedicalOrder> retVal=new List<MedicalOrder>();
			MedicalOrder medicalOrder;
			foreach(DataRow row in table.Rows) {
				medicalOrder=new MedicalOrder();
				medicalOrder.MedicalOrderNum= PIn.Long  (row["MedicalOrderNum"].ToString());
				medicalOrder.MedOrderType   = (OpenDentBusiness.MedicalOrderType)PIn.Int(row["MedOrderType"].ToString());
				medicalOrder.PatNum         = PIn.Long  (row["PatNum"].ToString());
				medicalOrder.DateTimeOrder  = PIn.DateT (row["DateTimeOrder"].ToString());
				medicalOrder.Description    = PIn.String(row["Description"].ToString());
				medicalOrder.IsDiscontinued = PIn.Bool  (row["IsDiscontinued"].ToString());
				medicalOrder.ProvNum        = PIn.Long  (row["ProvNum"].ToString());
				retVal.Add(medicalOrder);
			}
			return retVal;
		}

		///<summary>Converts a list of MedicalOrder into a DataTable.</summary>
		public static DataTable ListToTable(List<MedicalOrder> listMedicalOrders,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="MedicalOrder";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("MedicalOrderNum");
			table.Columns.Add("MedOrderType");
			table.Columns.Add("PatNum");
			table.Columns.Add("DateTimeOrder");
			table.Columns.Add("Description");
			table.Columns.Add("IsDiscontinued");
			table.Columns.Add("ProvNum");
			foreach(MedicalOrder medicalOrder in listMedicalOrders) {
				table.Rows.Add(new object[] {
					POut.Long  (medicalOrder.MedicalOrderNum),
					POut.Int   ((int)medicalOrder.MedOrderType),
					POut.Long  (medicalOrder.PatNum),
					POut.DateT (medicalOrder.DateTimeOrder,false),
					            medicalOrder.Description,
					POut.Bool  (medicalOrder.IsDiscontinued),
					POut.Long  (medicalOrder.ProvNum),
				});
			}
			return table;
		}

		///<summary>Inserts one MedicalOrder into the database.  Returns the new priKey.</summary>
		public static long Insert(MedicalOrder medicalOrder) {
			return Insert(medicalOrder,false);
		}

		///<summary>Inserts one MedicalOrder into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(MedicalOrder medicalOrder,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				medicalOrder.MedicalOrderNum=ReplicationServers.GetKey("medicalorder","MedicalOrderNum");
			}
			string command="INSERT INTO medicalorder (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="MedicalOrderNum,";
			}
			command+="MedOrderType,PatNum,DateTimeOrder,Description,IsDiscontinued,ProvNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(medicalOrder.MedicalOrderNum)+",";
			}
			command+=
				     POut.Int   ((int)medicalOrder.MedOrderType)+","
				+    POut.Long  (medicalOrder.PatNum)+","
				+    POut.DateT (medicalOrder.DateTimeOrder)+","
				+"'"+POut.String(medicalOrder.Description)+"',"
				+    POut.Bool  (medicalOrder.IsDiscontinued)+","
				+    POut.Long  (medicalOrder.ProvNum)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				medicalOrder.MedicalOrderNum=Db.NonQ(command,true,"MedicalOrderNum","medicalOrder");
			}
			return medicalOrder.MedicalOrderNum;
		}

		///<summary>Inserts one MedicalOrder into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(MedicalOrder medicalOrder) {
			return InsertNoCache(medicalOrder,false);
		}

		///<summary>Inserts one MedicalOrder into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(MedicalOrder medicalOrder,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO medicalorder (";
			if(!useExistingPK && isRandomKeys) {
				medicalOrder.MedicalOrderNum=ReplicationServers.GetKeyNoCache("medicalorder","MedicalOrderNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="MedicalOrderNum,";
			}
			command+="MedOrderType,PatNum,DateTimeOrder,Description,IsDiscontinued,ProvNum) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(medicalOrder.MedicalOrderNum)+",";
			}
			command+=
				     POut.Int   ((int)medicalOrder.MedOrderType)+","
				+    POut.Long  (medicalOrder.PatNum)+","
				+    POut.DateT (medicalOrder.DateTimeOrder)+","
				+"'"+POut.String(medicalOrder.Description)+"',"
				+    POut.Bool  (medicalOrder.IsDiscontinued)+","
				+    POut.Long  (medicalOrder.ProvNum)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				medicalOrder.MedicalOrderNum=Db.NonQ(command,true,"MedicalOrderNum","medicalOrder");
			}
			return medicalOrder.MedicalOrderNum;
		}

		///<summary>Updates one MedicalOrder in the database.</summary>
		public static void Update(MedicalOrder medicalOrder) {
			string command="UPDATE medicalorder SET "
				+"MedOrderType   =  "+POut.Int   ((int)medicalOrder.MedOrderType)+", "
				+"PatNum         =  "+POut.Long  (medicalOrder.PatNum)+", "
				+"DateTimeOrder  =  "+POut.DateT (medicalOrder.DateTimeOrder)+", "
				+"Description    = '"+POut.String(medicalOrder.Description)+"', "
				+"IsDiscontinued =  "+POut.Bool  (medicalOrder.IsDiscontinued)+", "
				+"ProvNum        =  "+POut.Long  (medicalOrder.ProvNum)+" "
				+"WHERE MedicalOrderNum = "+POut.Long(medicalOrder.MedicalOrderNum);
			Db.NonQ(command);
		}

		///<summary>Updates one MedicalOrder in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(MedicalOrder medicalOrder,MedicalOrder oldMedicalOrder) {
			string command="";
			if(medicalOrder.MedOrderType != oldMedicalOrder.MedOrderType) {
				if(command!="") { command+=",";}
				command+="MedOrderType = "+POut.Int   ((int)medicalOrder.MedOrderType)+"";
			}
			if(medicalOrder.PatNum != oldMedicalOrder.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(medicalOrder.PatNum)+"";
			}
			if(medicalOrder.DateTimeOrder != oldMedicalOrder.DateTimeOrder) {
				if(command!="") { command+=",";}
				command+="DateTimeOrder = "+POut.DateT(medicalOrder.DateTimeOrder)+"";
			}
			if(medicalOrder.Description != oldMedicalOrder.Description) {
				if(command!="") { command+=",";}
				command+="Description = '"+POut.String(medicalOrder.Description)+"'";
			}
			if(medicalOrder.IsDiscontinued != oldMedicalOrder.IsDiscontinued) {
				if(command!="") { command+=",";}
				command+="IsDiscontinued = "+POut.Bool(medicalOrder.IsDiscontinued)+"";
			}
			if(medicalOrder.ProvNum != oldMedicalOrder.ProvNum) {
				if(command!="") { command+=",";}
				command+="ProvNum = "+POut.Long(medicalOrder.ProvNum)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE medicalorder SET "+command
				+" WHERE MedicalOrderNum = "+POut.Long(medicalOrder.MedicalOrderNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(MedicalOrder,MedicalOrder) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(MedicalOrder medicalOrder,MedicalOrder oldMedicalOrder) {
			if(medicalOrder.MedOrderType != oldMedicalOrder.MedOrderType) {
				return true;
			}
			if(medicalOrder.PatNum != oldMedicalOrder.PatNum) {
				return true;
			}
			if(medicalOrder.DateTimeOrder != oldMedicalOrder.DateTimeOrder) {
				return true;
			}
			if(medicalOrder.Description != oldMedicalOrder.Description) {
				return true;
			}
			if(medicalOrder.IsDiscontinued != oldMedicalOrder.IsDiscontinued) {
				return true;
			}
			if(medicalOrder.ProvNum != oldMedicalOrder.ProvNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one MedicalOrder from the database.</summary>
		public static void Delete(long medicalOrderNum) {
			string command="DELETE FROM medicalorder "
				+"WHERE MedicalOrderNum = "+POut.Long(medicalOrderNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many MedicalOrders from the database.</summary>
		public static void DeleteMany(List<long> listMedicalOrderNums) {
			if(listMedicalOrderNums==null || listMedicalOrderNums.Count==0) {
				return;
			}
			string command="DELETE FROM medicalorder "
				+"WHERE MedicalOrderNum IN("+string.Join(",",listMedicalOrderNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}