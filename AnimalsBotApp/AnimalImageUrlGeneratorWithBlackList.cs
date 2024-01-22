using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AnimalsBotApp
{
    /// <summary> AnimalImageUrlGeneratorWithBlackList class. </summary>
    internal static class AnimalImageUrlGeneratorWithBlackList
    {
        /// <summary> The black list </summary>
        private static readonly HashSet<string> blackList = new HashSet<string>();

        /// <summary> Gets or sets the retry count. </summary>
        /// <value> The retry count. </value>
        public static int RetryCount { get; set; } = 5;

        /// <summary> Alpacas this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Alpaca()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                string url = await AnimalImageUrlGenerator.Alpaca();
                if (!blackList.Contains(url))
                {
                    return url;
                }
            }

            return string.Empty;
        }

        /// <summary> Birds this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Bird()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                string url = await AnimalImageUrlGenerator.Bird();
                if (!blackList.Contains(url))
                {
                    return url;
                }
            }

            return string.Empty;
        }

        /// <summary> Bunnies this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Bunny()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                string url = await AnimalImageUrlGenerator.Bunny();
                if (!blackList.Contains(url))
                {
                    return url;
                }
            }

            return string.Empty;
        }

        /// <summary> Cats this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Cat()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                string url = await AnimalImageUrlGenerator.Cat();
                if (!blackList.Contains(url))
                {
                    return url;
                }
            }

            return string.Empty;
        }

        /// <summary> CSVs the specified tag. </summary>
        /// <param name="tag"> The tag. </param>
        /// <returns> </returns>
        public static string Csv(string tag)
        {
            for (int i = 0; i < RetryCount; i++)
            {
                string url = AnimalImageUrlGenerator.Csv(tag);
                if (!blackList.Contains(url))
                {
                    return url;
                }
            }

            return string.Empty;
        }

        /// <summary> Dogs this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Dog()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                string url = await AnimalImageUrlGenerator.Dog();
                if (!blackList.Contains(url))
                {
                    return url;
                }
            }

            return string.Empty;
        }

        /// <summary> Ducks this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Duck()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                string url = await AnimalImageUrlGenerator.Duck();
                if (!blackList.Contains(url))
                {
                    return url;
                }
            }

            return string.Empty;
        }

        /// <summary> Fishes this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Fish()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                string url = await AnimalImageUrlGenerator.Fish();
                if (!blackList.Contains(url))
                {
                    return url;
                }
            }

            return string.Empty;
        }

        /// <summary> Foxes this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Fox()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                string url = await AnimalImageUrlGenerator.Fox();
                if (!blackList.Contains(url))
                {
                    return url;
                }
            }

            return string.Empty;
        }

        /// <summary> Lizards this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Lizard()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                string url = await AnimalImageUrlGenerator.Lizard();
                if (!blackList.Contains(url))
                {
                    return url;
                }
            }

            return string.Empty;
        }

        /// <summary> Loads the black list. </summary>
        /// <param name="path"> The path. </param>
        public static void LoadBlackList(string path)
        {
            blackList.Clear();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                _ = blackList.Add(line);
            }
        }

        /// <summary> Shibas this instance. </summary>
        /// <returns> </returns>
        public static async Task<string> Shiba()
        {
            for (int i = 0; i < RetryCount; i++)
            {
                string url = await AnimalImageUrlGenerator.Shiba();
                if (!blackList.Contains(url))
                {
                    return url;
                }
            }

            return string.Empty;
        }
    }
}
