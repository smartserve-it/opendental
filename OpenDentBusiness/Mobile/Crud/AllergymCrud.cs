//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace OpenDentBusiness.Mobile.Crud{
	internal class AllergymCrud {
		///<summary>Gets one Allergym object from the database using primaryKey1(CustomerNum) and primaryKey2.  Returns null if not found.</summary>
		internal static Allergym SelectOne(long customerNum,long allergyNum){
			string command="SELECT * FROM allergym "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND AllergyNum = "+POut.Long(allergyNum);
			List<Allergym> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one Allergym object from the database using a query.</summary>
		internal static Allergym SelectOne(string command){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Allergym> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of Allergym objects from the database using a query.</summary>
		internal static List<Allergym> SelectMany(string command){
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<Allergym> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		internal static List<Allergym> TableToList(DataTable table){
			List<Allergym> retVal=new List<Allergym>();
			Allergym allergym;
			for(int i=0;i<table.Rows.Count;i++) {
				allergym=new Allergym();
				allergym.CustomerNum        = PIn.Long  (table.Rows[i]["CustomerNum"].ToString());
				allergym.AllergyNum         = PIn.Long  (table.Rows[i]["AllergyNum"].ToString());
				allergym.AllergyDefNum      = PIn.Long  (table.Rows[i]["AllergyDefNum"].ToString());
				allergym.PatNum             = PIn.Long  (table.Rows[i]["PatNum"].ToString());
				allergym.Reaction           = PIn.String(table.Rows[i]["Reaction"].ToString());
				allergym.StatusIsActive     = PIn.Bool  (table.Rows[i]["StatusIsActive"].ToString());
				allergym.DateAdverseReaction= PIn.Date  (table.Rows[i]["DateAdverseReaction"].ToString());
				retVal.Add(allergym);
			}
			return retVal;
		}

		///<summary>Usually set useExistingPK=true.  Inserts one Allergym into the database.</summary>
		internal static long Insert(Allergym allergym,bool useExistingPK){
			if(!useExistingPK) {
				allergym.AllergyNum=ReplicationServers.GetKey("allergym","AllergyNum");
			}
			string command="INSERT INTO allergym (";
			command+="AllergyNum,";
			command+="CustomerNum,AllergyDefNum,PatNum,Reaction,StatusIsActive,DateAdverseReaction) VALUES(";
			command+=POut.Long(allergym.AllergyNum)+",";
			command+=
				     POut.Long  (allergym.CustomerNum)+","
				+    POut.Long  (allergym.AllergyDefNum)+","
				+    POut.Long  (allergym.PatNum)+","
				+"'"+POut.String(allergym.Reaction)+"',"
				+    POut.Bool  (allergym.StatusIsActive)+","
				+    POut.Date  (allergym.DateAdverseReaction)+")";
			Db.NonQ(command);//There is no autoincrement in the mobile server.
			return allergym.AllergyNum;
		}

		///<summary>Updates one Allergym in the database.</summary>
		internal static void Update(Allergym allergym){
			string command="UPDATE allergym SET "
				+"AllergyDefNum      =  "+POut.Long  (allergym.AllergyDefNum)+", "
				+"PatNum             =  "+POut.Long  (allergym.PatNum)+", "
				+"Reaction           = '"+POut.String(allergym.Reaction)+"', "
				+"StatusIsActive     =  "+POut.Bool  (allergym.StatusIsActive)+", "
				+"DateAdverseReaction=  "+POut.Date  (allergym.DateAdverseReaction)+" "
				+"WHERE CustomerNum = "+POut.Long(allergym.CustomerNum)+" AND AllergyNum = "+POut.Long(allergym.AllergyNum);
			Db.NonQ(command);
		}

		///<summary>Deletes one Allergym from the database.</summary>
		internal static void Delete(long customerNum,long allergyNum){
			string command="DELETE FROM allergym "
				+"WHERE CustomerNum = "+POut.Long(customerNum)+" AND AllergyNum = "+POut.Long(allergyNum);
			Db.NonQ(command);
		}

		///<summary>Converts one Allergy object to its mobile equivalent.  Warning! CustomerNum will always be 0.</summary>
		internal static Allergym ConvertToM(Allergy allergy){
			Allergym allergym=new Allergym();
			//CustomerNum cannot be set.  Remains 0.
			allergym.AllergyNum         =allergy.AllergyNum;
			allergym.AllergyDefNum      =allergy.AllergyDefNum;
			allergym.PatNum             =allergy.PatNum;
			allergym.Reaction           =allergy.Reaction;
			allergym.StatusIsActive     =allergy.StatusIsActive;
			allergym.DateAdverseReaction=allergy.DateAdverseReaction;
			return allergym;
		}

	}
}