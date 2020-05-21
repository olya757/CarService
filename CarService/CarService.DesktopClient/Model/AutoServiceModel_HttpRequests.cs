using CarService.DataAccess.DTO;
using CarService.DataAccess.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DesktopClient.Model
{
    public static class AutoServiceModel_HttpRequests
    {
        private static HttpClient httpClient;

        private static int Source { get; set; }

        static AutoServiceModel_HttpRequests()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.BaseAddress = new Uri("https://localhost:44341/api/");
        }

        public static void UpdateSource(int source)
        {
            Source = source;
        }

        public static void AddCarOwner(CarOwnerDTO carOwner)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(carOwner);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var request = httpClient.PostAsync($"CarOwner/{Source}", data);
            request.Wait();
            var responce = request.Result;
        }

        public static void AddOrder(OrderDTO order)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(order);
            //var json = JsonConvert.SerializeObject(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var request = httpClient.PostAsync($"Order/{Source}", data);
            request.Wait();
            var responce = request.Result;
        }

        public static void DeleteCarOwner(int id)
        {
            var request = httpClient.DeleteAsync($"CarOwner/{Source}/{id}");
            request.Wait();
            var responce = request.Result;
        }

        public static void DeleteOrder(int id)
        {
            var request = httpClient.DeleteAsync($"Order/{Source}/{id}");
            request.Wait();
            var responce = request.Result;
        }

        public static CarOwnerDTO GetCarOwnerByID(int id)
        {
            var request = httpClient.GetAsync($"CarOwner/{Source}/{id}");
            request.Wait();
            if (request.Result.IsSuccessStatusCode)
            {
                try
                {
                    var responce = request.Result.Content.ReadAsAsync<CarOwnerDTO>();
                    responce.Wait();
                    var result = responce.Result;
                    return result;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        public static List<CarOwnerDTO> GetCarOwners()
        {
            try
            {
                var request = httpClient.GetAsync($"CarOwner/{Source}");
                request.Wait();
                if (request.Result.IsSuccessStatusCode)
                {
                    try
                    {
                        var responce = request.Result.Content.ReadAsAsync<List<CarOwnerDTO>>();
                        responce.Wait();
                        var result = responce.Result;
                        return result;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Не удалось получить доступ к базе данных");
            }
            return null;
        }

        public static OrderDTO GetOrderByID(int id)
        {
            var request = httpClient.GetAsync($"Order/{Source}/{id}");
            request.Wait();
            if (request.Result.IsSuccessStatusCode)
            {
                try
                {
                    var responce = request.Result.Content.ReadAsAsync<OrderDTO>();
                    responce.Wait();
                    var result = responce.Result;
                    return result;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        public static List<OrderDTO> GetOrders()
        {
            try
            {
                var request = httpClient.GetAsync($"Order/{Source}");
                request.Wait();
                if (request.Result.IsSuccessStatusCode)
                {
                    try
                    {
                        var responce = request.Result.Content.ReadAsAsync<List<OrderDTO>>();
                        responce.Wait();
                        var result = responce.Result;
                        return result;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Не удалось получить доступ к базе данных");
            }
            return null;
        }

        public static void UpdateCarOwner(CarOwnerDTO carOwner, int id)
        {
            var json = JsonConvert.SerializeObject(carOwner);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var request = httpClient.PutAsync($"CarOwner/{Source}/{id}", data);
            request.Wait();
            var responce = request.Result;
        }

        public static void UpdateOrder(OrderDTO order, int id)
        {
            var json = JsonConvert.SerializeObject(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var request = httpClient.PutAsync($"Order/{Source}/{id}", data);
            request.Wait();
            var responce = request.Result;
        }
    }
}
