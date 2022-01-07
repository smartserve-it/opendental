﻿using System;
using System.ComponentModel;
using System.Xml.Serialization;
using CodeBase;

namespace OpenDentBusiness {
	///<summary>Web Sched recall reminders that may have been sent via EConnector to HQ.</summary>
	public class WebSchedRecall:TableBase {
		///<summary>PK. Generated by HQ.</summary>
		[CrudColumn(IsPriKey=true)]
		public long WebSchedRecallNum;
		///<summary>FK to clinic.ClinicNum. Generated by OD.</summary>
		public long ClinicNum;
		///<summary>FK to patient.PatNum. Generated by OD. Patient that this request is linked to.</summary>
		public long PatNum;
		///<summary>FK to recall.RecallNum. Generated by OD.</summary>
		public long RecallNum;
		///<summary>Generated by OD. Timestamp when row is created.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.DateTEntry)]
		public DateTime DateTimeEntry;
		///<summary>The date that the recall is due.</summary>
		public DateTime DateDue;
		///<summary>The number of reminders that have been sent for this recall.</summary>
		public int ReminderCount;
		/// <summary>Enum:ContactMethod </summary>
		public ContactMethod PreferRecallMethod;
		///<summary>When a reminder was sent for this recall. Will be 01/01/0001 if a reminder has never been sent.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.DateT)]
		public DateTime DateTimeReminderSent;
		///<summary>The most recent time that sending a reminder failed. Will be 01/01/0001 if a reminder has never been attempted.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.DateT)]
		public DateTime DateTimeSendFailed;
		///<summary>Enum:AutoCommStatus The status of sending the email for this recall.</summary>
		public AutoCommStatus EmailSendStatus;
		///<summary>Enum:AutoCommStatus The status of sending the text for this recall.</summary>
		public AutoCommStatus SmsSendStatus;
		///<summary>Generated by OD. Only allowed to be empty is IsForSms==false. In that case then it is assumed that OD proper will probably be emailing 
		///and does not want a text message sent.</summary>
		public string PhonePat;
		///<summary>Generated by OD. Only allowed to be empty is IsForEmail==false.</summary>
		public string EmailPat;
		///<summary>Generated by OD. Includes tags that will be replaced by OD and by HQ. Will be converted to final MsgText and sent to patient once 
		///tags are replaced with real values.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.TextIsClob)]
		public string MsgTextToMobileTemplate;
		///<summary>Generated by HQ. Applied real text to tags from MsgTextTemplate.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.TextIsClob)]
		public string MsgTextToMobile;
		///<summary>Generated by OD. Includes tags that will be replaced by OD and by HQ. Will be converted to final EmailSubj and sent to patient once 
		///tags are replaced with real values.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.TextIsClob)]
		public string EmailSubjTemplate;
		///<summary>Generated by HQ. Applied real text to tags from EmailSubjTemplate.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.TextIsClob)]
		public string EmailSubj;
		///<summary>Generated by OD. Includes tags that will be replaced by OD and by HQ. Will be converted to final EmailText and emailed to patient 
		///once tags are replaced with real values.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.TextIsClob)]
		public string EmailTextTemplate;
		///<summary>Generated by HQ. Applied real text to tags from EmailTextTemplate.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.TextIsClob)]
		public string EmailText;
		///<summary>FK to smstomobile.GuidMessage. Generated at HQ when the confirmation is generated.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.TextIsClob)]
		public string GuidMessageToMobile;
		///<summary>FK to smstomobile.GuidMessage. Generated at HQ when the confirmation is generated.</summary>
		public string ShortGUIDSms;
		///<summary>FK to smstomobile.GuidMessage. Generated at HQ when the confirmation is generated.</summary>
		public string ShortGUIDEmail;
		///<summary>If true, this WebSchedRecall represents a communication item sent for multiple recalls.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.TextIsClob)]
		public string ResponseDescript;
		///<summary>Enum:WebSchedRecallSource Where this row came from.</summary>
		public WebSchedRecallSource Source;
		///<summary>Generated by OD. If true then generate and send MT text message. 
		///If false then OD proper is probably panning on emailing the messag.</summary>
		[CrudColumn(IsNotDbColumn=true)]
		public bool IsForSms;
		///<summary>Generated by OD. If true then generate and send email.</summary>
		[CrudColumn(IsNotDbColumn=true)]
		public bool IsForEmail;
		///<summary>True if at least one comm format has been sent.</summary>
		public bool IsSent => EmailSendStatus==AutoCommStatus.SendSuccessful || SmsSendStatus==AutoCommStatus.SendSuccessful;

		public WebSchedRecall Copy() {
			return (WebSchedRecall)MemberwiseClone();
		}
	}
	
	public enum AutoCommStatus {
		///<summary>0 - Should not be in the database but can be used in the program.</summary>
		Undefined,
		///<summary>1 - Do not send a reminder.</summary>
		DoNotSend,
		///<summary>2 - Has not been attempted to send yet.</summary>
		SendNotAttempted,
		///<summary>3 - Has been sent successfully.</summary>
		SendSuccessful,
		///<summary>4 - Attempted to send but not successful.</summary>
		SendFailed,
		///<summary>5 - Has been sent successfully, awaiting receipt.</summary>
		SentAwaitingReceipt,
	}

	public enum WebSchedRecallSource {
		///<summary>0 - Should not be in the database.</summary>
		Undefined,
		///<summary>1 - Originated from a user clicking the Web Sched button in the Recall List.</summary>
		FormRecallList,
		///<summary>2 - The eConnector created this row in the Auto Comm Web Sched thread.</summary>
		EConnectorAutoComm,
	}

}
