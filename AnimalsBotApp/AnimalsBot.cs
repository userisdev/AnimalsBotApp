﻿using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            yield return new SlashCommandBuilder().WithName("animals").WithDescription("動物コマンド").Build();
            yield return new SlashCommandBuilder().WithName("animals_cat").WithDescription("動物コマンド 猫").Build();
            yield return new SlashCommandBuilder().WithName("animals_dog").WithDescription("動物コマンド 犬").Build();
            yield return new SlashCommandBuilder().WithName("animals_fox").WithDescription("動物コマンド 狐").Build();
            yield return new SlashCommandBuilder().WithName("animals_fish").WithDescription("動物コマンド 魚").Build();
            yield return new SlashCommandBuilder().WithName("animals_alpaca").WithDescription("動物コマンド アルパカ").Build();
            yield return new SlashCommandBuilder().WithName("animals_bird").WithDescription("動物コマンド 鳥").Build();
            yield return new SlashCommandBuilder().WithName("animals_bunny").WithDescription("動物コマンド ウサギ").Build();
            yield return new SlashCommandBuilder().WithName("animals_duck").WithDescription("動物コマンド アヒル").Build();
            yield return new SlashCommandBuilder().WithName("animals_lizard").WithDescription("動物コマンド トカゲ").Build();
            yield return new SlashCommandBuilder().WithName("animals_shiba").WithDescription("動物コマンド 柴犬").Build();
        }

        /// <summary> Animalses the alpaca slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsAlpacaSlashCommandHandler(SocketSlashCommand command)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/alpaca");
            Embed embed = new EmbedBuilder()
                .WithTitle("アルパカ！")
                .WithImageUrl(AnimalImageUrlGenerator.Alpaca())
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the bird slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsBirdSlashCommandHandler(SocketSlashCommand command)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/bird");
            Embed embed = new EmbedBuilder()
                .WithTitle("鳥！")
                .WithImageUrl(AnimalImageUrlGenerator.Bird())
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the bunny slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsBunnySlashCommandHandler(SocketSlashCommand command)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/bunny");
            Embed embed = new EmbedBuilder()
                .WithTitle("ウサギ！")
                .WithImageUrl(AnimalImageUrlGenerator.Bunny())
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the cat slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsCatSlashCommandHandler(SocketSlashCommand command)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/cat");
            Embed embed = new EmbedBuilder()
                .WithTitle("猫！")
                .WithImageUrl(AnimalImageUrlGenerator.Cat())
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the dog slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsDogSlashCommandHandler(SocketSlashCommand command)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/dog");
            Embed embed = new EmbedBuilder()
                .WithTitle("犬！")
                .WithImageUrl(AnimalImageUrlGenerator.Dog())
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the duck slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsDuckSlashCommandHandler(SocketSlashCommand command)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/duck");
            Embed embed = new EmbedBuilder()
                .WithTitle("アヒル！")
                .WithImageUrl(AnimalImageUrlGenerator.Duck())
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the fish slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsFishSlashCommandHandler(SocketSlashCommand command)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/fish");
            Embed embed = new EmbedBuilder()
                .WithTitle("魚！")
                .WithImageUrl(AnimalImageUrlGenerator.Fish())
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the fox slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsFoxSlashCommandHandler(SocketSlashCommand command)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/fox");
            Embed embed = new EmbedBuilder()
                .WithTitle("狐！")
                .WithImageUrl(AnimalImageUrlGenerator.Fox())
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the lizard slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsLizardSlashCommandHandler(SocketSlashCommand command)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/lizard");
            Embed embed = new EmbedBuilder()
                .WithTitle("トカゲ！")
                .WithImageUrl(AnimalImageUrlGenerator.Lizard())
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the shiba slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsShibaSlashCommandHandler(SocketSlashCommand command)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals/shiba");
            Embed embed = new EmbedBuilder()
                .WithTitle("柴犬！")
                .WithImageUrl(AnimalImageUrlGenerator.Shiba())
                .Build();

            await command.RespondAsync(embed: embed);
        }

        /// <summary> Animalses the slash command handler. </summary>
        /// <param name="command"> The command. </param>
        private async Task AnimalsSlashCommandHandler(SocketSlashCommand command)
        {
            Trace.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff} : Animals");
            Embed embed = new EmbedBuilder()
                .WithTitle("動物！")
                .WithImageUrl(AnimalImageUrlGenerator.All())
                .Build();

            await command.RespondAsync(embed: embed);
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
            switch (command.Data.Name)
            {
                case "animals":
                    await AnimalsSlashCommandHandler(command);
                    return;

                case "animals_cat":
                    await AnimalsCatSlashCommandHandler(command);
                    return;

                case "animals_dog":
                    await AnimalsDogSlashCommandHandler(command);
                    return;

                case "animals_fox":
                    await AnimalsFoxSlashCommandHandler(command);
                    return;

                case "animals_fish":
                    await AnimalsFishSlashCommandHandler(command);
                    return;

                case "animals_alpaca":
                    await AnimalsAlpacaSlashCommandHandler(command);
                    return;

                case "animals_bird":
                    await AnimalsBirdSlashCommandHandler(command);
                    return;

                case "animals_bunny":
                    await AnimalsBunnySlashCommandHandler(command);
                    return;

                case "animals_duck":
                    await AnimalsDuckSlashCommandHandler(command);
                    return;

                case "animals_lizard":
                    await AnimalsLizardSlashCommandHandler(command);
                    return;

                case "animals_shiba":
                    await AnimalsShibaSlashCommandHandler(command);
                    return;

                default:
                    return;
            }
        }
    }
}
