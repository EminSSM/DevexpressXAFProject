using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

//namespace XAFNewProject.Module.BusinessObjects.LanguageSettings
//{
//	//[DefaultClassOptions]
//	//[DomainComponent, Serializable]
//	//[System.ComponentModel.DisplayName("Log In")]
//	//public class CustomLogonParameters : INotifyPropertyChanged
//	//{
//	//	private Language _Language;
//	//	private ApplicationUser _applicationUser;
//	//	private string password;

//	//	[ImmediatePostData]
//	//	public Language Language
//	//	{
//	//		get { return _Language; }
//	//		set
//	//		{
//	//			if (value == _Language) return;
//	//			_Language = value;
//	//			if (ApplicationUser?.Language != _Language)
//	//			{
//	//				ApplicationUser = null;
//	//			}
//	//			OnPropertyChanged(nameof(Language));
//	//		}
//	//	}
//	//	[DataSourceProperty("Language.ApplicationUsers"), ImmediatePostData]
//	//	public ApplicationUser ApplicationUser
//	//	{
//	//		get { return _applicationUser; }
//	//		set
//	//		{
//	//			if (value == _applicationUser) return;
//	//			_applicationUser = value;
//	//			Language = _applicationUser?.Language;
//	//			UserName = _applicationUser?.UserName;
//	//			OnPropertyChanged(nameof(ApplicationUser));
//	//		}
//	//	}
//	//	[Browsable(false)]
//	//	public String UserName { get; set; }
//	//	[PasswordPropertyText(true)]
//	//	public string Password
//	//	{
//	//		get { return password; }
//	//		set
//	//		{
//	//			if (password == value) return;
//	//			password = value;
//	//		}
//	//	}

//	//	private void OnPropertyChanged(string propertyName)
//	//	{
//	//		if (PropertyChanged != null)
//	//		{
//	//			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
//	//		}
//	//	}
//	//	public event PropertyChangedEventHandler PropertyChanged;

//	//	public void RefreshPersistentObjects(IObjectSpace objectSpace)
//	//	{
//	//		ApplicationUser = (UserName == null) ? null : objectSpace.FirstOrDefault<ApplicationUser>(e => e.UserName == UserName);
//	//	}

//	//}
