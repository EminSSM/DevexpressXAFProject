namespace XAFNewProject.Module.Controllers
{
    partial class ProductViewController
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
			//
			//Stock Current Action
			//
			this.StockCurrentList = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);

			this.StockCurrentList.Caption = "Stock Current List";
			this.StockCurrentList.Category = "RecordsNavigation";
			this.StockCurrentList.ConfirmationMessage = null;
			this.StockCurrentList.Id = "StockCurrentList";
			this.StockCurrentList.ImageName = "BO_Task"; ;
			this.StockCurrentList.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
			this.StockCurrentList.ToolTip = null;
			this.StockCurrentList.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.StockCurrentList_Execute);

			this.TargetViewId = "Product_ListView;Product_DetailView";
			this.Actions.Add(this.StockCurrentList);

			this.components = new System.ComponentModel.Container();

		}

        private DevExpress.ExpressApp.Actions.SimpleAction DeleteProduct;
		private DevExpress.ExpressApp.Actions.SimpleAction CreateStockAction;
		private DevExpress.ExpressApp.Actions.SimpleAction StockCurrentList;



		#endregion

	}

}


