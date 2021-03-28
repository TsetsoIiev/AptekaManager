using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;
using System.Text.Json.Serialization;

using AptekaManager.Internal.Dto;
using AptekaManager.Internal.Models;
using System.IO;
using System.Net;
using System.Net.Http;

namespace AptekaManager.Inventory
{
    internal class ApiConnection
    {
        const string ApiDomain = "https://localhost:44306/";

        public ApiConnection()
        {
        }

        public ProductDto GetProduct(string productName)
        {
            var apiEndPoint = "/api/Pharmacy/GetMedicines/" + productName;
            var path = Path.Combine(ApiDomain, apiEndPoint);

            WebRequest request = WebRequest.Create(path);
            WebResponse response = request.GetResponse();

            var responseResult = this.ReadResponse(response);

            var result = JsonSerializer.Deserialize<ProductDto>(responseResult);
            return result;

            throw new NotImplementedException("TOWA NE PRAWI ZAQKA DO SERVERA PONEJE NQMA TAKYW END_POINT");
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            var apiEndPoint = "api/Product/GetProducts";
            var path = Path.Combine(ApiDomain, apiEndPoint);
            
            WebRequest request = WebRequest.Create(path);
            WebResponse response = request.GetResponse();
            
            var responseResult = this.ReadResponse(response);

            var result = JsonSerializer.Deserialize<IEnumerable<ProductDto>>(responseResult);

            return result;
        }

        public void InsertProducts(IEnumerable<ProductDto> products)
        {
            var apiEndPoint = "api/Product/CreateProduct";
            var path = Path.Combine(ApiDomain, apiEndPoint);

            foreach (var product in products)
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(path);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                Task task = new Task(() =>
                {
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        var jsonData = JsonSerializer.Serialize(product);
                        streamWriter.Write(jsonData);
                    }

                    try
                    {
                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();
                        }
                    }
                    catch (Exception)
                    {

                    }
                });

                task.Start();
            }
        }

        private string ReadResponse(WebResponse response)
        {
            string result = string.Empty;
            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                result = reader.ReadToEnd();
            }

            return result;
        }

    }
}
