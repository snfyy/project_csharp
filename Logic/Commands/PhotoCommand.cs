using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Logic.Commands
{
    class PhotoCommand : Command
    {
        public override string Name => "photo";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            var photo = new FileToSend("https://1800hocking.files.wordpress.com/2011/07/hi-ohio-logo.jpg");

            await client.SendPhotoAsync(chatId, photo, null, false, messageId);
        }
    }

}
