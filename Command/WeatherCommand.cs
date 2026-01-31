using C_Shape_DiscordBot.API;
using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace C_Shape_DiscordBot.Command {
    internal class WeatherCommand {

        public static async Task SlashCommandHandler(SocketSlashCommand command) {
            if (command.CommandName.Equals("get_weather")) {
                // 引数を指定する
                var option = command.Data.Options;
                var cityCode = option
                    .First(option => option.Name.Equals("city_code"))
                    .Value
                    .ToString();
                WeatherAPI weatherAPI = WeatherAPI.GetWeather(cityCode);
                var embed = new EmbedBuilder();
                embed.Title = "お天気情報";
                embed.AddField("情報", weatherAPI.forecast[0].detail.wind);
                var channel = command.Channel;
                await channel.SendMessageAsync(embed: embed.Build());
            }

        }

    }
}
