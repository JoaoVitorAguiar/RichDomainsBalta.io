namespace PaymentContext.Domain.Entities;
public class CreditPayment : Payment
{
    public CreditPayment(
        string cardHolderName,
        string cardNumber,
        string lastTransactionNumber,
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
        CardHolderName = cardHolderName;
        CardNumber = cardNumber;
        LastTransactionNumber = lastTransactionNumber;
    }

    public string CardHolderName { get; private set; }
    public string CardNumber { get; private set; }
    public string LastTransactionNumber { get; private set; }
}