using System.Collections.Generic;
using System.Threading.Tasks;
using Logic.Commands;
using Telegram.Bot;


namespace Logic
{
    public static class TelegramBot
    {
        private static TelegramBotClient _client;
        private static List<Command> _commandsList;

        public static IReadOnlyList<Command> Commands => _commandsList.AsReadOnly();


        public static async Task<TelegramBotClient> Get()
        {
            if (_client != null)
            {
                return _client;
            }

            _commandsList = new List<Command>{ new HelloCommand(), new PhotoCommand() };

            //TODO: add more commands

            _client = new TelegramBotClient(BotSettings.Key);
            var hook = string.Format(BotSettings.Url, "api/message/update");
            await _client.SetWebhookAsync(hook);

            return _client;
        }

    }
}
