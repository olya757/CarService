using CarService.DataAccess.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CarService.DesktopClient.Helpers
{
    public static class AutoServiceRequestsHelper
    {
        private static HttpClient httpClient;

        private static int Source { get; set; }
        private static string SourceName;

        static AutoServiceRequestsHelper()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.BaseAddress = new Uri("https://localhost:44341/api/");
        }

        public static void UpdateSource(DataSourceType source)
        {
            Source = ((int)source)+1;
            SourceName = "";
            switch (Source)
            {
                case 1: SourceName = "CarServiceDB"; break;
                case 2: SourceName = "AutoServiceData.xml"; break;
                case 3: SourceName = "AutoServiceData.dat"; break;
            }
        }

        public static void AddCarOwner(CarOwnerDTO carOwner)
        {
            try
            {
                var json = System.Text.Json.JsonSerializer.Serialize(carOwner);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var request = httpClient.PostAsync($"CarOwner/{Source}", data);
                request.Wait();
                var responce = request.Result;
                if (!responce.IsSuccessStatusCode)
                    throw new Exception("Не удалось сохранить данные");
            }
            catch(Exception e)
            {
                throw new Exception("Не удалось сохранить данные");
            }
        }

        public static void AddOrder(OrderDTO order)
        {
            try { 
            var json = System.Text.Json.JsonSerializer.Serialize(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var request = httpClient.PostAsync($"Order/{Source}", data);
            request.Wait();
            var responce = request.Result;
            if (!responce.IsSuccessStatusCode)
                throw new Exception("Не удалось сохранить данные");
            }
            catch(Exception e)
            {
                throw new Exception("Не удалось сохранить данные");
            }

        }

        public static void DeleteCarOwner(int id)
        {
            var request = httpClient.DeleteAsync($"CarOwner/{Source}/{id}");
            request.Wait();
            var responce = request.Result;
            if (!responce.IsSuccessStatusCode)
                throw new Exception("Не удалось выполнить удаление");
        }

        public static void DeleteOrder(int id)
        {
            var request = httpClient.DeleteAsync($"Order/{Source}/{id}");
            request.Wait();
            var responce = request.Result;
            if (!responce.IsSuccessStatusCode)
                throw new Exception("Не удалось выполнить удаление");
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
                    throw new Exception("Не удалось загрузить данные");
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
                        throw e;
                    }
                }
                else
                {
                    throw new Exception("Не удалось загрузить данные из источника " + SourceName);
                }
            }
            catch (Exception e)
            {                
                throw new Exception("Не удалось загрузить данные из источника " + SourceName);
            }
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
                    throw new Exception("Не удалось загрузить данные");
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
                        throw e;
                    }
                }
                else
                {
                    throw new Exception("Не удалось загрузить данные из источника " + SourceName);
                }
            }
            catch (Exception e)
            {                
                throw new Exception("Не удалось загрузить данные из источника " + SourceName);
            }
        }

        public static void UpdateCarOwner(CarOwnerDTO carOwner, int id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(carOwner);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var request = httpClient.PutAsync($"CarOwner/{Source}/{id}", data);
                request.Wait();
                var responce = request.Result;
                if (!responce.IsSuccessStatusCode)
                    throw new Exception("Не удалось сохранить данные");
            }
            catch(Exception e)
            {
                throw new Exception("Не удалось сохранить данные");
            }
        }

        public static void UpdateOrder(OrderDTO order, int id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(order);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var request = httpClient.PutAsync($"Order/{Source}/{id}", data);
                request.Wait();
                var responce = request.Result;
                if (!responce.IsSuccessStatusCode)
                    throw new Exception("Не удалось сохранить данные");
            }
            catch(Exception e)
            {
                throw new Exception("Не удалось сохранить данные");
            }
        }
    }
}
