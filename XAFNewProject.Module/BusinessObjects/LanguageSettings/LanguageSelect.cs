using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.Security;

//namespace XAFNewProject.Module.BusinessObjects.LanguageSettings
//{
//    public class LanguageSelect : AuthenticationBase, IAuthenticationStandard
//	{
//    //    private CustomLogonParameters customLogonParameters;
//    //    private XPObjectSpace _XPObjectSpace;
//    //    public LanguageSelect()
//    //    {
//    //        customLogonParameters = new LanguageSelect();
//    //    }
//    //    public override void Logoff()
//    //    {
//    //        base.Logoff();
//    //        customLogonParameters = new CustomLogonParameters();
//    //    }
//    //    public override void ClearSecuredLogonParameters()
//    //    {
//    //        customLogonParameters.Password = "";
//    //        base.ClearSecuredLogonParameters();
//    //    }
//    //    public override object Authenticate(IObjectSpace objectSpace)
//    //    {
//    //        customLogonParameters.UserName = "Admin";


//    //        ApplicationUser applicationUser = objectSpace.FirstOrDefault<ApplicationUser>(e => e.UserName == customLogonParameters.UserName);


//    //        //if (applicationUser == null)

//    //        //    throw new ArgumentNullException("ApplicationUser");

//    //        //if (!((IAuthenticationStandardUser)applicationUser).ComparePassword(customLogonParameters.Password))
//    //        //    throw new AuthenticationException(
//    //        //        applicationUser.UserName, "Password mismatch.");

//    //        return applicationUser;
//    //    }

//    //    public override void SetLogonParameters(object logonParameters)
//    //    {
//    //        customLogonParameters = (CustomLogonParameters)logonParameters;
//    //    }

//    //    public override IList<Type> GetBusinessClasses()
//    //    {
//    //        return new Type[] { typeof(CustomLogonParameters) };
//    //    }
//    //    public override bool AskLogonParametersViaUI
//    //    {
//    //        get { return true; }
//    //    }
//    //    public override object LogonParameters
//    //    {
//    //        get { return customLogonParameters; }
//    //    }
//    //    public override bool IsLogoffEnabled
//    //    {
//    //        get { return true; }
//    //    }
//    //}
//}
