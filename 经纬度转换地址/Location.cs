namespace 经纬度转换地址
{
    internal class Location
    {
        private decimal lng = 0M;

        /// <summary>
        /// 经度
        /// </summary>
        public decimal Lng
        {
            get { return lng; }
            set { lng = value; }
        }
        private decimal lat = 0M;
        /// <summary>
        /// 纬度
        /// </summary>
        public decimal Lat
        {
            get { return lat; }
            set { lat = value; }
        }
    }
}