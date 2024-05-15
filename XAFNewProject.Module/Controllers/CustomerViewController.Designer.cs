namespace XAFNewProject.Module.Controllers
{
    partial class CustomerViewController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FinancialCurrentAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            //
            //Current Action
            //
            this.FinancialCurrentAction.Caption = "Financial Current Action";
            this.FinancialCurrentAction.Category = "RecordsNavigation";
            this.FinancialCurrentAction.ConfirmationMessage = null;
            this.FinancialCurrentAction.Id = "FinancialCurrentAction";
            this.FinancialCurrentAction.ImageName = "BO_Task"; ;
            this.FinancialCurrentAction.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.FinancialCurrentAction.ToolTip = null;
            this.FinancialCurrentAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.FinancialCurrentAction_Execute);

            this.TargetViewId = "Customer_ListView;Customer_DetailView";
            this.Actions.Add(this.FinancialCurrentAction);

            this.components = new System.ComponentModel.Container();
        }

        private DevExpress.ExpressApp.Actions.SimpleAction FinancialCurrentAction;

        #endregion
    }
}
