//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class JobReviewCrud {
		///<summary>Gets one JobReview object from the database using the primary key.  Returns null if not found.</summary>
		public static JobReview SelectOne(long jobReviewNum) {
			string command="SELECT * FROM jobreview "
				+"WHERE JobReviewNum = "+POut.Long(jobReviewNum);
			List<JobReview> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one JobReview object from the database using a query.</summary>
		public static JobReview SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<JobReview> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of JobReview objects from the database using a query.</summary>
		public static List<JobReview> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<JobReview> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<JobReview> TableToList(DataTable table) {
			List<JobReview> retVal=new List<JobReview>();
			JobReview jobReview;
			foreach(DataRow row in table.Rows) {
				jobReview=new JobReview();
				jobReview.JobReviewNum= PIn.Long  (row["JobReviewNum"].ToString());
				jobReview.JobNum      = PIn.Long  (row["JobNum"].ToString());
				jobReview.ReviewerNum = PIn.Long  (row["ReviewerNum"].ToString());
				jobReview.DateTStamp  = PIn.DateT (row["DateTStamp"].ToString());
				jobReview.Description = PIn.String(row["Description"].ToString());
				string reviewStatus=row["ReviewStatus"].ToString();
				if(reviewStatus=="") {
					jobReview.ReviewStatus=(OpenDentBusiness.JobReviewStatus)0;
				}
				else try{
					jobReview.ReviewStatus=(OpenDentBusiness.JobReviewStatus)Enum.Parse(typeof(OpenDentBusiness.JobReviewStatus),reviewStatus);
				}
				catch{
					jobReview.ReviewStatus=(OpenDentBusiness.JobReviewStatus)0;
				}
				jobReview.TimeReview  = TimeSpan.FromTicks(PIn.Long(row["TimeReview"].ToString()));
				retVal.Add(jobReview);
			}
			return retVal;
		}

		///<summary>Converts a list of JobReview into a DataTable.</summary>
		public static DataTable ListToTable(List<JobReview> listJobReviews,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="JobReview";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("JobReviewNum");
			table.Columns.Add("JobNum");
			table.Columns.Add("ReviewerNum");
			table.Columns.Add("DateTStamp");
			table.Columns.Add("Description");
			table.Columns.Add("ReviewStatus");
			table.Columns.Add("TimeReview");
			foreach(JobReview jobReview in listJobReviews) {
				table.Rows.Add(new object[] {
					POut.Long  (jobReview.JobReviewNum),
					POut.Long  (jobReview.JobNum),
					POut.Long  (jobReview.ReviewerNum),
					POut.DateT (jobReview.DateTStamp,false),
					            jobReview.Description,
					POut.Int   ((int)jobReview.ReviewStatus),
					POut.Long (jobReview.TimeReview.Ticks),
				});
			}
			return table;
		}

		///<summary>Inserts one JobReview into the database.  Returns the new priKey.</summary>
		public static long Insert(JobReview jobReview) {
			return Insert(jobReview,false);
		}

		///<summary>Inserts one JobReview into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(JobReview jobReview,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				jobReview.JobReviewNum=ReplicationServers.GetKey("jobreview","JobReviewNum");
			}
			string command="INSERT INTO jobreview (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="JobReviewNum,";
			}
			command+="JobNum,ReviewerNum,Description,ReviewStatus,TimeReview) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(jobReview.JobReviewNum)+",";
			}
			command+=
				     POut.Long  (jobReview.JobNum)+","
				+    POut.Long  (jobReview.ReviewerNum)+","
				//DateTStamp can only be set by MySQL
				+    DbHelper.ParamChar+"paramDescription,"
				+"'"+POut.String(jobReview.ReviewStatus.ToString())+"',"
				+"'"+POut.Long  (jobReview.TimeReview.Ticks)+"')";
			if(jobReview.Description==null) {
				jobReview.Description="";
			}
			OdSqlParameter paramDescription=new OdSqlParameter("paramDescription",OdDbType.Text,POut.StringParam(jobReview.Description));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramDescription);
			}
			else {
				jobReview.JobReviewNum=Db.NonQ(command,true,"JobReviewNum","jobReview",paramDescription);
			}
			return jobReview.JobReviewNum;
		}

		///<summary>Inserts one JobReview into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(JobReview jobReview) {
			return InsertNoCache(jobReview,false);
		}

		///<summary>Inserts one JobReview into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(JobReview jobReview,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO jobreview (";
			if(!useExistingPK && isRandomKeys) {
				jobReview.JobReviewNum=ReplicationServers.GetKeyNoCache("jobreview","JobReviewNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="JobReviewNum,";
			}
			command+="JobNum,ReviewerNum,Description,ReviewStatus,TimeReview) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(jobReview.JobReviewNum)+",";
			}
			command+=
				     POut.Long  (jobReview.JobNum)+","
				+    POut.Long  (jobReview.ReviewerNum)+","
				//DateTStamp can only be set by MySQL
				+    DbHelper.ParamChar+"paramDescription,"
				+"'"+POut.String(jobReview.ReviewStatus.ToString())+"',"
				+"'"+POut.Long(jobReview.TimeReview.Ticks)+"')";
			if(jobReview.Description==null) {
				jobReview.Description="";
			}
			OdSqlParameter paramDescription=new OdSqlParameter("paramDescription",OdDbType.Text,POut.StringParam(jobReview.Description));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramDescription);
			}
			else {
				jobReview.JobReviewNum=Db.NonQ(command,true,"JobReviewNum","jobReview",paramDescription);
			}
			return jobReview.JobReviewNum;
		}

		///<summary>Updates one JobReview in the database.</summary>
		public static void Update(JobReview jobReview) {
			string command="UPDATE jobreview SET "
				+"JobNum      =  "+POut.Long  (jobReview.JobNum)+", "
				+"ReviewerNum =  "+POut.Long  (jobReview.ReviewerNum)+", "
				//DateTStamp can only be set by MySQL
				+"Description =  "+DbHelper.ParamChar+"paramDescription, "
				+"ReviewStatus= '"+POut.String(jobReview.ReviewStatus.ToString())+"', "
				+"TimeReview  =  "+POut.Long  (jobReview.TimeReview.Ticks)+" "
				+"WHERE JobReviewNum = "+POut.Long(jobReview.JobReviewNum);
			if(jobReview.Description==null) {
				jobReview.Description="";
			}
			OdSqlParameter paramDescription=new OdSqlParameter("paramDescription",OdDbType.Text,POut.StringParam(jobReview.Description));
			Db.NonQ(command,paramDescription);
		}

		///<summary>Updates one JobReview in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(JobReview jobReview,JobReview oldJobReview) {
			string command="";
			if(jobReview.JobNum != oldJobReview.JobNum) {
				if(command!="") { command+=",";}
				command+="JobNum = "+POut.Long(jobReview.JobNum)+"";
			}
			if(jobReview.ReviewerNum != oldJobReview.ReviewerNum) {
				if(command!="") { command+=",";}
				command+="ReviewerNum = "+POut.Long(jobReview.ReviewerNum)+"";
			}
			//DateTStamp can only be set by MySQL
			if(jobReview.Description != oldJobReview.Description) {
				if(command!="") { command+=",";}
				command+="Description = "+DbHelper.ParamChar+"paramDescription";
			}
			if(jobReview.ReviewStatus != oldJobReview.ReviewStatus) {
				if(command!="") { command+=",";}
				command+="ReviewStatus = '"+POut.String(jobReview.ReviewStatus.ToString())+"'";
			}
			if(jobReview.TimeReview != oldJobReview.TimeReview) {
				if(command!="") { command+=",";}
				command+="TimeReview = '"+POut.Long  (jobReview.TimeReview.Ticks)+"'";
			}
			if(command=="") {
				return false;
			}
			if(jobReview.Description==null) {
				jobReview.Description="";
			}
			OdSqlParameter paramDescription=new OdSqlParameter("paramDescription",OdDbType.Text,POut.StringParam(jobReview.Description));
			command="UPDATE jobreview SET "+command
				+" WHERE JobReviewNum = "+POut.Long(jobReview.JobReviewNum);
			Db.NonQ(command,paramDescription);
			return true;
		}

		///<summary>Returns true if Update(JobReview,JobReview) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(JobReview jobReview,JobReview oldJobReview) {
			if(jobReview.JobNum != oldJobReview.JobNum) {
				return true;
			}
			if(jobReview.ReviewerNum != oldJobReview.ReviewerNum) {
				return true;
			}
			//DateTStamp can only be set by MySQL
			if(jobReview.Description != oldJobReview.Description) {
				return true;
			}
			if(jobReview.ReviewStatus != oldJobReview.ReviewStatus) {
				return true;
			}
			if(jobReview.TimeReview != oldJobReview.TimeReview) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one JobReview from the database.</summary>
		public static void Delete(long jobReviewNum) {
			string command="DELETE FROM jobreview "
				+"WHERE JobReviewNum = "+POut.Long(jobReviewNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many JobReviews from the database.</summary>
		public static void DeleteMany(List<long> listJobReviewNums) {
			if(listJobReviewNums==null || listJobReviewNums.Count==0) {
				return;
			}
			string command="DELETE FROM jobreview "
				+"WHERE JobReviewNum IN("+string.Join(",",listJobReviewNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<JobReview> listNew,List<JobReview> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<JobReview> listIns    =new List<JobReview>();
			List<JobReview> listUpdNew =new List<JobReview>();
			List<JobReview> listUpdDB  =new List<JobReview>();
			List<JobReview> listDel    =new List<JobReview>();
			listNew.Sort((JobReview x,JobReview y) => { return x.JobReviewNum.CompareTo(y.JobReviewNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			listDB.Sort((JobReview x,JobReview y) => { return x.JobReviewNum.CompareTo(y.JobReviewNum); });//Anonymous function, sorts by compairing PK.  Lambda expressions are not allowed, this is the one and only exception.  JS approved.
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			JobReview fieldNew;
			JobReview fieldDB;
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
				else if(fieldNew.JobReviewNum<fieldDB.JobReviewNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.JobReviewNum>fieldDB.JobReviewNum) {//dbPK less than newPK, dbItem is 'next'
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
			DeleteMany(listDel.Select(x => x.JobReviewNum).ToList());
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}