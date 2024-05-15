using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using XAFInvoiceProject.Module.BusinessObjects.PurchaseManagement;

namespace XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement
{

    [DefaultClassOptions]
    //[Appearance("FinancialTRX_CreditDeActive", Enabled = false, Criteria = "FinancialType=='Debit'", TargetItems = "Credit")]
    //[Appearance("FinancialTRX_DebitDeActive", Enabled = false, Criteria = "FinancialType=='Credit'", TargetItems = "Debit")]

    public class FinancialTrx : BaseObject
    {


        public enum FinancialTypes
        {
            
            Debit = 0,
            Credit = 1
        }
        public FinancialTrx(Session session) : base(session)
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
            _CreateDate = hm;
        }

        private decimal _Credit;
		[Custom("AllowEdit", "False")]

		public decimal Credit
        {
            get { return _Credit; }
            set
            {
                if (SetPropertyValue<decimal>("Credit", ref _Credit, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private decimal _Debit;
		[Custom("AllowEdit", "False")]
		public decimal Debit
        {
            get { return _Debit; }
            set
            {
                if (SetPropertyValue<decimal>("Debit", ref _Debit, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private decimal _Balance;
        [NonPersistent]
		[Custom("AllowEdit", "False")]
		public decimal Balance
        {
            get

            {
                decimal currentBalance = 0;
                foreach (var item in Session.Query<FinancialTrx>().Where(x=>x.Customer.Oid==Customer.Oid)
                    .OrderByDescending(x => x.CreateDate).ToList())
                {
                    currentBalance += item.Credit - item.Debit;

                    item.Balance = currentBalance;
                }
                return _Balance; 
               
            }
            set
            {
                if (SetPropertyValue<decimal>(nameof(Balance), ref _Balance, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private DateTime _CreateDate;

        /// <summary>
        ///
        /// </summary>
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set
            {
                if (SetPropertyValue<DateTime>(nameof(CreateDate), ref _CreateDate, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                       
                    }
                }
            }
        }

        private Customer _Customer;

        /// <summary>
        ///
        /// </summary>
        public Customer Customer
        {
            get { return _Customer; }
            set
            {
                if (SetPropertyValue<Customer>(nameof(Customer), ref _Customer, value))
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

        private FinancialTypes _FinancialType;
        /// <summary>
        ///
        /// </summary>
        public FinancialTypes FinancialType
        {
            get { return _FinancialType; }
            set
            {
                if (SetPropertyValue<FinancialTypes>(nameof(FinancialType), ref _FinancialType, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

    }
}