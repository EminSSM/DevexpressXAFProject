using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using XAFInvoiceProject.Module.BusinessObjects.StockManagement;

namespace XAFInvoicesProject.Module.BusinessObjects.StockManagement
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]

    public class Category : BaseObject
    {
        public Category(Session session)
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
                if (SetPropertyValue<string>("Code", ref _Code, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private string _Name;

        /// <summary>
        ///
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set
            {
                if (SetPropertyValue<string>("Name", ref _Name, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        [Association("Category-Products"), Aggregated]
        public XPCollection<Product> Products
        {
            get { return GetCollection<Product>("Products"); }
        }




    }
}