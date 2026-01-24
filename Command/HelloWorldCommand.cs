using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
internal class HelloWorldCommand {

    public static async Task SlashCommandHandler(SocketSlashCommand command) {
        if (command.CommandName.Equals("helloworld")) {
            var embed = new EmbedBuilder();
            embed.Title = "HelloWorld";
            embed.AddField("HelloWorld", "あああ");
            var channel = command.Channel;
            await channel.SendMessageAsync(embed: embed.Build());
        }

    }
}

