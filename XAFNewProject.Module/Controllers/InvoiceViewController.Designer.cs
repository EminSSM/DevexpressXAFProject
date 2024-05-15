namespace XAFInvoicesProject.Module.Controllers
{
    partial class InvoiceViewController
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
            this.CreateCurrentAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            //
            //Current Action
            //
            this.CreateCurrentAction.Caption = "Created Current Action";
            this.CreateCurrentAction.Category = "RecordsNavigation";
            this.CreateCurrentAction.ConfirmationMessage = null;
            this.CreateCurrentAction.Id = "CreateCurrentAction";
            this.CreateCurrentAction.ImageName = "BO_Report"; ;
            this.CreateCurrentAction.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.CreateCurrentAction.ToolTip = null;
            this.CreateCurrentAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.CreateCurrentAction_Execute);

            this.TargetViewId = "Invoice_ListView;Invoice_DetailView";
            this.Actions.Add(this.CreateCurrentAction);

            this.components = new System.ComponentModel.Container();
            ////
            //stock action 
            //
            this.CreateStockAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);

            this.CreateStockAction.Caption = "Created Stock Action";
            this.CreateStockAction.Category = "RecordsNavigation";
            this.CreateStockAction.ConfirmationMessage = null;
            this.CreateStockAction.Id = "CreateStockAction";
            this.CreateStockAction.ImageName = "BO_QUOTE"; ;
            this.CreateStockAction.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.CreateStockAction.ToolTip = null;
            this.CreateStockAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.CreateStockAction_Execute);

            this.TargetViewId = "Invoice_ListView;Invoice_DetailView";
            this.Actions.Add(this.CreateStockAction);

            //Delete Action Invoice and financialtrx
            this.DeleteInvoice = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);

            this.DeleteInvoice.Caption = "Delete Invoice";
            this.DeleteInvoice.Category = "Edit";
            this.DeleteInvoice.ConfirmationMessage = null;
            this.DeleteInvoice.Id = "DeleteInvoice";
            this.DeleteInvoice.ImageName = "del"; ;
            this.DeleteInvoice.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.DeleteInvoice.ToolTip = null;
            this.DeleteInvoice.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.DeleteInvoice_Execute);

            this.TargetViewId = "Invoice_ListView;Invoice_DetailView";
            this.Actions.Add(this.DeleteInvoice);
        }

        #endregion
        private DevExpress.ExpressApp.Actions.SimpleAction CreateCurrentAction;
        private DevExpress.ExpressApp.Actions.SimpleAction CreateStockAction;
        private DevExpress.ExpressApp.Actions.SimpleAction DeleteInvoice;




    }
}
