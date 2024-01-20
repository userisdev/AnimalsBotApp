using Codeplex.Data;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimalsBotApp
{
    /// <summary> ImageUrlGenerator class. </summary>
    internal static class AnimalImageUrlGenerator
    {
        /// <summary> The CSV </summary>
        private static readonly AnimalCsv csv = new AnimalCsv();

        /// <summary> The random. </summary>
        private static readonly Random rnd = new Random();

        /// <summary> Alpacas this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Alpaca()
        {
            string jsonText = await GetRequestAsync("https://api.sefinek.net/api/v2/random/animal/alpaca");
            dynamic json = DynamicJson.Parse(jsonText);
            return json.message;
        }

        /// <summary> Birds this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Bird()
        {
            string jsonText = await GetRequestAsync("https://api.sefinek.net/api/v2/random/animal/bird");
            dynamic json = DynamicJson.Parse(jsonText);
            return json.message;
        }

        /// <summary> Bunnies this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Bunny()
        {
            string jsonText = await GetRequestAsync("https://api.bunnies.io/v2/loop/random/?media=gif,png");
            dynamic json = DynamicJson.Parse(jsonText);
            return json.media.gif;
        }

        /// <summary> Cats this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Cat()
        {
            const int count = 4;
            switch (rnd.Next(count))
            {
                case 0:
                    {
                        string jsonText = await GetRequestAsync("https://api.thecatapi.com/v1/images/search");
                        dynamic json = DynamicJson.Parse(jsonText);
                        return json[0].url;
                    }

                case 1:
                    {
                        string jsonText = await GetRequestAsync("https://cataas.com/cat?json=true");
                        dynamic json = DynamicJson.Parse(jsonText);
                        dynamic id = json._id;
                        return $"https://cataas.com/cat/{id}.jpeg";
                    }

                case 2:
                    {
                        string jsonText = await GetRequestAsync("https://cataas.com/cat/gif?json=true");
                        dynamic json = DynamicJson.Parse(jsonText);
                        dynamic id = json._id;
                        return $"https://cataas.com/cat/{id}.gif";
                    }

                case 3:
                default:
                    {
                        string jsonText = await GetRequestAsync("https://api.sefinek.net/api/v2/random/animal/cat");
                        dynamic json = DynamicJson.Parse(jsonText);
                        return json.message;
                    }
            }
        }

        /// <summary> CSVs the specified tag. </summary>
        /// <param name="tag"> The tag. </param>
        /// <returns> </returns>
        public static string Csv(string tag)
        {
            string[] list = csv.GetUrl(tag);
            if (list.Length == 0)
            {
                return string.Empty;
            }

            int index = rnd.Next(list.Length);
            return list[index];
        }

        /// <summary> Dogs this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Dog()
        {
            const int count = 3;
            switch (rnd.Next(count))
            {
                case 0:
                    {
                        string jsonText = await GetRequestAsync("https://api.sefinek.net/api/v2/random/animal/dog");
                        dynamic json = DynamicJson.Parse(jsonText);
                        return json.message;
                    }

                case 1:
                    {
                        string jsonText = await GetRequestAsync("https://random.dog/woof.json");
                        dynamic json = DynamicJson.Parse(jsonText);
                        return json.url;
                    }

                case 2:
                default:
                    {
                        string jsonText = await GetRequestAsync("https://dog.ceo/api/breeds/image/random");
                        dynamic json = DynamicJson.Parse(jsonText);
                        return json.message;
                    }
            }
        }

        /// <summary> Ducks this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Duck()
        {
            string jsonText = await GetRequestAsync("https://random-d.uk/api/v1/random");
            dynamic json = DynamicJson.Parse(jsonText);
            return json.url;
        }

        /// <summary> Fishes this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Fish()
        {
            string jsonText = await GetRequestAsync("https://api.sefinek.net/api/v2/random/animal/fish");
            dynamic json = DynamicJson.Parse(jsonText);
            return json.message;
        }

        /// <summary> Foxes this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Fox()
        {
            string jsonText = await GetRequestAsync("https://api.sefinek.net/api/v2/random/animal/fox");
            dynamic json = DynamicJson.Parse(jsonText);
            return json.message;
        }

        /// <summary> Lizards this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Lizard()
        {
            string jsonText = await GetRequestAsync("https://nekos.life/api/v2/img/lizard");
            dynamic json = DynamicJson.Parse(jsonText);
            return json.url;
        }

        /// <summary> Loads the CSV. </summary>
        /// <param name="path"> The path. </param>
        public static void LoadCSV(string path)
        {
            csv.Load(path);
        }

        /// <summary> Shibas this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Shiba()
        {
            string jsonText = await GetRequestAsync("http://shibe.online/api/shibes");
            dynamic json = DynamicJson.Parse(jsonText);
            return json[0];
        }

        /// <summary> Gets the request. </summary>
        /// <param name="url"> The endpoint. </param>
        /// <returns> </returns>
        /// <exception cref="System.Net.Http.HttpRequestException"> Failed to fetch {endpoint} </exception>
        private static async Task<string> GetRequestAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                return response.IsSuccessStatusCode
                    ? await response.Content.ReadAsStringAsync()
                    : throw new HttpRequestException($"Failed to fetch {url}");
            }
        }
    }
}
