using System;
using System.Xml;

namespace XML操作
{
    class Program
    {
        static void Main(string[] args)
        {
            string postStr = "<xml><appid><![CDATA[wxd84a4a1b6aa17499]]></appid> <attach><![CDATA[LBSJ]]></attach> <bank_type><![CDATA[CFT]]></bank_type> <cash_fee><![CDATA[1]]></cash_fee> <fee_type><![CDATA[CNY]]></fee_type> <is_subscribe><![CDATA[N]]></is_subscribe> <mch_id><![CDATA[1385285302]]></mch_id> <nonce_str><![CDATA[49086911701399824302]]></nonce_str> <openid><![CDATA[ofSQKwlEsppTiJV2K0Qrjw6LBkEs]]></openid> <out_trade_no><![CDATA[20160909100716]]></out_trade_no> <result_code><![CDATA[SUCCESS]]></result_code> <return_code><![CDATA[SUCCESS]]></return_code> <sign><![CDATA[435BD3D551468D73D80FC907117203CC]]></sign> <time_end><![CDATA[20160909100724]]></time_end> <total_fee>1</total_fee> <trade_type><![CDATA[APP]]></trade_type> <transaction_id><![CDATA[4007762001201609093482512379]]></transaction_id> </xml>";

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(postStr);

            XmlNode xmlNode_appid = xml.GetElementsByTagName("appid")[0];
            string appid = xmlNode_appid.InnerText;
            XmlNode xmlNode_mch_id = xml.GetElementsByTagName("mch_id")[0];
            string partnerid = xmlNode_mch_id.InnerText;
            XmlNode xmlNode_prepay_id = xml.GetElementsByTagName("prepay_id")[0];
            string prepayid = xmlNode_prepay_id.InnerText;
            XmlNode xmlNode_nonce_str = xml.GetElementsByTagName("nonce_str")[0];
            string noncestr = xmlNode_nonce_str.InnerText;



            Console.ReadKey();

        }
    }
}
