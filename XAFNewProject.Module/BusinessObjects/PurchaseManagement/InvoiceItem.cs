using DevExpress.DirectX.Common.Direct2D;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using XAFInvoiceProject.Module.BusinessObjects.PurchaseManagement;
using XAFInvoiceProject.Module.BusinessObjects.StockManagement;

namespace XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]

    public class InvoiceItem : BaseObject
    {
        public InvoiceItem(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }




        private decimal _VatAmount;
        [PersistentAlias("Piece*Product.VatRateMultiply/100")]
        /// <summary>
        ///
        /// </summary>
        public decimal VatAmount
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(VatAmount))); }

        }



        private decimal _NetAmount;
        [PersistentAlias("Product.UnitPrice*Piece")]

        /// <summary>
        ///
        /// </summary>
        public decimal NetAmount
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(NetAmount))); }

        }



        private Product _Product;

        /// <summary>
        ///
        /// </summary>
        public Product Product
        {
            get { return _Product; }
            set
            {
                if (SetPropertyValue<Product>("Product", ref _Product, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private int _Piece;

        /// <summary>
        ///
        /// </summary>
        public int Piece
        {
            get { return _Piece; }
            set
            {
                if (SetPropertyValue<int>(nameof(Piece), ref _Piece, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }



        private Invoice _Invoice;
        [Association("Invoice-InvoiceItems")]
        /// <summary>
        ///
        /// </summary>
        public Invoice Invoice
        {
            get { return _Invoice; }
            set
            {
                if (SetPropertyValue<Invoice>(nameof(Invoice), ref _Invoice, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }





    }
}