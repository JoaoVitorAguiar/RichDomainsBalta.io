namespace PaymentContext.Domain.Entities;
public class PaypalPayment : Payment
{
    public PaypalPayment(
        string transactionCode,
        string email,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        string payer,
        string document,
        string address
        ) : base(
            paidDate,
            expireDate,
            total,
            totalPaid,
            payer,
            document,
            address)
    {
        TransactionCode = transactionCode;
        Email = email;
    }

    public string TransactionCode { get; private set; }
    public string Email { get; private set; }
}