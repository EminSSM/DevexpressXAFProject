using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using XAFInvoiceProject.Module.BusinessObjects.PurchaseManagement;
using XAFInvoiceProject.Module.BusinessObjects.StockManagement;
using XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement;

namespace XAFInvoicesProject.Module.BusinessObjects.StockManagement
{
    public enum StockActionType
    {
        Entry = 0,
        Output = 1
    }

    [DefaultClassOptions]
    [Appearance("StockTRX_CreditDeActive", Enabled = false, Criteria = "FinancialType=='Debit'", TargetItems = "Credit")]
    //[ImageName("BO_Contact")]

    public class StockTrx : BaseObject
    {
        public StockTrx(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        protected override void OnSaving()
        {
            base.OnSaving();

            var src = DateTime.Now;
            var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, src.Second);
            _Date = hm;
        }
        private DateTime _Date;

        /// <summary>
        ///
        /// </summary>
        public DateTime Date
        {
            get { return _Date; }
            set
            {
                if (SetPropertyValue<DateTime>(nameof(Date), ref _Date, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private Invoice _Invoice;

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


        private StockActionType _StockActionType;

        /// <summary>
        ///
        /// </summary>
        public StockActionType StockActionType
        {
            get { return _StockActionType; }
            set
            {
                if (SetPropertyValue<StockActionType>(nameof(StockActionType), ref _StockActionType, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private int _Entry;
        /// <summary>
        ///
        /// </summary>
        public int Entry
        {
            get { return _Entry; }
            set
            {
                if (SetPropertyValue<int>(nameof(Entry), ref _Entry, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }
        private int _Output;

        /// <summary>
        ///
        /// </summary>
        public int Output
        {
            get { return _Output; }
            set
            {
                if (SetPropertyValue<int>(nameof(Output), ref _Output, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }
        private int _Balance;

        [NonPersistent]
        public int Balance
        {
            get

            {
                int currentBalance = 0;
                foreach (var item in Session.Query<StockTrx>().Where(x=>x.Product.Oid==Product.Oid).OrderByDescending(x=>x.Product.CreatedDate).ToList())
                {
                    currentBalance += item.Entry - item.Output;
                    item.Balance = currentBalance;
                }
                return _Balance;

            }
            set
            {
                if (SetPropertyValue<int>(nameof(Balance), ref _Balance, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }




    }
}