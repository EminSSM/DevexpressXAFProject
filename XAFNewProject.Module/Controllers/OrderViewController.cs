using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates.ActionControls;
using DevExpress.ExpressApp.Xpo;
using System.ComponentModel;
using XAFInvoiceProject.Module.BusinessObjects.PurchaseManagement;
using XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement;
using XAFOrdersProject.Module.BusinessObjects.PurchaseManagement;

namespace XAFInvoicesProject.Module.Controllers
{

    public partial class OrderViewController : ViewController
    {
        private XPObjectSpace controllerOS;

        public OrderViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();

        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
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
            base.OnDeactivated();
            {

            }
        }


    private void CreateInvoice_Execute(object sender, DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs e)
        {
            try
            {
                Order selectedDocument = View.CurrentObject as Order;

                controllerOS = (XPObjectSpace)View.ObjectSpace;

                //var existingFatura = ObjectSpace.FindObject<Order>(CriteriaOperator.Parse("OrderNo = ?", selectedDocument));

                if (selectedDocument.IsOrderCreated == false)
                {

                    Invoice invoice = new Invoice(controllerOS.Session);
                    invoice.Customer = selectedDocument.Customer;
                    invoice.InvoiceNo = selectedDocument.OrderNo;
                    invoice.TaxNo = selectedDocument.TaxNo;
                    invoice.TaxOffice = selectedDocument.TaxOffice;
                    invoice.PaymentType = selectedDocument.PaymentType;


                    foreach (var item in selectedDocument.OrderItems)
                    {
                        InvoiceItem invoiceitem = new InvoiceItem(controllerOS.Session);

                        invoiceitem.Product = item.Product;
                        invoiceitem.Piece = item.Piece;
                        invoiceitem.Product.UnitPrice = item.Product.UnitPrice;
                        invoiceitem.Product.VatDefinition.VatRate = item.Product.VatDefinition.VatRate;

                        invoice.InvoiceItems.Add(invoiceitem);
                        invoice.Save();


                    }
                    selectedDocument.IsOrderCreated = true;
                    controllerOS.CommitChanges();
                }
                //else
                //{
                //    throw new Exception("Bu siparişin faturası oluşmuştur.");
                //}
                View.Refresh();

            }
            catch (Exception ex)
            {

                controllerOS.Rollback();
                View.Refresh();
                throw new UserFriendlyException(ex.Message);
            }
        }
    }
}
