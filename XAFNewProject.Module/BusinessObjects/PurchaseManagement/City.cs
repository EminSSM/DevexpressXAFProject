using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace XAFNewProject.Module.BusinessObjects.PurchaseManagement
{
    [DefaultClassOptions]
    
    public class City : BaseObject
    {
        public City(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }


		private string _CityCode;
        [RuleUniqueValue("RuleUniqueValue for City.CityCode", DefaultContexts.Save, "Bu plaka zaten mevcut.")]

        /// <summary>
        ///
        /// </summary>
        public string CityCode
		{
			get { return _CityCode; }
            set
            {
                if (SetPropertyValue<string>(nameof(CityCode), ref _CityCode, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        var districts = new XPQuery<District>(Session).Where(x => x.City.Name == this.Name)
                            .OrderByDescending(y => y.DistrictCode);
                        foreach (var item in districts)
                        {
                            var splitCode = item.DistrictCode.Split('-');
                            int lastDistrictCodeValue = int.Parse(splitCode[1].Trim());
                            item.DistrictCode = CityCode + " - " + lastDistrictCodeValue;
                        }
                    }
                }
            }
        }


		private string _Name;
        [RuleUniqueValue("RuleUniqueValue for City.Name", DefaultContexts.Save, "Bu isimde bir il zaten var.")]
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



		[Association("City-Districts")]
		public XPCollection<District> Districts
		{
			get { return GetCollection<District>("Districts"); }
		}


		

	}
}