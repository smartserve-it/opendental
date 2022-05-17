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
	public class WebSchedRecallCrud {
		///<summary>Gets one WebSchedRecall object from the database using the primary key.  Returns null if not found.</summary>
		public static WebSchedRecall SelectOne(long webSchedRecallNum) {
			string command="SELECT * FROM webschedrecall "
				+"WHERE WebSchedRecallNum = "+POut.Long(webSchedRecallNum);
			List<WebSchedRecall> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one WebSchedRecall object from the database using a query.</summary>
		public static WebSchedRecall SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<WebSchedRecall> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of WebSchedRecall objects from the database using a query.</summary>
		public static List<WebSchedRecall> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<WebSchedRecall> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<WebSchedRecall> TableToList(DataTable table) {
			List<WebSchedRecall> retVal=new List<WebSchedRecall>();
			WebSchedRecall webSchedRecall;
			foreach(DataRow row in table.Rows) {
				webSchedRecall=new WebSchedRecall();
				webSchedRecall.WebSchedRecallNum  = PIn.Long  (row["WebSchedRecallNum"].ToString());
				webSchedRecall.RecallNum          = PIn.Long  (row["RecallNum"].ToString());
				webSchedRecall.DateDue            = PIn.DateT (row["DateDue"].ToString());
				webSchedRecall.ReminderCount      = PIn.Int   (row["ReminderCount"].ToString());
				webSchedRecall.DateTimeSendFailed = PIn.DateT (row["DateTimeSendFailed"].ToString());
				webSchedRecall.Source             = (OpenDentBusiness.WebSchedRecallSource)PIn.Int(row["Source"].ToString());
				webSchedRecall.CommlogNum         = PIn.Long  (row["CommlogNum"].ToString());
				webSchedRecall.ShortGUID          = PIn.String(row["ShortGUID"].ToString());
				webSchedRecall.PatNum             = PIn.Long  (row["PatNum"].ToString());
				webSchedRecall.ClinicNum          = PIn.Long  (row["ClinicNum"].ToString());
				webSchedRecall.SendStatus         = (OpenDentBusiness.AutoCommStatus)PIn.Int(row["SendStatus"].ToString());
				webSchedRecall.MessageType        = (OpenDentBusiness.CommType)PIn.Int(row["MessageType"].ToString());
				webSchedRecall.MessageFk          = PIn.Long  (row["MessageFk"].ToString());
				webSchedRecall.DateTimeEntry      = PIn.DateT (row["DateTimeEntry"].ToString());
				webSchedRecall.DateTimeSent       = PIn.DateT (row["DateTimeSent"].ToString());
				webSchedRecall.ResponseDescript   = PIn.String(row["ResponseDescript"].ToString());
				webSchedRecall.ApptReminderRuleNum= PIn.Long  (row["ApptReminderRuleNum"].ToString());
				retVal.Add(webSchedRecall);
			}
			return retVal;
		}

		///<summary>Converts a list of WebSchedRecall into a DataTable.</summary>
		public static DataTable ListToTable(List<WebSchedRecall> listWebSchedRecalls,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="WebSchedRecall";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("WebSchedRecallNum");
			table.Columns.Add("RecallNum");
			table.Columns.Add("DateDue");
			table.Columns.Add("ReminderCount");
			table.Columns.Add("DateTimeSendFailed");
			table.Columns.Add("Source");
			table.Columns.Add("CommlogNum");
			table.Columns.Add("ShortGUID");
			table.Columns.Add("PatNum");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("SendStatus");
			table.Columns.Add("MessageType");
			table.Columns.Add("MessageFk");
			table.Columns.Add("DateTimeEntry");
			table.Columns.Add("DateTimeSent");
			table.Columns.Add("ResponseDescript");
			table.Columns.Add("ApptReminderRuleNum");
			foreach(WebSchedRecall webSchedRecall in listWebSchedRecalls) {
				table.Rows.Add(new object[] {
					POut.Long  (webSchedRecall.WebSchedRecallNum),
					POut.Long  (webSchedRecall.RecallNum),
					POut.DateT (webSchedRecall.DateDue,false),
					POut.Int   (webSchedRecall.ReminderCount),
					POut.DateT (webSchedRecall.DateTimeSendFailed,false),
					POut.Int   ((int)webSchedRecall.Source),
					POut.Long  (webSchedRecall.CommlogNum),
					            webSchedRecall.ShortGUID,
					POut.Long  (webSchedRecall.PatNum),
					POut.Long  (webSchedRecall.ClinicNum),
					POut.Int   ((int)webSchedRecall.SendStatus),
					POut.Int   ((int)webSchedRecall.MessageType),
					POut.Long  (webSchedRecall.MessageFk),
					POut.DateT (webSchedRecall.DateTimeEntry,false),
					POut.DateT (webSchedRecall.DateTimeSent,false),
					            webSchedRecall.ResponseDescript,
					POut.Long  (webSchedRecall.ApptReminderRuleNum),
				});
			}
			return table;
		}

		///<summary>Inserts one WebSchedRecall into the database.  Returns the new priKey.</summary>
		public static long Insert(WebSchedRecall webSchedRecall) {
			return Insert(webSchedRecall,false);
		}

		///<summary>Inserts one WebSchedRecall into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(WebSchedRecall webSchedRecall,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				webSchedRecall.WebSchedRecallNum=ReplicationServers.GetKey("webschedrecall","WebSchedRecallNum");
			}
			string command="INSERT INTO webschedrecall (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="WebSchedRecallNum,";
			}
			command+="RecallNum,DateDue,ReminderCount,DateTimeSendFailed,Source,CommlogNum,ShortGUID,PatNum,ClinicNum,SendStatus,MessageType,MessageFk,DateTimeEntry,DateTimeSent,ResponseDescript,ApptReminderRuleNum) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(webSchedRecall.WebSchedRecallNum)+",";
			}
			command+=
				     POut.Long  (webSchedRecall.RecallNum)+","
				+    POut.DateT (webSchedRecall.DateDue)+","
				+    POut.Int   (webSchedRecall.ReminderCount)+","
				+    POut.DateT (webSchedRecall.DateTimeSendFailed)+","
				+    POut.Int   ((int)webSchedRecall.Source)+","
				+    POut.Long  (webSchedRecall.CommlogNum)+","
				+"'"+POut.String(webSchedRecall.ShortGUID)+"',"
				+    POut.Long  (webSchedRecall.PatNum)+","
				+    POut.Long  (webSchedRecall.ClinicNum)+","
				+    POut.Int   ((int)webSchedRecall.SendStatus)+","
				+    POut.Int   ((int)webSchedRecall.MessageType)+","
				+    POut.Long  (webSchedRecall.MessageFk)+","
				+    DbHelper.Now()+","
				+    POut.DateT (webSchedRecall.DateTimeSent)+","
				+    DbHelper.ParamChar+"paramResponseDescript,"
				+    POut.Long  (webSchedRecall.ApptReminderRuleNum)+")";
			if(webSchedRecall.ResponseDescript==null) {
				webSchedRecall.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,POut.StringParam(webSchedRecall.ResponseDescript));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramResponseDescript);
			}
			else {
				webSchedRecall.WebSchedRecallNum=Db.NonQ(command,true,"WebSchedRecallNum","webSchedRecall",paramResponseDescript);
			}
			return webSchedRecall.WebSchedRecallNum;
		}

		///<summary>Inserts many WebSchedRecalls into the database.</summary>
		public static void InsertMany(List<WebSchedRecall> listWebSchedRecalls) {
			InsertMany(listWebSchedRecalls,false);
		}

		///<summary>Inserts many WebSchedRecalls into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<WebSchedRecall> listWebSchedRecalls,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(WebSchedRecall webSchedRecall in listWebSchedRecalls) {
					Insert(webSchedRecall);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listWebSchedRecalls.Count) {
					WebSchedRecall webSchedRecall=listWebSchedRecalls[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO webschedrecall (");
						if(useExistingPK) {
							sbCommands.Append("WebSchedRecallNum,");
						}
						sbCommands.Append("RecallNum,DateDue,ReminderCount,DateTimeSendFailed,Source,CommlogNum,ShortGUID,PatNum,ClinicNum,SendStatus,MessageType,MessageFk,DateTimeEntry,DateTimeSent,ResponseDescript,ApptReminderRuleNum) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(webSchedRecall.WebSchedRecallNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.Long(webSchedRecall.RecallNum)); sbRow.Append(",");
					sbRow.Append(POut.DateT(webSchedRecall.DateDue)); sbRow.Append(",");
					sbRow.Append(POut.Int(webSchedRecall.ReminderCount)); sbRow.Append(",");
					sbRow.Append(POut.DateT(webSchedRecall.DateTimeSendFailed)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)webSchedRecall.Source)); sbRow.Append(",");
					sbRow.Append(POut.Long(webSchedRecall.CommlogNum)); sbRow.Append(",");
					sbRow.Append("'"+POut.String(webSchedRecall.ShortGUID)+"'"); sbRow.Append(",");
					sbRow.Append(POut.Long(webSchedRecall.PatNum)); sbRow.Append(",");
					sbRow.Append(POut.Long(webSchedRecall.ClinicNum)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)webSchedRecall.SendStatus)); sbRow.Append(",");
					sbRow.Append(POut.Int((int)webSchedRecall.MessageType)); sbRow.Append(",");
					sbRow.Append(POut.Long(webSchedRecall.MessageFk)); sbRow.Append(",");
					sbRow.Append(DbHelper.Now()); sbRow.Append(",");
					sbRow.Append(POut.DateT(webSchedRecall.DateTimeSent)); sbRow.Append(",");
					sbRow.Append("'"+POut.String(webSchedRecall.ResponseDescript)+"'"); sbRow.Append(",");
					sbRow.Append(POut.Long(webSchedRecall.ApptReminderRuleNum)); sbRow.Append(")");
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
						if(index==listWebSchedRecalls.Count-1) {
							Db.NonQ(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one WebSchedRecall into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(WebSchedRecall webSchedRecall) {
			return InsertNoCache(webSchedRecall,false);
		}

		///<summary>Inserts one WebSchedRecall into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(WebSchedRecall webSchedRecall,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO webschedrecall (";
			if(!useExistingPK && isRandomKeys) {
				webSchedRecall.WebSchedRecallNum=ReplicationServers.GetKeyNoCache("webschedrecall","WebSchedRecallNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="WebSchedRecallNum,";
			}
			command+="RecallNum,DateDue,ReminderCount,DateTimeSendFailed,Source,CommlogNum,ShortGUID,PatNum,ClinicNum,SendStatus,MessageType,MessageFk,DateTimeEntry,DateTimeSent,ResponseDescript,ApptReminderRuleNum) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(webSchedRecall.WebSchedRecallNum)+",";
			}
			command+=
				     POut.Long  (webSchedRecall.RecallNum)+","
				+    POut.DateT (webSchedRecall.DateDue)+","
				+    POut.Int   (webSchedRecall.ReminderCount)+","
				+    POut.DateT (webSchedRecall.DateTimeSendFailed)+","
				+    POut.Int   ((int)webSchedRecall.Source)+","
				+    POut.Long  (webSchedRecall.CommlogNum)+","
				+"'"+POut.String(webSchedRecall.ShortGUID)+"',"
				+    POut.Long  (webSchedRecall.PatNum)+","
				+    POut.Long  (webSchedRecall.ClinicNum)+","
				+    POut.Int   ((int)webSchedRecall.SendStatus)+","
				+    POut.Int   ((int)webSchedRecall.MessageType)+","
				+    POut.Long  (webSchedRecall.MessageFk)+","
				+    DbHelper.Now()+","
				+    POut.DateT (webSchedRecall.DateTimeSent)+","
				+    DbHelper.ParamChar+"paramResponseDescript,"
				+    POut.Long  (webSchedRecall.ApptReminderRuleNum)+")";
			if(webSchedRecall.ResponseDescript==null) {
				webSchedRecall.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,POut.StringParam(webSchedRecall.ResponseDescript));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramResponseDescript);
			}
			else {
				webSchedRecall.WebSchedRecallNum=Db.NonQ(command,true,"WebSchedRecallNum","webSchedRecall",paramResponseDescript);
			}
			return webSchedRecall.WebSchedRecallNum;
		}

		///<summary>Updates one WebSchedRecall in the database.</summary>
		public static void Update(WebSchedRecall webSchedRecall) {
			string command="UPDATE webschedrecall SET "
				+"RecallNum          =  "+POut.Long  (webSchedRecall.RecallNum)+", "
				+"DateDue            =  "+POut.DateT (webSchedRecall.DateDue)+", "
				+"ReminderCount      =  "+POut.Int   (webSchedRecall.ReminderCount)+", "
				+"DateTimeSendFailed =  "+POut.DateT (webSchedRecall.DateTimeSendFailed)+", "
				+"Source             =  "+POut.Int   ((int)webSchedRecall.Source)+", "
				+"CommlogNum         =  "+POut.Long  (webSchedRecall.CommlogNum)+", "
				+"ShortGUID          = '"+POut.String(webSchedRecall.ShortGUID)+"', "
				+"PatNum             =  "+POut.Long  (webSchedRecall.PatNum)+", "
				+"ClinicNum          =  "+POut.Long  (webSchedRecall.ClinicNum)+", "
				+"SendStatus         =  "+POut.Int   ((int)webSchedRecall.SendStatus)+", "
				+"MessageType        =  "+POut.Int   ((int)webSchedRecall.MessageType)+", "
				+"MessageFk          =  "+POut.Long  (webSchedRecall.MessageFk)+", "
				//DateTimeEntry not allowed to change
				+"DateTimeSent       =  "+POut.DateT (webSchedRecall.DateTimeSent)+", "
				+"ResponseDescript   =  "+DbHelper.ParamChar+"paramResponseDescript, "
				+"ApptReminderRuleNum=  "+POut.Long  (webSchedRecall.ApptReminderRuleNum)+" "
				+"WHERE WebSchedRecallNum = "+POut.Long(webSchedRecall.WebSchedRecallNum);
			if(webSchedRecall.ResponseDescript==null) {
				webSchedRecall.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,POut.StringParam(webSchedRecall.ResponseDescript));
			Db.NonQ(command,paramResponseDescript);
		}

		///<summary>Updates one WebSchedRecall in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(WebSchedRecall webSchedRecall,WebSchedRecall oldWebSchedRecall) {
			string command="";
			if(webSchedRecall.RecallNum != oldWebSchedRecall.RecallNum) {
				if(command!="") { command+=",";}
				command+="RecallNum = "+POut.Long(webSchedRecall.RecallNum)+"";
			}
			if(webSchedRecall.DateDue != oldWebSchedRecall.DateDue) {
				if(command!="") { command+=",";}
				command+="DateDue = "+POut.DateT(webSchedRecall.DateDue)+"";
			}
			if(webSchedRecall.ReminderCount != oldWebSchedRecall.ReminderCount) {
				if(command!="") { command+=",";}
				command+="ReminderCount = "+POut.Int(webSchedRecall.ReminderCount)+"";
			}
			if(webSchedRecall.DateTimeSendFailed != oldWebSchedRecall.DateTimeSendFailed) {
				if(command!="") { command+=",";}
				command+="DateTimeSendFailed = "+POut.DateT(webSchedRecall.DateTimeSendFailed)+"";
			}
			if(webSchedRecall.Source != oldWebSchedRecall.Source) {
				if(command!="") { command+=",";}
				command+="Source = "+POut.Int   ((int)webSchedRecall.Source)+"";
			}
			if(webSchedRecall.CommlogNum != oldWebSchedRecall.CommlogNum) {
				if(command!="") { command+=",";}
				command+="CommlogNum = "+POut.Long(webSchedRecall.CommlogNum)+"";
			}
			if(webSchedRecall.ShortGUID != oldWebSchedRecall.ShortGUID) {
				if(command!="") { command+=",";}
				command+="ShortGUID = '"+POut.String(webSchedRecall.ShortGUID)+"'";
			}
			if(webSchedRecall.PatNum != oldWebSchedRecall.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(webSchedRecall.PatNum)+"";
			}
			if(webSchedRecall.ClinicNum != oldWebSchedRecall.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(webSchedRecall.ClinicNum)+"";
			}
			if(webSchedRecall.SendStatus != oldWebSchedRecall.SendStatus) {
				if(command!="") { command+=",";}
				command+="SendStatus = "+POut.Int   ((int)webSchedRecall.SendStatus)+"";
			}
			if(webSchedRecall.MessageType != oldWebSchedRecall.MessageType) {
				if(command!="") { command+=",";}
				command+="MessageType = "+POut.Int   ((int)webSchedRecall.MessageType)+"";
			}
			if(webSchedRecall.MessageFk != oldWebSchedRecall.MessageFk) {
				if(command!="") { command+=",";}
				command+="MessageFk = "+POut.Long(webSchedRecall.MessageFk)+"";
			}
			//DateTimeEntry not allowed to change
			if(webSchedRecall.DateTimeSent != oldWebSchedRecall.DateTimeSent) {
				if(command!="") { command+=",";}
				command+="DateTimeSent = "+POut.DateT(webSchedRecall.DateTimeSent)+"";
			}
			if(webSchedRecall.ResponseDescript != oldWebSchedRecall.ResponseDescript) {
				if(command!="") { command+=",";}
				command+="ResponseDescript = "+DbHelper.ParamChar+"paramResponseDescript";
			}
			if(webSchedRecall.ApptReminderRuleNum != oldWebSchedRecall.ApptReminderRuleNum) {
				if(command!="") { command+=",";}
				command+="ApptReminderRuleNum = "+POut.Long(webSchedRecall.ApptReminderRuleNum)+"";
			}
			if(command=="") {
				return false;
			}
			if(webSchedRecall.ResponseDescript==null) {
				webSchedRecall.ResponseDescript="";
			}
			OdSqlParameter paramResponseDescript=new OdSqlParameter("paramResponseDescript",OdDbType.Text,POut.StringParam(webSchedRecall.ResponseDescript));
			command="UPDATE webschedrecall SET "+command
				+" WHERE WebSchedRecallNum = "+POut.Long(webSchedRecall.WebSchedRecallNum);
			Db.NonQ(command,paramResponseDescript);
			return true;
		}

		///<summary>Returns true if Update(WebSchedRecall,WebSchedRecall) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(WebSchedRecall webSchedRecall,WebSchedRecall oldWebSchedRecall) {
			if(webSchedRecall.RecallNum != oldWebSchedRecall.RecallNum) {
				return true;
			}
			if(webSchedRecall.DateDue != oldWebSchedRecall.DateDue) {
				return true;
			}
			if(webSchedRecall.ReminderCount != oldWebSchedRecall.ReminderCount) {
				return true;
			}
			if(webSchedRecall.DateTimeSendFailed != oldWebSchedRecall.DateTimeSendFailed) {
				return true;
			}
			if(webSchedRecall.Source != oldWebSchedRecall.Source) {
				return true;
			}
			if(webSchedRecall.CommlogNum != oldWebSchedRecall.CommlogNum) {
				return true;
			}
			if(webSchedRecall.ShortGUID != oldWebSchedRecall.ShortGUID) {
				return true;
			}
			if(webSchedRecall.PatNum != oldWebSchedRecall.PatNum) {
				return true;
			}
			if(webSchedRecall.ClinicNum != oldWebSchedRecall.ClinicNum) {
				return true;
			}
			if(webSchedRecall.SendStatus != oldWebSchedRecall.SendStatus) {
				return true;
			}
			if(webSchedRecall.MessageType != oldWebSchedRecall.MessageType) {
				return true;
			}
			if(webSchedRecall.MessageFk != oldWebSchedRecall.MessageFk) {
				return true;
			}
			//DateTimeEntry not allowed to change
			if(webSchedRecall.DateTimeSent != oldWebSchedRecall.DateTimeSent) {
				return true;
			}
			if(webSchedRecall.ResponseDescript != oldWebSchedRecall.ResponseDescript) {
				return true;
			}
			if(webSchedRecall.ApptReminderRuleNum != oldWebSchedRecall.ApptReminderRuleNum) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one WebSchedRecall from the database.</summary>
		public static void Delete(long webSchedRecallNum) {
			string command="DELETE FROM webschedrecall "
				+"WHERE WebSchedRecallNum = "+POut.Long(webSchedRecallNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many WebSchedRecalls from the database.</summary>
		public static void DeleteMany(List<long> listWebSchedRecallNums) {
			if(listWebSchedRecallNums==null || listWebSchedRecallNums.Count==0) {
				return;
			}
			string command="DELETE FROM webschedrecall "
				+"WHERE WebSchedRecallNum IN("+string.Join(",",listWebSchedRecallNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}