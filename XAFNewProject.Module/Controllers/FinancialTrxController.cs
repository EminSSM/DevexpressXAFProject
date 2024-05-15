using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Utils;
using DevExpress.Xpo;
using XAFInvoiceProject.Module.BusinessObjects.PurchaseManagement;
using XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement;
using XAFNewProject.Module.BusinessObjects.NonPersistant;
using XAFNewProject.Module.BusinessObjects.PurchaseManagement;

namespace XAFNewProject.Module.Controllers
{

    public partial class FinancialTrxController : ViewController
    {
        private XPObjectSpace controllerOS;

        public FinancialTrxController()
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

        private void XPView_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(FinancialNonPersistent));
            controllerOS = (XPObjectSpace)View.ObjectSpace;
            CollectionSourceBase cs = Application.CreateCollectionSource(objectSpace, typeof(FinancialNonPersistent), "FinancialNonPersistent_ListView");

            FinancialTrx finans = controllerOS.GetObject(e.CurrentObject) as FinancialTrx;
            //cs.Criteria["filter"] = CriteriaOperator.Parse("Customer.Oid == ?", finans.Customer.Oid);
             
            XPView xpView = new XPView(((XPObjectSpace)ObjectSpace).Session, typeof(FinancialTrx));
            xpView.AddProperty("Customer", "Customer", true);
            xpView.AddProperty("Credit", "Credit", true);
            xpView.AddProperty("Debit", "Debit", true);
            xpView.Criteria = CriteriaOperator.Parse("Customer.Oid == ?", finans.Customer.Oid);

            decimal total = 0;
            if (xpView.Count > 0)
            {
                foreach (ViewRecord record in xpView)
                {

                    FinancialNonPersistent fin = new FinancialNonPersistent();
                    decimal totalBalance = (decimal)record["Credit"] - (decimal)record["Debit"];

                    total += totalBalance;

                    fin.Customer = finans.Customer;
                    fin.Credit = (decimal)record["Credit"];
                    fin.Debit = (decimal)record["Debit"];
                    fin.Balance = total;
                    cs.Add(fin);


                }
                e.ShowViewParameters.CreatedView = Application.CreateListView("FinancialNonPersistent_ListView", cs, false);
                e.ShowViewParameters.CreatedView.Caption ="Müşteri Cari Listesi";
                e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;
            }
       
        }

    }

}

