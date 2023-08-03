using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{
    public Document(string number, EDocumentType documentType)
    {
        Number = number;
        Type = documentType;
    }

    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }
}