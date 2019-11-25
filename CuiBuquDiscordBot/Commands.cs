using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace CuiBuquDiscordBot
{
    public class Commands : ModuleBase
    {
        [Command("hello")]
        public async Task Hello()
        {
            await ReplyAsync("Hello, I am QuQu bot. Have you seen Feng-er?");
        }

        [Command("fx?")]
        public async Task WhereIsFengXiao()
        {
            await ReplyAsync("Feng-er is being naughty spamming on Twitter at @FENGXlAO");
        }

        [Command("qqhelp")]
        public async Task HelpMeQuQu()
        {
            await ReplyAsync("My Commands \n ==========================\n" +
            " QuQu Bot can be summoned with the prefix 'ququ', 'QuQu' or simply mentioning me.\n\n" +
            "1. hello - for a message\n" +
            "2. fx? - to ask where Feng Xiao is\n" +
            "3. dm <mention a user> - to make QuQu bot dm them (Warning: Do not misuse this to spam)\n" +
            "4. join <mention a role> - to join a role\n" +
            "5. leave <mention a role> - to leave a role\n");
        }

        [Command("dm")]
        public async Task DM(SocketGuildUser _mention, string _msg = null)
        {
            if (_mention != null)
            {
                var channel = await _mention.GetOrCreateDMChannelAsync();
                await channel.SendMessageAsync(_msg);
            }
        }

        [Command("join")]
        public async Task GiveRole(SocketRole _role)
        {
            var fxs = Context.Guild.Roles.FirstOrDefault(x => x.Name == "FengXiaoStan");
            var ywss = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Yan Wushi Squad");
            var member = Context.Guild.Roles.FirstOrDefault(x => x.Name == "member");
            if (_role == fxs || _role == ywss || _role == member)
            {
                var msg = Context.Message;
                await msg.DeleteAsync();
                var user = Context.User;
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == _role.ToString());
                await (user as IGuildUser).AddRoleAsync(role);
                await ReplyAsync("<@" + user.Id + "> has been given the role " + role.Mention);
            }
        }

        [Command("leave")]
        public async Task RemoveRole(SocketRole _role)
        {
            if (_role != null)
            {
                var msg = Context.Message;
                await msg.DeleteAsync();
                var user = Context.User;
                var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == _role.ToString());
                await (user as IGuildUser).RemoveRoleAsync(role);
                await ReplyAsync("The role " + role.Mention + " has been removed from user <@" + user.Id + ">");
            }
        }

        //[Command("kick")]
        //public async Task Kick(SocketGuildUser mention, string reason = null)
        //{
        //    if(mention != null)
        //    {
        //        var channel = await mention.GetOrCreateDMChannelAsync();
        //        System.Console.WriteLine(mention.Username);
        //        await mention.KickAsync();
        //        await channel.SendMessageAsync("You have been kicked from Joyce's dummy server for no reason.");
        //    }
        //}
    }
}
