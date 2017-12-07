using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Logic;
using Telegram.Bot.Types;

namespace project.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/update")] //webhook url
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = TelegramBot.Commands;
            var message = update.Message;
            var client = await TelegramBot.Get();

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, client);
                    break;
                }
                
            }
            return Ok();
        }
    }
}
