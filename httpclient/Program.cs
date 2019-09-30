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
    public delegate void Onhttpresponse(ref string strcontent, ref byte[] bytes);
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static  void Main()
        {
            string url = "http://192.168.1.240:7000/";
///////
///http get begin
            //httpget(url, (ref string strcontent, ref byte[] bytes) => {
            //    Console.WriteLine(strcontent+":lam");
            //});
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
            httppost(url, httpContent,(ref string strcontent, ref byte[] bytes) => {
                Console.WriteLine(strcontent + ":lam");
            });
///////////////////
///http post end
            Console.Read();

        }
        static async void httpget(string url, Onhttpresponse callback)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("user", "xiaoxiao");
                    client.DefaultRequestHeaders.Add("pass", "xxx12");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("username/xiaoxiao"));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("password/#345"));
                    HttpResponseMessage response = await client.GetAsync(url);
                    //response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        byte[] bytes = await response.Content.ReadAsByteArrayAsync();
                        callback?.Invoke(ref responseBody,ref bytes);
                    }
                }
                catch( Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        static async void httppost(string url, HttpContent httpContent, Onhttpresponse callback =null)
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("user", "xiaoxiao");
                client.DefaultRequestHeaders.Add("pass", "xxx12");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("username/xiaoxiao"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("password/#345"));
                HttpResponseMessage response = await client.PostAsync("http://192.168.1.240:7000/", httpContent);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    byte[] bytes = await response.Content.ReadAsByteArrayAsync();
                    callback?.Invoke(ref responseBody,ref bytes);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }  
        }
    }
}
