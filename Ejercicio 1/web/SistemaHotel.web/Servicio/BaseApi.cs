using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SistemaHotel.web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SistemaHotel.web.Servicio
{
    public class BaseApi : IBaseApi
    {
        private HttpWebRequest httpWebRequest;
        protected string BaseUrl;
        protected string ApiKey;

        public void AddBodyData<T>(T data)
        {
            string postString = JsonConvert.SerializeObject(data);
            byte[] byteArray = Encoding.UTF8.GetBytes(postString);
            httpWebRequest.ContentLength = byteArray.Length;

            Stream dataStream = httpWebRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }

        public void PostData<T>(T data)
        {
            httpWebRequest.Method = "POST";
            AddBodyData(data);
        }

        public void PutData<T>(T data)
        {
            httpWebRequest.Method = "PUT";
            AddBodyData(data);
        }

        public async Task<ApiResponse<T>> Request<T>()
        {
            ApiResponse<T> rs;
            try
            {
                var res = await httpWebRequest.GetResponseAsync();
                var response = (HttpWebResponse)res;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var st = response.GetResponseStream();
                    StreamReader sr = new StreamReader(st, System.Text.Encoding.UTF8);
                    var result = sr.ReadToEnd();
                    if (result.Contains("data"))
                    {
                        JObject objJson = JObject.Parse(result);
                        result = objJson.SelectToken("data").ToString();
                    }
                    var resp = JsonConvert.DeserializeObject<T>(result);
                    rs = new ApiResponse<T>(resp);
                    rs.status = (int)response.StatusCode;
                }
                else
                {
                    T item = default(T);
                    rs = new ApiResponse<T>(item)
                    {
                        _Error = true,
                        status = (int)response.StatusCode
                    };
                }
            }
            catch (WebException ex)
            {
                T item = default(T); ;
                var response = (HttpWebResponse)ex.Response;
                var st = response.GetResponseStream();
                StreamReader sr = new StreamReader(st, System.Text.Encoding.UTF8);
                var result = sr.ReadToEnd();
                rs = new ApiResponse<T>(item)
                {
                    _Error = true,
                    status = (int)response.StatusCode,
                    Mensaje = ex.Message
                };
            }
            return rs;
        }

        public void SetURL(string action)
        {
            httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(BaseUrl + action);
            if (!httpWebRequest.Headers.AllKeys.Any(a => a == "ApiKey"))
                httpWebRequest.Headers.Add("ApiKey", this.ApiKey + "");
            httpWebRequest.ContentType = "application/json; charset=utf-8";
        }
    }
}