using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void AddSubscription()
    {
        var subscription = new Subscription(null);

        // student.Subscriptions.Add(subscription); // Erro
        var name = new Name("Teste", "Teste");
        foreach (var notification in name.Notifications)
        {
            System.Console.WriteLine(notification.Message);
        }
    }
}