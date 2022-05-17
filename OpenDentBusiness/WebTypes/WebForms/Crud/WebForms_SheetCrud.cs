//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace OpenDentBusiness.WebTypes.WebForms.Crud{
	public class WebForms_SheetCrud {
		///<summary>Gets one WebForms_Sheet object from the database using the primary key.  Returns null if not found.</summary>
		public static WebForms_Sheet SelectOne(long sheetID) {
			string command="SELECT * FROM webforms_sheet "
				+"WHERE SheetID = "+POut.Long(sheetID);
			List<WebForms_Sheet> list=TableToList(DataCore.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one WebForms_Sheet object from the database using a query.</summary>
		public static WebForms_Sheet SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<WebForms_Sheet> list=TableToList(DataCore.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of WebForms_Sheet objects from the database using a query.</summary>
		public static List<WebForms_Sheet> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<WebForms_Sheet> list=TableToList(DataCore.GetTable(command));
			return list;
		}

		///<summary>Converts a list of WebForms_Sheet into a DataTable.</summary>
		public static DataTable ListToTable(List<WebForms_Sheet> listWebForms_Sheets,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="WebForms_Sheet";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("SheetID");
			table.Columns.Add("DentalOfficeID");
			table.Columns.Add("Description");
			table.Columns.Add("SheetType");
			table.Columns.Add("DateTimeSheet");
			table.Columns.Add("FontSize");
			table.Columns.Add("FontName");
			table.Columns.Add("Width");
			table.Columns.Add("Height");
			table.Columns.Add("IsLandscape");
			table.Columns.Add("ClinicNum");
			table.Columns.Add("HasMobileLayout");
			table.Columns.Add("SheetDefNum");
			table.Columns.Add("RegistrationKeyNum");
			foreach(WebForms_Sheet webForms_Sheet in listWebForms_Sheets) {
				table.Rows.Add(new object[] {
					POut.Long  (webForms_Sheet.SheetID),
					POut.Long  (webForms_Sheet.DentalOfficeID),
					            webForms_Sheet.Description,
					POut.Int   ((int)webForms_Sheet.SheetType),
					POut.DateT (webForms_Sheet.DateTimeSheet),
					POut.Float (webForms_Sheet.FontSize),
					            webForms_Sheet.FontName,
					POut.Int   (webForms_Sheet.Width),
					POut.Int   (webForms_Sheet.Height),
					POut.Bool  (webForms_Sheet.IsLandscape),
					POut.Long  (webForms_Sheet.ClinicNum),
					POut.Bool  (webForms_Sheet.HasMobileLayout),
					POut.Long  (webForms_Sheet.SheetDefNum),
					POut.Long  (webForms_Sheet.RegistrationKeyNum),
				});
			}
			return table;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<WebForms_Sheet> TableToList(DataTable table) {
			List<WebForms_Sheet> retVal=new List<WebForms_Sheet>();
			WebForms_Sheet webForms_Sheet;
			for(int i=0;i<table.Rows.Count;i++) {
				webForms_Sheet=new WebForms_Sheet();
				webForms_Sheet.SheetID           = PIn.Long  (table.Rows[i]["SheetID"].ToString());
				webForms_Sheet.DentalOfficeID    = PIn.Long  (table.Rows[i]["DentalOfficeID"].ToString());
				webForms_Sheet.Description       = PIn.String(table.Rows[i]["Description"].ToString());
				webForms_Sheet.SheetType         = (OpenDentBusiness.SheetTypeEnum)PIn.Int(table.Rows[i]["SheetType"].ToString());
				webForms_Sheet.DateTimeSheet     = PIn.DateT (table.Rows[i]["DateTimeSheet"].ToString());
				webForms_Sheet.FontSize          = PIn.Float (table.Rows[i]["FontSize"].ToString());
				webForms_Sheet.FontName          = PIn.String(table.Rows[i]["FontName"].ToString());
				webForms_Sheet.Width             = PIn.Int   (table.Rows[i]["Width"].ToString());
				webForms_Sheet.Height            = PIn.Int   (table.Rows[i]["Height"].ToString());
				webForms_Sheet.IsLandscape       = PIn.Bool  (table.Rows[i]["IsLandscape"].ToString());
				webForms_Sheet.ClinicNum         = PIn.Long  (table.Rows[i]["ClinicNum"].ToString());
				webForms_Sheet.HasMobileLayout   = PIn.Bool  (table.Rows[i]["HasMobileLayout"].ToString());
				webForms_Sheet.SheetDefNum       = PIn.Long  (table.Rows[i]["SheetDefNum"].ToString());
				webForms_Sheet.RegistrationKeyNum= PIn.Long  (table.Rows[i]["RegistrationKeyNum"].ToString());
				retVal.Add(webForms_Sheet);
			}
			return retVal;
		}

		///<summary>Inserts one WebForms_Sheet into the database.  Returns the new priKey.</summary>
		public static long Insert(WebForms_Sheet webForms_Sheet) {
			return Insert(webForms_Sheet,false);
		}

		///<summary>Inserts one WebForms_Sheet into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(WebForms_Sheet webForms_Sheet,bool useExistingPK) {
			string command="INSERT INTO webforms_sheet (";
			if(useExistingPK) {
				command+="SheetID,";
			}
			command+="DentalOfficeID,Description,SheetType,DateTimeSheet,FontSize,FontName,Width,Height,IsLandscape,ClinicNum,HasMobileLayout,SheetDefNum,RegistrationKeyNum) VALUES(";
			if(useExistingPK) {
				command+=POut.Long(webForms_Sheet.SheetID)+",";
			}
			command+=
				     POut.Long  (webForms_Sheet.DentalOfficeID)+","
				+"'"+POut.String(webForms_Sheet.Description)+"',"
				+    POut.Int   ((int)webForms_Sheet.SheetType)+","
				+    POut.DateT (webForms_Sheet.DateTimeSheet)+","
				+    POut.Float (webForms_Sheet.FontSize)+","
				+"'"+POut.String(webForms_Sheet.FontName)+"',"
				+    POut.Int   (webForms_Sheet.Width)+","
				+    POut.Int   (webForms_Sheet.Height)+","
				+    POut.Bool  (webForms_Sheet.IsLandscape)+","
				+    POut.Long  (webForms_Sheet.ClinicNum)+","
				+    POut.Bool  (webForms_Sheet.HasMobileLayout)+","
				+    POut.Long  (webForms_Sheet.SheetDefNum)+","
				+    POut.Long  (webForms_Sheet.RegistrationKeyNum)+")";
			if(useExistingPK) {
				DataCore.NonQ(command);
			}
			else {
				webForms_Sheet.SheetID=DataCore.NonQ(command,true);
			}
			return webForms_Sheet.SheetID;
		}

		///<summary>Inserts many WebForms_Sheets into the database.</summary>
		public static void InsertMany(List<WebForms_Sheet> listWebForms_Sheets) {
			InsertMany(listWebForms_Sheets,false);
		}

		///<summary>Inserts many WebForms_Sheets into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<WebForms_Sheet> listWebForms_Sheets,bool useExistingPK) {
			StringBuilder sbCommands=null;
			int index=0;
			int countRows=0;
			while(index < listWebForms_Sheets.Count) {
				WebForms_Sheet webForms_Sheet=listWebForms_Sheets[index];
				StringBuilder sbRow=new StringBuilder("(");
				bool hasComma=false;
				if(sbCommands==null) {
					sbCommands=new StringBuilder();
					sbCommands.Append("INSERT INTO webforms_sheet (");
					if(useExistingPK) {
						sbCommands.Append("SheetID,");
					}
					sbCommands.Append("DentalOfficeID,Description,SheetType,DateTimeSheet,FontSize,FontName,Width,Height,IsLandscape,ClinicNum,HasMobileLayout,SheetDefNum,RegistrationKeyNum) VALUES ");
					countRows=0;
				}
				else {
					hasComma=true;
				}
				if(useExistingPK) {
					sbRow.Append(POut.Long(webForms_Sheet.SheetID)); sbRow.Append(",");
				}
				sbRow.Append(POut.Long(webForms_Sheet.DentalOfficeID)); sbRow.Append(",");
				sbRow.Append("'"+POut.String(webForms_Sheet.Description)+"'"); sbRow.Append(",");
				sbRow.Append(POut.Int((int)webForms_Sheet.SheetType)); sbRow.Append(",");
				sbRow.Append(POut.DateT(webForms_Sheet.DateTimeSheet)); sbRow.Append(",");
				sbRow.Append(POut.Float(webForms_Sheet.FontSize)); sbRow.Append(",");
				sbRow.Append("'"+POut.String(webForms_Sheet.FontName)+"'"); sbRow.Append(",");
				sbRow.Append(POut.Int(webForms_Sheet.Width)); sbRow.Append(",");
				sbRow.Append(POut.Int(webForms_Sheet.Height)); sbRow.Append(",");
				sbRow.Append(POut.Bool(webForms_Sheet.IsLandscape)); sbRow.Append(",");
				sbRow.Append(POut.Long(webForms_Sheet.ClinicNum)); sbRow.Append(",");
				sbRow.Append(POut.Bool(webForms_Sheet.HasMobileLayout)); sbRow.Append(",");
				sbRow.Append(POut.Long(webForms_Sheet.SheetDefNum)); sbRow.Append(",");
				sbRow.Append(POut.Long(webForms_Sheet.RegistrationKeyNum)); sbRow.Append(")");
				if(sbCommands.Length+sbRow.Length+1 > TableBase.MaxAllowedPacketCount && countRows > 0) {
					DataCore.NonQ(sbCommands.ToString());
					sbCommands=null;
				}
				else {
					if(hasComma) {
						sbCommands.Append(",");
					}
					sbCommands.Append(sbRow.ToString());
					countRows++;
					if(index==listWebForms_Sheets.Count-1) {
						DataCore.NonQ(sbCommands.ToString());
					}
					index++;
				}
			}
		}

		///<summary>Updates one WebForms_Sheet in the database.</summary>
		public static void Update(WebForms_Sheet webForms_Sheet) {
			string command="UPDATE webforms_sheet SET "
				+"DentalOfficeID    =  "+POut.Long  (webForms_Sheet.DentalOfficeID)+", "
				+"Description       = '"+POut.String(webForms_Sheet.Description)+"', "
				+"SheetType         =  "+POut.Int   ((int)webForms_Sheet.SheetType)+", "
				+"DateTimeSheet     =  "+POut.DateT (webForms_Sheet.DateTimeSheet)+", "
				+"FontSize          =  "+POut.Float (webForms_Sheet.FontSize)+", "
				+"FontName          = '"+POut.String(webForms_Sheet.FontName)+"', "
				+"Width             =  "+POut.Int   (webForms_Sheet.Width)+", "
				+"Height            =  "+POut.Int   (webForms_Sheet.Height)+", "
				+"IsLandscape       =  "+POut.Bool  (webForms_Sheet.IsLandscape)+", "
				+"ClinicNum         =  "+POut.Long  (webForms_Sheet.ClinicNum)+", "
				+"HasMobileLayout   =  "+POut.Bool  (webForms_Sheet.HasMobileLayout)+", "
				+"SheetDefNum       =  "+POut.Long  (webForms_Sheet.SheetDefNum)+", "
				+"RegistrationKeyNum=  "+POut.Long  (webForms_Sheet.RegistrationKeyNum)+" "
				+"WHERE SheetID = "+POut.Long(webForms_Sheet.SheetID);
			DataCore.NonQ(command);
		}

		///<summary>Updates one WebForms_Sheet in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(WebForms_Sheet webForms_Sheet,WebForms_Sheet oldWebForms_Sheet) {
			string command="";
			if(webForms_Sheet.DentalOfficeID != oldWebForms_Sheet.DentalOfficeID) {
				if(command!="") { command+=",";}
				command+="DentalOfficeID = "+POut.Long(webForms_Sheet.DentalOfficeID)+"";
			}
			if(webForms_Sheet.Description != oldWebForms_Sheet.Description) {
				if(command!="") { command+=",";}
				command+="Description = '"+POut.String(webForms_Sheet.Description)+"'";
			}
			if(webForms_Sheet.SheetType != oldWebForms_Sheet.SheetType) {
				if(command!="") { command+=",";}
				command+="SheetType = "+POut.Int   ((int)webForms_Sheet.SheetType)+"";
			}
			if(webForms_Sheet.DateTimeSheet != oldWebForms_Sheet.DateTimeSheet) {
				if(command!="") { command+=",";}
				command+="DateTimeSheet = "+POut.DateT(webForms_Sheet.DateTimeSheet)+"";
			}
			if(webForms_Sheet.FontSize != oldWebForms_Sheet.FontSize) {
				if(command!="") { command+=",";}
				command+="FontSize = "+POut.Float(webForms_Sheet.FontSize)+"";
			}
			if(webForms_Sheet.FontName != oldWebForms_Sheet.FontName) {
				if(command!="") { command+=",";}
				command+="FontName = '"+POut.String(webForms_Sheet.FontName)+"'";
			}
			if(webForms_Sheet.Width != oldWebForms_Sheet.Width) {
				if(command!="") { command+=",";}
				command+="Width = "+POut.Int(webForms_Sheet.Width)+"";
			}
			if(webForms_Sheet.Height != oldWebForms_Sheet.Height) {
				if(command!="") { command+=",";}
				command+="Height = "+POut.Int(webForms_Sheet.Height)+"";
			}
			if(webForms_Sheet.IsLandscape != oldWebForms_Sheet.IsLandscape) {
				if(command!="") { command+=",";}
				command+="IsLandscape = "+POut.Bool(webForms_Sheet.IsLandscape)+"";
			}
			if(webForms_Sheet.ClinicNum != oldWebForms_Sheet.ClinicNum) {
				if(command!="") { command+=",";}
				command+="ClinicNum = "+POut.Long(webForms_Sheet.ClinicNum)+"";
			}
			if(webForms_Sheet.HasMobileLayout != oldWebForms_Sheet.HasMobileLayout) {
				if(command!="") { command+=",";}
				command+="HasMobileLayout = "+POut.Bool(webForms_Sheet.HasMobileLayout)+"";
			}
			if(webForms_Sheet.SheetDefNum != oldWebForms_Sheet.SheetDefNum) {
				if(command!="") { command+=",";}
				command+="SheetDefNum = "+POut.Long(webForms_Sheet.SheetDefNum)+"";
			}
			if(webForms_Sheet.RegistrationKeyNum != oldWebForms_Sheet.RegistrationKeyNum) {
				if(command!="") { command+=",";}
				command+="RegistrationKeyNum = "+POut.Long(webForms_Sheet.RegistrationKeyNum)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE webforms_sheet SET "+command
				+" WHERE SheetID = "+POut.Long(webForms_Sheet.SheetID);
			DataCore.NonQ(command);
			return true;
		}

		///<summary>Deletes one WebForms_Sheet from the database.</summary>
		public static void Delete(long sheetID) {
			string command="DELETE FROM webforms_sheet "
				+"WHERE SheetID = "+POut.Long(sheetID);
			DataCore.NonQ(command);
		}

	}
}