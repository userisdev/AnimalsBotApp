using AnimalsBotApp.Animal;
using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AnimalsBotApp
{
    /// <summary> AnimalsBot class. </summary>
    internal sealed class AnimalsBot
    {
        /// <summary> The animal gen </summary>
        private readonly AnimalImageUrlGenerator animalGen = new AnimalImageUrlGenerator();

        /// <summary> The animals </summary>
        private readonly string[] animals = GenerateAnimals().ToArray();

        /// <summary> The client </summary>
        private readonly DiscordSocketClient client;

        /// <summary> The random </summary>
        private readonly Random rnd = new Random();

        /// <summary> The token </summary>
        private readonly string token;

        /// <summary> Initializes a new instance of the <see cref="AnimalsBot" /> class. </summary>
        /// <param name="token"> The token. </param>
        public AnimalsBot(string token)
        {
            this.token = token;

            client = new DiscordSocketClient();

            client.Log += OnLog;
            client.Ready += OnReady;
            client.SlashCommandExecuted += SlashCommandHandlerWithExceptionLogging;
        }

        /// <summary> Loads the specified animal CSV paht. </summary>
        /// <param name="animalCsvPaht"> The animal CSV paht. </param>
        /// <param name="blackListPath"> The black list path. </param>
        public void Load(string animalCsvPaht, string blackListPath)
        {
            animalGen.LoadAnimalCSV(animalCsvPaht);
            animalGen.LoadBlackList(blackListPath);
        }

        /// <summary> Runs the asynchronous. </summary>
        public async Task RunAsync()
        {
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            await Task.Delay(Timeout.Infinite);
        }

        /// <summary> Generates the animals. </summary>
        /// <returns> </returns>
        private static IEnumerable<string> GenerateAnimals()
        {
            yield return "cat";
            yield return "dog";
            yield return "fox";
            yield return "fish";
            yield return "alpaca";
            yield return "bird";
            yield return "bunny";
            yield return "duck";
            yield return "lizard";
            yield return "shiba";
            yield return "bear";
            yield return "polarbear";
            yield return "panda";
            yield return "goat";
            yield return "giraffe";
            yield return "elephant";
            yield return "lion";
            yield return "tiger";
            yield return "cheetah";
            yield return "whale";
            yield return "dolphin";
            yield return "snake";
            yield return "penguin";
            yield return "capybara";
            yield return "mouse";
            yield return "koala";
            yield return "kangaroo";
            yield return "raccoon";
        }

        /// <summary> Generates the log text. </summary>
        /// <param name="log"> The log. </param>
        /// <returns> </returns>
        private static string GenerateLogText(LogMessage log)
        {
            return $"{log.Source} {log.Message}";
        }

        /// <summary> Generates the slash commands. </summary>
        /// <returns> </returns>
        private static IEnumerable<SlashCommandProperties> GenerateSlashCommands()
        {
            yield return new SlashCommandBuilder()
                .WithName("animals")
                .WithDescription("動物コマンド")
                .AddOption("mode", ApplicationCommandOptionType.String, "You can see the list in [help].")
                .Build();
        }

        /// <summary> Animalses the alpaca slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsAlpacaSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await animalGen.Alpaca();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/alpaca[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("アルパカ！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the bear slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsBearSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("bear");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/bear[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("クマ！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the bird slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsBirdSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await animalGen.Bird();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/bird[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("鳥！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the bunny slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsBunnySlashCommandHandler(SocketSlashCommand command)
        {
            string url = await animalGen.Bunny();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/bunny[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("ウサギ！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the capybara slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsCapybaraSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("capybara");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/capybara[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("カピバラ！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the cat slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsCatSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await animalGen.Cat();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/cat[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("猫！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the cheetah slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsCheetahSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("cheetah");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/cheetah[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("チーター！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the dog slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsDogSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await animalGen.Dog();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/dog[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("犬！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the dolphin slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsDolphinSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("dolphin");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/dolphin[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("イルカ！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the duck slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsDuckSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await animalGen.Duck();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/duck[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("アヒル！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the elephant slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsElephantSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("elephant");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/elephant[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("象！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the fish slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsFishSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await animalGen.Fish();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/fish[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("魚！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the fox slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsFoxSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await animalGen.Fox();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/fox[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("狐！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the giraffe slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsGiraffeSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("giraffe");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/giraffe[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("キリン！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the goat slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsGoatSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("goat");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/goat[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("ヤギ！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the kangaroo slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsKangarooSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("kangaroo");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/kangaroo[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("カンガルー！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the koala slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsKoalaSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("koala");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/koala[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("コアラ！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the lion slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsLionSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("lion");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/lion[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("ライオン！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the lizard slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsLizardSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await animalGen.Lizard();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/lizard[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("トカゲ！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the mouse slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsMouseSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("mouse");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/mouse[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("ねずみ！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the panda slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsPandaSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("panda");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/panda[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("パンダ！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the penguin slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsPenguinSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("penguin");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/penguin[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("ペンギン！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the polar bear slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsPolarBearSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("polarbear");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/polarbear[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("シロクマ！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the raccoon slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsRaccoonSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("raccoon");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/raccoon[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("アライグマ！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the shiba slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsShibaSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await animalGen.Shiba();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/shiba[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("柴犬！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the snake slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsSnakeSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("snake");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/snake[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("ヘビ！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the tiger slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsTigerSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("tiger");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/tiger[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("トラ！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the whale slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsWhaleSlashCommandHandler(SocketSlashCommand command)
        {
            string url = animalGen.Csv("whale");
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/whale[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("くじら！")
                .WithImageUrl(url)
                .AddField("\u200B", $"[URL]({url})")
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Helps the option slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task HelpOptionSlashCommandHandler(SocketSlashCommand command)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/help");
            Embed embed = new EmbedBuilder()
                .WithTitle("一覧")
                .WithDescription(string.Join(Environment.NewLine, animals))
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Invalids the option slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task InvalidOptionSlashCommandHandler(SocketSlashCommand command)
        {
            await command.RespondAsync("invalid mode.");
        }

        /// <summary> Called when [log]. </summary>
        /// <param name="log"> The log. </param>
        /// <returns> </returns>
        private Task OnLog(LogMessage log)
        {
            string text = GenerateLogText(log);
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : {text}");
            return Task.CompletedTask;
        }

        /// <summary> Clients the ready. </summary>
        private async Task OnReady()
        {
            await client.SetGameAsync("動物園", type: ActivityType.Watching);

            try
            {
                IEnumerable<SlashCommandProperties> commands = GenerateSlashCommands();
                foreach (SlashCommandProperties command in commands)
                {
                    _ = await client.CreateGlobalApplicationCommandAsync(command);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Exception/{ex}");
            }
        }

        /// <summary> Slashes the command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task SlashCommandHandler(SocketSlashCommand command)
        {
            string mode = (command.Data.Options.FirstOrDefault()?.Value as string) ?? string.Empty;

            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Input/{mode}");

            if (string.IsNullOrEmpty(mode))
            {
                int index = rnd.Next(animals.Length);
                mode = animals[index];
            }

            switch (mode)
            {
                case "cat":
                    await AnimalsCatSlashCommandHandler(command);
                    return;

                case "dog":
                    await AnimalsDogSlashCommandHandler(command);
                    return;

                case "fox":
                    await AnimalsFoxSlashCommandHandler(command);
                    return;

                case "fish":
                    await AnimalsFishSlashCommandHandler(command);
                    return;

                case "alpaca":
                    await AnimalsAlpacaSlashCommandHandler(command);
                    return;

                case "bird":
                    await AnimalsBirdSlashCommandHandler(command);
                    return;

                case "bunny":
                    await AnimalsBunnySlashCommandHandler(command);
                    return;

                case "duck":
                    await AnimalsDuckSlashCommandHandler(command);
                    return;

                case "lizard":
                    await AnimalsLizardSlashCommandHandler(command);
                    return;

                case "shiba":
                    await AnimalsShibaSlashCommandHandler(command);
                    return;

                case "bear":
                    await AnimalsBearSlashCommandHandler(command);
                    return;

                case "polarbear":
                    await AnimalsPolarBearSlashCommandHandler(command);
                    return;

                case "panda":
                    await AnimalsPandaSlashCommandHandler(command);
                    return;

                case "goat":
                    await AnimalsGoatSlashCommandHandler(command);
                    return;

                case "giraffe":
                    await AnimalsGiraffeSlashCommandHandler(command);
                    return;

                case "elephant":
                    await AnimalsElephantSlashCommandHandler(command);
                    return;

                case "lion":
                    await AnimalsLionSlashCommandHandler(command);
                    return;

                case "tiger":
                    await AnimalsTigerSlashCommandHandler(command);
                    return;

                case "cheetah":
                    await AnimalsCheetahSlashCommandHandler(command);
                    return;

                case "whale":
                    await AnimalsWhaleSlashCommandHandler(command);
                    return;

                case "dolphin":
                    await AnimalsDolphinSlashCommandHandler(command);
                    return;

                case "snake":
                    await AnimalsSnakeSlashCommandHandler(command);
                    return;

                case "penguin":
                    await AnimalsPenguinSlashCommandHandler(command);
                    return;

                case "capybara":
                    await AnimalsCapybaraSlashCommandHandler(command);
                    return;

                case "mouse":
                    await AnimalsMouseSlashCommandHandler(command);
                    return;

                case "koala":
                    await AnimalsKoalaSlashCommandHandler(command);
                    return;

                case "kangaroo":
                    await AnimalsKangarooSlashCommandHandler(command);
                    return;

                case "raccoon":
                    await AnimalsRaccoonSlashCommandHandler(command);
                    return;

                case "help":
                    await HelpOptionSlashCommandHandler(command);
                    return;

                default:
                    await InvalidOptionSlashCommandHandler(command);
                    return;
            }
        }

        /// <summary> Slashes the command handler with exception logging. </summary>
        /// <param name="command"> The command. </param>
        private async Task SlashCommandHandlerWithExceptionLogging(SocketSlashCommand command)
        {
            try
            {
                await SlashCommandHandler(command);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Exception/{ex}");
            }
        }
    }
}
