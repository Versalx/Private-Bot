using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        public MyBot()
        {
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x => {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });
            commands = discord.GetService<CommandService>();

            RegisterClearCommand();

            commands.CreateCommand("ip")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("s7.polskihurtworld.eu");
                });

            commands.CreateCommand("admin")
              .Do(async (e) =>
              {
                  await e.Channel.SendMessage("Versal");
              });

            discord.ExecuteAndWait(async () =>
           {
               await discord.Connect("Mjk5ODQ5MTY3MTA5NjE5NzEy.C8kczQ.doeavFAIelQLDLD96DzCjYEMv8U", TokenType.Bot);
           });
        }

        private void RegisterClearCommand()
        {
            commands.CreateCommand("clear")
          .Do(async (e) =>
          {
              Message[] messagesToDelete;
              messagesToDelete = await e.Channel.DownloadMessages(100);

             await e.Channel.DeleteMessages(messagesToDelete);
          });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
