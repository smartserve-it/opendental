//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class CovCatCrud {
		///<summary>Gets one CovCat object from the database using the primary key.  Returns null if not found.</summary>
		public static CovCat SelectOne(long covCatNum) {
			string command="SELECT * FROM covcat "
				+"WHERE CovCatNum = "+POut.Long(covCatNum);
			List<CovCat> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one CovCat object from the database using a query.</summary>
		public static CovCat SelectOne(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<CovCat> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of CovCat objects from the database using a query.</summary>
		public static List<CovCat> SelectMany(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<CovCat> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<CovCat> TableToList(DataTable table) {
			List<CovCat> retVal=new List<CovCat>();
			CovCat covCat;
			foreach(DataRow row in table.Rows) {
				covCat=new CovCat();
				covCat.CovCatNum     = PIn.Long  (row["CovCatNum"].ToString());
				covCat.Description   = PIn.String(row["Description"].ToString());
				covCat.DefaultPercent= PIn.Int   (row["DefaultPercent"].ToString());
				covCat.CovOrder      = PIn.Byte  (row["CovOrder"].ToString());
				covCat.IsHidden      = PIn.Bool  (row["IsHidden"].ToString());
				covCat.EbenefitCat   = (OpenDentBusiness.EbenefitCategory)PIn.Int(row["EbenefitCat"].ToString());
				retVal.Add(covCat);
			}
			return retVal;
		}

		///<summary>Converts a list of CovCat into a DataTable.</summary>
		public static DataTable ListToTable(List<CovCat> listCovCats,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="CovCat";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("CovCatNum");
			table.Columns.Add("Description");
			table.Columns.Add("DefaultPercent");
			table.Columns.Add("CovOrder");
			table.Columns.Add("IsHidden");
			table.Columns.Add("EbenefitCat");
			foreach(CovCat covCat in listCovCats) {
				table.Rows.Add(new object[] {
					POut.Long  (covCat.CovCatNum),
					            covCat.Description,
					POut.Int   (covCat.DefaultPercent),
					POut.Byte  (covCat.CovOrder),
					POut.Bool  (covCat.IsHidden),
					POut.Int   ((int)covCat.EbenefitCat),
				});
			}
			return table;
		}

		///<summary>Inserts one CovCat into the database.  Returns the new priKey.</summary>
		public static long Insert(CovCat covCat) {
			return Insert(covCat,false);
		}

		///<summary>Inserts one CovCat into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(CovCat covCat,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				covCat.CovCatNum=ReplicationServers.GetKey("covcat","CovCatNum");
			}
			string command="INSERT INTO covcat (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="CovCatNum,";
			}
			command+="Description,DefaultPercent,CovOrder,IsHidden,EbenefitCat) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(covCat.CovCatNum)+",";
			}
			command+=
				 "'"+POut.String(covCat.Description)+"',"
				+    POut.Int   (covCat.DefaultPercent)+","
				+    POut.Byte  (covCat.CovOrder)+","
				+    POut.Bool  (covCat.IsHidden)+","
				+    POut.Int   ((int)covCat.EbenefitCat)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				covCat.CovCatNum=Db.NonQ(command,true,"CovCatNum","covCat");
			}
			return covCat.CovCatNum;
		}

		///<summary>Inserts one CovCat into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(CovCat covCat) {
			return InsertNoCache(covCat,false);
		}

		///<summary>Inserts one CovCat into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(CovCat covCat,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO covcat (";
			if(!useExistingPK && isRandomKeys) {
				covCat.CovCatNum=ReplicationServers.GetKeyNoCache("covcat","CovCatNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="CovCatNum,";
			}
			command+="Description,DefaultPercent,CovOrder,IsHidden,EbenefitCat) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(covCat.CovCatNum)+",";
			}
			command+=
				 "'"+POut.String(covCat.Description)+"',"
				+    POut.Int   (covCat.DefaultPercent)+","
				+    POut.Byte  (covCat.CovOrder)+","
				+    POut.Bool  (covCat.IsHidden)+","
				+    POut.Int   ((int)covCat.EbenefitCat)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				covCat.CovCatNum=Db.NonQ(command,true,"CovCatNum","covCat");
			}
			return covCat.CovCatNum;
		}

		///<summary>Updates one CovCat in the database.</summary>
		public static void Update(CovCat covCat) {
			string command="UPDATE covcat SET "
				+"Description   = '"+POut.String(covCat.Description)+"', "
				+"DefaultPercent=  "+POut.Int   (covCat.DefaultPercent)+", "
				+"CovOrder      =  "+POut.Byte  (covCat.CovOrder)+", "
				+"IsHidden      =  "+POut.Bool  (covCat.IsHidden)+", "
				+"EbenefitCat   =  "+POut.Int   ((int)covCat.EbenefitCat)+" "
				+"WHERE CovCatNum = "+POut.Long(covCat.CovCatNum);
			Db.NonQ(command);
		}

		///<summary>Updates one CovCat in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(CovCat covCat,CovCat oldCovCat) {
			string command="";
			if(covCat.Description != oldCovCat.Description) {
				if(command!="") { command+=",";}
				command+="Description = '"+POut.String(covCat.Description)+"'";
			}
			if(covCat.DefaultPercent != oldCovCat.DefaultPercent) {
				if(command!="") { command+=",";}
				command+="DefaultPercent = "+POut.Int(covCat.DefaultPercent)+"";
			}
			if(covCat.CovOrder != oldCovCat.CovOrder) {
				if(command!="") { command+=",";}
				command+="CovOrder = "+POut.Byte(covCat.CovOrder)+"";
			}
			if(covCat.IsHidden != oldCovCat.IsHidden) {
				if(command!="") { command+=",";}
				command+="IsHidden = "+POut.Bool(covCat.IsHidden)+"";
			}
			if(covCat.EbenefitCat != oldCovCat.EbenefitCat) {
				if(command!="") { command+=",";}
				command+="EbenefitCat = "+POut.Int   ((int)covCat.EbenefitCat)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE covcat SET "+command
				+" WHERE CovCatNum = "+POut.Long(covCat.CovCatNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(CovCat,CovCat) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(CovCat covCat,CovCat oldCovCat) {
			if(covCat.Description != oldCovCat.Description) {
				return true;
			}
			if(covCat.DefaultPercent != oldCovCat.DefaultPercent) {
				return true;
			}
			if(covCat.CovOrder != oldCovCat.CovOrder) {
				return true;
			}
			if(covCat.IsHidden != oldCovCat.IsHidden) {
				return true;
			}
			if(covCat.EbenefitCat != oldCovCat.EbenefitCat) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one CovCat from the database.</summary>
		public static void Delete(long covCatNum) {
			string command="DELETE FROM covcat "
				+"WHERE CovCatNum = "+POut.Long(covCatNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many CovCats from the database.</summary>
		public static void DeleteMany(List<long> listCovCatNums) {
			if(listCovCatNums==null || listCovCatNums.Count==0) {
				return;
			}
			string command="DELETE FROM covcat "
				+"WHERE CovCatNum IN("+string.Join(",",listCovCatNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}