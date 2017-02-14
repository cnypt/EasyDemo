namespace 经纬度转换地址
{
    public class AddressComponent
    {
        private string country = string.Empty;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        private int country_code = 0;

        public int Country_code
        {
            get { return country_code; }
            set { country_code = value; }
        }
        private string province = string.Empty;

        public string Province
        {
            get { return province; }
            set { province = value; }
        }
        private string city = string.Empty;

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        private string district = string.Empty;

        public string District
        {
            get { return district; }
            set { district = value; }
        }
        private string adcode = string.Empty;

        public string Adcode
        {
            get { return adcode; }
            set { adcode = value; }
        }
        private string street = string.Empty;

        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        private string street_number = string.Empty;

        public string Street_number
        {
            get { return street_number; }
            set { street_number = value; }
        }
        private string direction = string.Empty;

        public string Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        private string distance = string.Empty;

        public string Distance
        {
            get { return distance; }
            set { distance = value; }
        }
    }
}