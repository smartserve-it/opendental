﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5466
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpenDental.DivvyConnect {
	using System.Runtime.Serialization;


	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization","3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Name="Postcard",Namespace="http://schemas.datacontract.org/2004/07/DivvyConnect.Services",IsReference=true)]
	public partial class Postcard:object,System.Runtime.Serialization.IExtensibleDataObject {

		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

		private System.DateTime AppointmentDateTimeField;

		private int DesignIDField;

		private string ExternalPostcardIDField;

		private string MessageField;

		private OpenDental.DivvyConnect.Recipient RecipientField;

		public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
			get {
				return this.extensionDataField;
			}
			set {
				this.extensionDataField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public System.DateTime AppointmentDateTime {
			get {
				return this.AppointmentDateTimeField;
			}
			set {
				this.AppointmentDateTimeField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public int DesignID {
			get {
				return this.DesignIDField;
			}
			set {
				this.DesignIDField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string ExternalPostcardID {
			get {
				return this.ExternalPostcardIDField;
			}
			set {
				this.ExternalPostcardIDField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Message {
			get {
				return this.MessageField;
			}
			set {
				this.MessageField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public OpenDental.DivvyConnect.Recipient Recipient {
			get {
				return this.RecipientField;
			}
			set {
				this.RecipientField = value;
			}
		}
	}

	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization","3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Name="Recipient",Namespace="http://schemas.datacontract.org/2004/07/DivvyConnect.Services",IsReference=true)]
	public partial class Recipient:object,System.Runtime.Serialization.IExtensibleDataObject {

		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

		private string Address1Field;

		private string Address2Field;

		private string CityField;

		private string ExternalRecipientIDField;

		private string NameField;

		private string StateField;

		private string ZipField;

		public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
			get {
				return this.extensionDataField;
			}
			set {
				this.extensionDataField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Address1 {
			get {
				return this.Address1Field;
			}
			set {
				this.Address1Field = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Address2 {
			get {
				return this.Address2Field;
			}
			set {
				this.Address2Field = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string City {
			get {
				return this.CityField;
			}
			set {
				this.CityField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string ExternalRecipientID {
			get {
				return this.ExternalRecipientIDField;
			}
			set {
				this.ExternalRecipientIDField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Name {
			get {
				return this.NameField;
			}
			set {
				this.NameField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string State {
			get {
				return this.StateField;
			}
			set {
				this.StateField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Zip {
			get {
				return this.ZipField;
			}
			set {
				this.ZipField = value;
			}
		}
	}

	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization","3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Name="Practice",Namespace="http://schemas.datacontract.org/2004/07/DivvyConnect.Services",IsReference=true)]
	public partial class Practice:object,System.Runtime.Serialization.IExtensibleDataObject {

		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

		private string Address1Field;

		private string Address2Field;

		private string CityField;

		private string CompanyField;

		private string EmailField;

		private string ExternalPracticeIDField;

		private string FaxField;

		private string NameField;

		private string PhoneField;

		private string StateField;

		private string WebURLField;

		private string ZipField;

		public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
			get {
				return this.extensionDataField;
			}
			set {
				this.extensionDataField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Address1 {
			get {
				return this.Address1Field;
			}
			set {
				this.Address1Field = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Address2 {
			get {
				return this.Address2Field;
			}
			set {
				this.Address2Field = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string City {
			get {
				return this.CityField;
			}
			set {
				this.CityField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Company {
			get {
				return this.CompanyField;
			}
			set {
				this.CompanyField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Email {
			get {
				return this.EmailField;
			}
			set {
				this.EmailField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string ExternalPracticeID {
			get {
				return this.ExternalPracticeIDField;
			}
			set {
				this.ExternalPracticeIDField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Fax {
			get {
				return this.FaxField;
			}
			set {
				this.FaxField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Name {
			get {
				return this.NameField;
			}
			set {
				this.NameField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Phone {
			get {
				return this.PhoneField;
			}
			set {
				this.PhoneField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string State {
			get {
				return this.StateField;
			}
			set {
				this.StateField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string WebURL {
			get {
				return this.WebURLField;
			}
			set {
				this.WebURLField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Zip {
			get {
				return this.ZipField;
			}
			set {
				this.ZipField = value;
			}
		}
	}

	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization","3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Name="PostcardReturnMessage",Namespace="http://schemas.datacontract.org/2004/07/DivvyConnect.Services")]
	public partial class PostcardReturnMessage:object,System.Runtime.Serialization.IExtensibleDataObject {

		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

		private string MessageField;

		private OpenDental.DivvyConnect.MessageCode MessageCodeField;

		private OpenDental.DivvyConnect.SinglePostcardMessage[] PostcardMessagesField;

		public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
			get {
				return this.extensionDataField;
			}
			set {
				this.extensionDataField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Message {
			get {
				return this.MessageField;
			}
			set {
				this.MessageField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public OpenDental.DivvyConnect.MessageCode MessageCode {
			get {
				return this.MessageCodeField;
			}
			set {
				this.MessageCodeField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public OpenDental.DivvyConnect.SinglePostcardMessage[] PostcardMessages {
			get {
				return this.PostcardMessagesField;
			}
			set {
				this.PostcardMessagesField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization","3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Name="MessageCode",Namespace="http://schemas.datacontract.org/2004/07/DivvyConnect.Services")]
	public enum MessageCode:int {

		[System.Runtime.Serialization.EnumMemberAttribute()]
		CompletedSucessfully = 0,

		[System.Runtime.Serialization.EnumMemberAttribute()]
		CompletedWithErrors = 1,

		[System.Runtime.Serialization.EnumMemberAttribute()]
		Failure = 2,
	}

	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization","3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Name="SinglePostcardMessage",Namespace="http://schemas.datacontract.org/2004/07/DivvyConnect.Services")]
	public partial class SinglePostcardMessage:object,System.Runtime.Serialization.IExtensibleDataObject {

		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

		private string MessageField;

		private OpenDental.DivvyConnect.PostcardCode postcardCodeField;

		private OpenDental.DivvyConnect.Postcard postcardRecordField;

		public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
			get {
				return this.extensionDataField;
			}
			set {
				this.extensionDataField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Message {
			get {
				return this.MessageField;
			}
			set {
				this.MessageField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public OpenDental.DivvyConnect.PostcardCode postcardCode {
			get {
				return this.postcardCodeField;
			}
			set {
				this.postcardCodeField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public OpenDental.DivvyConnect.Postcard postcardRecord {
			get {
				return this.postcardRecordField;
			}
			set {
				this.postcardRecordField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization","3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Name="PostcardCode",Namespace="http://schemas.datacontract.org/2004/07/DivvyConnect.Services")]
	public enum PostcardCode:int {

		[System.Runtime.Serialization.EnumMemberAttribute()]
		Successful = 0,

		[System.Runtime.Serialization.EnumMemberAttribute()]
		CardNotLoaded = 1,
	}


	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel","3.0.0.0")]
	[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IPostcardService")]
	public interface IPostcardService {

		[System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPostcardService/SendPostcards",ReplyAction="http://tempuri.org/IPostcardService/SendPostcardsResponse")]
		OpenDental.DivvyConnect.PostcardReturnMessage SendPostcards(System.Guid apiKey,string username,string password,OpenDental.DivvyConnect.Postcard[] postcards,OpenDental.DivvyConnect.Practice practice);
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel","3.0.0.0")]
	public interface IPostcardServiceChannel:IPostcardService,System.ServiceModel.IClientChannel {
	}

	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel","3.0.0.0")]
	public partial class PostcardServiceClient:System.ServiceModel.ClientBase<IPostcardService>,IPostcardService {

		public PostcardServiceClient() {
		}

		public PostcardServiceClient(string endpointConfigurationName) :
			base(endpointConfigurationName) {
		}

		public PostcardServiceClient(string endpointConfigurationName,string remoteAddress) :
			base(endpointConfigurationName,remoteAddress) {
		}

		public PostcardServiceClient(string endpointConfigurationName,System.ServiceModel.EndpointAddress remoteAddress) :
			base(endpointConfigurationName,remoteAddress) {
		}

		public PostcardServiceClient(System.ServiceModel.Channels.Binding binding,System.ServiceModel.EndpointAddress remoteAddress) :
			base(binding,remoteAddress) {
		}

		public OpenDental.DivvyConnect.PostcardReturnMessage SendPostcards(System.Guid apiKey,string username,string password,OpenDental.DivvyConnect.Postcard[] postcards,OpenDental.DivvyConnect.Practice practice) {
			return base.Channel.SendPostcards(apiKey,username,password,postcards,practice);
		}
	}

}