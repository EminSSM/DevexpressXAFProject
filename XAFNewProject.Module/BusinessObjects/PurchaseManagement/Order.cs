using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using XAFInvoiceProject.Module.BusinessObjects.PurchaseManagement;
using XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement;

namespace XAFOrdersProject.Module.BusinessObjects.PurchaseManagement
{

    [DefaultClassOptions]

    public class Order : BaseObject
    {
        public Order(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            _IsOrderCreated = false;
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
        private bool _IsOrderCreated;
         
        /// <summary>
        ///
        /// </summary>
        public bool IsOrderCreated
        {
            get { return _IsOrderCreated; }
            set
            {
                if (SetPropertyValue<bool>("IsOrderCreated", ref _IsOrderCreated, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private string _OrderNo;
        [RuleUniqueValue("RuleUniqueValue for Order.OrderNo", DefaultContexts.Save, "Bu numaraya ait sipariş mevcut.")]

        /// <summary>
        /// 
        /// </summary>

        public string OrderNo
        {
            get { return _OrderNo; }
            set
            {
                if (SetPropertyValue<string>(nameof(OrderNo), ref _OrderNo, value))
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
        [PersistentAlias("[OrderItems].Sum([NetAmount])")]
        /// <summary>
        /// 
        ///
        /// </summary>
        public decimal TotalNetAmount
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(TotalNetAmount))); }

        }

        private decimal _TotalVatAmount;
        [PersistentAlias("[OrderItems].Sum([VatAmount])")]
        /// <summary>
        ///
        /// </summary>
        public decimal TotalVatAmount
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(TotalVatAmount))); }

        }

        private decimal _TotalAmount;

        /// <summary>
        ///
        /// </summary>
        public decimal TotalAmount
        {
            get { return TotalVatAmount + TotalNetAmount; }

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

        [Association("Order-OrderItems")]
        public XPCollection<OrderItem> OrderItems
        {
            get { return GetCollection<OrderItem>(nameof(OrderItems)); }

        }



    }
}