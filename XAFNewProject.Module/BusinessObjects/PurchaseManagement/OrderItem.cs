using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using XAFInvoiceProject.Module.BusinessObjects.StockManagement;
using XAFOrdersProject.Module.BusinessObjects.PurchaseManagement;

namespace XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement
{
    [DefaultClassOptions]

    public class OrderItem : BaseObject
    {
        public OrderItem(Session session)
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


        private Order _Order;
        [Association("Order-OrderItems")]
        /// <summary>
        ///
        /// </summary>
        public Order Order
        {
            get { return _Order; }
            set
            {
                if (SetPropertyValue<Order>(nameof(Order), ref _Order, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


    }
}