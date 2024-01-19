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
        /// <summary> The client </summary>
        private readonly DiscordSocketClient client;

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
            client.SlashCommandExecuted += SlashCommandHandler;
        }

        /// <summary> Runs the asynchronous. </summary>
        public async Task RunAsync()
        {
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            await Task.Delay(Timeout.Infinite);
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
                .AddOption("mode", ApplicationCommandOptionType.String, "cat, dog, fox, fish, alpaca, bird, bunny, duck, lizard, shiba")
                .Build();
        }

        /// <summary> Animalses the alpaca slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsAlpacaSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await AnimalImageUrlGenerator.Alpaca();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/alpaca[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("アルパカ！")
                .WithImageUrl(url)
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the bird slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsBirdSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await AnimalImageUrlGenerator.Bird();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/bird[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("鳥！")
                .WithImageUrl(url)
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the bunny slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsBunnySlashCommandHandler(SocketSlashCommand command)
        {
            string url = await AnimalImageUrlGenerator.Bunny();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/bunny[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("ウサギ！")
                .WithImageUrl(url)
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the cat slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsCatSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await AnimalImageUrlGenerator.Cat();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/cat[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("猫！")
                .WithImageUrl(url)
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the dog slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsDogSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await AnimalImageUrlGenerator.Dog();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/dog[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("犬！")
                .WithImageUrl(url)
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the duck slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsDuckSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await AnimalImageUrlGenerator.Duck();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/duck[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("アヒル！")
                .WithImageUrl(url)
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the fish slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsFishSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await AnimalImageUrlGenerator.Fish();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/fish[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("魚！")
                .WithImageUrl(url)
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the fox slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsFoxSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await AnimalImageUrlGenerator.Fox();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/fox[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("狐！")
                .WithImageUrl(url)
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the lizard slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsLizardSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await AnimalImageUrlGenerator.Lizard();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/lizard[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("トカゲ！")
                .WithImageUrl(url)
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the shiba slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsShibaSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await AnimalImageUrlGenerator.Shiba();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/shiba[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("柴犬！")
                .WithImageUrl(url)
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsSlashCommandHandler(SocketSlashCommand command)
        {
            string url = await AnimalImageUrlGenerator.All();
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals[{url}]");
            Embed embed = new EmbedBuilder()
                .WithTitle("動物！")
                .WithImageUrl(url)
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
            await client.SetGameAsync("サーバー", type: ActivityType.Watching);

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
            switch (mode)
            {
                case "":
                    await AnimalsSlashCommandHandler(command);
                    return;

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

                default:
                    await InvalidOptionSlashCommandHandler(command);
                    return;
            }
        }
    }
}
