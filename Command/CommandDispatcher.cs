using C_Shape_DiscordBot.Command;
using Discord.WebSocket;
using System.Threading.Tasks;

internal static class CommandDispatcher {

    public static Task DispatchAsync(SocketSlashCommand command) {
        switch (command.CommandName) {
            case "helloworld":
                return HelloWorldCommand.SlashCommandHandler(command);
            case "guild_info":
                return GuildCommand.SlashCommandHandler(command);
            case "get_weather":
                return WeatherCommand.SlashCommandHandler(command);
            default:
                return Task.CompletedTask;
        }
    }
}
