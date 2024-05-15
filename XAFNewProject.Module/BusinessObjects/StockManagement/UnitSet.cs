using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace XAFInvoiceProject.Module.BusinessObjects.StockManagement
{
    [DefaultClassOptions]
    [ImageName("BO_Contact")]

    public class UnitSet : BaseObject
    {
        public UnitSet(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }
        private string _Code;

        [RuleRequiredField("RuleRequiredField for UnitSet.Code", DefaultContexts.Save, "{TargetPropertyName} must be specified")]
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
                        //Kodlar buraya yazılacak
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
                if (SetPropertyValue<string>(nameof(Name), ref _Name, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }

                }

            }
        }



    }
}