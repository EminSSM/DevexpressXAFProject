﻿namespace XAFNewProject.Module.Controllers
{
    partial class FinancialTrxController
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
            this.XPView = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            //
            //Current Action
            //
            this.XPView.Caption = "XPView Action";
            this.XPView.Category = "RecordsNavigation";
            this.XPView.ConfirmationMessage = null;
            this.XPView.Id = "XPViewAction";
            this.XPView.ImageName = "BO_Task"; ;
            this.XPView.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.XPView.ToolTip = null;
            this.XPView.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.XPView_Execute);

            this.TargetViewId = "FinancialTrx_ListView;FinancialTrx_DetailView";
            this.Actions.Add(this.XPView);

            this.components = new System.ComponentModel.Container();
        }

        private DevExpress.ExpressApp.Actions.SimpleAction XPView;
    }

       #endregion
    
}
