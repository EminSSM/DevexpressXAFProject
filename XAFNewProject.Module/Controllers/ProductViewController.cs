using DevExpress.Charts.Model;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using XAFInvoiceProject.Module.BusinessObjects.PurchaseManagement;
using XAFInvoiceProject.Module.BusinessObjects.StockManagement;
using XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement;
using XAFInvoicesProject.Module.BusinessObjects.StockManagement;

namespace XAFNewProject.Module.Controllers
{

	public partial class ProductViewController : ViewController
	{
		private XPObjectSpace controllerOS;

		public ProductViewController()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			// Perform various tasks depending on the target View.
		}
		protected override void OnViewControlsCreated()
		{
			base.OnViewControlsCreated();
			// Access and customize the target View control.
		}
		protected override void OnDeactivated()
		{
			// Unsubscribe from previously subscribed events and release other references and resources.
			base.OnDeactivated();
		}

		private void StockCurrentList_Execute(object sender, SimpleActionExecuteEventArgs e)
		{
			controllerOS = (XPObjectSpace)View.ObjectSpace;
			Product product = controllerOS.GetObject(e.CurrentObject) as Product;
			if (product != null)
			{
				CollectionSourceBase cs = Application.CreateCollectionSource(controllerOS, typeof(StockTrx), "StockTrx_ListView_ProductList");
				cs.Criteria["filter"] = CriteriaOperator.Parse("Product.Oid == ?", product.Oid);
				if (cs.List.Count > 0)
				{
					e.ShowViewParameters.CreatedView = Application.CreateListView("StockTrx_ListView_ProductList", cs, false);
					e.ShowViewParameters.CreatedView.Caption = product.Name + "Ürün Giriş Çıkış Listesi";
					e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;
				}

			}

		}

	}
}