//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class GroupPermissionCrud {
		///<summary>Gets one GroupPermission object from the database using the primary key.  Returns null if not found.</summary>
		public static GroupPermission SelectOne(long groupPermNum) {
			string command="SELECT * FROM grouppermission "
				+"WHERE GroupPermNum = "+POut.Long(groupPermNum);
			List<GroupPermission> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one GroupPermission object from the database using a query.</summary>
		public static GroupPermission SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<GroupPermission> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of GroupPermission objects from the database using a query.</summary>
		public static List<GroupPermission> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<GroupPermission> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<GroupPermission> TableToList(DataTable table) {
			List<GroupPermission> retVal=new List<GroupPermission>();
			GroupPermission groupPermission;
			foreach(DataRow row in table.Rows) {
				groupPermission=new GroupPermission();
				groupPermission.GroupPermNum= PIn.Long  (row["GroupPermNum"].ToString());
				groupPermission.NewerDate   = PIn.Date  (row["NewerDate"].ToString());
				groupPermission.NewerDays   = PIn.Int   (row["NewerDays"].ToString());
				groupPermission.UserGroupNum= PIn.Long  (row["UserGroupNum"].ToString());
				groupPermission.PermType    = (OpenDentBusiness.Permissions)PIn.Int(row["PermType"].ToString());
				groupPermission.FKey        = PIn.Long  (row["FKey"].ToString());
				retVal.Add(groupPermission);
			}
			return retVal;
		}

		///<summary>Converts a list of GroupPermission into a DataTable.</summary>
		public static DataTable ListToTable(List<GroupPermission> listGroupPermissions,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="GroupPermission";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("GroupPermNum");
			table.Columns.Add("NewerDate");
			table.Columns.Add("NewerDays");
			table.Columns.Add("UserGroupNum");
			table.Columns.Add("PermType");
			table.Columns.Add("FKey");
			foreach(GroupPermission groupPermission in listGroupPermissions) {
				table.Rows.Add(new object[] {
					POut.Long  (groupPermission.GroupPermNum),
					POut.DateT (groupPermission.NewerDate,false),
					POut.Int   (groupPermission.NewerDays),
					POut.Long  (groupPermission.UserGroupNum),
					POut.Int   ((int)groupPermission.PermType),
					POut.Long  (groupPermission.FKey),
				});
			}
			return table;
		}

		///<summary>Inserts one GroupPermission into the database.  Returns the new priKey.</summary>
		public static long Insert(GroupPermission groupPermission) {
			return Insert(groupPermission,false);
		}

		///<summary>Inserts one GroupPermission into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(GroupPermission groupPermission,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				groupPermission.GroupPermNum=ReplicationServers.GetKey("grouppermission","GroupPermNum");
			}
			string command="INSERT INTO grouppermission (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="GroupPermNum,";
			}
			command+="NewerDate,NewerDays,UserGroupNum,PermType,FKey) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(groupPermission.GroupPermNum)+",";
			}
			command+=
				     POut.Date  (groupPermission.NewerDate)+","
				+    POut.Int   (groupPermission.NewerDays)+","
				+    POut.Long  (groupPermission.UserGroupNum)+","
				+    POut.Int   ((int)groupPermission.PermType)+","
				+    POut.Long  (groupPermission.FKey)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				groupPermission.GroupPermNum=Db.NonQ(command,true,"GroupPermNum","groupPermission");
			}
			return groupPermission.GroupPermNum;
		}

		///<summary>Inserts one GroupPermission into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(GroupPermission groupPermission) {
			return InsertNoCache(groupPermission,false);
		}

		///<summary>Inserts one GroupPermission into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(GroupPermission groupPermission,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO grouppermission (";
			if(!useExistingPK && isRandomKeys) {
				groupPermission.GroupPermNum=ReplicationServers.GetKeyNoCache("grouppermission","GroupPermNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="GroupPermNum,";
			}
			command+="NewerDate,NewerDays,UserGroupNum,PermType,FKey) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(groupPermission.GroupPermNum)+",";
			}
			command+=
				     POut.Date  (groupPermission.NewerDate)+","
				+    POut.Int   (groupPermission.NewerDays)+","
				+    POut.Long  (groupPermission.UserGroupNum)+","
				+    POut.Int   ((int)groupPermission.PermType)+","
				+    POut.Long  (groupPermission.FKey)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				groupPermission.GroupPermNum=Db.NonQ(command,true,"GroupPermNum","groupPermission");
			}
			return groupPermission.GroupPermNum;
		}

		///<summary>Updates one GroupPermission in the database.</summary>
		public static void Update(GroupPermission groupPermission) {
			string command="UPDATE grouppermission SET "
				+"NewerDate   =  "+POut.Date  (groupPermission.NewerDate)+", "
				+"NewerDays   =  "+POut.Int   (groupPermission.NewerDays)+", "
				+"UserGroupNum=  "+POut.Long  (groupPermission.UserGroupNum)+", "
				+"PermType    =  "+POut.Int   ((int)groupPermission.PermType)+", "
				+"FKey        =  "+POut.Long  (groupPermission.FKey)+" "
				+"WHERE GroupPermNum = "+POut.Long(groupPermission.GroupPermNum);
			Db.NonQ(command);
		}

		///<summary>Updates one GroupPermission in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(GroupPermission groupPermission,GroupPermission oldGroupPermission) {
			string command="";
			if(groupPermission.NewerDate.Date != oldGroupPermission.NewerDate.Date) {
				if(command!="") { command+=",";}
				command+="NewerDate = "+POut.Date(groupPermission.NewerDate)+"";
			}
			if(groupPermission.NewerDays != oldGroupPermission.NewerDays) {
				if(command!="") { command+=",";}
				command+="NewerDays = "+POut.Int(groupPermission.NewerDays)+"";
			}
			if(groupPermission.UserGroupNum != oldGroupPermission.UserGroupNum) {
				if(command!="") { command+=",";}
				command+="UserGroupNum = "+POut.Long(groupPermission.UserGroupNum)+"";
			}
			if(groupPermission.PermType != oldGroupPermission.PermType) {
				if(command!="") { command+=",";}
				command+="PermType = "+POut.Int   ((int)groupPermission.PermType)+"";
			}
			if(groupPermission.FKey != oldGroupPermission.FKey) {
				if(command!="") { command+=",";}
				command+="FKey = "+POut.Long(groupPermission.FKey)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE grouppermission SET "+command
				+" WHERE GroupPermNum = "+POut.Long(groupPermission.GroupPermNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(GroupPermission,GroupPermission) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(GroupPermission groupPermission,GroupPermission oldGroupPermission) {
			if(groupPermission.NewerDate.Date != oldGroupPermission.NewerDate.Date) {
				return true;
			}
			if(groupPermission.NewerDays != oldGroupPermission.NewerDays) {
				return true;
			}
			if(groupPermission.UserGroupNum != oldGroupPermission.UserGroupNum) {
				return true;
			}
			if(groupPermission.PermType != oldGroupPermission.PermType) {
				return true;
			}
			if(groupPermission.FKey != oldGroupPermission.FKey) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one GroupPermission from the database.</summary>
		public static void Delete(long groupPermNum) {
			string command="DELETE FROM grouppermission "
				+"WHERE GroupPermNum = "+POut.Long(groupPermNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many GroupPermissions from the database.</summary>
		public static void DeleteMany(List<long> listGroupPermNums) {
			if(listGroupPermNums==null || listGroupPermNums.Count==0) {
				return;
			}
			string command="DELETE FROM grouppermission "
				+"WHERE GroupPermNum IN("+string.Join(",",listGroupPermNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<GroupPermission> listNew,List<GroupPermission> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<GroupPermission> listIns    =new List<GroupPermission>();
			List<GroupPermission> listUpdNew =new List<GroupPermission>();
			List<GroupPermission> listUpdDB  =new List<GroupPermission>();
			List<GroupPermission> listDel    =new List<GroupPermission>();
			listNew.Sort((GroupPermission x,GroupPermission y) => { return x.GroupPermNum.CompareTo(y.GroupPermNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((GroupPermission x,GroupPermission y) => { return x.GroupPermNum.CompareTo(y.GroupPermNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			GroupPermission fieldNew;
			GroupPermission fieldDB;
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
				else if(fieldNew.GroupPermNum<fieldDB.GroupPermNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.GroupPermNum>fieldDB.GroupPermNum) {//dbPK less than newPK, dbItem is 'next'
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
			DeleteMany(listDel.Select(x => x.GroupPermNum).ToList());
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}