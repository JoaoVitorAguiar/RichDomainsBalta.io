using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.Entities;
public class PaypalPayment : Payment
{
    public PaypalPayment(
        string transactionCode,
        Email email,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        string payer,
        Document document,
        Address address
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
    public Email Email { get; private set; }
}