using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace httpclient
{
    class Program
    {
        static  void Main()
        {
            window_file_log.Log("hi log");
            string url = "http://192.168.1.240:7000/";
            url  = "http://192.168.1.174:8080/api/pakCallback";
            window_file_log.Log(url);
            ///////
            ///http get begin
            //HttpclientHelper.httpget(url, (ref string strcontent, ref byte[] bytes) =>
            //{
            //    Console.WriteLine(strcontent + ":lam");
            //});
            ////////// 
            ///http get end

            ///////////////////
            ///http post begin
            var payload = new Dictionary<string, string>
                        {
                          {"wid","12345"},
                          {"assetpath", "game/add"},
                          {"android_pak","hi.pak"},
                          {"ios_pak", "ios.pak"}
                        };
            string strPayload = JsonConvert.SerializeObject(payload);
            HttpContent httpContent = new StringContent(strPayload, Encoding.UTF8, "application/json");
            // HttpContent httpContent = new StringContent(strPayload, Encoding.UTF8, "application/x-www-form-urlencoded");
            //HttpContent httpContent1 = new ByteArrayContent(new byte[0]);
            HttpclientHelper.httppost(url, httpContent,(ref string strcontent, ref byte[] bytes) => {
                Console.WriteLine(strcontent + ":lam");
            });
///////////////////
///http post end
            Console.Read();
        }
    }
}
