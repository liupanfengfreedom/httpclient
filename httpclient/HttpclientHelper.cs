﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
namespace httpclient
{
    class HttpclientHelper
    {
        public delegate void Onhttpresponse(ref string strcontent, ref byte[] bytes);
        public static async void httpget(string url, Onhttpresponse callback)
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
                        callback?.Invoke(ref responseBody, ref bytes);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public  static async void httppost(string url, HttpContent httpContent, Onhttpresponse callback = null)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("user", "xiaoxiao");
                    client.DefaultRequestHeaders.Add("user", "xiaoxiao");
                    client.DefaultRequestHeaders.Add("RARpath", "http://192.168.1.240/x.rar");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("username/xiaoxiao"));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("password/#345"));
                    HttpResponseMessage response = await client.PostAsync("http://192.168.1.240:7000/", httpContent);
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        byte[] bytes = await response.Content.ReadAsByteArrayAsync();
                        callback?.Invoke(ref responseBody, ref bytes);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
