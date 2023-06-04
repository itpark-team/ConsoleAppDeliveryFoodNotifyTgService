using System.Text.Json;
using Confluent.Kafka;
using ConsoleAppDeliveryFoodNotifyTgService;

var config = new ConsumerConfig
{
    GroupId = "demo-group",
    BootstrapServers = "localhost:9092",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

var tgBot = new TgBot();

using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
{
    consumer.Subscribe("tgqueue");
    while (true)
    {
        var dataFromKafka = consumer.Consume();

        Order order = JsonSerializer.Deserialize<Order>(dataFromKafka.Message.Value);

        tgBot.SendOrderToChat(order);
    }
}