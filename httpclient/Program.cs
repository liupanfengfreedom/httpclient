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
            string url = "http://192.168.1.240:7000/";
            ///////
            ///http get begin
            HttpclientHelper.httpget(url, (ref string strcontent, ref byte[] bytes) =>
            {
                Console.WriteLine(strcontent + ":lam");
            });
            //////////
            ///http get end

            ///////////////////
            ///http post begin
            var payload = new Dictionary<string, string>
                {
                  {"CustomerId", "5"},
                  {"CustomerName", "Pepsi"}
                };
            string strPayload = JsonConvert.SerializeObject(payload);
            HttpContent httpContent = new StringContent(strPayload, Encoding.UTF8, "application/json");
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
