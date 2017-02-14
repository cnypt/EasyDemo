using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace WebformApiJson
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SortedDictionary<string, string> GetPostData = GetRequestGetPost();


                if (GetPostData.ContainsKey("test"))
                {
                    string test = GetPostData["test"];

                    if (!string.IsNullOrEmpty(test))
                    {
                        string[] result = test.Split(new char[] { ' ' }, StringSplitOptions.None);

                        string[] result2 = test.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    }
                }

                string sss = "[{\"GoodsID\":\"84\",\"Num\":1},{\"GoodsID\":\"83\",\"Num\":1}]";

                ArrayList al = (ArrayList)Decode(sss);

                if (GetPostData.ContainsKey("hashtable"))
                {
                    // Hashtable ht = (Hashtable)JsonConvert.DeserializeObject(GetPostData["usefacedetails"], typeof(Hashtable));
                    Hashtable ht = (Hashtable)Decode(GetPostData["hashtable"]);
                    //Dictionary<string, object> dt = (Dictionary<string, object>)JsonConvert.DeserializeObject(GetPostData["usefacedetails"]);

                    //ArrayList ht = (ArrayList)Decode(GetPostData["usefacedetails"]);

                }
                if (GetPostData.ContainsKey("arraylist"))
                {
                    // Hashtable ht = (Hashtable)JsonConvert.DeserializeObject(GetPostData["usefacedetails"], typeof(Hashtable));
                    //   Hashtable ht = (Hashtable)Decode(GetPostData["usefacedetails"]);
                    //Dictionary<string, object> dt = (Dictionary<string, object>)JsonConvert.DeserializeObject(GetPostData["usefacedetails"]);
                    //ArrayList arr = (ArrayList)JsonConvert.DeserializeObject(GetPostData["arraylist"]);
                    ArrayList ht = (ArrayList)Decode(GetPostData["arraylist"]);

                }
                string useragent = Request.UserAgent;

                string address = Request.UserHostAddress;
                string hostname = Request.UserHostName;

                SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();

                NameValueCollection nvc = Request.Headers;

                String[] requestItem = nvc.AllKeys;

                for (int i = 0; i < requestItem.Length; i++)
                {

                    sArray.Add(requestItem[i].ToLower().Trim(), nvc[requestItem[i]]);

                }
            }


        }


        /// <summary>
        /// 获取用户POST/GET过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestGetPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();

            #region Post得到的参数集合
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                if (requestItem[i] != null && Request.Form[requestItem[i]] != null && Request.Form[requestItem[i]] != "")
                {
                    sArray.Add(requestItem[i].ToLower().Trim(), Request.Form[requestItem[i]]);
                }
            }
            #endregion

            #region GET得到的参数集合
            NameValueCollection collGet;
            collGet = Request.QueryString;
            String[] requestItemGet = collGet.AllKeys;

            for (i = 0; i < requestItemGet.Length; i++)
            {
                if (requestItemGet[i] != null && Request.QueryString[requestItemGet[i]] != null && Request.QueryString[requestItemGet[i]].ToString() != "")
                {
                    sArray.Add(requestItemGet[i].ToLower().Trim(), Request.QueryString[requestItemGet[i]]);
                }
            }
            #endregion
            return sArray;
        }

        public object Decode(string json)
        {
            if (String.IsNullOrEmpty(json)) return "";
            object o = JsonConvert.DeserializeObject(json);
            if (o.GetType() == typeof(String) || o.GetType() == typeof(string))
            {
                o = JsonConvert.DeserializeObject(o.ToString());
            }
            object v = toObject(o);
            return v;
        }

        private static object toObject(object o)
        {
            if (o == null) return null;

            if (o.GetType() == typeof(string))
            {
                //判断是否符合2010-09-02T10:00:00的格式
                string s = o.ToString();
                if (s.Length == 19 && s[10] == 'T' && s[4] == '-' && s[13] == ':')
                {
                    o = System.Convert.ToDateTime(o);
                }
            }
            else if (o is JObject)
            {
                JObject jo = o as JObject;

                Hashtable h = new Hashtable();

                foreach (KeyValuePair<string, JToken> entry in jo)
                {
                    h[entry.Key] = toObject(entry.Value);
                }

                o = h;
            }
            else if (o is IList)
            {

                ArrayList list = new ArrayList();
                list.AddRange((o as IList));
                int i = 0, l = list.Count;
                for (; i < l; i++)
                {
                    list[i] = toObject(list[i]);
                }
                o = list;

            }
            else if (typeof(JValue) == o.GetType())
            {
                JValue v = (JValue)o;
                o = toObject(v.Value);
            }
            else
            {
            }
            return o;
        }
    }
}