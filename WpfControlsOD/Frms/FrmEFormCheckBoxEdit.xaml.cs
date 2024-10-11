using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OpenDentBusiness;
using WpfControls;
using WpfControls.UI;

namespace OpenDental {
	/// <summary>The editor is for the EFormField even though we're really editing the EFormFieldDef. This editor is not patient facing.</summary>
	public partial class FrmEFormCheckBoxEdit : FrmODBase {
		///<summary>This is the object being edited.</summary>
		public EFormField EFormFieldCur;
		///<summary>We need access to a few other fields of the EFormDef.</summary>
		public EFormDef EFormDefCur;
		///<summary>Siblings</summary>
		public List<EFormField> ListEFormFields;
		///<summary>Set this before opening this window. It's the current language being used in the parent form. Format is the text that's showing in the comboBox. Will be empty string if languages are not set up in pref LanguagesUsedByPatients or if the default language is being used in the parent FrmEFormDefs.</summary>
		public string LanguageShowing="";
		///<summary>This is all sibings in a horizontal stack, not including the field passed in. If not in a h-stack, then this is an empty list. Even if the current field is not stacking, it can be part of a stack group if the next field is set as stacking. So this list gets recalculated each time the user checks or unchecks the stacking box. If this is a new field, then it is not yet in the list, but we do know where it will potientially go, based on IdxNew, and that's what we use to create this list.</summary>
		private List<EFormField> _listEFormFieldsSiblings;
		///<summary>We don't fire off a signal to update the language cache on other computers until we hit Save in the form window. So each edit window has this variable to keep track of whether there are any new translations. This bubbles up to the parent.</summary>
		public bool IsChangedLanCache;
		private bool _alreadyAsked;

		///<summary></summary>
		public FrmEFormCheckBoxEdit() {
			InitializeComponent();
			Load+=FrmEFormsCheckBoxEdit_Load;
			PreviewKeyDown+=FrmEFormCheckBoxEdit_PreviewKeyDown;
			comboDbLink.SelectionTrulyChanged+=ComboDbLink_SelectionTrulyChanged;
			textMedAllerProb.LostKeyboardFocus+=TextMedAllerProb_LostKeyboardFocus;
			checkIsWidthPercentage.Click+=CheckIsWidthPercentage_Click;
			checkIsHorizStacking.Click+=CheckIsHorizStacking_Click;
		}

		private void FrmEFormsCheckBoxEdit_Load(object sender, EventArgs e) {
			Lang.F(this);
			if(LanguageShowing==""){
				groupLanguage.Visible=false;
			}
			else{
				textLanguage.Text=LanguageShowing;
				textLabelTranslated.Text=LanguagePats.TranslateEFormField(EFormFieldCur.EFormFieldDefNum,LanguageShowing,EFormFieldCur.ValueLabel);
			}
			textLabel.Text=EFormFieldCur.ValueLabel;
			List<string> listAvailCheckBox=EFormFieldsAvailable.GetList_CheckBox();
			comboDbLink.Items.AddList(listAvailCheckBox);
			if(EFormFieldCur.DbLink==""){//None
				comboDbLink.SelectedIndex=0;
			}
			else if(EFormFieldCur.DbLink.StartsWith("allergy:")){
				comboDbLink.SelectedItem="allergy:";
				textMedAllerProb.Text=EFormFieldCur.DbLink.Substring(8);
			}
			else if(EFormFieldCur.DbLink.StartsWith("problem:")){
				comboDbLink.SelectedItem="problem:";
				textMedAllerProb.Text=EFormFieldCur.DbLink.Substring(8);
			}
			else{
				comboDbLink.SelectedItem=EFormFieldCur.DbLink;
			}
			SetVisAllerProb();
			checkIsHorizStacking.Checked=EFormFieldCur.IsHorizStacking;
			bool isPreviousStackable=EFormFields.IsPreviousStackable(EFormFieldCur,ListEFormFields);
			if(!isPreviousStackable){
				labelStackable.Text="previous field is not stackable";
				checkIsHorizStacking.IsEnabled=false;
			}
			checkIsRequired.Checked=EFormFieldCur.IsRequired;
			textVIntWidth.Value=EFormFieldCur.Width;
			if(EFormFieldCur.IsWidthPercentage){
				checkIsWidthPercentage.Checked=true;
				textVIntMinWidth.Value=EFormFieldCur.MinWidth;
			}
			else{
				labelMinWidth.Visible=false;
				textVIntMinWidth.Visible=false;
			}
			_listEFormFieldsSiblings=EFormFields.GetSiblingsInStack(EFormFieldCur,ListEFormFields,checkIsHorizStacking.Checked==true);
			//this is just for loading. It will recalc each time CheckIsHorizStacking_Click is raised.
			if(_listEFormFieldsSiblings.Count==0){
				labelWidthIsPercentageNote.Visible=false;
			}
			checkBorder.Checked=EFormFieldCur.Border==EnumEFormBorder.ThreeD;
			textVIntFontScale.Value=EFormFieldCur.FontScale;
			bool isLastInHorizStack=EFormFields.IsLastInHorizStack(EFormFieldCur,ListEFormFields);
			if(isLastInHorizStack){
				int spaceBelowDefault=PrefC.GetInt(PrefName.EformsSpaceBelowEachField);
				labelSpaceDefault.Text=Lang.g(this,"leave blank to use the default value of ")+spaceBelowDefault.ToString();
				if(EFormFieldCur.SpaceBelow==-1){
					textSpaceBelow.Text="";
				}
				else{
					textSpaceBelow.Text=EFormFieldCur.SpaceBelow.ToString();
				}
			}
			else{
				labelSpaceDefault.Text=Lang.g(this,"only the right-most field in this row may be set");
				textSpaceBelow.IsEnabled=false;
			}
			textReportableName.Text=EFormFieldCur.ReportableName;
			checkIsLocked.Checked=EFormFieldCur.IsLocked;
			textCondParent.Text=EFormFieldCur.ConditionalParent;
			textCondValue.Text=EFormL.ConvertCondDbToVis(ListEFormFields,EFormFieldCur.ConditionalParent,EFormFieldCur.ConditionalValue);
			List<EFormField> listEFormFieldsChildren=ListEFormFields.FindAll(
				x=>x.ConditionalParent==EFormFieldCur.ValueLabel.Substring(0,Math.Min(EFormFieldCur.ValueLabel.Length,255))
				&& x.ConditionalParent!="" //for a new checkbox, ValueLabel might be blank
			);
			textCountChildren.Text=listEFormFieldsChildren.Count.ToString();
		}

		private void ComboDbLink_SelectionTrulyChanged(object sender,EventArgs e) {
			if((string)comboDbLink.SelectedItem=="allergy:"){
				FormLauncher formLauncher=new FormLauncher(EnumFormName.FormAllergySetup);
				formLauncher.SetField("IsSelectionMode",true);
				formLauncher.ShowDialog();
				if(formLauncher.IsDialogCancel){
					textMedAllerProb.Text="";
					SetVisAllerProb();
					textMedAllerProb.Focus();
					return;
				}
				long allergyDefNumSelected=formLauncher.GetField<long>("AllergyDefNumSelected");
				AllergyDef allergyDef=AllergyDefs.GetOne(allergyDefNumSelected);//from db
				textMedAllerProb.Text=allergyDef.Description;
				textLabel.Text=allergyDef.Description;
				SetVisAllerProb();
				textMedAllerProb.Focus();
				return;
			}
			if((string)comboDbLink.SelectedItem=="problem:"){
				FormLauncher formLauncher=new FormLauncher(EnumFormName.FormDiseaseDefs);
				formLauncher.SetField("IsSelectionMode",true);
				formLauncher.ShowDialog();
				if(formLauncher.IsDialogCancel){
					textMedAllerProb.Text="";
					SetVisAllerProb();
					textMedAllerProb.Focus();
					return;
				}
				DiseaseDef diseaseDef=formLauncher.GetField<List<DiseaseDef>>("ListDiseaseDefsSelected")[0];
				textMedAllerProb.Text=diseaseDef.DiseaseName;
				textLabel.Text=diseaseDef.DiseaseName;
				SetVisAllerProb();
				textMedAllerProb.Focus();
				return;
			}
			//all others
			if(textLabel.Text==""){
				textLabel.Text=(string)comboDbLink.SelectedItem;
			}
			SetVisAllerProb();
		}

		private void butChange_Click(object sender,EventArgs e) {
			if((string)comboDbLink.SelectedItem=="allergy:"){
				FormLauncher formLauncher=new FormLauncher(EnumFormName.FormAllergySetup);
				formLauncher.SetField("IsSelectionMode",true);
				formLauncher.ShowDialog();
				if(formLauncher.IsDialogCancel){
					textMedAllerProb.Text="";
					SetVisAllerProb();
					textMedAllerProb.Focus();
					return;
				}
				long allergyDefNumSelected=formLauncher.GetField<long>("AllergyDefNumSelected");
				AllergyDef allergyDef=AllergyDefs.GetOne(allergyDefNumSelected);
				textMedAllerProb.Text=allergyDef.Description;
				textLabel.Text=allergyDef.Description;
				SetVisAllerProb();
				textMedAllerProb.Focus();
				return;
			}
			if((string)comboDbLink.SelectedItem=="problem:"){
				FormLauncher formLauncher=new FormLauncher(EnumFormName.FormDiseaseDefs);
				formLauncher.SetField("IsSelectionMode",true);
				formLauncher.ShowDialog();
				if(formLauncher.IsDialogCancel){
					textMedAllerProb.Text="";
					SetVisAllerProb();
					textMedAllerProb.Focus();
					return;
				}
				DiseaseDef diseaseDef=formLauncher.GetField<List<DiseaseDef>>("ListDiseaseDefsSelected")[0];
				textMedAllerProb.Text=diseaseDef.DiseaseName;
				textLabel.Text=diseaseDef.DiseaseName;
				SetVisAllerProb();
				textMedAllerProb.Focus();
				return;
			}
			//all others:
			SetVisAllerProb();
		}

		private void TextMedAllerProb_LostKeyboardFocus(object sender,KeyboardFocusChangedEventArgs e) {
			//AskChangeLabelToMatch();
			//This was too annoying.
			//Lots of edge cases where I couldn't suppress it properly
		}

		private void AskChangeLabelToMatch(){
			if(textMedAllerProb.Text==textLabel.Text){
				return;
			}
			if(textMedAllerProb.Text==""){
				return;
			}
			if(_alreadyAsked){
				return;
			}
			string str= "";
			if((string)comboDbLink.SelectedItem=="allergy:") {
				str="allergy";
			}
			else if((string)comboDbLink.SelectedItem=="problem:"){
				str="problem";
			}
			else{
				return;
			}
			_alreadyAsked=true;
			if(!MsgBox.Show(MsgBoxButtons.YesNo,"Change label to match "+str+"?")){
				return;
			}
			textLabel.Text=textMedAllerProb.Text;
		}

		///<summary>This sets visibility based on selected index of comboDbLink.</summary>
		private void SetVisAllerProb(){
			if((string)comboDbLink.SelectedItem=="allergy:"){
				labelAllergProb.Visible=true;
				textMedAllerProb.Visible=true;
				butChange.Visible=true;
				labelAllergProb.Text="Allergy";
				checkIsRequired.Visible=false;
				return;
			}
			if((string)comboDbLink.SelectedItem=="problem:"){
				labelAllergProb.Visible=true;
				textMedAllerProb.Visible=true;
				butChange.Visible=true;
				labelAllergProb.Text="Problem";
				checkIsRequired.Visible=false;
				return;
			}
			//all others
			labelAllergProb.Visible=false;
			textMedAllerProb.Visible=false;
			butChange.Visible=false;
			textMedAllerProb.Text="";
			checkIsRequired.Visible=true;
		}

		private void butDelete_Click(object sender,EventArgs e) {
			//no need to verify with user because they have another chance to cancel in the parent window.
			//delete and cancel of a new field are equivalent.
			//We handle cancel outside this window, so we will also handle delete outside this window.
			//If not new, it won't get immediately deleted because they might not eventually click Save on the form itself.
			EFormFieldCur.IsDeleted=true;
			//if(EFormFieldCur.IsNew//not sure if this is needed.
			//if the field to the right is stacked and this one is not, then change the field to the right to not be stacked.
			int idx=ListEFormFields.IndexOf(EFormFieldCur);
			if(idx<ListEFormFields.Count-1 
				&& !ListEFormFields[idx].IsHorizStacking
				&& ListEFormFields[idx+1].IsHorizStacking)
			{
				ListEFormFields[idx+1].IsHorizStacking=false;
			}
			IsDialogOK=true;
		}

		private void CheckIsHorizStacking_Click(object sender,EventArgs e) {
			_listEFormFieldsSiblings=EFormFields.GetSiblingsInStack(EFormFieldCur,ListEFormFields,checkIsHorizStacking.Checked==true);
			if(_listEFormFieldsSiblings.Count>0){
				labelWidthIsPercentageNote.Visible=true;
			}
			else{
				labelWidthIsPercentageNote.Visible=false;
			}
		}

		private void CheckIsWidthPercentage_Click(object sender,EventArgs e) {
			if(checkIsWidthPercentage.Checked==true){
				labelMinWidth.Visible=true;
				textVIntMinWidth.Visible=true;
			}
			else{
				labelMinWidth.Visible=false;
				textVIntMinWidth.Visible=false;
			}
		}

		private void butPickParent_Click(object sender,EventArgs e) {
			FrmEFormFieldPicker frmEFormFieldPicker=new FrmEFormFieldPicker();
			frmEFormFieldPicker.ListEFormFields=ListEFormFields;
			int idx=ListEFormFields.IndexOf(EFormFieldCur);
			frmEFormFieldPicker.ListSelectedIndices.Add(idx);//Prevents self selection as parent
			frmEFormFieldPicker.ShowDialog();
			if(frmEFormFieldPicker.IsDialogCancel){
				return;
			}
			textCondParent.Text=frmEFormFieldPicker.ParentSelected;
		}

		private void butPickValue_Click(object sender,EventArgs e) {
			textCondValue.Text=EFormL.PickCondValue(ListEFormFields,textCondParent.Text,textCondValue.Text);
		}

		private void FrmEFormCheckBoxEdit_PreviewKeyDown(object sender,KeyEventArgs e) {
			if(butSave.IsAltKey(Key.S,e)) {
				butSave_Click(this,new EventArgs());
			}
		}

		private void butSave_Click(object sender, EventArgs e) {
			AskChangeLabelToMatch();
			if(!textVIntWidth.IsValid()
				|| !textVIntMinWidth.IsValid()
				|| !textVIntFontScale.IsValid())
			{
				MsgBox.Show("Please fix entry errors first.");
				return;
			}
			if(textMedAllerProb.Text==""){
				if((string)comboDbLink.SelectedItem=="allergy:"){
					MsgBox.Show("Please enter an allergy name first.");
					return;
				}
				if((string)comboDbLink.SelectedItem=="problem:"){
					MsgBox.Show("Please enter a problem name first.");
					return;
				}
			}
			int spaceBelow=-1;
			if(textSpaceBelow.Text!=""){
				try{
					spaceBelow=Convert.ToInt32(textSpaceBelow.Text);
				}
				catch{
					MsgBox.Show(this,"Please fix error in Space Below first.");
					return;
				}
				if(spaceBelow<0 || spaceBelow>200){
					MsgBox.Show(this,"Space Below value is invalid.");
					return;
				}
			}
			//end of validation
			if(LanguageShowing!=""){
				IsChangedLanCache=LanguagePats.SaveTranslationEFormField(EFormFieldCur.EFormFieldDefNum,LanguageShowing,textLabelTranslated.Text);
				if(IsChangedLanCache){
					LanguagePats.RefreshCache();
				}
			}
			EFormFieldCur.ValueLabel=textLabel.Text;
			if(comboDbLink.SelectedIndex==0){//None
				EFormFieldCur.DbLink="";
			}
			else if((string)comboDbLink.SelectedItem=="allergy:"){
				EFormFieldCur.DbLink="allergy:"+textMedAllerProb.Text;
			}
			else if((string)comboDbLink.SelectedItem=="problem:"){
				EFormFieldCur.DbLink="problem:"+textMedAllerProb.Text;
			}
			else{
				EFormFieldCur.DbLink=(string)comboDbLink.SelectedItem;
			}
			EFormFieldCur.IsHorizStacking=checkIsHorizStacking.Checked==true;
			EFormFieldCur.IsRequired=checkIsRequired.Checked==true && checkIsRequired.Visible;
			EFormFieldCur.Width=textVIntWidth.Value;
			EFormFieldCur.IsWidthPercentage=checkIsWidthPercentage.Checked==true;
			//change all siblings to match
			_listEFormFieldsSiblings=EFormFields.GetSiblingsInStack(EFormFieldCur,ListEFormFields,checkIsHorizStacking.Checked==true);
			for(int i=0;i<_listEFormFieldsSiblings.Count;i++){
				_listEFormFieldsSiblings[i].IsWidthPercentage=EFormFieldCur.IsWidthPercentage;
			}
			if(textVIntMinWidth.Visible){
				EFormFieldCur.MinWidth=textVIntMinWidth.Value;
			}
			else{
				EFormFieldCur.MinWidth=0;
			}
			if(checkBorder.Checked==true){
				EFormFieldCur.Border=EnumEFormBorder.ThreeD;
			}
			else{
				EFormFieldCur.Border=EnumEFormBorder.None;
			}
			EFormFieldCur.FontScale=textVIntFontScale.Value;
			EFormFieldCur.SpaceBelow=spaceBelow;
			EFormFieldCur.ReportableName=textReportableName.Text;
			EFormFieldCur.IsLocked=checkIsLocked.Checked==true;
			EFormFieldCur.ConditionalParent=textCondParent.Text;
			EFormField eFormFieldParent=ListEFormFields.Find(x=>x.ValueLabel==EFormFieldCur.ConditionalParent);
			EFormFieldCur.ConditionalValue=EFormL.ConvertCondVisToDb(ListEFormFields,textCondParent.Text,textCondValue.Text);
			//not saved to db here. That happens when clicking Save in parent window.
			IsDialogOK=true;
		}

		
	}
}