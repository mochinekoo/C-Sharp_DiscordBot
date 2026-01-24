using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

internal class GuildCommand {

    public static async Task SlashCommandHandler(SocketSlashCommand command) {
        if (command.CommandName.Equals("guild_info")) {
            SocketGuild guild = Program.client.GetGuild(command.GuildId.Value);
            var embed = new EmbedBuilder();
            embed.Title = guild.Name;
            embed.AddField("メンバーの人数", guild.MemberCount);
            var channel = command.Channel;
            await channel.SendMessageAsync(embed: embed.Build());
        }

    }
}
