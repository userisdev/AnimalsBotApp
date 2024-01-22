using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimalsBotApp.Animal
{
    /// <summary> ImageUrlGenerator class. </summary>
    internal sealed class AnimalImageUrlGenerator
    {
        /// <summary> The black list </summary>
        private readonly HashSet<string> blackList = new HashSet<string>();

        /// <summary> The CSV </summary>
        private readonly AnimalCsv csv = new AnimalCsv();

        /// <summary> The random. </summary>
        private readonly Random rnd = new Random();

        /// <summary> Gets or sets the retry count. </summary>
        /// <value> The retry count. </value>
        public int RetryCount { get; set; } = 5;

        /// <summary> Alpacas this instance. </summary>
        /// <returns> </returns>
        public async Task<string> Alpaca()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                try
                {
                    string jsonText = await GetRequestStringAsync("https://api.sefinek.net/api/v2/random/animal/alpaca");
                    dynamic json = DynamicJson.Parse(jsonText);
                    dynamic url = json.message;
                    if (!blackList.Contains(url))
                    {
                        return url;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Exception/{ex.Message}");
                }

                Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Retry/{i + 1}");
            }

            return string.Empty;
        }

        /// <summary> Birds this instance. </summary>
        /// <returns> </returns>
        public async Task<string> Bird()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                try
                {
                    string jsonText = await GetRequestStringAsync("https://api.sefinek.net/api/v2/random/animal/bird");
                    dynamic json = DynamicJson.Parse(jsonText);
                    dynamic url = json.message;
                    if (!blackList.Contains(url))
                    {
                        return url;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Exception/{ex.Message}");
                }

                Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Retry/{i + 1}");
            }

            return string.Empty;
        }

        /// <summary> Bunnies this instance. </summary>
        /// <returns> </returns>
        public async Task<string> Bunny()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                try
                {
                    string jsonText = await GetRequestStringAsync("https://api.bunnies.io/v2/loop/random/?media=gif,png");
                    dynamic json = DynamicJson.Parse(jsonText);
                    dynamic url = json.media.gif;
                    if (!blackList.Contains(url))
                    {
                        return url;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Exception/{ex.Message}");
                }

                Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Retry/{i + 1}");
            }

            return string.Empty;
        }

        /// <summary> Cats this instance. </summary>
        /// <returns> </returns>
        public async Task<string> Cat()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                try
                {
                    string url = await CatRaw(rnd);
                    if (!blackList.Contains(url))
                    {
                        return url;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Exception/{ex.Message}");
                }

                Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Retry/{i + 1}");
            }

            return string.Empty;
        }

        /// <summary> CSVs the specified tag. </summary>
        /// <param name="tag"> The tag. </param>
        /// <returns> </returns>
        public string Csv(string tag)
        {
            for (int i = 0; i < RetryCount; i++)
            {
                try
                {
                    string[] list = csv.GetUrl(tag);
                    string url = list.Any() ? list[rnd.Next(list.Length)] : string.Empty;
                    if (!blackList.Contains(url))
                    {
                        return url;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Exception/{ex.Message}");
                }

                Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Retry/{i + 1}");
            }

            return string.Empty;
        }

        /// <summary> Dogs this instance. </summary>
        /// <returns> </returns>
        public async Task<string> Dog()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                try
                {
                    string url = await DogRaw(rnd);
                    if (!blackList.Contains(url))
                    {
                        return url;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Exception/{ex.Message}");
                }

                Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Retry/{i + 1}");
            }

            return string.Empty;
        }

        /// <summary> Ducks this instance. </summary>
        /// <returns> </returns>
        public async Task<string> Duck()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                try
                {
                    string jsonText = await GetRequestStringAsync("https://random-d.uk/api/v1/random");
                    dynamic json = DynamicJson.Parse(jsonText);
                    dynamic url = json.url;
                    if (!blackList.Contains(url))
                    {
                        return url;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Exception/{ex.Message}");
                }

                Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Retry/{i + 1}");
            }

            return string.Empty;
        }

        /// <summary> Fishes this instance. </summary>
        /// <returns> </returns>
        public async Task<string> Fish()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                try
                {
                    string jsonText = await GetRequestStringAsync("https://api.sefinek.net/api/v2/random/animal/fish");
                    dynamic json = DynamicJson.Parse(jsonText);
                    dynamic url = json.message;
                    if (!blackList.Contains(url))
                    {
                        return url;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Exception/{ex.Message}");
                }

                Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Retry/{i + 1}");
            }

            return string.Empty;
        }

        /// <summary> Foxes this instance. </summary>
        /// <returns> </returns>
        public async Task<string> Fox()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                try
                {
                    string jsonText = await GetRequestStringAsync("https://api.sefinek.net/api/v2/random/animal/fox");
                    dynamic json = DynamicJson.Parse(jsonText);
                    dynamic url = json.message;
                    if (!blackList.Contains(url))
                    {
                        return url;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Exception/{ex.Message}");
                }

                Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Retry/{i + 1}");
            }

            return string.Empty;
        }

        /// <summary> Lizards this instance. </summary>
        /// <returns> </returns>
        public async Task<string> Lizard()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                try
                {
                    string jsonText = await GetRequestStringAsync("https://nekos.life/api/v2/img/lizard");
                    dynamic json = DynamicJson.Parse(jsonText);
                    dynamic url = json.url;
                    if (!blackList.Contains(url))
                    {
                        return url;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Exception/{ex.Message}");
                }

                Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Retry/{i + 1}");
            }

            return string.Empty;
        }

        /// <summary> Loads the CSV. </summary>
        /// <param name="path"> The path. </param>
        public void LoadAnimalCSV(string path)
        {
            if (File.Exists(path))
            {
                csv.Load(path);
            }
        }

        /// <summary> Loads the black list. </summary>
        /// <param name="path"> The path. </param>
        public void LoadBlackList(string path)
        {
            if (File.Exists(path))
            {
                blackList.Clear();
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    _ = blackList.Add(line);
                }
            }
        }

        /// <summary> Shibas this instance. </summary>
        /// <returns> </returns>
        public async Task<string> Shiba()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                string jsonText = await GetRequestStringAsync("http://shibe.online/api/shibes");
                dynamic json = DynamicJson.Parse(jsonText);
                dynamic url = json[0];
                if (!blackList.Contains(url))
                {
                    return url;
                }
            }

            return string.Empty;
        }

        /// <summary> Cats this instance. </summary>
        /// <returns> </returns>
        private static async Task<string> CatRaw(Random rnd)
        {
            const int count = 4;
            switch (rnd.Next(count))
            {
                case 0:
                    {
                        string jsonText = await GetRequestStringAsync("https://api.thecatapi.com/v1/images/search");
                        dynamic json = DynamicJson.Parse(jsonText);
                        return json[0].url;
                    }

                case 1:
                    {
                        string jsonText = await GetRequestStringAsync("https://cataas.com/cat?json=true");
                        dynamic json = DynamicJson.Parse(jsonText);
                        dynamic id = json._id;
                        return $"https://cataas.com/cat/{id}.jpeg";
                    }

                case 2:
                    {
                        string jsonText = await GetRequestStringAsync("https://cataas.com/cat/gif?json=true");
                        dynamic json = DynamicJson.Parse(jsonText);
                        dynamic id = json._id;
                        return $"https://cataas.com/cat/{id}.gif";
                    }

                case 3:
                default:
                    {
                        string jsonText = await GetRequestStringAsync("https://api.sefinek.net/api/v2/random/animal/cat");
                        dynamic json = DynamicJson.Parse(jsonText);
                        return json.message;
                    }
            }
        }

        /// <summary> Dogs this instance. </summary>
        /// <returns> </returns>
        private static async Task<string> DogRaw(Random rnd)
        {
            const int count = 3;
            switch (rnd.Next(count))
            {
                case 0:
                    {
                        string jsonText = await GetRequestStringAsync("https://api.sefinek.net/api/v2/random/animal/dog");
                        dynamic json = DynamicJson.Parse(jsonText);
                        return json.message;
                    }

                case 1:
                    {
                        string jsonText = await GetRequestStringAsync("https://random.dog/woof.json");
                        dynamic json = DynamicJson.Parse(jsonText);
                        return json.url;
                    }

                case 2:
                default:
                    {
                        string jsonText = await GetRequestStringAsync("https://dog.ceo/api/breeds/image/random");
                        dynamic json = DynamicJson.Parse(jsonText);
                        return json.message;
                    }
            }
        }

        /// <summary> Gets the request string asynchronous. </summary>
        /// <param name="url"> The endpoint. </param>
        /// <returns> </returns>
        /// <exception cref="System.Net.Http.HttpRequestException"> Failed to fetch {endpoint} </exception>
        private static async Task<string> GetRequestStringAsync(string url)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Url/{url}");

            HttpClient httpClient = HttpClientFactory.Create();
            HttpResponseMessage response = await httpClient.GetAsync(url);

            return response.IsSuccessStatusCode
                ? await response.Content.ReadAsStringAsync()
                : throw new HttpRequestException($"Failed : {response.StatusCode}");
        }
    }
}
