using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void AddSubscription()
    {
        var subscription = new Subscription(null);
        var student = new Student(
            "João",
            "Aguiar",
            "12345678910",
            "joao@gmail.com"
        );
        // student.Subscriptions.Add(subscription); // Erro
        student.AddSubscription(subscription);
    }
}