//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class AppointmentTypeCrud {
		///<summary>Gets one AppointmentType object from the database using the primary key.  Returns null if not found.</summary>
		public static AppointmentType SelectOne(long appointmentTypeNum) {
			string command="SELECT * FROM appointmenttype "
				+"WHERE AppointmentTypeNum = "+POut.Long(appointmentTypeNum);
			List<AppointmentType> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one AppointmentType object from the database using a query.</summary>
		public static AppointmentType SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<AppointmentType> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of AppointmentType objects from the database using a query.</summary>
		public static List<AppointmentType> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<AppointmentType> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<AppointmentType> TableToList(DataTable table) {
			List<AppointmentType> retVal=new List<AppointmentType>();
			AppointmentType appointmentType;
			foreach(DataRow row in table.Rows) {
				appointmentType=new AppointmentType();
				appointmentType.AppointmentTypeNum  = PIn.Long  (row["AppointmentTypeNum"].ToString());
				appointmentType.AppointmentTypeName = PIn.String(row["AppointmentTypeName"].ToString());
				appointmentType.AppointmentTypeColor= Color.FromArgb(PIn.Int(row["AppointmentTypeColor"].ToString()));
				appointmentType.ItemOrder           = PIn.Int   (row["ItemOrder"].ToString());
				appointmentType.IsHidden            = PIn.Bool  (row["IsHidden"].ToString());
				appointmentType.Pattern             = PIn.String(row["Pattern"].ToString());
				appointmentType.CodeStr             = PIn.String(row["CodeStr"].ToString());
				retVal.Add(appointmentType);
			}
			return retVal;
		}

		///<summary>Converts a list of AppointmentType into a DataTable.</summary>
		public static DataTable ListToTable(List<AppointmentType> listAppointmentTypes,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="AppointmentType";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("AppointmentTypeNum");
			table.Columns.Add("AppointmentTypeName");
			table.Columns.Add("AppointmentTypeColor");
			table.Columns.Add("ItemOrder");
			table.Columns.Add("IsHidden");
			table.Columns.Add("Pattern");
			table.Columns.Add("CodeStr");
			foreach(AppointmentType appointmentType in listAppointmentTypes) {
				table.Rows.Add(new object[] {
					POut.Long  (appointmentType.AppointmentTypeNum),
					            appointmentType.AppointmentTypeName,
					POut.Int   (appointmentType.AppointmentTypeColor.ToArgb()),
					POut.Int   (appointmentType.ItemOrder),
					POut.Bool  (appointmentType.IsHidden),
					            appointmentType.Pattern,
					            appointmentType.CodeStr,
				});
			}
			return table;
		}

		///<summary>Inserts one AppointmentType into the database.  Returns the new priKey.</summary>
		public static long Insert(AppointmentType appointmentType) {
			return Insert(appointmentType,false);
		}

		///<summary>Inserts one AppointmentType into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(AppointmentType appointmentType,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				appointmentType.AppointmentTypeNum=ReplicationServers.GetKey("appointmenttype","AppointmentTypeNum");
			}
			string command="INSERT INTO appointmenttype (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="AppointmentTypeNum,";
			}
			command+="AppointmentTypeName,AppointmentTypeColor,ItemOrder,IsHidden,Pattern,CodeStr) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(appointmentType.AppointmentTypeNum)+",";
			}
			command+=
				 "'"+POut.String(appointmentType.AppointmentTypeName)+"',"
				+    POut.Int   (appointmentType.AppointmentTypeColor.ToArgb())+","
				+    POut.Int   (appointmentType.ItemOrder)+","
				+    POut.Bool  (appointmentType.IsHidden)+","
				+"'"+POut.String(appointmentType.Pattern)+"',"
				+"'"+POut.String(appointmentType.CodeStr)+"')";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				appointmentType.AppointmentTypeNum=Db.NonQ(command,true,"AppointmentTypeNum","appointmentType");
			}
			return appointmentType.AppointmentTypeNum;
		}

		///<summary>Inserts one AppointmentType into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(AppointmentType appointmentType) {
			return InsertNoCache(appointmentType,false);
		}

		///<summary>Inserts one AppointmentType into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(AppointmentType appointmentType,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO appointmenttype (";
			if(!useExistingPK && isRandomKeys) {
				appointmentType.AppointmentTypeNum=ReplicationServers.GetKeyNoCache("appointmenttype","AppointmentTypeNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="AppointmentTypeNum,";
			}
			command+="AppointmentTypeName,AppointmentTypeColor,ItemOrder,IsHidden,Pattern,CodeStr) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(appointmentType.AppointmentTypeNum)+",";
			}
			command+=
				 "'"+POut.String(appointmentType.AppointmentTypeName)+"',"
				+    POut.Int   (appointmentType.AppointmentTypeColor.ToArgb())+","
				+    POut.Int   (appointmentType.ItemOrder)+","
				+    POut.Bool  (appointmentType.IsHidden)+","
				+"'"+POut.String(appointmentType.Pattern)+"',"
				+"'"+POut.String(appointmentType.CodeStr)+"')";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				appointmentType.AppointmentTypeNum=Db.NonQ(command,true,"AppointmentTypeNum","appointmentType");
			}
			return appointmentType.AppointmentTypeNum;
		}

		///<summary>Updates one AppointmentType in the database.</summary>
		public static void Update(AppointmentType appointmentType) {
			string command="UPDATE appointmenttype SET "
				+"AppointmentTypeName = '"+POut.String(appointmentType.AppointmentTypeName)+"', "
				+"AppointmentTypeColor=  "+POut.Int   (appointmentType.AppointmentTypeColor.ToArgb())+", "
				+"ItemOrder           =  "+POut.Int   (appointmentType.ItemOrder)+", "
				+"IsHidden            =  "+POut.Bool  (appointmentType.IsHidden)+", "
				+"Pattern             = '"+POut.String(appointmentType.Pattern)+"', "
				+"CodeStr             = '"+POut.String(appointmentType.CodeStr)+"' "
				+"WHERE AppointmentTypeNum = "+POut.Long(appointmentType.AppointmentTypeNum);
			Db.NonQ(command);
		}

		///<summary>Updates one AppointmentType in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(AppointmentType appointmentType,AppointmentType oldAppointmentType) {
			string command="";
			if(appointmentType.AppointmentTypeName != oldAppointmentType.AppointmentTypeName) {
				if(command!="") { command+=",";}
				command+="AppointmentTypeName = '"+POut.String(appointmentType.AppointmentTypeName)+"'";
			}
			if(appointmentType.AppointmentTypeColor != oldAppointmentType.AppointmentTypeColor) {
				if(command!="") { command+=",";}
				command+="AppointmentTypeColor = "+POut.Int(appointmentType.AppointmentTypeColor.ToArgb())+"";
			}
			if(appointmentType.ItemOrder != oldAppointmentType.ItemOrder) {
				if(command!="") { command+=",";}
				command+="ItemOrder = "+POut.Int(appointmentType.ItemOrder)+"";
			}
			if(appointmentType.IsHidden != oldAppointmentType.IsHidden) {
				if(command!="") { command+=",";}
				command+="IsHidden = "+POut.Bool(appointmentType.IsHidden)+"";
			}
			if(appointmentType.Pattern != oldAppointmentType.Pattern) {
				if(command!="") { command+=",";}
				command+="Pattern = '"+POut.String(appointmentType.Pattern)+"'";
			}
			if(appointmentType.CodeStr != oldAppointmentType.CodeStr) {
				if(command!="") { command+=",";}
				command+="CodeStr = '"+POut.String(appointmentType.CodeStr)+"'";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE appointmenttype SET "+command
				+" WHERE AppointmentTypeNum = "+POut.Long(appointmentType.AppointmentTypeNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(AppointmentType,AppointmentType) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(AppointmentType appointmentType,AppointmentType oldAppointmentType) {
			if(appointmentType.AppointmentTypeName != oldAppointmentType.AppointmentTypeName) {
				return true;
			}
			if(appointmentType.AppointmentTypeColor != oldAppointmentType.AppointmentTypeColor) {
				return true;
			}
			if(appointmentType.ItemOrder != oldAppointmentType.ItemOrder) {
				return true;
			}
			if(appointmentType.IsHidden != oldAppointmentType.IsHidden) {
				return true;
			}
			if(appointmentType.Pattern != oldAppointmentType.Pattern) {
				return true;
			}
			if(appointmentType.CodeStr != oldAppointmentType.CodeStr) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one AppointmentType from the database.</summary>
		public static void Delete(long appointmentTypeNum) {
			string command="DELETE FROM appointmenttype "
				+"WHERE AppointmentTypeNum = "+POut.Long(appointmentTypeNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many AppointmentTypes from the database.</summary>
		public static void DeleteMany(List<long> listAppointmentTypeNums) {
			if(listAppointmentTypeNums==null || listAppointmentTypeNums.Count==0) {
				return;
			}
			string command="DELETE FROM appointmenttype "
				+"WHERE AppointmentTypeNum IN("+string.Join(",",listAppointmentTypeNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<AppointmentType> listNew,List<AppointmentType> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<AppointmentType> listIns    =new List<AppointmentType>();
			List<AppointmentType> listUpdNew =new List<AppointmentType>();
			List<AppointmentType> listUpdDB  =new List<AppointmentType>();
			List<AppointmentType> listDel    =new List<AppointmentType>();
			listNew.Sort((AppointmentType x,AppointmentType y) => { return x.AppointmentTypeNum.CompareTo(y.AppointmentTypeNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((AppointmentType x,AppointmentType y) => { return x.AppointmentTypeNum.CompareTo(y.AppointmentTypeNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			AppointmentType fieldNew;
			AppointmentType fieldDB;
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
				else if(fieldNew.AppointmentTypeNum<fieldDB.AppointmentTypeNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.AppointmentTypeNum>fieldDB.AppointmentTypeNum) {//dbPK less than newPK, dbItem is 'next'
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
			DeleteMany(listDel.Select(x => x.AppointmentTypeNum).ToList());
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}