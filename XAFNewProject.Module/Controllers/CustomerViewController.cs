using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using XAFInvoiceProject.Module.BusinessObjects.PurchaseManagement;
using XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement;

namespace XAFNewProject.Module.Controllers
{
    public partial class CustomerViewController : ViewController
    {
        private XPObjectSpace currentOS;

        public CustomerViewController()
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

            base.OnDeactivated();
        }

        private void FinancialCurrentAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            currentOS = (XPObjectSpace)View.ObjectSpace;
            Customer customer = currentOS.GetObject(e.CurrentObject) as Customer;
            if (customer != null) 
            {
                CollectionSourceBase cs = Application.CreateCollectionSource(currentOS, typeof(FinancialTrx), "FinancialTrx_ListView_CustomerList");
                cs.Criteria["filter"] = CriteriaOperator.Parse("Customer.Oid == ?", customer.Oid);
                if (cs.List.Count>0)
                {
                    e.ShowViewParameters.CreatedView = Application.CreateListView("FinancialTrx_ListView_CustomerList", cs, false);
                    e.ShowViewParameters.CreatedView.Caption = customer.Name + "Müşteri Cari Listesi";
                    e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;
                }
               
            }


        }
    }
}
