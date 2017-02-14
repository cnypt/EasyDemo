using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 经纬度转换地址
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            string url = "http://api.map.baidu.com/geocoder/v2/?ak=x3oaGchvS3OvGrKCxpCHiVjgEBbqG3yM&location=39.982788,116.322344&output=json&pois=1";
            client.Encoding = Encoding.UTF8;
            string responseTest222 = client.DownloadString(url);

            //string teststudent = "{\"students\":[{\"name\":\"coolszy\",\"age\": 24},{\"name\":\"kuka\",\"age\":24}]}";

            //TestStudent ts = JsonConvert.DeserializeObject<TestStudent>(teststudent);

            //string name0 = ts.Students[0].Name;

            //List<Student> ls = ts.Students;
            //for (int i = 0; i < ls.Count; i++)
            //{
            //    Console.WriteLine(ls[i].Name);
            //}

            string testobject = "{\"status\":\"0\",\"result\":\"123\"}";

            TestClass tc = new TestClass();
            tc = JsonConvert.DeserializeObject<TestClass>(testobject);

            int t1 = tc.Status;
            string t2 = tc.Result;

            string responseTest = "{\"status\":0,\"result\":{\"location\":{\"lng\":116.32234399999993,\"lat\":39.98278807145794},\"formatted_address\":\"北京市海淀区中关村大街29号\",\"business\":\"中关村,人民大学,苏州街\",\"addressComponent\":{\"country\":\"中国\",\"country_code\":0,\"province\":\"北京市\",\"city\":\"北京市\",\"district\":\"海淀区\",\"adcode\":\"110108\",\"street\":\"中关村大街\",\"street_number\":\"29号\",\"direction\":\"附近\",\"distance\":\"14\"},\"pois\":[{\"addr\":\"北京市海淀区中关村大街29号(海淀黄庄路口)\",\"cp\":\"\",\"direction\":\"内\",\"distance\":\"0\",\"name\":\"北京市海淀医院\",\"poiType\":\"医疗\",\"point\":{\"x\":116.32234402690887,\"y\":39.98278799397245},\"tag\":\"医疗\",\"tel\":\"\",\"uid\":\"fa01e9371a040053774ff1ca\",\"zip\":\"\"},{\"addr\":\"北京市海淀区中关村大街29号(海淀黄庄路口)\",\"cp\":\" \",\"direction\":\"附近\",\"distance\":\"0\",\"name\":\"海淀医院\",\"poiType\":\"医疗\",\"point\":{\"x\":116.32234402690887,\"y\":39.98278799397245},\"tag\":\"医疗;综合医院\",\"tel\":\"\",\"uid\":\"fa01e9371a040053774ff1ca\",\"zip\":\"\"},{\"addr\":\"海淀区中关村北大街27号\",\"cp\":\" \",\"direction\":\"西南\",\"distance\":\"128\",\"name\":\"中关村大厦\",\"poiType\":\"房地产\",\"point\":{\"x\":116.32290995938016,\"y\":39.98356198726214},\"tag\":\"房地产;写字楼\",\"tel\":\"\",\"uid\":\"06d2dffdaef1b7ef88f15d04\",\"zip\":\"\"},{\"addr\":\"北京市海淀区中关村大街27号中关村大厦二层\",\"cp\":\" \",\"direction\":\"西南\",\"distance\":\"114\",\"name\":\"眉州东坡酒楼(中关村店)\",\"poiType\":\"美食\",\"point\":{\"x\":116.32293690854546,\"y\":39.98343759607948},\"tag\":\"美食;中餐厅\",\"tel\":\"\",\"uid\":\"2c0bd6c57dbdd3b342ab9a8c\",\"zip\":\"\"},{\"addr\":\"中关村大街19号新中关大厦(近丹棱街)\",\"cp\":\" \",\"direction\":\"南\",\"distance\":\"214\",\"name\":\"新中关购物中心\",\"poiType\":\"购物\",\"point\":{\"x\":116.32172419610699,\"y\":39.984190850302329},\"tag\":\"购物;购物中心\",\"tel\":\"\",\"uid\":\"8d96925c0372e65cc1f1cf7f\",\"zip\":\"\"},{\"addr\":\"北京市海淀区海淀南路甲2号\",\"cp\":\" \",\"direction\":\"西北\",\"distance\":\"232\",\"name\":\"东润商厦\",\"poiType\":\"购物\",\"point\":{\"x\":116.32365555295344,\"y\":39.981537146848648},\"tag\":\"购物;购物中心\",\"tel\":\"\",\"uid\":\"0dc3d82d4ba1b06c74e5b6af\",\"zip\":\"\"},{\"addr\":\"中关村大街19号\",\"cp\":\" \",\"direction\":\"南\",\"distance\":\"241\",\"name\":\"新中关大厦\",\"poiType\":\"房地产\",\"point\":{\"x\":116.32193978942938,\"y\":39.98442580862234},\"tag\":\"房地产;写字楼\",\"tel\":\"\",\"uid\":\"d687662c0a24ffaffa42b2cc\",\"zip\":\"\"},{\"addr\":\"中关村大街与大泥湾路交叉口东北角\",\"cp\":\" \",\"direction\":\"西\",\"distance\":\"237\",\"name\":\"必胜客(希望餐厅)\",\"poiType\":\"美食\",\"point\":{\"x\":116.32440114652673,\"y\":39.983230276934488},\"tag\":\"美食;外国餐厅\",\"tel\":\"\",\"uid\":\"c85cfc41edd6631cc5effb84\",\"zip\":\"\"},{\"addr\":\"北京市海淀区中关村大街28号\",\"cp\":\" \",\"direction\":\"西\",\"distance\":\"270\",\"name\":\"海淀剧院\",\"poiType\":\"休闲娱乐\",\"point\":{\"x\":116.32476046873072,\"y\":39.98262213711767},\"tag\":\"休闲娱乐;电影院\",\"tel\":\"\",\"uid\":\"edd64ce1a6d799913ee231b3\",\"zip\":\"\"},{\"addr\":\"北京市海淀区中关村大街37号\",\"cp\":\" \",\"direction\":\"西北\",\"distance\":\"406\",\"name\":\"中国人民大学附属中学\",\"poiType\":\"教育培训\",\"point\":{\"x\":116.32432928208593,\"y\":39.98043140641402},\"tag\":\"教育培训;中学\",\"tel\":\"\",\"uid\":\"0c9506efc63eeca8ae04575a\",\"zip\":\"\"}],\"poiRegions\":[{\"direction_desc\":\"内\",\"name\":\"北京市海淀医院\",\"tag\":\"医疗\"}],\"sematic_description\":\"北京市海淀医院内,海淀医院附近0米\",\"cityCode\":131}}";

            string shuchu = "正确";
            try
            {
                MapResult mr = JsonConvert.DeserializeObject<MapResult>(responseTest);

                string province = mr.Result.AddressComponent.Province;
                string city = mr.Result.AddressComponent.City;
                string district = mr.Result.AddressComponent.District;
                Console.WriteLine(string.Format("该经纬度所在地址为：{0}-{1}-{2}", province, city, district));
            }
            catch (Exception)
            {
                shuchu = "抛异常";
            }

            Console.WriteLine(shuchu);


            Console.ReadKey();
        }
    }

    /// <summary>
    /// 测试object
    /// </summary>
    public class TestClass
    {
        private int status = -1;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }


        private string result = string.Empty;

        public string Result
        {
            get { return result; }
            set { result = value; }
        }
    }

    /// <summary>
    /// TestArray
    /// </summary>
    public class TestStudent
    {
        private List<Student> students = new List<Student>();

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }
    }

    public class Student
    {
        private string name = string.Empty;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private int age = 0;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
}

