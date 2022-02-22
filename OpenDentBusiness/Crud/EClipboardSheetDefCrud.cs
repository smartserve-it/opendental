//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class EClipboardSheetDefCrud {
		///<summary>Gets one EClipboardSheetDef object from the database using the primary key.  Returns null if not found.</summary>
		public static EClipboardSheetDef SelectOne(long eClipboardSheetDefNum) {
			string command="SELECT * FROM eclipboardsheetdef "
				+"WHERE EClipboardSheetDefNum = "+POut.Long(eClipboardSheetDefNum);
			List<EClipboardSheetDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EClipboardSheetDef object from the database using a query.</summary>
		public static EClipboardSheetDef SelectOne(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EClipboardSheetDef> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EClipboardSheetDef objects from the database using a query.</summary>
		public static List<EClipboardSheetDef> SelectMany(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EClipboardSheetDef> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EClipboardSheetDef> TableToList(DataTable table) {
			List<EClipboardSheetDef> retVal=new List<EClipboardSheetDef>();
			EClipboardSheetDef eClipboardSheetDef;
			foreach(DataRow row in table.Rows) {
				eClipboardSheetDef=new EClipboardSheetDef();
				eClipboardSheetDef.EClipboardSheetDefNum= PIn.Long  (row["EClipboardSheetDefNum"].ToString());
				eClipboardSheetDef.SheetDefNum          = PIn.Long  (row["SheetDefNum"].ToString());
				eClipboardSheetDef.ClinicNum            = PIn.Long  (row["ClinicNum"].ToString());
				eClipboardSheetDef.ResubmitInterval     = TimeSpan.FromTicks(PIn.Long(row["ResubmitInterval"].ToString()));
				eClipboardSheetDef.ItemOrder            = PIn.Int   (row["ItemOrder"].ToString());
				eClipboardSheetDef.PrefillStatus        = (PrefillStatuses)PIn.Int(row["PrefillStatus"].ToString());
				eClipboardSheetDef.MinAge               = PIn.Int   (row["MinAge"].ToString());
				eClipboardSheetDef.MaxAge               = PIn.Int   (row["MaxAge"].ToString());
				eClipboardSheetDef.IgnoreSheetDefNums   = PIn.String(row["IgnoreSheetDefNums"].ToString());
				eClipboardSheetDef.PrefillStatusOverride= PIn.Long  (row["PrefillStatusOverride"].ToString());
				retVal.Add(eClipboardSheetDef);
			}
			return retVal;
		}

		///<summary>Converts a list of EClipboardSheetDef into a DataTable.</summary>
		public static DataTable ListToTable(List<EClipboardSheetDef> listEClipboardSheetDefs,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="EClipboardSheetDef";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("EClipboardSheetDefNum");
			table.Columns.Add("SheetDefNum");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("ResubmitInterval");
			table.Columns.Add("ItemOrder");
			table.Columns.Add("PrefillStatus");
			table.Columns.Add("MinAge");
			table.Columns.Add("MaxAge");
			table.Columns.Add("IgnoreSheetDefNums");
			table.Columns.Add("PrefillStatusOverride");
			foreach(EClipboardSheetDef eClipboardSheetDef in listEClipboardSheetDefs) {
				table.Rows.Add(new object[] {
					POut.Long  (eClipboardSheetDef.EClipboardSheetDefNum),
					POut.Long  (eClipboardSheetDef.SheetDefNum),
					POut.Long  (eClipboardSheetDef.ClinicNum),
					POut.Long (eClipboardSheetDef.ResubmitInterval.Ticks),
					POut.Int   (eClipboardSheetDef.ItemOrder),
					POut.Int   ((int)eClipboardSheetDef.PrefillStatus),
					POut.Int   (eClipboardSheetDef.MinAge),
					POut.Int   (eClipboardSheetDef.MaxAge),
					            eClipboardSheetDef.IgnoreSheetDefNums,
					POut.Long  (eClipboardSheetDef.PrefillStatusOverride),
				});
			}
			return table;
		}

		///<summary>Inserts one EClipboardSheetDef into the database.  Returns the new priKey.</summary>
		public static long Insert(EClipboardSheetDef eClipboardSheetDef) {
			return Insert(eClipboardSheetDef,false);
		}

		///<summary>Inserts one EClipboardSheetDef into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EClipboardSheetDef eClipboardSheetDef,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				eClipboardSheetDef.EClipboardSheetDefNum=ReplicationServers.GetKey("eclipboardsheetdef","EClipboardSheetDefNum");
			}
			string command="INSERT INTO eclipboardsheetdef (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EClipboardSheetDefNum,";
			}
			command+="SheetDefNum,ClinicNum,ResubmitInterval,ItemOrder,PrefillStatus,MinAge,MaxAge,IgnoreSheetDefNums,PrefillStatusOverride) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(eClipboardSheetDef.EClipboardSheetDefNum)+",";
			}
			command+=
				     POut.Long  (eClipboardSheetDef.SheetDefNum)+","
				+    POut.Long  (eClipboardSheetDef.ClinicNum)+","
				+"'"+POut.Long  (eClipboardSheetDef.ResubmitInterval.Ticks)+"',"
				+    POut.Int   (eClipboardSheetDef.ItemOrder)+","
				+    POut.Int   ((int)eClipboardSheetDef.PrefillStatus)+","
				+    POut.Int   (eClipboardSheetDef.MinAge)+","
				+    POut.Int   (eClipboardSheetDef.MaxAge)+","
				+    DbHelper.ParamChar+"paramIgnoreSheetDefNums,"
				+    POut.Long  (eClipboardSheetDef.PrefillStatusOverride)+")";
			if(eClipboardSheetDef.IgnoreSheetDefNums==null) {
				eClipboardSheetDef.IgnoreSheetDefNums="";
			}
			OdSqlParameter paramIgnoreSheetDefNums=new OdSqlParameter("paramIgnoreSheetDefNums",OdDbType.Text,POut.StringParam(eClipboardSheetDef.IgnoreSheetDefNums));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramIgnoreSheetDefNums);
			}
			else {
				eClipboardSheetDef.EClipboardSheetDefNum=Db.NonQ(command,true,"EClipboardSheetDefNum","eClipboardSheetDef",paramIgnoreSheetDefNums);
			}
			return eClipboardSheetDef.EClipboardSheetDefNum;
		}

		///<summary>Inserts one EClipboardSheetDef into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EClipboardSheetDef eClipboardSheetDef) {
			return InsertNoCache(eClipboardSheetDef,false);
		}

		///<summary>Inserts one EClipboardSheetDef into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EClipboardSheetDef eClipboardSheetDef,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO eclipboardsheetdef (";
			if(!useExistingPK && isRandomKeys) {
				eClipboardSheetDef.EClipboardSheetDefNum=ReplicationServers.GetKeyNoCache("eclipboardsheetdef","EClipboardSheetDefNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="EClipboardSheetDefNum,";
			}
			command+="SheetDefNum,ClinicNum,ResubmitInterval,ItemOrder,PrefillStatus,MinAge,MaxAge,IgnoreSheetDefNums,PrefillStatusOverride) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(eClipboardSheetDef.EClipboardSheetDefNum)+",";
			}
			command+=
				     POut.Long  (eClipboardSheetDef.SheetDefNum)+","
				+    POut.Long  (eClipboardSheetDef.ClinicNum)+","
				+"'"+POut.Long(eClipboardSheetDef.ResubmitInterval.Ticks)+"',"
				+    POut.Int   (eClipboardSheetDef.ItemOrder)+","
				+    POut.Int   ((int)eClipboardSheetDef.PrefillStatus)+","
				+    POut.Int   (eClipboardSheetDef.MinAge)+","
				+    POut.Int   (eClipboardSheetDef.MaxAge)+","
				+    DbHelper.ParamChar+"paramIgnoreSheetDefNums,"
				+    POut.Long  (eClipboardSheetDef.PrefillStatusOverride)+")";
			if(eClipboardSheetDef.IgnoreSheetDefNums==null) {
				eClipboardSheetDef.IgnoreSheetDefNums="";
			}
			OdSqlParameter paramIgnoreSheetDefNums=new OdSqlParameter("paramIgnoreSheetDefNums",OdDbType.Text,POut.StringParam(eClipboardSheetDef.IgnoreSheetDefNums));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramIgnoreSheetDefNums);
			}
			else {
				eClipboardSheetDef.EClipboardSheetDefNum=Db.NonQ(command,true,"EClipboardSheetDefNum","eClipboardSheetDef",paramIgnoreSheetDefNums);
			}
			return eClipboardSheetDef.EClipboardSheetDefNum;
		}

		///<summary>Updates one EClipboardSheetDef in the database.</summary>
		public static void Update(EClipboardSheetDef eClipboardSheetDef) {
			string command="UPDATE eclipboardsheetdef SET "
				+"SheetDefNum          =  "+POut.Long  (eClipboardSheetDef.SheetDefNum)+", "
				+"ClinicNum            =  "+POut.Long  (eClipboardSheetDef.ClinicNum)+", "
				+"ResubmitInterval     =  "+POut.Long  (eClipboardSheetDef.ResubmitInterval.Ticks)+", "
				+"ItemOrder            =  "+POut.Int   (eClipboardSheetDef.ItemOrder)+", "
				+"PrefillStatus        =  "+POut.Int   ((int)eClipboardSheetDef.PrefillStatus)+", "
				+"MinAge               =  "+POut.Int   (eClipboardSheetDef.MinAge)+", "
				+"MaxAge               =  "+POut.Int   (eClipboardSheetDef.MaxAge)+", "
				+"IgnoreSheetDefNums   =  "+DbHelper.ParamChar+"paramIgnoreSheetDefNums, "
				+"PrefillStatusOverride=  "+POut.Long  (eClipboardSheetDef.PrefillStatusOverride)+" "
				+"WHERE EClipboardSheetDefNum = "+POut.Long(eClipboardSheetDef.EClipboardSheetDefNum);
			if(eClipboardSheetDef.IgnoreSheetDefNums==null) {
				eClipboardSheetDef.IgnoreSheetDefNums="";
			}
			OdSqlParameter paramIgnoreSheetDefNums=new OdSqlParameter("paramIgnoreSheetDefNums",OdDbType.Text,POut.StringParam(eClipboardSheetDef.IgnoreSheetDefNums));
			Db.NonQ(command,paramIgnoreSheetDefNums);
		}

		///<summary>Updates one EClipboardSheetDef in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EClipboardSheetDef eClipboardSheetDef,EClipboardSheetDef oldEClipboardSheetDef) {
			string command="";
			if(eClipboardSheetDef.SheetDefNum != oldEClipboardSheetDef.SheetDefNum) {
				if(command!="") { command+=",";}
				command+="SheetDefNum = "+POut.Long(eClipboardSheetDef.SheetDefNum)+"";
			}
			if(eClipboardSheetDef.ClinicNum != oldEClipboardSheetDef.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(eClipboardSheetDef.ClinicNum)+"";
			}
			if(eClipboardSheetDef.ResubmitInterval != oldEClipboardSheetDef.ResubmitInterval) {
				if(command!="") { command+=",";}
				command+="ResubmitInterval = '"+POut.Long  (eClipboardSheetDef.ResubmitInterval.Ticks)+"'";
			}
			if(eClipboardSheetDef.ItemOrder != oldEClipboardSheetDef.ItemOrder) {
				if(command!="") { command+=",";}
				command+="ItemOrder = "+POut.Int(eClipboardSheetDef.ItemOrder)+"";
			}
			if(eClipboardSheetDef.PrefillStatus != oldEClipboardSheetDef.PrefillStatus) {
				if(command!="") { command+=",";}
				command+="PrefillStatus = "+POut.Int   ((int)eClipboardSheetDef.PrefillStatus)+"";
			}
			if(eClipboardSheetDef.MinAge != oldEClipboardSheetDef.MinAge) {
				if(command!="") { command+=",";}
				command+="MinAge = "+POut.Int(eClipboardSheetDef.MinAge)+"";
			}
			if(eClipboardSheetDef.MaxAge != oldEClipboardSheetDef.MaxAge) {
				if(command!="") { command+=",";}
				command+="MaxAge = "+POut.Int(eClipboardSheetDef.MaxAge)+"";
			}
			if(eClipboardSheetDef.IgnoreSheetDefNums != oldEClipboardSheetDef.IgnoreSheetDefNums) {
				if(command!="") { command+=",";}
				command+="IgnoreSheetDefNums = "+DbHelper.ParamChar+"paramIgnoreSheetDefNums";
			}
			if(eClipboardSheetDef.PrefillStatusOverride != oldEClipboardSheetDef.PrefillStatusOverride) {
				if(command!="") { command+=",";}
				command+="PrefillStatusOverride = "+POut.Long(eClipboardSheetDef.PrefillStatusOverride)+"";
			}
			if(command=="") {
				return false;
			}
			if(eClipboardSheetDef.IgnoreSheetDefNums==null) {
				eClipboardSheetDef.IgnoreSheetDefNums="";
			}
			OdSqlParameter paramIgnoreSheetDefNums=new OdSqlParameter("paramIgnoreSheetDefNums",OdDbType.Text,POut.StringParam(eClipboardSheetDef.IgnoreSheetDefNums));
			command="UPDATE eclipboardsheetdef SET "+command
				+" WHERE EClipboardSheetDefNum = "+POut.Long(eClipboardSheetDef.EClipboardSheetDefNum);
			Db.NonQ(command,paramIgnoreSheetDefNums);
			return true;
		}

		///<summary>Returns true if Update(EClipboardSheetDef,EClipboardSheetDef) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(EClipboardSheetDef eClipboardSheetDef,EClipboardSheetDef oldEClipboardSheetDef) {
			if(eClipboardSheetDef.SheetDefNum != oldEClipboardSheetDef.SheetDefNum) {
				return true;
			}
			if(eClipboardSheetDef.ClinicNum != oldEClipboardSheetDef.ClinicNum) {
				return true;
			}
			if(eClipboardSheetDef.ResubmitInterval != oldEClipboardSheetDef.ResubmitInterval) {
				return true;
			}
			if(eClipboardSheetDef.ItemOrder != oldEClipboardSheetDef.ItemOrder) {
				return true;
			}
			if(eClipboardSheetDef.PrefillStatus != oldEClipboardSheetDef.PrefillStatus) {
				return true;
			}
			if(eClipboardSheetDef.MinAge != oldEClipboardSheetDef.MinAge) {
				return true;
			}
			if(eClipboardSheetDef.MaxAge != oldEClipboardSheetDef.MaxAge) {
				return true;
			}
			if(eClipboardSheetDef.IgnoreSheetDefNums != oldEClipboardSheetDef.IgnoreSheetDefNums) {
				return true;
			}
			if(eClipboardSheetDef.PrefillStatusOverride != oldEClipboardSheetDef.PrefillStatusOverride) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one EClipboardSheetDef from the database.</summary>
		public static void Delete(long eClipboardSheetDefNum) {
			string command="DELETE FROM eclipboardsheetdef "
				+"WHERE EClipboardSheetDefNum = "+POut.Long(eClipboardSheetDefNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many EClipboardSheetDefs from the database.</summary>
		public static void DeleteMany(List<long> listEClipboardSheetDefNums) {
			if(listEClipboardSheetDefNums==null || listEClipboardSheetDefNums.Count==0) {
				return;
			}
			string command="DELETE FROM eclipboardsheetdef "
				+"WHERE EClipboardSheetDefNum IN("+string.Join(",",listEClipboardSheetDefNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<EClipboardSheetDef> listNew,List<EClipboardSheetDef> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<EClipboardSheetDef> listIns    =new List<EClipboardSheetDef>();
			List<EClipboardSheetDef> listUpdNew =new List<EClipboardSheetDef>();
			List<EClipboardSheetDef> listUpdDB  =new List<EClipboardSheetDef>();
			List<EClipboardSheetDef> listDel    =new List<EClipboardSheetDef>();
			listNew.Sort((EClipboardSheetDef x,EClipboardSheetDef y) => { return x.EClipboardSheetDefNum.CompareTo(y.EClipboardSheetDefNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((EClipboardSheetDef x,EClipboardSheetDef y) => { return x.EClipboardSheetDefNum.CompareTo(y.EClipboardSheetDefNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			EClipboardSheetDef fieldNew;
			EClipboardSheetDef fieldDB;
			//Because both lists have been sorted using the same criteria, we can now walk each list to determine which list contians the next element.  The next element is determined by Primary Key.
			//If the New list contains the next item it will be inserted.  If the DB contains the next item, it will be deleted.  If both lists contain the next item, the item will be updated.
			while(idxNew<listNew.Count || idxDB<listDB.Count) {
				fieldNew=null;
				if(idxNew<listNew.Count) {
					fieldNew=listNew[idxNew];
				}
				fieldDB=null;
				if(idxDB<listDB.Count) {
					fieldDB=listDB[idxDB];
				}
				//begin compare
				if(fieldNew!=null && fieldDB==null) {//listNew has more items, listDB does not.
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew==null && fieldDB!=null) {//listDB has more items, listNew does not.
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				else if(fieldNew.EClipboardSheetDefNum<fieldDB.EClipboardSheetDefNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.EClipboardSheetDefNum>fieldDB.EClipboardSheetDefNum) {//dbPK less than newPK, dbItem is 'next'
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				//Both lists contain the 'next' item, update required
				listUpdNew.Add(fieldNew);
				listUpdDB.Add(fieldDB);
				idxNew++;
				idxDB++;
			}
			//Commit changes to DB
			for(int i=0;i<listIns.Count;i++) {
				Insert(listIns[i]);
			}
			for(int i=0;i<listUpdNew.Count;i++) {
				if(Update(listUpdNew[i],listUpdDB[i])) {
					rowsUpdatedCount++;
				}
			}
			DeleteMany(listDel.Select(x => x.EClipboardSheetDefNum).ToList());
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}