using System;

namespace 根据经纬度计算距离
{
    class Program
    {
        public static double DEF_PI = 3.14159265359; // PI
        public static double DEF_2PI = 6.28318530712; // 2*PI
        public static double DEF_PI180 = 0.01745329252; // PI/180.0
        public static double DEF_R = 6370693.5; // radius of earth

        private const double EARTH_RADIUS = 6378.137;//地球半径
        public static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        static void Main(string[] args)
        {
            double mLat1 = 39.940823; // point1纬度
            double mLon1 = 116.329739; // point1经度
            double mLat2 = 39.940831;// point2纬度
            double mLon2 = 116.329655;// point2经度

            //保留四位小数，精确到千米
            double distance = Math.Round(GetShortDistance(mLon1, mLat1, mLon2, mLat2) / 1000, 4);

            double tt = Math.Round(GetShortDistance(mLon2, mLat2, mLon1, mLat1) / 1000, 4);

            double distance2 = GetLongDistance(mLon1, mLat1, mLon2, mLat2);

            double s = GetDistance();

            Console.ReadKey();
        }



        public static double GetDistance()
        {
            double s = 0;
            double mLat1 = 39.940823; // point1纬度
            double mLon1 = 116.329739; // point1经度
            double mLat2 = 39.940831;// point2纬度
            double mLon2 = 116.329655;// point2经度 

            double radLat1 = rad(mLat1);
            double radLat2 = rad(mLat2);

            double lng1 = rad(mLon1);
            double lng2 = rad(mLon2);

            double a = radLat1 - radLat2;
            double b = lng1 - lng2;

            s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;

            return s;
        }




        /// <summary>
        /// 获取距离,返回的距离是 ：M
        /// </summary>
        /// <param name="lon1">point1经度</param>
        /// <param name="lat1">point1纬度</param>
        /// <param name="lon2">point2经度</param>
        /// <param name="lat2">point2经度</param>
        /// <returns></returns>
        public static double GetShortDistance(double lon1, double lat1, double lon2, double lat2)
        {
            double ew1, ns1, ew2, ns2;
            double dx, dy, dew;
            double distance;

            //角度转化为弧度
            ew1 = lon1 * DEF_PI180;
            ns1 = lat1 * DEF_PI180;
            ew2 = lon2 * DEF_PI180;
            ns2 = lat2 * DEF_PI180;

            //经度差
            dew = ew1 - ew2;
            // 若跨东经和西经180 度，进行调整
            if (dew > DEF_PI)
                dew = DEF_2PI - dew;
            else if (dew < -DEF_PI)
                dew = DEF_2PI + dew;
            dx = DEF_R * Math.Cos(ns1) * dew; // 东西方向长度(在纬度圈上的投影长度)
            dy = DEF_R * (ns1 - ns2); // 南北方向长度(在经度圈上的投影长度)
            // 勾股定理求斜边长
            distance = Math.Sqrt(dx * dx + dy * dy);
            return distance;
        }

        public static double GetLongDistance(double lon1, double lat1, double lon2, double lat2)
        {
            double ew1, ns1, ew2, ns2;
            double distance;
            // 角度转换为弧度
            ew1 = lon1 * DEF_PI180;
            ns1 = lat1 * DEF_PI180;
            ew2 = lon2 * DEF_PI180;
            ns2 = lat2 * DEF_PI180;
            // 求大圆劣弧与球心所夹的角(弧度)
            distance = Math.Sin(ns1) * Math.Sin(ns2) + Math.Cos(ns1) * Math.Cos(ns2) * Math.Cos(ew1 - ew2);
            // 调整到[-1..1]范围内，避免溢出
            if (distance > 1.0)
                distance = 1.0;
            else if (distance < -1.0)
                distance = -1.0;
            // 求大圆劣弧长度   
            distance = DEF_R * Math.Acos(distance);
            return distance;
        }
    }
}

