using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using OpenDentBusiness;
using System.Collections.Generic;
using System.Linq;
using CodeBase;
using OpenDental.UI;

namespace OpenDental {
	public partial class FormMessagingButSetup : FormODBase {
		private SigButDef[] _arraySigButDefs;
		private List<Computer> _listComputers;
		private const int _maxNumButtonsInList=40;

		///<summary></summary>
		public FormMessagingButSetup()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			InitializeLayoutManager();
			Lan.F(this);
		}

		private void FormMessagingButSetup_Load(object sender,EventArgs e) {
			Reinitialize();
			butSynchAll.Visible=PrefC.IsODHQ;
		}

		private void Reinitialize() {
			_listComputers=Computers.GetDeepCopy();
			listComputers.Items.Clear();
			listComputers.Items.Add(Lan.g(this,"All"));
			string s;
			for(int i=0;i<_listComputers.Count;i++) {
				s=_listComputers[i].CompName;
				if(ODEnvironment.MachineName==_listComputers[i].CompName){
					s+=" "+Lan.g(this,"(this computer)");
				}
				listComputers.Items.Add(s);
			}
			listComputers.SelectedIndex=0;
			_arraySigButDefs=SigButDefs.GetByComputer("");
			FillList();
		}

		private void FillList() {
			if(listComputers.SelectedIndex==-1) {//although I don't know how this could happen
				listComputers.SelectedIndex=0;
			}
			int selected=listButtons.SelectedIndex;
			listButtons.Items.Clear();
			SigButDef sigButDef;
			List<SigElementDef> listSigElementDefs;
			string buttonText;
			for(int i=0;i<_maxNumButtonsInList;i++) {
				sigButDef=SigButDefs.GetByIndex(i,_arraySigButDefs);
				if(sigButDef==null) {
					listButtons.Items.Add("-"+(i+1).ToString()+"-");
				}
				else {
					buttonText=sigButDef.ButtonText;
					listSigElementDefs=SigElementDefs.GetElementsForButDef(sigButDef);
					if(listSigElementDefs.Count > 0) {
						buttonText+=" ("+string.Join(",",listSigElementDefs.Select(x => x.SigText))+")";
					}
					if(sigButDef.ComputerName=="" && listComputers.SelectedIndex!=0) {
						buttonText+=" "+Lan.g(this,"(all)");
					}
					listButtons.Items.Add(buttonText);
				}
			}
		}

		private void listComputers_Click(object sender,EventArgs e) {
			//Cache needs to be saved to the database.
			if(SigButDefs.UpdateButtonIndexIfChanged(_arraySigButDefs)) {
				DataValid.SetInvalid(InvalidType.SigMessages);
			}
			if(listComputers.SelectedIndex==0) {
				_arraySigButDefs=SigButDefs.GetByComputer("");
			}
			else {
				//remember, defaults are mixed into this list unless overridden:
				_arraySigButDefs=SigButDefs.GetByComputer(_listComputers[listComputers.SelectedIndex-1].CompName);
			}
			FillList();
		}

		private void listButtons_DoubleClick(object sender,EventArgs e) {
			if(listButtons.SelectedIndex==-1) {//should never happen
				return;
			}
			//Save any changes to the cache because the item order could have changed.
			if(SigButDefs.UpdateButtonIndexIfChanged(_arraySigButDefs)) {
				DataValid.SetInvalid(InvalidType.SigMessages);
			}
			int selected=listButtons.SelectedIndex;
			SigButDef sigButDef=SigButDefs.GetByIndex(selected,_arraySigButDefs);
			//Keep track of the currently selected computer name so we know what computer buttons to refresh after making changes.
			string computerNameSelected=(listComputers.SelectedIndex > 0) ? _listComputers[listComputers.SelectedIndex-1].CompName : "";
			//Now create a new computer name variable that will represent the computer name for the SigButDef.
			string computerNameSigButDef="";
			if(sigButDef==null) {//Add
				sigButDef=new SigButDef();
				sigButDef.ButtonIndex=selected;
				if(listComputers.SelectedIndex!=0) {
					computerNameSigButDef=_listComputers[listComputers.SelectedIndex-1].CompName;
				}
				sigButDef.ComputerName=computerNameSigButDef;
				using FormSigButDefEdit FormS=new FormSigButDefEdit(sigButDef.Copy());
				FormS.IsNew=true;
				FormS.ShowDialog();
			}
			else if(sigButDef.ComputerName=="" && listComputers.SelectedIndex!=0) {
				//create a copy of the default, and treat it as a new
				sigButDef.ComputerName=_listComputers[listComputers.SelectedIndex-1].CompName;
				using FormSigButDefEdit FormS=new FormSigButDefEdit(sigButDef.Copy());
				FormS.IsNew=true;
				FormS.ShowDialog();
			}
			else {//edit
				if(listComputers.SelectedIndex>0) {//If "All" is selected, the computerName will already be blank, so it only needs reset if it isn't "All".
					computerNameSigButDef=_listComputers[listComputers.SelectedIndex-1].CompName;
				}
				using FormSigButDefEdit FormS=new FormSigButDefEdit(sigButDef.Copy());
				FormS.ShowDialog();
			}
			//Refresh our local list to match the cache in case the user edited or added a new button item.
			_arraySigButDefs=SigButDefs.GetByComputer(computerNameSelected);
			FillList();
		}

		private void butSynchAll_Click(object sender,EventArgs e) {
			//Cache needs to be saved to the database just in case the user JUST made a change to the 'All' computer and hasn't clicked away yet.
			if(SigButDefs.UpdateButtonIndexIfChanged(_arraySigButDefs)) {
				DataValid.SetInvalid(InvalidType.SigMessages);
			}
			string strWarning="Synchronize the Buttons associated to the 'All' computer to phonecomp computers."
				+"\r\n1.) Verifies or creates a 'User Message Element' for every extension in the phonecomp table."
				+"\r\n2.) Propagates the Buttons for the 'All' Computer to every computer in the phonecomp table."
				+"\r\n  2a. Each Button (SigButDef) will utilize the message element from step 1 (SigElementDefNumUser)."
				+"\r\n  2b. The phonecomp rows are used in order to correctly tie these computers to their corresponding Buttons."
				+"\r\n3.) Delete any Buttons that were not associated to a 'User' that has a corresponding entry in the phonecomp table."
				+"\r\n"
				+"\r\nThis process could take a while and will most likely delete data. Continue?";
			if(!MsgBox.Show(MsgBoxButtons.OKCancel,strWarning)) {
				return;
			}
			try {
				ProgressOD progressOD=new ProgressOD();
				progressOD.ActionMain=SigButDefs.SynchTheAllComputerWithPhoneComps;
				progressOD.ShowDialogProgress();
				if(progressOD.IsCancelled) {
					MsgBox.Show(this,"User manually cancelled. The database has most likely been partially manipulated.");
					return;
				}
			}
			catch(Exception ex) {
				FriendlyException.Show("Critical error during the synchronization process. The database has most likely been partially manipulated.",ex);
			}
			DataValid.SetInvalid(InvalidType.SigMessages);
			Reinitialize();
			MsgBox.Show(this,"Done");
		}

		private void butUp_Click(object sender,EventArgs e) {
			if(listButtons.SelectedIndex==-1) {
				MsgBox.Show(this,"Please select an item first.");
				return;
			}
			int selected=listButtons.SelectedIndex;
			if(selected==0) {
				return;
			}
			SigButDef button=SigButDefs.GetByIndex(selected,_arraySigButDefs);
			if(button==null) {
				return;
			}
			_arraySigButDefs=SigButDefs.MoveUp(button,_arraySigButDefs);
			FillList();
			listButtons.SelectedIndex=selected-1;
		}

		private void butDown_Click(object sender,EventArgs e) {
			if(listButtons.SelectedIndex==-1) {
				MsgBox.Show(this,"Please select an item first.");
				return;
			}
			int selected=listButtons.SelectedIndex;
			if(selected==listButtons.Items.Count-1) {
				return;
			}
			SigButDef button=SigButDefs.GetByIndex(selected,_arraySigButDefs);
			if(button==null) {
				return;
			}
			if(button.ButtonIndex==_maxNumButtonsInList-1) {
				MsgBox.Show(this,$"No more than {_maxNumButtonsInList} buttons are allowed.");
				return;
			}
			_arraySigButDefs=SigButDefs.MoveDown(button,_arraySigButDefs);
			FillList();
			listButtons.SelectedIndex=selected+1;
		}

		private void butClose_Click(object sender, System.EventArgs e) {
			Close();
		}

		private void FormMessagingButSetup_FormClosing(object sender,FormClosingEventArgs e) {
			SigButDefs.UpdateButtonIndexIfChanged(_arraySigButDefs);
			DataValid.SetInvalid(InvalidType.SigMessages);
		}

		

		

		

		

	

		


	}
}





















