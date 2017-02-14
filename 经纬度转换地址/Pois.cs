namespace 经纬度转换地址
{
    internal class Pois
    {
        private string addr = string.Empty;

        public string Addr
        {
            get { return addr; }
            set { addr = value; }
        }
        private string cp = string.Empty;

        public string Cp
        {
            get { return cp; }
            set { cp = value; }
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
        private string name = string.Empty;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string poiType = string.Empty;

        public string PoiType
        {
            get { return poiType; }
            set { poiType = value; }
        }
        private Point point = new Point();

        internal Point Point
        {
            get { return point; }
            set { point = value; }
        }

        private string tag = string.Empty;

        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }
        private string tel = string.Empty;

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        private string uid = string.Empty;

        public string Uid
        {
            get { return uid; }
            set { uid = value; }
        }
        private string zip = string.Empty;

        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }
    }
}