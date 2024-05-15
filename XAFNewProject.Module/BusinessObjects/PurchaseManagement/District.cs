using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace XAFNewProject.Module.BusinessObjects.PurchaseManagement
{
    [DefaultClassOptions]

    public class District : BaseObject
    {
        public District(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

       
        private string _DistrictCode;
        [ModelDefault("AllowEdit","false")]
        /// <summary>
        ///
        /// </summary>
        public string DistrictCode
        {
            get { return _DistrictCode; }
            set
            {
                if (SetPropertyValue<string>(nameof(DistrictCode), ref _DistrictCode, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        var cityCode = Session.Query<City>().Where(x => x.Oid == this.City.Oid).FirstOrDefault().CityCode;

                     }
                }
            }
        }





        private string _Name;
        [RuleUniqueValue("RuleUniqueValue for District.Name", DefaultContexts.Save, "Bu isimde bir ilçe zaten var.")]
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
                        if (this.City != null && this.City.Oid != null)
                        {
                            var cityCode = Session.Query<City>().Where(x => x.Oid == this.City.Oid).FirstOrDefault().CityCode;
                            var districtCodeCount = new XPQuery<District>(Session).Where(x => x.City == this.City).Count();

                            if (districtCodeCount == 0)
                            {
                                _DistrictCode = cityCode + " - " + 1;
                            }
                            else
                            {
                                var lastDistrictCode = new XPQuery<District>(Session).Where(x => x.City == this.City)
                                    .OrderByDescending(y => y.DistrictCode).Select(z => z.DistrictCode).FirstOrDefault();
                                string[] splitCode = lastDistrictCode.Split('-');
                                int lastDistrictCodeValue = int.Parse(splitCode[1].Trim());
                                lastDistrictCodeValue++;
                                _DistrictCode = this.City.CityCode + " - " + lastDistrictCodeValue;
                            }
                        }
                    }
                }
            }
        }


        private City _City;
        [Association("City-Districts")]
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



    }
}