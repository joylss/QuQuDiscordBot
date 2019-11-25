using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace CuiBuquDiscordBot
{
    public class Program
    {
        //NTY3MTcwMjU5NjI3NDA5NDA4.XdeIDw.kCZ0t8sGM0TrRgLkGvY4l3Gum1M

        public DiscordSocketClient Client;
        public CommandHandler Handler;
        static void Main(string[] args) => new Program().Start().GetAwaiter().GetResult();

        public async Task Start()
        {
            Client = new DiscordSocketClient();

            Handler = new CommandHandler();

            await Client.LoginAsync(Discord.TokenType.Bot, "NTY3MTcwMjU5NjI3NDA5NDA4.XdeIDw.kCZ0t8sGM0TrRgLkGvY4l3Gum1M", true);

            await Client.StartAsync();

            await Handler.Install(Client);

            Client.Ready += Client_Ready;
            Client.UserJoined += AnnounceJoinedUser;
            await Task.Delay(-1);
        }

        private async Task Client_Ready()
        {
            Console.Write("Bot is ready.");  
            return;
        }

        public async Task AnnounceJoinedUser(SocketGuildUser user) //Welcomes the new user
        {
            var channel = Client.GetChannel(633166864486367233) as SocketTextChannel;
            await channel.SendMessageAsync($"Welcome {user.Username} to {channel.Guild.Name}, I am QuQu, please check out <#633502666248421396> then introduce yourself in <#633497759286296577> to get your roles.");
        }
    }
}
