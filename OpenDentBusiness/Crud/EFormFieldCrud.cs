//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class EFormFieldCrud {
		///<summary>Gets one EFormField object from the database using the primary key.  Returns null if not found.</summary>
		public static EFormField SelectOne(long eFormFieldNum) {
			string command="SELECT * FROM eformfield "
				+"WHERE EFormFieldNum = "+POut.Long(eFormFieldNum);
			List<EFormField> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EFormField object from the database using a query.</summary>
		public static EFormField SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EFormField> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EFormField objects from the database using a query.</summary>
		public static List<EFormField> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EFormField> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EFormField> TableToList(DataTable table) {
			List<EFormField> retVal=new List<EFormField>();
			EFormField eFormField;
			foreach(DataRow row in table.Rows) {
				eFormField=new EFormField();
				eFormField.EFormFieldNum    = PIn.Long  (row["EFormFieldNum"].ToString());
				eFormField.EFormNum         = PIn.Long  (row["EFormNum"].ToString());
				eFormField.PatNum           = PIn.Long  (row["PatNum"].ToString());
				eFormField.FieldType        = (OpenDentBusiness.EnumEFormFieldType)PIn.Int(row["FieldType"].ToString());
				eFormField.DbLink           = PIn.String(row["DbLink"].ToString());
				eFormField.ValueLabel       = PIn.String(row["ValueLabel"].ToString());
				eFormField.ValueString      = PIn.String(row["ValueString"].ToString());
				eFormField.ItemOrder        = PIn.Int   (row["ItemOrder"].ToString());
				eFormField.PickListVis      = PIn.String(row["PickListVis"].ToString());
				eFormField.PickListDb       = PIn.String(row["PickListDb"].ToString());
				eFormField.IsHorizStacking  = PIn.Bool  (row["IsHorizStacking"].ToString());
				eFormField.IsTextWrap       = PIn.Bool  (row["IsTextWrap"].ToString());
				eFormField.Width            = PIn.Int   (row["Width"].ToString());
				eFormField.FontScale        = PIn.Int   (row["FontScale"].ToString());
				eFormField.IsRequired       = PIn.Bool  (row["IsRequired"].ToString());
				eFormField.ConditionalParent= PIn.String(row["ConditionalParent"].ToString());
				eFormField.ConditionalValue = PIn.String(row["ConditionalValue"].ToString());
				eFormField.LabelAlign       = (OpenDentBusiness.EnumEFormLabelAlign)PIn.Int(row["LabelAlign"].ToString());
				eFormField.SpaceBelow       = PIn.Int   (row["SpaceBelow"].ToString());
				eFormField.ReportableName   = PIn.String(row["ReportableName"].ToString());
				eFormField.IsLocked         = PIn.Bool  (row["IsLocked"].ToString());
				eFormField.Border           = (OpenDentBusiness.EnumEFormBorder)PIn.Int(row["Border"].ToString());
				eFormField.IsWidthPercentage= PIn.Bool  (row["IsWidthPercentage"].ToString());
				eFormField.MinWidth         = PIn.Int   (row["MinWidth"].ToString());
				retVal.Add(eFormField);
			}
			return retVal;
		}

		///<summary>Converts a list of EFormField into a DataTable.</summary>
		public static DataTable ListToTable(List<EFormField> listEFormFields,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="EFormField";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("EFormFieldNum");
			table.Columns.Add("EFormNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("FieldType");
			table.Columns.Add("DbLink");
			table.Columns.Add("ValueLabel");
			table.Columns.Add("ValueString");
			table.Columns.Add("ItemOrder");
			table.Columns.Add("PickListVis");
			table.Columns.Add("PickListDb");
			table.Columns.Add("IsHorizStacking");
			table.Columns.Add("IsTextWrap");
			table.Columns.Add("Width");
			table.Columns.Add("FontScale");
			table.Columns.Add("IsRequired");
			table.Columns.Add("ConditionalParent");
			table.Columns.Add("ConditionalValue");
			table.Columns.Add("LabelAlign");
			table.Columns.Add("SpaceBelow");
			table.Columns.Add("ReportableName");
			table.Columns.Add("IsLocked");
			table.Columns.Add("Border");
			table.Columns.Add("IsWidthPercentage");
			table.Columns.Add("MinWidth");
			foreach(EFormField eFormField in listEFormFields) {
				table.Rows.Add(new object[] {
					POut.Long  (eFormField.EFormFieldNum),
					POut.Long  (eFormField.EFormNum),
					POut.Long  (eFormField.PatNum),
					POut.Int   ((int)eFormField.FieldType),
					            eFormField.DbLink,
					            eFormField.ValueLabel,
					            eFormField.ValueString,
					POut.Int   (eFormField.ItemOrder),
					            eFormField.PickListVis,
					            eFormField.PickListDb,
					POut.Bool  (eFormField.IsHorizStacking),
					POut.Bool  (eFormField.IsTextWrap),
					POut.Int   (eFormField.Width),
					POut.Int   (eFormField.FontScale),
					POut.Bool  (eFormField.IsRequired),
					            eFormField.ConditionalParent,
					            eFormField.ConditionalValue,
					POut.Int   ((int)eFormField.LabelAlign),
					POut.Int   (eFormField.SpaceBelow),
					            eFormField.ReportableName,
					POut.Bool  (eFormField.IsLocked),
					POut.Int   ((int)eFormField.Border),
					POut.Bool  (eFormField.IsWidthPercentage),
					POut.Int   (eFormField.MinWidth),
				});
			}
			return table;
		}

		///<summary>Inserts one EFormField into the database.  Returns the new priKey.</summary>
		public static long Insert(EFormField eFormField) {
			return Insert(eFormField,false);
		}

		///<summary>Inserts one EFormField into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EFormField eFormField,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				eFormField.EFormFieldNum=ReplicationServers.GetKey("eformfield","EFormFieldNum");
			}
			string command="INSERT INTO eformfield (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EFormFieldNum,";
			}
			command+="EFormNum,PatNum,FieldType,DbLink,ValueLabel,ValueString,ItemOrder,PickListVis,PickListDb,IsHorizStacking,IsTextWrap,Width,FontScale,IsRequired,ConditionalParent,ConditionalValue,LabelAlign,SpaceBelow,ReportableName,IsLocked,Border,IsWidthPercentage,MinWidth) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(eFormField.EFormFieldNum)+",";
			}
			command+=
				     POut.Long  (eFormField.EFormNum)+","
				+    POut.Long  (eFormField.PatNum)+","
				+    POut.Int   ((int)eFormField.FieldType)+","
				+"'"+POut.String(eFormField.DbLink)+"',"
				+    DbHelper.ParamChar+"paramValueLabel,"
				+    DbHelper.ParamChar+"paramValueString,"
				+    POut.Int   (eFormField.ItemOrder)+","
				+"'"+POut.String(eFormField.PickListVis)+"',"
				+"'"+POut.String(eFormField.PickListDb)+"',"
				+    POut.Bool  (eFormField.IsHorizStacking)+","
				+    POut.Bool  (eFormField.IsTextWrap)+","
				+    POut.Int   (eFormField.Width)+","
				+    POut.Int   (eFormField.FontScale)+","
				+    POut.Bool  (eFormField.IsRequired)+","
				+"'"+POut.String(eFormField.ConditionalParent)+"',"
				+"'"+POut.String(eFormField.ConditionalValue)+"',"
				+    POut.Int   ((int)eFormField.LabelAlign)+","
				+    POut.Int   (eFormField.SpaceBelow)+","
				+"'"+POut.String(eFormField.ReportableName)+"',"
				+    POut.Bool  (eFormField.IsLocked)+","
				+    POut.Int   ((int)eFormField.Border)+","
				+    POut.Bool  (eFormField.IsWidthPercentage)+","
				+    POut.Int   (eFormField.MinWidth)+")";
			if(eFormField.ValueLabel==null) {
				eFormField.ValueLabel="";
			}
			OdSqlParameter paramValueLabel=new OdSqlParameter("paramValueLabel",OdDbType.Text,POut.StringParam(eFormField.ValueLabel));
			if(eFormField.ValueString==null) {
				eFormField.ValueString="";
			}
			OdSqlParameter paramValueString=new OdSqlParameter("paramValueString",OdDbType.Text,POut.StringParam(eFormField.ValueString));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramValueLabel,paramValueString);
			}
			else {
				eFormField.EFormFieldNum=Db.NonQ(command,true,"EFormFieldNum","eFormField",paramValueLabel,paramValueString);
			}
			return eFormField.EFormFieldNum;
		}

		///<summary>Inserts one EFormField into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EFormField eFormField) {
			return InsertNoCache(eFormField,false);
		}

		///<summary>Inserts one EFormField into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EFormField eFormField,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO eformfield (";
			if(!useExistingPK && isRandomKeys) {
				eFormField.EFormFieldNum=ReplicationServers.GetKeyNoCache("eformfield","EFormFieldNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="EFormFieldNum,";
			}
			command+="EFormNum,PatNum,FieldType,DbLink,ValueLabel,ValueString,ItemOrder,PickListVis,PickListDb,IsHorizStacking,IsTextWrap,Width,FontScale,IsRequired,ConditionalParent,ConditionalValue,LabelAlign,SpaceBelow,ReportableName,IsLocked,Border,IsWidthPercentage,MinWidth) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(eFormField.EFormFieldNum)+",";
			}
			command+=
				     POut.Long  (eFormField.EFormNum)+","
				+    POut.Long  (eFormField.PatNum)+","
				+    POut.Int   ((int)eFormField.FieldType)+","
				+"'"+POut.String(eFormField.DbLink)+"',"
				+    DbHelper.ParamChar+"paramValueLabel,"
				+    DbHelper.ParamChar+"paramValueString,"
				+    POut.Int   (eFormField.ItemOrder)+","
				+"'"+POut.String(eFormField.PickListVis)+"',"
				+"'"+POut.String(eFormField.PickListDb)+"',"
				+    POut.Bool  (eFormField.IsHorizStacking)+","
				+    POut.Bool  (eFormField.IsTextWrap)+","
				+    POut.Int   (eFormField.Width)+","
				+    POut.Int   (eFormField.FontScale)+","
				+    POut.Bool  (eFormField.IsRequired)+","
				+"'"+POut.String(eFormField.ConditionalParent)+"',"
				+"'"+POut.String(eFormField.ConditionalValue)+"',"
				+    POut.Int   ((int)eFormField.LabelAlign)+","
				+    POut.Int   (eFormField.SpaceBelow)+","
				+"'"+POut.String(eFormField.ReportableName)+"',"
				+    POut.Bool  (eFormField.IsLocked)+","
				+    POut.Int   ((int)eFormField.Border)+","
				+    POut.Bool  (eFormField.IsWidthPercentage)+","
				+    POut.Int   (eFormField.MinWidth)+")";
			if(eFormField.ValueLabel==null) {
				eFormField.ValueLabel="";
			}
			OdSqlParameter paramValueLabel=new OdSqlParameter("paramValueLabel",OdDbType.Text,POut.StringParam(eFormField.ValueLabel));
			if(eFormField.ValueString==null) {
				eFormField.ValueString="";
			}
			OdSqlParameter paramValueString=new OdSqlParameter("paramValueString",OdDbType.Text,POut.StringParam(eFormField.ValueString));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramValueLabel,paramValueString);
			}
			else {
				eFormField.EFormFieldNum=Db.NonQ(command,true,"EFormFieldNum","eFormField",paramValueLabel,paramValueString);
			}
			return eFormField.EFormFieldNum;
		}

		///<summary>Updates one EFormField in the database.</summary>
		public static void Update(EFormField eFormField) {
			string command="UPDATE eformfield SET "
				+"EFormNum         =  "+POut.Long  (eFormField.EFormNum)+", "
				+"PatNum           =  "+POut.Long  (eFormField.PatNum)+", "
				+"FieldType        =  "+POut.Int   ((int)eFormField.FieldType)+", "
				+"DbLink           = '"+POut.String(eFormField.DbLink)+"', "
				+"ValueLabel       =  "+DbHelper.ParamChar+"paramValueLabel, "
				+"ValueString      =  "+DbHelper.ParamChar+"paramValueString, "
				+"ItemOrder        =  "+POut.Int   (eFormField.ItemOrder)+", "
				+"PickListVis      = '"+POut.String(eFormField.PickListVis)+"', "
				+"PickListDb       = '"+POut.String(eFormField.PickListDb)+"', "
				+"IsHorizStacking  =  "+POut.Bool  (eFormField.IsHorizStacking)+", "
				+"IsTextWrap       =  "+POut.Bool  (eFormField.IsTextWrap)+", "
				+"Width            =  "+POut.Int   (eFormField.Width)+", "
				+"FontScale        =  "+POut.Int   (eFormField.FontScale)+", "
				+"IsRequired       =  "+POut.Bool  (eFormField.IsRequired)+", "
				+"ConditionalParent= '"+POut.String(eFormField.ConditionalParent)+"', "
				+"ConditionalValue = '"+POut.String(eFormField.ConditionalValue)+"', "
				+"LabelAlign       =  "+POut.Int   ((int)eFormField.LabelAlign)+", "
				+"SpaceBelow       =  "+POut.Int   (eFormField.SpaceBelow)+", "
				+"ReportableName   = '"+POut.String(eFormField.ReportableName)+"', "
				+"IsLocked         =  "+POut.Bool  (eFormField.IsLocked)+", "
				+"Border           =  "+POut.Int   ((int)eFormField.Border)+", "
				+"IsWidthPercentage=  "+POut.Bool  (eFormField.IsWidthPercentage)+", "
				+"MinWidth         =  "+POut.Int   (eFormField.MinWidth)+" "
				+"WHERE EFormFieldNum = "+POut.Long(eFormField.EFormFieldNum);
			if(eFormField.ValueLabel==null) {
				eFormField.ValueLabel="";
			}
			OdSqlParameter paramValueLabel=new OdSqlParameter("paramValueLabel",OdDbType.Text,POut.StringParam(eFormField.ValueLabel));
			if(eFormField.ValueString==null) {
				eFormField.ValueString="";
			}
			OdSqlParameter paramValueString=new OdSqlParameter("paramValueString",OdDbType.Text,POut.StringParam(eFormField.ValueString));
			Db.NonQ(command,paramValueLabel,paramValueString);
		}

		///<summary>Updates one EFormField in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EFormField eFormField,EFormField oldEFormField) {
			string command="";
			if(eFormField.EFormNum != oldEFormField.EFormNum) {
				if(command!="") { command+=",";}
				command+="EFormNum = "+POut.Long(eFormField.EFormNum)+"";
			}
			if(eFormField.PatNum != oldEFormField.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(eFormField.PatNum)+"";
			}
			if(eFormField.FieldType != oldEFormField.FieldType) {
				if(command!="") { command+=",";}
				command+="FieldType = "+POut.Int   ((int)eFormField.FieldType)+"";
			}
			if(eFormField.DbLink != oldEFormField.DbLink) {
				if(command!="") { command+=",";}
				command+="DbLink = '"+POut.String(eFormField.DbLink)+"'";
			}
			if(eFormField.ValueLabel != oldEFormField.ValueLabel) {
				if(command!="") { command+=",";}
				command+="ValueLabel = "+DbHelper.ParamChar+"paramValueLabel";
			}
			if(eFormField.ValueString != oldEFormField.ValueString) {
				if(command!="") { command+=",";}
				command+="ValueString = "+DbHelper.ParamChar+"paramValueString";
			}
			if(eFormField.ItemOrder != oldEFormField.ItemOrder) {
				if(command!="") { command+=",";}
				command+="ItemOrder = "+POut.Int(eFormField.ItemOrder)+"";
			}
			if(eFormField.PickListVis != oldEFormField.PickListVis) {
				if(command!="") { command+=",";}
				command+="PickListVis = '"+POut.String(eFormField.PickListVis)+"'";
			}
			if(eFormField.PickListDb != oldEFormField.PickListDb) {
				if(command!="") { command+=",";}
				command+="PickListDb = '"+POut.String(eFormField.PickListDb)+"'";
			}
			if(eFormField.IsHorizStacking != oldEFormField.IsHorizStacking) {
				if(command!="") { command+=",";}
				command+="IsHorizStacking = "+POut.Bool(eFormField.IsHorizStacking)+"";
			}
			if(eFormField.IsTextWrap != oldEFormField.IsTextWrap) {
				if(command!="") { command+=",";}
				command+="IsTextWrap = "+POut.Bool(eFormField.IsTextWrap)+"";
			}
			if(eFormField.Width != oldEFormField.Width) {
				if(command!="") { command+=",";}
				command+="Width = "+POut.Int(eFormField.Width)+"";
			}
			if(eFormField.FontScale != oldEFormField.FontScale) {
				if(command!="") { command+=",";}
				command+="FontScale = "+POut.Int(eFormField.FontScale)+"";
			}
			if(eFormField.IsRequired != oldEFormField.IsRequired) {
				if(command!="") { command+=",";}
				command+="IsRequired = "+POut.Bool(eFormField.IsRequired)+"";
			}
			if(eFormField.ConditionalParent != oldEFormField.ConditionalParent) {
				if(command!="") { command+=",";}
				command+="ConditionalParent = '"+POut.String(eFormField.ConditionalParent)+"'";
			}
			if(eFormField.ConditionalValue != oldEFormField.ConditionalValue) {
				if(command!="") { command+=",";}
				command+="ConditionalValue = '"+POut.String(eFormField.ConditionalValue)+"'";
			}
			if(eFormField.LabelAlign != oldEFormField.LabelAlign) {
				if(command!="") { command+=",";}
				command+="LabelAlign = "+POut.Int   ((int)eFormField.LabelAlign)+"";
			}
			if(eFormField.SpaceBelow != oldEFormField.SpaceBelow) {
				if(command!="") { command+=",";}
				command+="SpaceBelow = "+POut.Int(eFormField.SpaceBelow)+"";
			}
			if(eFormField.ReportableName != oldEFormField.ReportableName) {
				if(command!="") { command+=",";}
				command+="ReportableName = '"+POut.String(eFormField.ReportableName)+"'";
			}
			if(eFormField.IsLocked != oldEFormField.IsLocked) {
				if(command!="") { command+=",";}
				command+="IsLocked = "+POut.Bool(eFormField.IsLocked)+"";
			}
			if(eFormField.Border != oldEFormField.Border) {
				if(command!="") { command+=",";}
				command+="Border = "+POut.Int   ((int)eFormField.Border)+"";
			}
			if(eFormField.IsWidthPercentage != oldEFormField.IsWidthPercentage) {
				if(command!="") { command+=",";}
				command+="IsWidthPercentage = "+POut.Bool(eFormField.IsWidthPercentage)+"";
			}
			if(eFormField.MinWidth != oldEFormField.MinWidth) {
				if(command!="") { command+=",";}
				command+="MinWidth = "+POut.Int(eFormField.MinWidth)+"";
			}
			if(command=="") {
				return false;
			}
			if(eFormField.ValueLabel==null) {
				eFormField.ValueLabel="";
			}
			OdSqlParameter paramValueLabel=new OdSqlParameter("paramValueLabel",OdDbType.Text,POut.StringParam(eFormField.ValueLabel));
			if(eFormField.ValueString==null) {
				eFormField.ValueString="";
			}
			OdSqlParameter paramValueString=new OdSqlParameter("paramValueString",OdDbType.Text,POut.StringParam(eFormField.ValueString));
			command="UPDATE eformfield SET "+command
				+" WHERE EFormFieldNum = "+POut.Long(eFormField.EFormFieldNum);
			Db.NonQ(command,paramValueLabel,paramValueString);
			return true;
		}

		///<summary>Returns true if Update(EFormField,EFormField) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(EFormField eFormField,EFormField oldEFormField) {
			if(eFormField.EFormNum != oldEFormField.EFormNum) {
				return true;
			}
			if(eFormField.PatNum != oldEFormField.PatNum) {
				return true;
			}
			if(eFormField.FieldType != oldEFormField.FieldType) {
				return true;
			}
			if(eFormField.DbLink != oldEFormField.DbLink) {
				return true;
			}
			if(eFormField.ValueLabel != oldEFormField.ValueLabel) {
				return true;
			}
			if(eFormField.ValueString != oldEFormField.ValueString) {
				return true;
			}
			if(eFormField.ItemOrder != oldEFormField.ItemOrder) {
				return true;
			}
			if(eFormField.PickListVis != oldEFormField.PickListVis) {
				return true;
			}
			if(eFormField.PickListDb != oldEFormField.PickListDb) {
				return true;
			}
			if(eFormField.IsHorizStacking != oldEFormField.IsHorizStacking) {
				return true;
			}
			if(eFormField.IsTextWrap != oldEFormField.IsTextWrap) {
				return true;
			}
			if(eFormField.Width != oldEFormField.Width) {
				return true;
			}
			if(eFormField.FontScale != oldEFormField.FontScale) {
				return true;
			}
			if(eFormField.IsRequired != oldEFormField.IsRequired) {
				return true;
			}
			if(eFormField.ConditionalParent != oldEFormField.ConditionalParent) {
				return true;
			}
			if(eFormField.ConditionalValue != oldEFormField.ConditionalValue) {
				return true;
			}
			if(eFormField.LabelAlign != oldEFormField.LabelAlign) {
				return true;
			}
			if(eFormField.SpaceBelow != oldEFormField.SpaceBelow) {
				return true;
			}
			if(eFormField.ReportableName != oldEFormField.ReportableName) {
				return true;
			}
			if(eFormField.IsLocked != oldEFormField.IsLocked) {
				return true;
			}
			if(eFormField.Border != oldEFormField.Border) {
				return true;
			}
			if(eFormField.IsWidthPercentage != oldEFormField.IsWidthPercentage) {
				return true;
			}
			if(eFormField.MinWidth != oldEFormField.MinWidth) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one EFormField from the database.</summary>
		public static void Delete(long eFormFieldNum) {
			string command="DELETE FROM eformfield "
				+"WHERE EFormFieldNum = "+POut.Long(eFormFieldNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many EFormFields from the database.</summary>
		public static void DeleteMany(List<long> listEFormFieldNums) {
			if(listEFormFieldNums==null || listEFormFieldNums.Count==0) {
				return;
			}
			string command="DELETE FROM eformfield "
				+"WHERE EFormFieldNum IN("+string.Join(",",listEFormFieldNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}