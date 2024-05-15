using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Templates.ActionControls;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XAFNewProject.Module.Controllers
{

	public partial class CategoryController : ViewController
	{
		private ActionControlsSiteController actionControlsSiteController = null;
		private FillActionContainersController fillActionsController = null;
		public CategoryController()
		{
			InitializeComponent();
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			actionControlsSiteController = Frame.GetController<ActionControlsSiteController>();
			if (actionControlsSiteController != null)
			{
				actionControlsSiteController.CustomAddActionControlToContainer += ActionControlsSiteController_CustomAddActionControlToContainer;
			}
			fillActionsController = Frame.GetController<FillActionContainersController>();
			if (fillActionsController != null)
			{
				fillActionsController.CustomRegisterActionInContainer += FillActionsController_CustomRegisterActionInContainer;
			}
		}
		private void DisableActionControlCreation(HandledEventArgs args, string actionId)
		{
			if (actionId == NewObjectViewController.NewActionId)
			{
				args.Handled = true;
			}
		}
		private void FillActionsController_CustomRegisterActionInContainer(object sender, CustomRegisterActionInContainerEventArgs e)
		{
			DisableActionControlCreation(e, e.Action.Id);
		}
		private void ActionControlsSiteController_CustomAddActionControlToContainer(object sender, CustomAddActionControlEventArgs e)
		{
			DisableActionControlCreation(e, e.Action.Id);
		}


		protected override void OnDeactivated()
		{
			if (actionControlsSiteController != null)
			{
				actionControlsSiteController.CustomAddActionControlToContainer -= ActionControlsSiteController_CustomAddActionControlToContainer;
			}
			if (fillActionsController != null)
			{
				fillActionsController.CustomRegisterActionInContainer -= FillActionsController_CustomRegisterActionInContainer;
			}
			base.OnDeactivated();

		}
	}
}
