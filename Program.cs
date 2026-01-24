using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

class Program {
    public static DiscordSocketClient? client;

    public static async Task Main() {
        client = new DiscordSocketClient();
        client.Log += Log;

        ConfigManager.CreateConfig();

        var helloCommand = new SlashCommandBuilder();
        helloCommand.WithName("helloworld");
        helloCommand.WithDescription("HelloWorldコマンド");

        var guildCommand = new SlashCommandBuilder();
        guildCommand.WithName("guild_info");
        guildCommand.WithDescription("ギルドの情報を表示するコマンド");

        await client.LoginAsync(TokenType.Bot, ConfigManager.GetConfig().DiscordToken);
        await client.StartAsync();

        client.Ready += async () => {
            try {
                client.SlashCommandExecuted += CommandDispatcher.DispatchAsync;
                await client.CreateGlobalApplicationCommandAsync(helloCommand.Build());
                await client.CreateGlobalApplicationCommandAsync(guildCommand.Build());
            }
            catch (Exception ex) {
                Console.WriteLine("エラーが発生しました:" + ex.Message);
                Environment.Exit(-1);
            }
        };

        await Task.Delay(-1);
    }

    private static Task Log(LogMessage msg) {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

}
