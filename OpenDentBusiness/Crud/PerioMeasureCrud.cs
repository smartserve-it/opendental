//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OpenDentBusiness.Crud{
	public class PerioMeasureCrud {
		///<summary>Gets one PerioMeasure object from the database using the primary key.  Returns null if not found.</summary>
		public static PerioMeasure SelectOne(long perioMeasureNum) {
			string command="SELECT * FROM periomeasure "
				+"WHERE PerioMeasureNum = "+POut.Long(perioMeasureNum);
			List<PerioMeasure> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one PerioMeasure object from the database using a query.</summary>
		public static PerioMeasure SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<PerioMeasure> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of PerioMeasure objects from the database using a query.</summary>
		public static List<PerioMeasure> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<PerioMeasure> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<PerioMeasure> TableToList(DataTable table) {
			List<PerioMeasure> retVal=new List<PerioMeasure>();
			PerioMeasure perioMeasure;
			foreach(DataRow row in table.Rows) {
				perioMeasure=new PerioMeasure();
				perioMeasure.PerioMeasureNum= PIn.Long  (row["PerioMeasureNum"].ToString());
				perioMeasure.PerioExamNum   = PIn.Long  (row["PerioExamNum"].ToString());
				perioMeasure.SequenceType   = (OpenDentBusiness.PerioSequenceType)PIn.Int(row["SequenceType"].ToString());
				perioMeasure.IntTooth       = PIn.Int   (row["IntTooth"].ToString());
				perioMeasure.ToothValue     = PIn.Int   (row["ToothValue"].ToString());
				perioMeasure.MBvalue        = PIn.Int   (row["MBvalue"].ToString());
				perioMeasure.Bvalue         = PIn.Int   (row["Bvalue"].ToString());
				perioMeasure.DBvalue        = PIn.Int   (row["DBvalue"].ToString());
				perioMeasure.MLvalue        = PIn.Int   (row["MLvalue"].ToString());
				perioMeasure.Lvalue         = PIn.Int   (row["Lvalue"].ToString());
				perioMeasure.DLvalue        = PIn.Int   (row["DLvalue"].ToString());
				perioMeasure.SecDateTEntry  = PIn.DateT (row["SecDateTEntry"].ToString());
				perioMeasure.SecDateTEdit   = PIn.DateT (row["SecDateTEdit"].ToString());
				retVal.Add(perioMeasure);
			}
			return retVal;
		}

		///<summary>Converts a list of PerioMeasure into a DataTable.</summary>
		public static DataTable ListToTable(List<PerioMeasure> listPerioMeasures,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="PerioMeasure";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("PerioMeasureNum");
			table.Columns.Add("PerioExamNum");
			table.Columns.Add("SequenceType");
			table.Columns.Add("IntTooth");
			table.Columns.Add("ToothValue");
			table.Columns.Add("MBvalue");
			table.Columns.Add("Bvalue");
			table.Columns.Add("DBvalue");
			table.Columns.Add("MLvalue");
			table.Columns.Add("Lvalue");
			table.Columns.Add("DLvalue");
			table.Columns.Add("SecDateTEntry");
			table.Columns.Add("SecDateTEdit");
			foreach(PerioMeasure perioMeasure in listPerioMeasures) {
				table.Rows.Add(new object[] {
					POut.Long  (perioMeasure.PerioMeasureNum),
					POut.Long  (perioMeasure.PerioExamNum),
					POut.Int   ((int)perioMeasure.SequenceType),
					POut.Int   (perioMeasure.IntTooth),
					POut.Int   (perioMeasure.ToothValue),
					POut.Int   (perioMeasure.MBvalue),
					POut.Int   (perioMeasure.Bvalue),
					POut.Int   (perioMeasure.DBvalue),
					POut.Int   (perioMeasure.MLvalue),
					POut.Int   (perioMeasure.Lvalue),
					POut.Int   (perioMeasure.DLvalue),
					POut.DateT (perioMeasure.SecDateTEntry,false),
					POut.DateT (perioMeasure.SecDateTEdit,false),
				});
			}
			return table;
		}

		///<summary>Inserts one PerioMeasure into the database.  Returns the new priKey.</summary>
		public static long Insert(PerioMeasure perioMeasure) {
			return Insert(perioMeasure,false);
		}

		///<summary>Inserts one PerioMeasure into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(PerioMeasure perioMeasure,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				perioMeasure.PerioMeasureNum=ReplicationServers.GetKey("periomeasure","PerioMeasureNum");
			}
			string command="INSERT INTO periomeasure (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="PerioMeasureNum,";
			}
			command+="PerioExamNum,SequenceType,IntTooth,ToothValue,MBvalue,Bvalue,DBvalue,MLvalue,Lvalue,DLvalue,SecDateTEntry) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(perioMeasure.PerioMeasureNum)+",";
			}
			command+=
				     POut.Long  (perioMeasure.PerioExamNum)+","
				+    POut.Int   ((int)perioMeasure.SequenceType)+","
				+    POut.Int   (perioMeasure.IntTooth)+","
				+    POut.Int   (perioMeasure.ToothValue)+","
				+    POut.Int   (perioMeasure.MBvalue)+","
				+    POut.Int   (perioMeasure.Bvalue)+","
				+    POut.Int   (perioMeasure.DBvalue)+","
				+    POut.Int   (perioMeasure.MLvalue)+","
				+    POut.Int   (perioMeasure.Lvalue)+","
				+    POut.Int   (perioMeasure.DLvalue)+","
				+    DbHelper.Now()+")";
				//SecDateTEdit can only be set by MySQL
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				perioMeasure.PerioMeasureNum=Db.NonQ(command,true,"PerioMeasureNum","perioMeasure");
			}
			return perioMeasure.PerioMeasureNum;
		}

		///<summary>Inserts many PerioMeasures into the database.</summary>
		public static void InsertMany(List<PerioMeasure> listPerioMeasures) {
			InsertMany(listPerioMeasures,false);
		}

		///<summary>Inserts many PerioMeasures into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<PerioMeasure> listPerioMeasures,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(PerioMeasure perioMeasure in listPerioMeasures) {
					Insert(perioMeasure);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listPerioMeasures.Count) {
					PerioMeasure perioMeasure=listPerioMeasures[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO periomeasure (");
						if(useExistingPK) {
							sbCommands.Append("PerioMeasureNum,");
						}
						sbCommands.Append("PerioExamNum,SequenceType,IntTooth,ToothValue,MBvalue,Bvalue,DBvalue,MLvalue,Lvalue,DLvalue,SecDateTEntry) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(perioMeasure.PerioMeasureNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.Long(perioMeasure.PerioExamNum)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)perioMeasure.SequenceType)); sbRow.Append(",");
					sbRow.Append(POut.Int(perioMeasure.IntTooth)); sbRow.Append(",");
					sbRow.Append(POut.Int(perioMeasure.ToothValue)); sbRow.Append(",");
					sbRow.Append(POut.Int(perioMeasure.MBvalue)); sbRow.Append(",");
					sbRow.Append(POut.Int(perioMeasure.Bvalue)); sbRow.Append(",");
					sbRow.Append(POut.Int(perioMeasure.DBvalue)); sbRow.Append(",");
					sbRow.Append(POut.Int(perioMeasure.MLvalue)); sbRow.Append(",");
					sbRow.Append(POut.Int(perioMeasure.Lvalue)); sbRow.Append(",");
					sbRow.Append(POut.Int(perioMeasure.DLvalue)); sbRow.Append(",");
					sbRow.Append(DbHelper.Now()); sbRow.Append(")");
					//SecDateTEdit can only be set by MySQL
					if(sbCommands.Length+sbRow.Length+1 > TableBase.MaxAllowedPacketCount && countRows > 0) {
						Db.NonQ(sbCommands.ToString());
						sbCommands=null;
					}
					else {
						if(hasComma) {
							sbCommands.Append(",");
						}
						sbCommands.Append(sbRow.ToString());
						countRows++;
						if(index==listPerioMeasures.Count-1) {
							Db.NonQ(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one PerioMeasure into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(PerioMeasure perioMeasure) {
			return InsertNoCache(perioMeasure,false);
		}

		///<summary>Inserts one PerioMeasure into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(PerioMeasure perioMeasure,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO periomeasure (";
			if(!useExistingPK && isRandomKeys) {
				perioMeasure.PerioMeasureNum=ReplicationServers.GetKeyNoCache("periomeasure","PerioMeasureNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="PerioMeasureNum,";
			}
			command+="PerioExamNum,SequenceType,IntTooth,ToothValue,MBvalue,Bvalue,DBvalue,MLvalue,Lvalue,DLvalue,SecDateTEntry) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(perioMeasure.PerioMeasureNum)+",";
			}
			command+=
				     POut.Long  (perioMeasure.PerioExamNum)+","
				+    POut.Int   ((int)perioMeasure.SequenceType)+","
				+    POut.Int   (perioMeasure.IntTooth)+","
				+    POut.Int   (perioMeasure.ToothValue)+","
				+    POut.Int   (perioMeasure.MBvalue)+","
				+    POut.Int   (perioMeasure.Bvalue)+","
				+    POut.Int   (perioMeasure.DBvalue)+","
				+    POut.Int   (perioMeasure.MLvalue)+","
				+    POut.Int   (perioMeasure.Lvalue)+","
				+    POut.Int   (perioMeasure.DLvalue)+","
				+    DbHelper.Now()+")";
				//SecDateTEdit can only be set by MySQL
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				perioMeasure.PerioMeasureNum=Db.NonQ(command,true,"PerioMeasureNum","perioMeasure");
			}
			return perioMeasure.PerioMeasureNum;
		}

		///<summary>Updates one PerioMeasure in the database.</summary>
		public static void Update(PerioMeasure perioMeasure) {
			string command="UPDATE periomeasure SET "
				+"PerioExamNum   =  "+POut.Long  (perioMeasure.PerioExamNum)+", "
				+"SequenceType   =  "+POut.Int   ((int)perioMeasure.SequenceType)+", "
				+"IntTooth       =  "+POut.Int   (perioMeasure.IntTooth)+", "
				+"ToothValue     =  "+POut.Int   (perioMeasure.ToothValue)+", "
				+"MBvalue        =  "+POut.Int   (perioMeasure.MBvalue)+", "
				+"Bvalue         =  "+POut.Int   (perioMeasure.Bvalue)+", "
				+"DBvalue        =  "+POut.Int   (perioMeasure.DBvalue)+", "
				+"MLvalue        =  "+POut.Int   (perioMeasure.MLvalue)+", "
				+"Lvalue         =  "+POut.Int   (perioMeasure.Lvalue)+", "
				+"DLvalue        =  "+POut.Int   (perioMeasure.DLvalue)+" "
				//SecDateTEntry not allowed to change
				//SecDateTEdit can only be set by MySQL
				+"WHERE PerioMeasureNum = "+POut.Long(perioMeasure.PerioMeasureNum);
			Db.NonQ(command);
		}

		///<summary>Updates one PerioMeasure in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(PerioMeasure perioMeasure,PerioMeasure oldPerioMeasure) {
			string command="";
			if(perioMeasure.PerioExamNum != oldPerioMeasure.PerioExamNum) {
				if(command!="") { command+=",";}
				command+="PerioExamNum = "+POut.Long(perioMeasure.PerioExamNum)+"";
			}
			if(perioMeasure.SequenceType != oldPerioMeasure.SequenceType) {
				if(command!="") { command+=",";}
				command+="SequenceType = "+POut.Int   ((int)perioMeasure.SequenceType)+"";
			}
			if(perioMeasure.IntTooth != oldPerioMeasure.IntTooth) {
				if(command!="") { command+=",";}
				command+="IntTooth = "+POut.Int(perioMeasure.IntTooth)+"";
			}
			if(perioMeasure.ToothValue != oldPerioMeasure.ToothValue) {
				if(command!="") { command+=",";}
				command+="ToothValue = "+POut.Int(perioMeasure.ToothValue)+"";
			}
			if(perioMeasure.MBvalue != oldPerioMeasure.MBvalue) {
				if(command!="") { command+=",";}
				command+="MBvalue = "+POut.Int(perioMeasure.MBvalue)+"";
			}
			if(perioMeasure.Bvalue != oldPerioMeasure.Bvalue) {
				if(command!="") { command+=",";}
				command+="Bvalue = "+POut.Int(perioMeasure.Bvalue)+"";
			}
			if(perioMeasure.DBvalue != oldPerioMeasure.DBvalue) {
				if(command!="") { command+=",";}
				command+="DBvalue = "+POut.Int(perioMeasure.DBvalue)+"";
			}
			if(perioMeasure.MLvalue != oldPerioMeasure.MLvalue) {
				if(command!="") { command+=",";}
				command+="MLvalue = "+POut.Int(perioMeasure.MLvalue)+"";
			}
			if(perioMeasure.Lvalue != oldPerioMeasure.Lvalue) {
				if(command!="") { command+=",";}
				command+="Lvalue = "+POut.Int(perioMeasure.Lvalue)+"";
			}
			if(perioMeasure.DLvalue != oldPerioMeasure.DLvalue) {
				if(command!="") { command+=",";}
				command+="DLvalue = "+POut.Int(perioMeasure.DLvalue)+"";
			}
			//SecDateTEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			if(command=="") {
				return false;
			}
			command="UPDATE periomeasure SET "+command
				+" WHERE PerioMeasureNum = "+POut.Long(perioMeasure.PerioMeasureNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(PerioMeasure,PerioMeasure) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(PerioMeasure perioMeasure,PerioMeasure oldPerioMeasure) {
			if(perioMeasure.PerioExamNum != oldPerioMeasure.PerioExamNum) {
				return true;
			}
			if(perioMeasure.SequenceType != oldPerioMeasure.SequenceType) {
				return true;
			}
			if(perioMeasure.IntTooth != oldPerioMeasure.IntTooth) {
				return true;
			}
			if(perioMeasure.ToothValue != oldPerioMeasure.ToothValue) {
				return true;
			}
			if(perioMeasure.MBvalue != oldPerioMeasure.MBvalue) {
				return true;
			}
			if(perioMeasure.Bvalue != oldPerioMeasure.Bvalue) {
				return true;
			}
			if(perioMeasure.DBvalue != oldPerioMeasure.DBvalue) {
				return true;
			}
			if(perioMeasure.MLvalue != oldPerioMeasure.MLvalue) {
				return true;
			}
			if(perioMeasure.Lvalue != oldPerioMeasure.Lvalue) {
				return true;
			}
			if(perioMeasure.DLvalue != oldPerioMeasure.DLvalue) {
				return true;
			}
			//SecDateTEntry not allowed to change
			//SecDateTEdit can only be set by MySQL
			return false;
		}

		///<summary>Deletes one PerioMeasure from the database.</summary>
		public static void Delete(long perioMeasureNum) {
			string command="DELETE FROM periomeasure "
				+"WHERE PerioMeasureNum = "+POut.Long(perioMeasureNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many PerioMeasures from the database.</summary>
		public static void DeleteMany(List<long> listPerioMeasureNums) {
			if(listPerioMeasureNums==null || listPerioMeasureNums.Count==0) {
				return;
			}
			string command="DELETE FROM periomeasure "
				+"WHERE PerioMeasureNum IN("+string.Join(",",listPerioMeasureNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<PerioMeasure> listNew,List<PerioMeasure> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<PerioMeasure> listIns    =new List<PerioMeasure>();
			List<PerioMeasure> listUpdNew =new List<PerioMeasure>();
			List<PerioMeasure> listUpdDB  =new List<PerioMeasure>();
			List<PerioMeasure> listDel    =new List<PerioMeasure>();
			listNew.Sort((PerioMeasure x,PerioMeasure y) => { return x.PerioMeasureNum.CompareTo(y.PerioMeasureNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((PerioMeasure x,PerioMeasure y) => { return x.PerioMeasureNum.CompareTo(y.PerioMeasureNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			PerioMeasure fieldNew;
			PerioMeasure fieldDB;
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
				else if(fieldNew.PerioMeasureNum<fieldDB.PerioMeasureNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.PerioMeasureNum>fieldDB.PerioMeasureNum) {//dbPK less than newPK, dbItem is 'next'
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
			DeleteMany(listDel.Select(x => x.PerioMeasureNum).ToList());
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}