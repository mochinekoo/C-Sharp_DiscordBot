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
                WeatherAPI.Forecast forecast = weatherAPI.forecast[0];
                WeatherAPI.Forecast.Detail detail = forecast.detail;

                var embed = new EmbedBuilder();
                embed.Title = cityCode + "のお天気情報";
                embed.AddField("天気", forecast.telop);
                embed.AddField("風", detail.wind);
                embed.AddField("波", detail.wave);
                var channel = command.Channel;
                await channel.SendMessageAsync(embed: embed.Build());
            }

        }

    }
}
