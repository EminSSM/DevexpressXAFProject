using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using XAFInvoiceProject.Module.BusinessObjects.PurchaseManagement;
using XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement;
using XAFInvoicesProject.Module.BusinessObjects.StockManagement;
using static XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement.FinancialTrx;

namespace XAFInvoicesProject.Module.Controllers
{

	public partial class InvoiceViewController : ViewController
    {
        protected XPObjectSpace controllerOS;

        public InvoiceViewController()
        {
            InitializeComponent();

        }
        protected override void OnActivated()
        {
            base.OnActivated();


        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();

        }

        private void CreateCurrentAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            try
            {
                Invoice selectedDocument = View.CurrentObject as Invoice;
                controllerOS = (XPObjectSpace)View.ObjectSpace;

                if (selectedDocument.IsFinancialCreated == false)
                {
                    FinancialTrx financalTRX = new FinancialTrx(controllerOS.Session);


                    financalTRX.Customer = selectedDocument.Customer;
                    financalTRX.CreateDate = selectedDocument.CreatedDate;
                    financalTRX.FinancialType = selectedDocument.InvoiceType == InvoiceTypes.Sales ? FinancialTypes.Credit : FinancialTypes.Debit;
                    financalTRX.Invoice = selectedDocument;
                    financalTRX.Invoice.InvoiceNo = selectedDocument.InvoiceNo;



                    if (selectedDocument.InvoiceType == InvoiceTypes.Sales)
                    {
                        financalTRX.Credit = selectedDocument.TotalAmount;

                    }
                    else
                    {
                        financalTRX.Debit = selectedDocument.TotalAmount;
                    }


                    financalTRX.Credit = selectedDocument.InvoiceType == InvoiceTypes.Sales ? selectedDocument.TotalAmount : 0;
                    financalTRX.Debit = selectedDocument.InvoiceType == InvoiceTypes.Sales ? 0 : selectedDocument.TotalAmount;


                    financalTRX.Save();
                    selectedDocument.IsFinancialCreated = true;

                    controllerOS.CommitChanges();

                }
                View.Refresh();
            }

            catch (Exception ex)
            {
                controllerOS.Rollback();
                View.Refresh();
                throw new UserFriendlyException(ex.Message);

            }
        }
        private void CreateStockAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            try
            {
                Invoice selectedDocument = View.CurrentObject as Invoice;
                controllerOS = (XPObjectSpace)View.ObjectSpace;

                if (selectedDocument.IsStockCreated == false)
                {

                    foreach (var item in selectedDocument.InvoiceItems)
                    {
                        StockTrx stokTRX = new StockTrx(controllerOS.Session);

                        stokTRX.Invoice = selectedDocument;
                        stokTRX.Date = selectedDocument.CreatedDate;
                        stokTRX.StockActionType = selectedDocument.InvoiceType == InvoiceTypes.Sales ? StockActionType.Output : StockActionType.Entry;
                        stokTRX.Product = item.Product;

                        stokTRX.Output = selectedDocument.InvoiceType == InvoiceTypes.Sales ? item.Piece : 0;
                        stokTRX.Entry = selectedDocument.InvoiceType == InvoiceTypes.Sales ? 0 : item.Piece;

                        stokTRX.Save();
                    }
                    selectedDocument.IsStockCreated = true;

                    controllerOS.CommitChanges();
                }
                View.Refresh();

            }

            catch (Exception ex)
            {
                controllerOS.Rollback();
                View.Refresh();
                throw new UserFriendlyException(ex.Message);
            }


        }
        private void DeleteInvoice_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if ((View is ListView && View.SelectedObjects.Count > 0))
            {

                controllerOS = (XPObjectSpace)View.ObjectSpace;
                var financialTRX = controllerOS.Session.Query<FinancialTrx>();
				var stockkTRX = controllerOS.Session.Query<StockTrx>();

				foreach (var items in View.SelectedObjects)
                {
                    Invoice invoice = items as Invoice;

                    XPCollection<InvoiceItem> invoiceLines = new XPCollection<InvoiceItem>(controllerOS.Session);
                    invoiceLines.Filter = CriteriaOperator.Parse("[Invoice.Oid] = ?", invoice.Oid);


                    controllerOS.Delete(invoiceLines);

                    if (invoice.IsFinancialCreated == true)
                    {
                        XPCollection<FinancialTrx> financialTRXs = new XPCollection<FinancialTrx>(controllerOS.Session);
                        financialTRXs.Filter = CriteriaOperator.Parse("[Invoice.Oid] = ?", invoice.Oid);
                        controllerOS.Delete(financialTRXs);
                    }

					if (invoice.IsStockCreated == true)
					{
						XPCollection<StockTrx> stockTRX = new XPCollection<StockTrx>(controllerOS.Session);
						stockTRX.Filter = CriteriaOperator.Parse("[Invoice.Oid] = ?", invoice.Oid);

                        controllerOS.Delete(stockTRX);

					}

					controllerOS.Delete(invoice);


                }

                controllerOS.CommitChanges();
            }
        }
    }
}

