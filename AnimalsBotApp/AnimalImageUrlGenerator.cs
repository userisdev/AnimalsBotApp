using Codeplex.Data;
using System;
using System.Net.Http;

namespace AnimalsBotApp
{
    /// <summary> ImageUrlGenerator class. </summary>
    internal static class AnimalImageUrlGenerator
    {
        /// <summary> The random. </summary>
        private static readonly Random rnd = new Random();

        /// <summary> Alls this instance. </summary>
        /// <returns> </returns>
        public static string All()
        {
            Func<string>[] fncs = new Func<string>[] { Cat, Dog, Fox, Fish, Alpaca, Bird, Bunny, Duck, Lizard, Shiba };
            int index = rnd.Next(fncs.Length);

            return fncs[index].Invoke();
        }

        /// <summary> Alpacas this instance. </summary>
        /// <returns> </returns>
        public static string Alpaca()
        {
            string jsonText = GetRequest("https://api.sefinek.net/api/v2/random/animal/alpaca");
            dynamic json = DynamicJson.Parse(jsonText);
            return json.message;
        }

        /// <summary> Birds this instance. </summary>
        /// <returns> </returns>
        public static string Bird()
        {
            string jsonText = GetRequest("https://api.sefinek.net/api/v2/random/animal/bird");
            dynamic json = DynamicJson.Parse(jsonText);
            return json.message;
        }

        /// <summary> Bunnies this instance. </summary>
        /// <returns> </returns>
        public static string Bunny()
        {
            string jsonText = GetRequest("https://api.bunnies.io/v2/loop/random/?media=gif,png");
            dynamic json = DynamicJson.Parse(jsonText);
            return json.media.poster;
        }

        /// <summary> Cats this instance. </summary>
        /// <returns> </returns>
        public static string Cat()
        {
            const int count = 2;
            switch (rnd.Next(count))
            {
                case 0:
                    {
                        string jsonText = GetRequest("https://api.thecatapi.com/v1/images/search");
                        dynamic json = DynamicJson.Parse(jsonText);
                        return json.url;
                    }

                case 1:
                default:
                    {
                        string jsonText = GetRequest("https://api.sefinek.net/api/v2/random/animal/cat");
                        dynamic json = DynamicJson.Parse(jsonText);
                        return json.message;
                    }
            }
        }

        /// <summary> Dogs this instance. </summary>
        /// <returns> </returns>
        public static string Dog()
        {
            const int count = 3;
            switch (rnd.Next(count))
            {
                case 0:
                    {
                        string jsonText = GetRequest("https://api.sefinek.net/api/v2/random/animal/dog");
                        dynamic json = DynamicJson.Parse(jsonText);
                        return json.message;
                    }

                case 1:
                    {
                        string jsonText = GetRequest("https://random.dog/woof.json");
                        dynamic json = DynamicJson.Parse(jsonText);
                        return json.url;
                    }

                case 2:
                default:
                    {
                        string jsonText = GetRequest("https://dog.ceo/api/breeds/image/random");
                        dynamic json = DynamicJson.Parse(jsonText);
                        return json.message;
                    }
            }
        }

        /// <summary> Ducks this instance. </summary>
        /// <returns> </returns>
        public static string Duck()
        {
            string jsonText = GetRequest("https://random-d.uk/api/v1/random?type=png");
            dynamic json = DynamicJson.Parse(jsonText);
            return json.url;
        }

        /// <summary> Fishes this instance. </summary>
        /// <returns> </returns>
        public static string Fish()
        {
            string jsonText = GetRequest("https://api.sefinek.net/api/v2/random/animal/fish");
            dynamic json = DynamicJson.Parse(jsonText);
            return json.message;
        }

        /// <summary> Foxes this instance. </summary>
        /// <returns> </returns>
        public static string Fox()
        {
            string jsonText = GetRequest("https://api.sefinek.net/api/v2/random/animal/fox");
            dynamic json = DynamicJson.Parse(jsonText);
            return json.message;
        }

        /// <summary> Lizards this instance. </summary>
        /// <returns> </returns>
        public static string Lizard()
        {
            string jsonText = GetRequest("https://nekos.life/api/v2/img/lizard");
            dynamic json = DynamicJson.Parse(jsonText);
            return json.url;
        }

        /// <summary> Shibas this instance. </summary>
        /// <returns> </returns>
        public static string Shiba()
        {
            string jsonText = GetRequest("http://shibe.online/api/shibes");
            dynamic json = DynamicJson.Parse(jsonText);
            return json[0];
        }

        /// <summary> Gets the request. </summary>
        /// <param name="endpoint"> The endpoint. </param>
        /// <returns> </returns>
        /// <exception cref="System.Net.Http.HttpRequestException"> Failed to fetch {endpoint} </exception>
        private static string GetRequest(string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(endpoint).Result;

                return response.IsSuccessStatusCode
                    ? response.Content.ReadAsStringAsync().Result
                    : throw new HttpRequestException($"Failed to fetch {endpoint}");
            }
        }
    }
}
