using System.Collections.Generic;

namespace 经纬度转换地址
{
    internal class Result
    {
        private Location location = new Location();


        private string formatted_address = string.Empty;

        public string Formatted_address
        {
            get { return formatted_address; }
            set { formatted_address = value; }
        }
        private string business = string.Empty;

        public string Business
        {
            get { return business; }
            set { business = value; }
        }
        private AddressComponent addressComponent = new AddressComponent();

        public AddressComponent AddressComponent
        {
            get { return addressComponent; }
            set { addressComponent = value; }
        }



        private List<Pois> pois = new List<Pois>();


        private List<PoiRegions> poiRegions = new List<PoiRegions>();


        private string sematic_description = string.Empty;

        public string Sematic_description
        {
            get { return sematic_description; }
            set { sematic_description = value; }
        }
        private int cityCode = -1;

        public int CityCode
        {
            get { return cityCode; }
            set { cityCode = value; }
        }
    }
}