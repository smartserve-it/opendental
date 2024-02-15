//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class ImageDrawCrud {
		///<summary>Gets one ImageDraw object from the database using the primary key.  Returns null if not found.</summary>
		public static ImageDraw SelectOne(long imageDrawNum) {
			string command="SELECT * FROM imagedraw "
				+"WHERE ImageDrawNum = "+POut.Long(imageDrawNum);
			List<ImageDraw> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ImageDraw object from the database using a query.</summary>
		public static ImageDraw SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ImageDraw> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ImageDraw objects from the database using a query.</summary>
		public static List<ImageDraw> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ImageDraw> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ImageDraw> TableToList(DataTable table) {
			List<ImageDraw> retVal=new List<ImageDraw>();
			ImageDraw imageDraw;
			foreach(DataRow row in table.Rows) {
				imageDraw=new ImageDraw();
				imageDraw.ImageDrawNum    = PIn.Long  (row["ImageDrawNum"].ToString());
				imageDraw.DocNum          = PIn.Long  (row["DocNum"].ToString());
				imageDraw.MountNum        = PIn.Long  (row["MountNum"].ToString());
				imageDraw.ColorDraw       = Color.FromArgb(PIn.Int(row["ColorDraw"].ToString()));
				imageDraw.ColorBack       = Color.FromArgb(PIn.Int(row["ColorBack"].ToString()));
				imageDraw.DrawingSegment  = PIn.String(row["DrawingSegment"].ToString());
				imageDraw.DrawText        = PIn.String(row["DrawText"].ToString());
				imageDraw.FontSize        = PIn.Float (row["FontSize"].ToString());
				imageDraw.DrawType        = (OpenDentBusiness.ImageDrawType)PIn.Int(row["DrawType"].ToString());
				imageDraw.ImageAnnotVendor= (OpenDentBusiness.EnumImageAnnotVendor)PIn.Int(row["ImageAnnotVendor"].ToString());
				imageDraw.Details         = PIn.String(row["Details"].ToString());
				retVal.Add(imageDraw);
			}
			return retVal;
		}

		///<summary>Converts a list of ImageDraw into a DataTable.</summary>
		public static DataTable ListToTable(List<ImageDraw> listImageDraws,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ImageDraw";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ImageDrawNum");
			table.Columns.Add("DocNum");
			table.Columns.Add("MountNum");
			table.Columns.Add("ColorDraw");
			table.Columns.Add("ColorBack");
			table.Columns.Add("DrawingSegment");
			table.Columns.Add("DrawText");
			table.Columns.Add("FontSize");
			table.Columns.Add("DrawType");
			table.Columns.Add("ImageAnnotVendor");
			table.Columns.Add("Details");
			foreach(ImageDraw imageDraw in listImageDraws) {
				table.Rows.Add(new object[] {
					POut.Long  (imageDraw.ImageDrawNum),
					POut.Long  (imageDraw.DocNum),
					POut.Long  (imageDraw.MountNum),
					POut.Int   (imageDraw.ColorDraw.ToArgb()),
					POut.Int   (imageDraw.ColorBack.ToArgb()),
					            imageDraw.DrawingSegment,
					            imageDraw.DrawText,
					POut.Float (imageDraw.FontSize),
					POut.Int   ((int)imageDraw.DrawType),
					POut.Int   ((int)imageDraw.ImageAnnotVendor),
					            imageDraw.Details,
				});
			}
			return table;
		}

		///<summary>Inserts one ImageDraw into the database.  Returns the new priKey.</summary>
		public static long Insert(ImageDraw imageDraw) {
			return Insert(imageDraw,false);
		}

		///<summary>Inserts one ImageDraw into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ImageDraw imageDraw,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				imageDraw.ImageDrawNum=ReplicationServers.GetKey("imagedraw","ImageDrawNum");
			}
			string command="INSERT INTO imagedraw (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ImageDrawNum,";
			}
			command+="DocNum,MountNum,ColorDraw,ColorBack,DrawingSegment,DrawText,FontSize,DrawType,ImageAnnotVendor,Details) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(imageDraw.ImageDrawNum)+",";
			}
			command+=
				     POut.Long  (imageDraw.DocNum)+","
				+    POut.Long  (imageDraw.MountNum)+","
				+    POut.Int   (imageDraw.ColorDraw.ToArgb())+","
				+    POut.Int   (imageDraw.ColorBack.ToArgb())+","
				+    DbHelper.ParamChar+"paramDrawingSegment,"
				+"'"+POut.String(imageDraw.DrawText)+"',"
				+    POut.Float (imageDraw.FontSize)+","
				+    POut.Int   ((int)imageDraw.DrawType)+","
				+    POut.Int   ((int)imageDraw.ImageAnnotVendor)+","
				+    DbHelper.ParamChar+"paramDetails)";
			if(imageDraw.DrawingSegment==null) {
				imageDraw.DrawingSegment="";
			}
			OdSqlParameter paramDrawingSegment=new OdSqlParameter("paramDrawingSegment",OdDbType.Text,POut.StringParam(imageDraw.DrawingSegment));
			if(imageDraw.Details==null) {
				imageDraw.Details="";
			}
			OdSqlParameter paramDetails=new OdSqlParameter("paramDetails",OdDbType.Text,POut.StringParam(imageDraw.Details));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramDrawingSegment,paramDetails);
			}
			else {
				imageDraw.ImageDrawNum=Db.NonQ(command,true,"ImageDrawNum","imageDraw",paramDrawingSegment,paramDetails);
			}
			return imageDraw.ImageDrawNum;
		}

		///<summary>Inserts one ImageDraw into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ImageDraw imageDraw) {
			return InsertNoCache(imageDraw,false);
		}

		///<summary>Inserts one ImageDraw into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ImageDraw imageDraw,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO imagedraw (";
			if(!useExistingPK && isRandomKeys) {
				imageDraw.ImageDrawNum=ReplicationServers.GetKeyNoCache("imagedraw","ImageDrawNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ImageDrawNum,";
			}
			command+="DocNum,MountNum,ColorDraw,ColorBack,DrawingSegment,DrawText,FontSize,DrawType,ImageAnnotVendor,Details) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(imageDraw.ImageDrawNum)+",";
			}
			command+=
				     POut.Long  (imageDraw.DocNum)+","
				+    POut.Long  (imageDraw.MountNum)+","
				+    POut.Int   (imageDraw.ColorDraw.ToArgb())+","
				+    POut.Int   (imageDraw.ColorBack.ToArgb())+","
				+    DbHelper.ParamChar+"paramDrawingSegment,"
				+"'"+POut.String(imageDraw.DrawText)+"',"
				+    POut.Float (imageDraw.FontSize)+","
				+    POut.Int   ((int)imageDraw.DrawType)+","
				+    POut.Int   ((int)imageDraw.ImageAnnotVendor)+","
				+    DbHelper.ParamChar+"paramDetails)";
			if(imageDraw.DrawingSegment==null) {
				imageDraw.DrawingSegment="";
			}
			OdSqlParameter paramDrawingSegment=new OdSqlParameter("paramDrawingSegment",OdDbType.Text,POut.StringParam(imageDraw.DrawingSegment));
			if(imageDraw.Details==null) {
				imageDraw.Details="";
			}
			OdSqlParameter paramDetails=new OdSqlParameter("paramDetails",OdDbType.Text,POut.StringParam(imageDraw.Details));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramDrawingSegment,paramDetails);
			}
			else {
				imageDraw.ImageDrawNum=Db.NonQ(command,true,"ImageDrawNum","imageDraw",paramDrawingSegment,paramDetails);
			}
			return imageDraw.ImageDrawNum;
		}

		///<summary>Updates one ImageDraw in the database.</summary>
		public static void Update(ImageDraw imageDraw) {
			string command="UPDATE imagedraw SET "
				+"DocNum          =  "+POut.Long  (imageDraw.DocNum)+", "
				+"MountNum        =  "+POut.Long  (imageDraw.MountNum)+", "
				+"ColorDraw       =  "+POut.Int   (imageDraw.ColorDraw.ToArgb())+", "
				+"ColorBack       =  "+POut.Int   (imageDraw.ColorBack.ToArgb())+", "
				+"DrawingSegment  =  "+DbHelper.ParamChar+"paramDrawingSegment, "
				+"DrawText        = '"+POut.String(imageDraw.DrawText)+"', "
				+"FontSize        =  "+POut.Float (imageDraw.FontSize)+", "
				+"DrawType        =  "+POut.Int   ((int)imageDraw.DrawType)+", "
				+"ImageAnnotVendor=  "+POut.Int   ((int)imageDraw.ImageAnnotVendor)+", "
				+"Details         =  "+DbHelper.ParamChar+"paramDetails "
				+"WHERE ImageDrawNum = "+POut.Long(imageDraw.ImageDrawNum);
			if(imageDraw.DrawingSegment==null) {
				imageDraw.DrawingSegment="";
			}
			OdSqlParameter paramDrawingSegment=new OdSqlParameter("paramDrawingSegment",OdDbType.Text,POut.StringParam(imageDraw.DrawingSegment));
			if(imageDraw.Details==null) {
				imageDraw.Details="";
			}
			OdSqlParameter paramDetails=new OdSqlParameter("paramDetails",OdDbType.Text,POut.StringParam(imageDraw.Details));
			Db.NonQ(command,paramDrawingSegment,paramDetails);
		}

		///<summary>Updates one ImageDraw in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ImageDraw imageDraw,ImageDraw oldImageDraw) {
			string command="";
			if(imageDraw.DocNum != oldImageDraw.DocNum) {
				if(command!="") { command+=",";}
				command+="DocNum = "+POut.Long(imageDraw.DocNum)+"";
			}
			if(imageDraw.MountNum != oldImageDraw.MountNum) {
				if(command!="") { command+=",";}
				command+="MountNum = "+POut.Long(imageDraw.MountNum)+"";
			}
			if(imageDraw.ColorDraw != oldImageDraw.ColorDraw) {
				if(command!="") { command+=",";}
				command+="ColorDraw = "+POut.Int(imageDraw.ColorDraw.ToArgb())+"";
			}
			if(imageDraw.ColorBack != oldImageDraw.ColorBack) {
				if(command!="") { command+=",";}
				command+="ColorBack = "+POut.Int(imageDraw.ColorBack.ToArgb())+"";
			}
			if(imageDraw.DrawingSegment != oldImageDraw.DrawingSegment) {
				if(command!="") { command+=",";}
				command+="DrawingSegment = "+DbHelper.ParamChar+"paramDrawingSegment";
			}
			if(imageDraw.DrawText != oldImageDraw.DrawText) {
				if(command!="") { command+=",";}
				command+="DrawText = '"+POut.String(imageDraw.DrawText)+"'";
			}
			if(imageDraw.FontSize != oldImageDraw.FontSize) {
				if(command!="") { command+=",";}
				command+="FontSize = "+POut.Float(imageDraw.FontSize)+"";
			}
			if(imageDraw.DrawType != oldImageDraw.DrawType) {
				if(command!="") { command+=",";}
				command+="DrawType = "+POut.Int   ((int)imageDraw.DrawType)+"";
			}
			if(imageDraw.ImageAnnotVendor != oldImageDraw.ImageAnnotVendor) {
				if(command!="") { command+=",";}
				command+="ImageAnnotVendor = "+POut.Int   ((int)imageDraw.ImageAnnotVendor)+"";
			}
			if(imageDraw.Details != oldImageDraw.Details) {
				if(command!="") { command+=",";}
				command+="Details = "+DbHelper.ParamChar+"paramDetails";
			}
			if(command=="") {
				return false;
			}
			if(imageDraw.DrawingSegment==null) {
				imageDraw.DrawingSegment="";
			}
			OdSqlParameter paramDrawingSegment=new OdSqlParameter("paramDrawingSegment",OdDbType.Text,POut.StringParam(imageDraw.DrawingSegment));
			if(imageDraw.Details==null) {
				imageDraw.Details="";
			}
			OdSqlParameter paramDetails=new OdSqlParameter("paramDetails",OdDbType.Text,POut.StringParam(imageDraw.Details));
			command="UPDATE imagedraw SET "+command
				+" WHERE ImageDrawNum = "+POut.Long(imageDraw.ImageDrawNum);
			Db.NonQ(command,paramDrawingSegment,paramDetails);
			return true;
		}

		///<summary>Returns true if Update(ImageDraw,ImageDraw) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ImageDraw imageDraw,ImageDraw oldImageDraw) {
			if(imageDraw.DocNum != oldImageDraw.DocNum) {
				return true;
			}
			if(imageDraw.MountNum != oldImageDraw.MountNum) {
				return true;
			}
			if(imageDraw.ColorDraw != oldImageDraw.ColorDraw) {
				return true;
			}
			if(imageDraw.ColorBack != oldImageDraw.ColorBack) {
				return true;
			}
			if(imageDraw.DrawingSegment != oldImageDraw.DrawingSegment) {
				return true;
			}
			if(imageDraw.DrawText != oldImageDraw.DrawText) {
				return true;
			}
			if(imageDraw.FontSize != oldImageDraw.FontSize) {
				return true;
			}
			if(imageDraw.DrawType != oldImageDraw.DrawType) {
				return true;
			}
			if(imageDraw.ImageAnnotVendor != oldImageDraw.ImageAnnotVendor) {
				return true;
			}
			if(imageDraw.Details != oldImageDraw.Details) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ImageDraw from the database.</summary>
		public static void Delete(long imageDrawNum) {
			string command="DELETE FROM imagedraw "
				+"WHERE ImageDrawNum = "+POut.Long(imageDrawNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many ImageDraws from the database.</summary>
		public static void DeleteMany(List<long> listImageDrawNums) {
			if(listImageDrawNums==null || listImageDrawNums.Count==0) {
				return;
			}
			string command="DELETE FROM imagedraw "
				+"WHERE ImageDrawNum IN("+string.Join(",",listImageDrawNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}