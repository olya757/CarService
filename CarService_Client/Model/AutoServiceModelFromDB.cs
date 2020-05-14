using Newtonsoft.Json;
using SQLServerLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarService_Client.Model
{
    public class AutoServiceModelFromDB : IAutoServiceModel
    {
        private HttpClient httpClient;
        public AutoServiceModelFromDB()
        {
            httpClient = new HttpClient(); 
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.BaseAddress = new Uri("https://localhost:44341/api/");
        }
        public void AddCarOwner(CarOwner carOwner)
        {
            var json = JsonConvert.SerializeObject(carOwner);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var request = httpClient.PostAsync("CarOwner", data);
            request.Wait();
            var responce = request.Result;
        }

        public void AddOrder(Order order)
        {
            var json = JsonConvert.SerializeObject(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var request = httpClient.PostAsync("Order", data);
            request.Wait();
            var responce = request.Result;
        }

        public void DeleteCarOwner(int id)
        {
            var request = httpClient.DeleteAsync($"CarOwner/{id}");
            request.Wait();
            var responce = request.Result;
        }

        public void DeleteOrder(int id)
        {
            var request = httpClient.DeleteAsync($"Order/{id}");
            request.Wait();
            var responce = request.Result;
        }

        public CarOwner GetCarOwnerByID(int id)
        {
            var request = httpClient.GetAsync($"CarOwner/{id}");
            request.Wait();
            if (request.Result.IsSuccessStatusCode)
            {
                try
                {
                    var responce = request.Result.Content.ReadAsAsync<CarOwner>();
                    responce.Wait();
                    var result = responce.Result;
                    return result;
                }
                catch(Exception e)
                {
                    return null;
                }
            }
            return null;
        }

        public List<CarOwner> GetCarOwners()
        {
            var request = httpClient.GetAsync("CarOwner");
            request.Wait();
            if (request.Result.IsSuccessStatusCode)
            {
                try
                {
                    var responce = request.Result.Content.ReadAsAsync<List<CarOwner>>();
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

        public Order GetOrderByID(int id)
        {
            var request = httpClient.GetAsync($"Order/{id}");
            request.Wait();
            if (request.Result.IsSuccessStatusCode)
            {
                try
                {
                    var responce = request.Result.Content.ReadAsAsync<Order>();
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

        public List<Order> GetOrders()
        {
            var request = httpClient.GetAsync("Order");
            request.Wait();
            if (request.Result.IsSuccessStatusCode)
            {
                try
                {
                    var responce = request.Result.Content.ReadAsAsync<List<Order>>();
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

        public void UpdateCarOwner(CarOwner carOwner, int id)
        {
            var json = JsonConvert.SerializeObject(carOwner);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var request = httpClient.PutAsync("CarOwner/{id}", data);
            request.Wait();
            var responce = request.Result;
        }

        public void UpdateOrder(Order order, int id)
        {
            var json = JsonConvert.SerializeObject(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var request = httpClient.PutAsync("Order/{id}", data);
            request.Wait();
            var responce = request.Result;
        }
    }
}
