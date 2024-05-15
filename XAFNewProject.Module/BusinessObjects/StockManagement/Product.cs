using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement;
using XAFInvoicesProject.Module.BusinessObjects.StockManagement;

namespace XAFInvoiceProject.Module.BusinessObjects.StockManagement
{
    [DefaultClassOptions]
    [ImageName("BO_Product")]

    public class Product : BaseObject
    {
        public Product(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
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
                if (SetPropertyValue<string>(nameof(Code), ref _Code, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }

                }

            }
        }
        private string _Name;
        [RuleUniqueValue("RuleUniqueValue for Product.Name", DefaultContexts.Save, "Bu isimde bir ürün zaten var.")]

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

        private string _Description;

        /// <summary>
        ///
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set
            {
                if (SetPropertyValue<string>("Description", ref _Description, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private decimal _UnitPrice;

        /// <summary>
        ///
        /// </summary>
        public decimal UnitPrice
        {
            get { return _UnitPrice; }
            set
            {
                if (SetPropertyValue<decimal>(nameof(UnitPrice), ref _UnitPrice, value))
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



        private Category _Category;
        [Association("Category-Products")]
        /// <summary>
        ///
        /// </summary>
        public Category Category
        {
            get { return _Category; }
            set
            {
                if (SetPropertyValue<Category>("Category", ref _Category, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private UnitSet _UnitSet;
        /// <summary>
        ///
        /// </summary>
        public UnitSet UnitSet
        {
            get { return _UnitSet; }
            set
            {
                if (SetPropertyValue<UnitSet>("UnitSet", ref _UnitSet, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private decimal _VatRateMultiply;
        [PersistentAlias("VatDefinition.VatRate*UnitPrice")]
        /// <summary>
        ///
        /// </summary>
        public decimal VatRateMultiply
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(VatRateMultiply))); }

        }




        private VatDefinition _VatDefinition;
        /// <summary>
        ///
        /// </summary>
        public VatDefinition VatDefinition
        {
            get { return _VatDefinition; }
            set
            {
                if (SetPropertyValue<VatDefinition>("VatDefinition", ref _VatDefinition, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }







    }
}