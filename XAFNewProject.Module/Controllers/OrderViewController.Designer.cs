namespace XAFInvoicesProject.Module.Controllers
{
    partial class OrderViewController
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
            this.CreateInvoice = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            //
            //Sales Order
            //
            this.CreateInvoice.Caption = "Created Invoice";
            this.CreateInvoice.Category = "View";
            this.CreateInvoice.ConfirmationMessage = null;
            this.CreateInvoice.Id = "CreateInvoice";
            this.CreateInvoice.ImageName = "BO_Validation"; ;
            this.CreateInvoice.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.CreateInvoice.ToolTip = null;
            this.CreateInvoice.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.CreateInvoice_Execute);

            this.TargetViewId = "Order_ListView;Order_DetailView";
            this.Actions.Add(this.CreateInvoice);

        }


        private DevExpress.ExpressApp.Actions.SimpleAction CreateInvoice;
        #endregion
    }
}
