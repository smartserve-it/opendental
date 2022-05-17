//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class ReqStudentCrud {
		///<summary>Gets one ReqStudent object from the database using the primary key.  Returns null if not found.</summary>
		public static ReqStudent SelectOne(long reqStudentNum) {
			string command="SELECT * FROM reqstudent "
				+"WHERE ReqStudentNum = "+POut.Long(reqStudentNum);
			List<ReqStudent> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one ReqStudent object from the database using a query.</summary>
		public static ReqStudent SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ReqStudent> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of ReqStudent objects from the database using a query.</summary>
		public static List<ReqStudent> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<ReqStudent> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<ReqStudent> TableToList(DataTable table) {
			List<ReqStudent> retVal=new List<ReqStudent>();
			ReqStudent reqStudent;
			foreach(DataRow row in table.Rows) {
				reqStudent=new ReqStudent();
				reqStudent.ReqStudentNum  = PIn.Long  (row["ReqStudentNum"].ToString());
				reqStudent.ReqNeededNum   = PIn.Long  (row["ReqNeededNum"].ToString());
				reqStudent.Descript       = PIn.String(row["Descript"].ToString());
				reqStudent.SchoolCourseNum= PIn.Long  (row["SchoolCourseNum"].ToString());
				reqStudent.ProvNum        = PIn.Long  (row["ProvNum"].ToString());
				reqStudent.AptNum         = PIn.Long  (row["AptNum"].ToString());
				reqStudent.PatNum         = PIn.Long  (row["PatNum"].ToString());
				reqStudent.InstructorNum  = PIn.Long  (row["InstructorNum"].ToString());
				reqStudent.DateCompleted  = PIn.Date  (row["DateCompleted"].ToString());
				retVal.Add(reqStudent);
			}
			return retVal;
		}

		///<summary>Converts a list of ReqStudent into a DataTable.</summary>
		public static DataTable ListToTable(List<ReqStudent> listReqStudents,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="ReqStudent";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("ReqStudentNum");
			table.Columns.Add("ReqNeededNum");
			table.Columns.Add("Descript");
			table.Columns.Add("SchoolCourseNum");
			table.Columns.Add("ProvNum");
			table.Columns.Add("AptNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("InstructorNum");
			table.Columns.Add("DateCompleted");
			foreach(ReqStudent reqStudent in listReqStudents) {
				table.Rows.Add(new object[] {
					POut.Long  (reqStudent.ReqStudentNum),
					POut.Long  (reqStudent.ReqNeededNum),
					            reqStudent.Descript,
					POut.Long  (reqStudent.SchoolCourseNum),
					POut.Long  (reqStudent.ProvNum),
					POut.Long  (reqStudent.AptNum),
					POut.Long  (reqStudent.PatNum),
					POut.Long  (reqStudent.InstructorNum),
					POut.DateT (reqStudent.DateCompleted,false),
				});
			}
			return table;
		}

		///<summary>Inserts one ReqStudent into the database.  Returns the new priKey.</summary>
		public static long Insert(ReqStudent reqStudent) {
			return Insert(reqStudent,false);
		}

		///<summary>Inserts one ReqStudent into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(ReqStudent reqStudent,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				reqStudent.ReqStudentNum=ReplicationServers.GetKey("reqstudent","ReqStudentNum");
			}
			string command="INSERT INTO reqstudent (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="ReqStudentNum,";
			}
			command+="ReqNeededNum,Descript,SchoolCourseNum,ProvNum,AptNum,PatNum,InstructorNum,DateCompleted) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(reqStudent.ReqStudentNum)+",";
			}
			command+=
				     POut.Long  (reqStudent.ReqNeededNum)+","
				+"'"+POut.String(reqStudent.Descript)+"',"
				+    POut.Long  (reqStudent.SchoolCourseNum)+","
				+    POut.Long  (reqStudent.ProvNum)+","
				+    POut.Long  (reqStudent.AptNum)+","
				+    POut.Long  (reqStudent.PatNum)+","
				+    POut.Long  (reqStudent.InstructorNum)+","
				+    POut.Date  (reqStudent.DateCompleted)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				reqStudent.ReqStudentNum=Db.NonQ(command,true,"ReqStudentNum","reqStudent");
			}
			return reqStudent.ReqStudentNum;
		}

		///<summary>Inserts one ReqStudent into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ReqStudent reqStudent) {
			return InsertNoCache(reqStudent,false);
		}

		///<summary>Inserts one ReqStudent into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(ReqStudent reqStudent,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO reqstudent (";
			if(!useExistingPK && isRandomKeys) {
				reqStudent.ReqStudentNum=ReplicationServers.GetKeyNoCache("reqstudent","ReqStudentNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="ReqStudentNum,";
			}
			command+="ReqNeededNum,Descript,SchoolCourseNum,ProvNum,AptNum,PatNum,InstructorNum,DateCompleted) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(reqStudent.ReqStudentNum)+",";
			}
			command+=
				     POut.Long  (reqStudent.ReqNeededNum)+","
				+"'"+POut.String(reqStudent.Descript)+"',"
				+    POut.Long  (reqStudent.SchoolCourseNum)+","
				+    POut.Long  (reqStudent.ProvNum)+","
				+    POut.Long  (reqStudent.AptNum)+","
				+    POut.Long  (reqStudent.PatNum)+","
				+    POut.Long  (reqStudent.InstructorNum)+","
				+    POut.Date  (reqStudent.DateCompleted)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				reqStudent.ReqStudentNum=Db.NonQ(command,true,"ReqStudentNum","reqStudent");
			}
			return reqStudent.ReqStudentNum;
		}

		///<summary>Updates one ReqStudent in the database.</summary>
		public static void Update(ReqStudent reqStudent) {
			string command="UPDATE reqstudent SET "
				+"ReqNeededNum   =  "+POut.Long  (reqStudent.ReqNeededNum)+", "
				+"Descript       = '"+POut.String(reqStudent.Descript)+"', "
				+"SchoolCourseNum=  "+POut.Long  (reqStudent.SchoolCourseNum)+", "
				+"ProvNum        =  "+POut.Long  (reqStudent.ProvNum)+", "
				+"AptNum         =  "+POut.Long  (reqStudent.AptNum)+", "
				+"PatNum         =  "+POut.Long  (reqStudent.PatNum)+", "
				+"InstructorNum  =  "+POut.Long  (reqStudent.InstructorNum)+", "
				+"DateCompleted  =  "+POut.Date  (reqStudent.DateCompleted)+" "
				+"WHERE ReqStudentNum = "+POut.Long(reqStudent.ReqStudentNum);
			Db.NonQ(command);
		}

		///<summary>Updates one ReqStudent in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(ReqStudent reqStudent,ReqStudent oldReqStudent) {
			string command="";
			if(reqStudent.ReqNeededNum != oldReqStudent.ReqNeededNum) {
				if(command!="") { command+=",";}
				command+="ReqNeededNum = "+POut.Long(reqStudent.ReqNeededNum)+"";
			}
			if(reqStudent.Descript != oldReqStudent.Descript) {
				if(command!="") { command+=",";}
				command+="Descript = '"+POut.String(reqStudent.Descript)+"'";
			}
			if(reqStudent.SchoolCourseNum != oldReqStudent.SchoolCourseNum) {
				if(command!="") { command+=",";}
				command+="SchoolCourseNum = "+POut.Long(reqStudent.SchoolCourseNum)+"";
			}
			if(reqStudent.ProvNum != oldReqStudent.ProvNum) {
				if(command!="") { command+=",";}
				command+="ProvNum = "+POut.Long(reqStudent.ProvNum)+"";
			}
			if(reqStudent.AptNum != oldReqStudent.AptNum) {
				if(command!="") { command+=",";}
				command+="AptNum = "+POut.Long(reqStudent.AptNum)+"";
			}
			if(reqStudent.PatNum != oldReqStudent.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(reqStudent.PatNum)+"";
			}
			if(reqStudent.InstructorNum != oldReqStudent.InstructorNum) {
				if(command!="") { command+=",";}
				command+="InstructorNum = "+POut.Long(reqStudent.InstructorNum)+"";
			}
			if(reqStudent.DateCompleted.Date != oldReqStudent.DateCompleted.Date) {
				if(command!="") { command+=",";}
				command+="DateCompleted = "+POut.Date(reqStudent.DateCompleted)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE reqstudent SET "+command
				+" WHERE ReqStudentNum = "+POut.Long(reqStudent.ReqStudentNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(ReqStudent,ReqStudent) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(ReqStudent reqStudent,ReqStudent oldReqStudent) {
			if(reqStudent.ReqNeededNum != oldReqStudent.ReqNeededNum) {
				return true;
			}
			if(reqStudent.Descript != oldReqStudent.Descript) {
				return true;
			}
			if(reqStudent.SchoolCourseNum != oldReqStudent.SchoolCourseNum) {
				return true;
			}
			if(reqStudent.ProvNum != oldReqStudent.ProvNum) {
				return true;
			}
			if(reqStudent.AptNum != oldReqStudent.AptNum) {
				return true;
			}
			if(reqStudent.PatNum != oldReqStudent.PatNum) {
				return true;
			}
			if(reqStudent.InstructorNum != oldReqStudent.InstructorNum) {
				return true;
			}
			if(reqStudent.DateCompleted.Date != oldReqStudent.DateCompleted.Date) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one ReqStudent from the database.</summary>
		public static void Delete(long reqStudentNum) {
			string command="DELETE FROM reqstudent "
				+"WHERE ReqStudentNum = "+POut.Long(reqStudentNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many ReqStudents from the database.</summary>
		public static void DeleteMany(List<long> listReqStudentNums) {
			if(listReqStudentNums==null || listReqStudentNums.Count==0) {
				return;
			}
			string command="DELETE FROM reqstudent "
				+"WHERE ReqStudentNum IN("+string.Join(",",listReqStudentNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}