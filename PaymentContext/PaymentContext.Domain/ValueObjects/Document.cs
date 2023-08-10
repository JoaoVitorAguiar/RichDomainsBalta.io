using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{
    public Document(string number, EDocumentType documentType)
    {
        Number = number;
        Type = documentType;

        AddNotifications(new Contract()
            .Requires()
            .IsTrue(Validate(), "Document.Number", "Documento inv�lido"));
    }

    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }
    private bool Validate()
    {
        if(Type == EDocumentType.CNPJ && Number.Length == 14)
        {
            return true;
        }
        if(Type == EDocumentType.CNPJ && Number.Length == 11)
        {
            return true;
        }
        return false;
    }
}