using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement;

namespace XAFInvoiceProject.Module.BusinessObjects.PurchaseManagement
{
    public enum PaymentType
    {
        Cash = 0,
        CreditCard = 1,
        Eft_Transfer = 2
    }
    public enum InvoiceTypes
    {
        Purchase = 0,
        Sales = 1
      
    }
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]

    public class Invoice : BaseObject
    {
        public Invoice(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
            _IsFinancialCreated = false;
            _IsStockCreated = false;

        }

        private string _Code;

        /// <summary>
        ///
        /// </summary>
        public string Code
        {
            get { return _Code; }
            set
            {
                if (SetPropertyValue<string>("Code", ref _Code, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }
        protected override void OnSaving()
        {
            base.OnSaving();
          
            var src = DateTime.Now;
            var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, src.Second);
            _CreatedDate = hm;
        }
        private bool _IsFinancialCreated;

        /// <summary>
        ///
        /// </summary>
        public bool IsFinancialCreated
        {
            get { return _IsFinancialCreated; }
            set
            {
                if (SetPropertyValue<bool>("IsFinancialCreated", ref _IsFinancialCreated, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }
        private bool _IsStockCreated;

        /// <summary>
        ///
        /// </summary>
        public bool IsStockCreated
        {
            get { return _IsStockCreated; }
            set
            {
                if (SetPropertyValue<bool>("IsStockCreated", ref _IsStockCreated, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private string _InvoiceNo;
        [RuleUniqueValue("RuleUniqueValue for Invoice.InvoiceNo", DefaultContexts.Save, "Bu numaraya ait bir fatura mevcut.")]

        /// <summary>
        /// 
        /// </summary>

        public string InvoiceNo
        {
            get { return _InvoiceNo; }
            set
            {
                if (SetPropertyValue<string>(nameof(InvoiceNo), ref _InvoiceNo, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }

                }

            }
        }

        private PaymentType _PaymentType;

        /// <summary>
        ///
        /// </summary>
        public PaymentType PaymentType
        {
            get { return _PaymentType; }
            set
            {
                if (SetPropertyValue<PaymentType>("PaymentType", ref _PaymentType, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }



        private InvoiceTypes _InvoiceType;

        /// <summary>
        ///
        /// </summary>
        public InvoiceTypes InvoiceType
        {
            get { return _InvoiceType; }
            set
            {
                if (SetPropertyValue<InvoiceTypes>("InvoiceType", ref _InvoiceType, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }



        private string _TaxOffice;

        /// <summary>
        ///
        /// </summary>
        public string TaxOffice
        {
            get { return _TaxOffice; }
            set
            {
                if (SetPropertyValue<string>("TaxOffice", ref _TaxOffice, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private string _TaxNo;

        /// <summary>
        ///
        /// </summary>
        public string TaxNo
        {
            get { return _TaxNo; }
            set
            {
                if (SetPropertyValue<string>(nameof(TaxNo), ref _TaxNo, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private DateTime _CreatedDate;

        /// <summary>
        ///
        /// </summary>
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set
            {
                if (SetPropertyValue<DateTime>("CreatedDate", ref _CreatedDate, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private decimal _TotalNetAmount;
        [PersistentAlias("[InvoiceItems].Sum([NetAmount])")]
        /// <summary>
        ///
        /// </summary>
        public decimal TotalNetAmount
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(TotalNetAmount))); }

        }

        private decimal _TotalVatAmount;
        [PersistentAlias("[InvoiceItems].Sum([VatAmount])")]
        /// <summary>
        ///
        /// </summary>
        public decimal TotalVatAmount
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(TotalVatAmount))); }

        }

        private decimal _TotalAmount;
		[PersistentAlias("[TotalVatAmount] + [TotalNetAmount]")]
		/// <summary>
		///
		/// </summary>
		public decimal TotalAmount
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(TotalAmount))); }
            set
            {
                if (SetPropertyValue<decimal>("TotalAmount", ref _TotalAmount, value))
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
                if (SetPropertyValue<Customer>("Customer", ref _Customer, value))
                {
                    if (!IsLoading && !IsSaving)
                    {


                    }
                }
            }
        }


        [Association("Invoice-InvoiceItems")]

        public XPCollection<InvoiceItem> InvoiceItems
        {
            get { return GetCollection<InvoiceItem>(nameof(InvoiceItems)); }
        }



    }

}