using DevExpress.Charts.Model;
using DevExpress.CodeParser;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System.Drawing;
using System.Text;
using XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement;
using XAFNewProject.Module.BusinessObjects.PurchaseManagement;
using static XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement.FinancialTrx;

namespace XAFInvoiceProject.Module.BusinessObjects.PurchaseManagement
{

    public enum CustomerType
    {
        Customer = 0,
        Seller = 1
    }
    public enum TaxType
    {
        Individual = 0, //bireysel
        Corporate = 1  //kurumsal
    }

    [DefaultClassOptions]
    [RuleCriteria("TaxNumberControlActive", DefaultContexts.Save, "IIF(TaxTypes == 'Individual',Len(TaxNumber)==10, IIF(TaxTypes == 'Corporate',Len(TaxNumber)==11,True))", "Lütfen TaxNumber'ı doğru giriniz.")]

    public class Customer : BaseObject
    {
        private const string EmailRegularExpression = "^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$";
        public Customer(Session session)
            : base(session)
        {

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            var lastItem = Session.Query<Customer>().OrderByDescending(x => x.CreateDate).Select(y => y.Code).FirstOrDefault();

            if (lastItem != null)
            {

                if (lastItem.Contains("-") == true)
                {
                    var splitLastAddedCode = lastItem.ToString().Split('-');
                    var code1 = splitLastAddedCode[0];
                    var code2 = splitLastAddedCode[1];
                    var code2minus = (int.Parse(code2) + 1);
                    _Code = code1 + "-" + code2minus;

                }
                else if (lastItem.All(char.IsDigit) == true)
                {
                    _Code = (int.Parse(lastItem) + 1).ToString();
                }
                else
                {
                    _Code += lastItem + "-" + 1;
                }
            }

            //var lastCode = Session.Query<Customer>().OrderByDescending(x => x.CreateDate).Select(x => x.Code).FirstOrDefault();
            //var customerCodeCount = Session.Query<Customer>().Where(x => x.Code.Contains(lastCode)).Count();

            //if (lastCode != null)
            //{
            //    if (lastCode.All(char.IsLetter) == true)
            //    {

            //        if (customerCodeCount.Equals(0))
            //        {
            //            _Code = lastCode;
            //        }
            //        else 
            //        {
            //            lastCode += "-" + customerCodeCount;
            //            Code = lastCode;
            //        }

            //    }
            //    else if (lastCode.All(char.IsDigit) == true)
            //    {
            //        var Numcode = int.Parse(lastCode);
            //        Numcode++;
            //        Code = Numcode.ToString();
            //    }
            //    else if (customerCodeCount > 0)
            //    {

            //        var split = lastCode.Split('-');
            //        int lastDistrictCodeValue = int.Parse(split[1].Trim());
            //        lastDistrictCodeValue++;
            //        var x = split[0] + "-" + lastDistrictCodeValue;

            //        Code = x;

            //    }
             
            //}
        }

        private DateTime _CreateDate;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]

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


        private CustomerType _CustomerTypes;

        /// <summary>
        ///
        /// </summary>
        public CustomerType CustomerTypes
        {
            get { return _CustomerTypes; }
            set
            {
                if (SetPropertyValue<CustomerType>(nameof(CustomerTypes), ref _CustomerTypes, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }
        /// <summary>
        ///
        /// </summary>

        protected override void OnSaving()
        {
            base.OnSaving();
            if (_Code.Length == 0)
            {
                _Code = "1";
            }
            var src = DateTime.Now;
            var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, src.Second);
            _CreateDate = hm;
        }
        private string _Code;
        [Size(20)]


        /// <summary>
        /// 
        /// </summary>

        public string Code
        {
            get { return _Code; }
            set
            {
                if (SetPropertyValue<string>(nameof(Code), ref _Code, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        if (value.All(char.IsLetter) == true)
                        {
                            var customerCodeCount = Session.Query<Customer>().Where(x => x.Code.Contains(value)).Count();
                            if (customerCodeCount.Equals(0))
                            {
                                value = _Code;
                            }
                            else
                            {

                                value += "-" + customerCodeCount;
                                customerCodeCount++;
                                Code = value;
                            }

                        }
                        else if (value.All(char.IsDigit) == true)
                        {
                            var customerNumCount = Session.Query<Customer>().Where(x => x.Code.Contains(value)).Count();
                            if (customerNumCount.Equals(0))
                            {
                                value = _Code;
                            }
                            else
                            {

                                value += "-" + customerNumCount;
                                customerNumCount++;
                                Code = value;
                            }
                        }
                    }
                }

            }
        }


        private string _Name;
        [Size(200)]

        /// <summary>
        /// 
        /// </summary>

        public string Name
        {
            get { return _Name; }
            set
            {
                if (SetPropertyValue<string>(nameof(Name), ref _Name, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }

                }

            }
        }

        private City _City;

        /// <summary>
        ///
        /// </summary>
        public City City
        {
            get { return _City; }
            set
            {
                if (SetPropertyValue<City>(nameof(City), ref _City, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private District _District;
        [DataSourceCriteria("City.Oid == '@This.City.Oid'")]

        /// <summary>
        ///
        /// </summary>
        public District District
        {
            get { return _District; }
            set
            {
                if (SetPropertyValue<District>(nameof(District), ref _District, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private string _PhoneNumber1;
        [Size(20)]
        [ModelDefault("EditMask", "(500)-000-00-00")]
        /// <summary>
        ///
        /// </summary  
        public string PhoneNumber1
        {
            get { return _PhoneNumber1; }
            set
            {
                if (SetPropertyValue<string>(nameof(PhoneNumber1), ref _PhoneNumber1, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private string _PhoneNumber2;
        [Size(20)]
        [ModelDefault("EditMask", "(500)-000-00-00")]

        /// <summary>
        ///
        /// </summary>
        public string PhoneNumber2
        {
            get { return _PhoneNumber2; }
            set
            {
                if (SetPropertyValue<string>(nameof(PhoneNumber2), ref _PhoneNumber2, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private string _MailAdress;
        [Size(20)]
        [RuleRegularExpression(DefaultContexts.Save, Customer.EmailRegularExpression, CustomMessageTemplate = "Hatalı E-Posta Formatı. Lütfen geçerli bir format giriniz.")]

        /// <summary>
        ///
        /// </summary>
        public string MailAdress
        {
            get { return _MailAdress; }
            set
            {
                if (SetPropertyValue<string>(nameof(MailAdress), ref _MailAdress, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

  
        private string _TaxNumber;
        [RuleRequiredField("RuleRequiredField for Customer.TaxNumber", DefaultContexts.Save, "A TaxNumber must be specified")]
        /// <summary>
        ///
        /// </summary>
        public string TaxNumber
        {
            get
            {
                return _TaxNumber;
            }
            set
            {
                SetPropertyValue(nameof(TaxNumber), ref _TaxNumber, value);
            }
        }

        private TaxType _TaxTypes;

        /// <summary>
        ///
        /// </summary>
        public TaxType TaxTypes
        {
            get { return _TaxTypes; }
            set
            {
                if (SetPropertyValue<TaxType>(nameof(TaxTypes), ref _TaxTypes, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }
        public XPCollection<FinancialTrx> CustomerFinancialTrx
        {
            get
            {
                return new XPCollection<FinancialTrx>(Session, CriteriaOperator.Parse("Customer == ?", this));
            }
        }

        private decimal _Credit;

        /// <summary>
        ///
        /// </summary>
        public decimal Credit
        {
            get {
                decimal creditTotal = 0;

                foreach (FinancialTrx financialTrx in CustomerFinancialTrx)
                {
                    if (financialTrx.FinancialType == FinancialTypes.Credit)
                    {
                        creditTotal += financialTrx.Credit;
                    }
                }
                _Credit = creditTotal;
                return _Credit;
            }

            
        }
      

        private decimal _Debit;

        /// <summary>
        ///
        /// </summary>
        public decimal Debit
        {
            get
            {
                decimal debitTotal = 0;

                foreach (FinancialTrx financialTrx in CustomerFinancialTrx)
                {
                    if (financialTrx.FinancialType == FinancialTypes.Debit)
                    {
                        debitTotal += financialTrx.Debit;
                    }
                }
                _Debit = debitTotal;
                return _Debit;

            }


        }



        private decimal _Balance;

        /// <summary>
        ///
        /// </summary>    
        public decimal Balance
        {
            get {
                decimal creditTotal = Credit;
                decimal debitTotal = Debit;

                return creditTotal - debitTotal;
            }
            //set
            //{
            //    if (SetPropertyValue<decimal>(nameof(Balance), ref _Balance, value))
            //    {
            //        if (!IsLoading && !IsSaving)
            //        {

            //        }
            //    }
            //}

        }

    }
}



