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
	public class ApptGeneralMessageSentCrud {
		///<summary>Gets one ApptGeneralMessageSent object from the database using the primary key.  Returns null if not found.</summary>
		public static ApptGeneralMessageSent SelectOne(long apptGeneralMessageSentNum) {
			string command="SELECT * FROM apptgeneralmessagesent "
				+"WHERE ApptGeneralMessageSentNum = "+POut.Long(apptGeneralMessageSentNum);
			List<ApptGeneralMessageSent> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ApptGeneralMessageSent object from the database using a query.</summary>
		public static ApptGeneralMessageSent SelectOne(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ApptGeneralMessageSent> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ApptGeneralMessageSent objects from the database using a query.</summary>
		public static List<ApptGeneralMessageSent> SelectMany(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ApptGeneralMessageSent> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ApptGeneralMessageSent> TableToList(DataTable table) {
			List<ApptGeneralMessageSent> retVal=new List<ApptGeneralMessageSent>();
			ApptGeneralMessageSent apptGeneralMessageSent;
			foreach(DataRow row in table.Rows) {
				apptGeneralMessageSent=new ApptGeneralMessageSent();
				apptGeneralMessageSent.ApptGeneralMessageSentNum= PIn.Long  (row["ApptGeneralMessageSentNum"].ToString());
				apptGeneralMessageSent.ApptNum                  = PIn.Long  (row["ApptNum"].ToString());
				apptGeneralMessageSent.PatNum                   = PIn.Long  (row["PatNum"].ToString());
				apptGeneralMessageSent.ClinicNum                = PIn.Long  (row["ClinicNum"].ToString());
				apptGeneralMessageSent.DateTimeEntry            = PIn.DateT (row["DateTimeEntry"].ToString());
				apptGeneralMessageSent.TSPrior                  = TimeSpan.FromTicks(PIn.Long(row["TSPrior"].ToString()));
				apptGeneralMessageSent.ApptReminderRuleNum      = PIn.Long  (row["ApptReminderRuleNum"].ToString());
				apptGeneralMessageSent.SmsSendStatus            = (OpenDentBusiness.AutoCommStatus)PIn.Int(row["SmsSendStatus"].ToString());
				apptGeneralMessageSent.EmailSendStatus          = (OpenDentBusiness.AutoCommStatus)PIn.Int(row["EmailSendStatus"].ToString());
				retVal.Add(apptGeneralMessageSent);
			}
			return retVal;
		}

		///<summary>Converts a list of ApptGeneralMessageSent into a DataTable.</summary>
		public static DataTable ListToTable(List<ApptGeneralMessageSent> listApptGeneralMessageSents,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ApptGeneralMessageSent";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ApptGeneralMessageSentNum");
			table.Columns.Add("ApptNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("DateTimeEntry");
			table.Columns.Add("TSPrior");
			table.Columns.Add("ApptReminderRuleNum");
			table.Columns.Add("SmsSendStatus");
			table.Columns.Add("EmailSendStatus");
			foreach(ApptGeneralMessageSent apptGeneralMessageSent in listApptGeneralMessageSents) {
				table.Rows.Add(new object[] {
					POut.Long  (apptGeneralMessageSent.ApptGeneralMessageSentNum),
					POut.Long  (apptGeneralMessageSent.ApptNum),
					POut.Long  (apptGeneralMessageSent.PatNum),
					POut.Long  (apptGeneralMessageSent.ClinicNum),
					POut.DateT (apptGeneralMessageSent.DateTimeEntry,false),
					POut.Long (apptGeneralMessageSent.TSPrior.Ticks),
					POut.Long  (apptGeneralMessageSent.ApptReminderRuleNum),
					POut.Int   ((int)apptGeneralMessageSent.SmsSendStatus),
					POut.Int   ((int)apptGeneralMessageSent.EmailSendStatus),
				});
			}
			return table;
		}

		///<summary>Inserts one ApptGeneralMessageSent into the database.  Returns the new priKey.</summary>
		public static long Insert(ApptGeneralMessageSent apptGeneralMessageSent) {
			return Insert(apptGeneralMessageSent,false);
		}

		///<summary>Inserts one ApptGeneralMessageSent into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ApptGeneralMessageSent apptGeneralMessageSent,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				apptGeneralMessageSent.ApptGeneralMessageSentNum=ReplicationServers.GetKey("apptgeneralmessagesent","ApptGeneralMessageSentNum");
			}
			string command="INSERT INTO apptgeneralmessagesent (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ApptGeneralMessageSentNum,";
			}
			command+="ApptNum,PatNum,ClinicNum,DateTimeEntry,TSPrior,ApptReminderRuleNum,SmsSendStatus,EmailSendStatus) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(apptGeneralMessageSent.ApptGeneralMessageSentNum)+",";
			}
			command+=
				     POut.Long  (apptGeneralMessageSent.ApptNum)+","
				+    POut.Long  (apptGeneralMessageSent.PatNum)+","
				+    POut.Long  (apptGeneralMessageSent.ClinicNum)+","
				+    DbHelper.Now()+","
				+"'"+POut.Long  (apptGeneralMessageSent.TSPrior.Ticks)+"',"
				+    POut.Long  (apptGeneralMessageSent.ApptReminderRuleNum)+","
				+    POut.Int   ((int)apptGeneralMessageSent.SmsSendStatus)+","
				+    POut.Int   ((int)apptGeneralMessageSent.EmailSendStatus)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				apptGeneralMessageSent.ApptGeneralMessageSentNum=Db.NonQ(command,true,"ApptGeneralMessageSentNum","apptGeneralMessageSent");
			}
			return apptGeneralMessageSent.ApptGeneralMessageSentNum;
		}

		///<summary>Inserts many ApptGeneralMessageSents into the database.</summary>
		public static void InsertMany(List<ApptGeneralMessageSent> listApptGeneralMessageSents) {
			InsertMany(listApptGeneralMessageSents,false);
		}

		///<summary>Inserts many ApptGeneralMessageSents into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<ApptGeneralMessageSent> listApptGeneralMessageSents,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(ApptGeneralMessageSent apptGeneralMessageSent in listApptGeneralMessageSents) {
					Insert(apptGeneralMessageSent);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listApptGeneralMessageSents.Count) {
					ApptGeneralMessageSent apptGeneralMessageSent=listApptGeneralMessageSents[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO apptgeneralmessagesent (");
						if(useExistingPK) {
							sbCommands.Append("ApptGeneralMessageSentNum,");
						}
						sbCommands.Append("ApptNum,PatNum,ClinicNum,DateTimeEntry,TSPrior,ApptReminderRuleNum,SmsSendStatus,EmailSendStatus) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(apptGeneralMessageSent.ApptGeneralMessageSentNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.Long(apptGeneralMessageSent.ApptNum)); sbRow.Append(",");
					sbRow.Append(POut.Long(apptGeneralMessageSent.PatNum)); sbRow.Append(",");
					sbRow.Append(POut.Long(apptGeneralMessageSent.ClinicNum)); sbRow.Append(",");
					sbRow.Append(DbHelper.Now()); sbRow.Append(",");
					sbRow.Append("'"+POut.Long  (apptGeneralMessageSent.TSPrior.Ticks)+"'"); sbRow.Append(",");
					sbRow.Append(POut.Long(apptGeneralMessageSent.ApptReminderRuleNum)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)apptGeneralMessageSent.SmsSendStatus)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)apptGeneralMessageSent.EmailSendStatus)); sbRow.Append(")");
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
						if(index==listApptGeneralMessageSents.Count-1) {
							Db.NonQ(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one ApptGeneralMessageSent into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ApptGeneralMessageSent apptGeneralMessageSent) {
			return InsertNoCache(apptGeneralMessageSent,false);
		}

		///<summary>Inserts one ApptGeneralMessageSent into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ApptGeneralMessageSent apptGeneralMessageSent,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO apptgeneralmessagesent (";
			if(!useExistingPK && isRandomKeys) {
				apptGeneralMessageSent.ApptGeneralMessageSentNum=ReplicationServers.GetKeyNoCache("apptgeneralmessagesent","ApptGeneralMessageSentNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ApptGeneralMessageSentNum,";
			}
			command+="ApptNum,PatNum,ClinicNum,DateTimeEntry,TSPrior,ApptReminderRuleNum,SmsSendStatus,EmailSendStatus) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(apptGeneralMessageSent.ApptGeneralMessageSentNum)+",";
			}
			command+=
				     POut.Long  (apptGeneralMessageSent.ApptNum)+","
				+    POut.Long  (apptGeneralMessageSent.PatNum)+","
				+    POut.Long  (apptGeneralMessageSent.ClinicNum)+","
				+    DbHelper.Now()+","
				+"'"+POut.Long(apptGeneralMessageSent.TSPrior.Ticks)+"',"
				+    POut.Long  (apptGeneralMessageSent.ApptReminderRuleNum)+","
				+    POut.Int   ((int)apptGeneralMessageSent.SmsSendStatus)+","
				+    POut.Int   ((int)apptGeneralMessageSent.EmailSendStatus)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				apptGeneralMessageSent.ApptGeneralMessageSentNum=Db.NonQ(command,true,"ApptGeneralMessageSentNum","apptGeneralMessageSent");
			}
			return apptGeneralMessageSent.ApptGeneralMessageSentNum;
		}

		///<summary>Updates one ApptGeneralMessageSent in the database.</summary>
		public static void Update(ApptGeneralMessageSent apptGeneralMessageSent) {
			string command="UPDATE apptgeneralmessagesent SET "
				+"ApptNum                  =  "+POut.Long  (apptGeneralMessageSent.ApptNum)+", "
				+"PatNum                   =  "+POut.Long  (apptGeneralMessageSent.PatNum)+", "
				+"ClinicNum                =  "+POut.Long  (apptGeneralMessageSent.ClinicNum)+", "
				//DateTimeEntry not allowed to change
				+"TSPrior                  =  "+POut.Long  (apptGeneralMessageSent.TSPrior.Ticks)+", "
				+"ApptReminderRuleNum      =  "+POut.Long  (apptGeneralMessageSent.ApptReminderRuleNum)+", "
				+"SmsSendStatus            =  "+POut.Int   ((int)apptGeneralMessageSent.SmsSendStatus)+", "
				+"EmailSendStatus          =  "+POut.Int   ((int)apptGeneralMessageSent.EmailSendStatus)+" "
				+"WHERE ApptGeneralMessageSentNum = "+POut.Long(apptGeneralMessageSent.ApptGeneralMessageSentNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ApptGeneralMessageSent in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ApptGeneralMessageSent apptGeneralMessageSent,ApptGeneralMessageSent oldApptGeneralMessageSent) {
			string command="";
			if(apptGeneralMessageSent.ApptNum != oldApptGeneralMessageSent.ApptNum) {
				if(command!="") { command+=",";}
				command+="ApptNum = "+POut.Long(apptGeneralMessageSent.ApptNum)+"";
			}
			if(apptGeneralMessageSent.PatNum != oldApptGeneralMessageSent.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(apptGeneralMessageSent.PatNum)+"";
			}
			if(apptGeneralMessageSent.ClinicNum != oldApptGeneralMessageSent.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(apptGeneralMessageSent.ClinicNum)+"";
			}
			//DateTimeEntry not allowed to change
			if(apptGeneralMessageSent.TSPrior != oldApptGeneralMessageSent.TSPrior) {
				if(command!="") { command+=",";}
				command+="TSPrior = '"+POut.Long  (apptGeneralMessageSent.TSPrior.Ticks)+"'";
			}
			if(apptGeneralMessageSent.ApptReminderRuleNum != oldApptGeneralMessageSent.ApptReminderRuleNum) {
				if(command!="") { command+=",";}
				command+="ApptReminderRuleNum = "+POut.Long(apptGeneralMessageSent.ApptReminderRuleNum)+"";
			}
			if(apptGeneralMessageSent.SmsSendStatus != oldApptGeneralMessageSent.SmsSendStatus) {
				if(command!="") { command+=",";}
				command+="SmsSendStatus = "+POut.Int   ((int)apptGeneralMessageSent.SmsSendStatus)+"";
			}
			if(apptGeneralMessageSent.EmailSendStatus != oldApptGeneralMessageSent.EmailSendStatus) {
				if(command!="") { command+=",";}
				command+="EmailSendStatus = "+POut.Int   ((int)apptGeneralMessageSent.EmailSendStatus)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE apptgeneralmessagesent SET "+command
				+" WHERE ApptGeneralMessageSentNum = "+POut.Long(apptGeneralMessageSent.ApptGeneralMessageSentNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(ApptGeneralMessageSent,ApptGeneralMessageSent) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ApptGeneralMessageSent apptGeneralMessageSent,ApptGeneralMessageSent oldApptGeneralMessageSent) {
			if(apptGeneralMessageSent.ApptNum != oldApptGeneralMessageSent.ApptNum) {
				return true;
			}
			if(apptGeneralMessageSent.PatNum != oldApptGeneralMessageSent.PatNum) {
				return true;
			}
			if(apptGeneralMessageSent.ClinicNum != oldApptGeneralMessageSent.ClinicNum) {
				return true;
			}
			//DateTimeEntry not allowed to change
			if(apptGeneralMessageSent.TSPrior != oldApptGeneralMessageSent.TSPrior) {
				return true;
			}
			if(apptGeneralMessageSent.ApptReminderRuleNum != oldApptGeneralMessageSent.ApptReminderRuleNum) {
				return true;
			}
			if(apptGeneralMessageSent.SmsSendStatus != oldApptGeneralMessageSent.SmsSendStatus) {
				return true;
			}
			if(apptGeneralMessageSent.EmailSendStatus != oldApptGeneralMessageSent.EmailSendStatus) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ApptGeneralMessageSent from the database.</summary>
		public static void Delete(long apptGeneralMessageSentNum) {
			string command="DELETE FROM apptgeneralmessagesent "
				+"WHERE ApptGeneralMessageSentNum = "+POut.Long(apptGeneralMessageSentNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many ApptGeneralMessageSents from the database.</summary>
		public static void DeleteMany(List<long> listApptGeneralMessageSentNums) {
			if(listApptGeneralMessageSentNums==null || listApptGeneralMessageSentNums.Count==0) {
				return;
			}
			string command="DELETE FROM apptgeneralmessagesent "
				+"WHERE ApptGeneralMessageSentNum IN("+string.Join(",",listApptGeneralMessageSentNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}