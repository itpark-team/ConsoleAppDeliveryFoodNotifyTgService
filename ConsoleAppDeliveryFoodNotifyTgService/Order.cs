namespace ConsoleAppDeliveryFoodNotifyTgService;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string MenuItems { get; set; }
    public string PromoCode { get; set; }
    public int TotalPrice { get; set; }
}