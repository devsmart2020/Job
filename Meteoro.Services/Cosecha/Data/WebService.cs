using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Meteoro.Services.Data
{
    public static class WebService<T>
    {
        private static HttpClient _client = new HttpClient();

        public static void InitializeClient()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(Resource.BaseUrlCorte)
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(Resource.RequestHeaders));
        }

        public static async Task<bool> DeleteAsync(string url)
        {
            try
            {
                using (HttpResponseMessage response = await _client.DeleteAsync(url))
                {
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        ExceptionMsj = response.ReasonPhrase.ToString();
                        return false;
                    }
                }               
            }
            catch (Exception ex)
            {
                ExceptionMsj = ex.Message.ToString();
                return false;
            }
        }

        public static async Task<IEnumerable<T>> GetAsync(string url)
        {
            try
            {
                using (HttpResponseMessage response = await _client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        List<T> list = new List<T>();
                        var jsonString = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<T>>(jsonString);
                        return list;
                    }
                    else
                    {
                        ExceptionMsj = response.ReasonPhrase.ToString();
                        return null;
                    }
                }                
            }
            catch (Exception ex)
            {
                ExceptionMsj = ex.Message.ToString();
                return null;
            }
        }

        public static async Task<bool> GetAsyncBool(string url)
        {
            try
            {
                using (HttpResponseMessage response = await _client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {                        
                        return true;
                    }
                    else
                    {
                        ExceptionMsj = response.ReasonPhrase.ToString();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionMsj = ex.Message.ToString();
                return false;
            }
        }

        public static async Task<IEnumerable<T>> GetPostAsync(string url, IEnumerable<T> entity)
        {
            try
            {
                using (HttpResponseMessage response = await _client.PostAsJsonAsync(url, entity))
                {
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonstring = await response.Content.ReadAsStringAsync();
                        IEnumerable<T> list = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonstring);
                        return list;
                    } 
                    else
                    {
                        ExceptionMsj = response.ReasonPhrase.ToString();
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionMsj = ex.Message.ToString();
                return null;
            }
        }


        public static async Task<T> GetByIdAsync(T entity, string url)
        {
            try
            {
                using (HttpResponseMessage response = await _client.PostAsJsonAsync(url, entity))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        T entityModel = default;
                        entityModel = await response.Content.ReadAsAsync<T>();
                        return entityModel;
                    }
                    else
                    {
                        ExceptionMsj = response.ReasonPhrase.ToString();
                        return default;
                    }
                }              
            }
            catch (Exception ex)
            {
                ExceptionMsj = ex.Message.ToString();               
                return default;
            }
        }

        public static async Task<bool> PostAsync(T entity, string url)
        {
            try
            {
                using (HttpResponseMessage response = await _client.PostAsJsonAsync(url,entity))
                {
                    response.EnsureSuccessStatusCode();
                    if (response.StatusCode == HttpStatusCode.Created)
                    {
                        return true;
                    }
                    else
                    {
                        ExceptionMsj = response.ReasonPhrase.ToString();
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionMsj = ex.Message.ToString();
                return false;
            }
        }

        public static async Task<bool> PutAsync(T entity, string url)
        {
            try
            {
                using (HttpResponseMessage response = await _client.PostAsJsonAsync(url, entity))
                {
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        ExceptionMsj = response.ReasonPhrase.ToString();
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionMsj = ex.Message.ToString();
                return false;
            }
        }

        public static async Task<T> LoginAsync(T entity, string url)
        {
            try
            {
                using (HttpResponseMessage response = await _client.PostAsJsonAsync(url, entity))
                {
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        T entityModel = default;
                        entityModel = await response.Content.ReadAsAsync<T>();
                        return entityModel;
                    }
                    else
                    {
                        ExceptionMsj = response.ReasonPhrase.ToString();
                        return entity;
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionMsj = ex.Message.ToString();
                return entity;
            }
        }

        public static async Task<T> PostAsyncEntity(T entity, string url)
        {
            try
            {
                using (HttpResponseMessage response = await _client.PostAsJsonAsync(url, entity))
                {
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        T entityModel = default;
                        entityModel = await response.Content.ReadAsAsync<T>();
                        return entityModel;
                    }
                    else
                    {
                        ExceptionMsj = response.ReasonPhrase.ToString();
                        return entity;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionMsj = ex.Message.ToString();
                return entity;
            }
        }


        public static string ExceptionMsj { get; set; }


    }
}
