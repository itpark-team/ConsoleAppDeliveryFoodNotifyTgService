using Telegram.Bot;

namespace ConsoleAppDeliveryFoodNotifyTgService;

public class TgBot
{
    private TelegramBotClient _botClient;

    public TgBot()
    {
        _botClient = new TelegramBotClient("6100935167:AAGn80IMbK-IUNuYPiglNrFwQb19aKNUZSY");
    }

    public void SendOrderToChat(Order order)
    {
        string message =
            @$"
ИД заказа:{order.Id}
ИД Пользователя:{order.UserId}
Состав заказа:{order.MenuItems}
Промокод:{order.PromoCode}
Цена заказа:{order.TotalPrice}";
        
        Console.WriteLine(message);

        Task.Run(() =>
            _botClient.SendTextMessageAsync(
                chatId: -916904820,
                text: message
            ));
    }
}