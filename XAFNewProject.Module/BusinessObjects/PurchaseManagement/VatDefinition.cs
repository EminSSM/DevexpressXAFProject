using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace XAFInvoicesProject.Module.BusinessObjects.PurchaseManagement
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]

    public class VatDefinition : BaseObject
    {
        public VatDefinition(Session session)
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


        private int _VatRate;

        /// <summary>
        ///
        /// </summary>
        public int VatRate
        {
            get { return _VatRate; }
            set
            {
                if (SetPropertyValue<int>(nameof(VatRate), ref _VatRate, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }



    }
}