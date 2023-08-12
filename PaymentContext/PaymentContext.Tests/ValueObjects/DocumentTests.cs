using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class DocumentTests
{
    // Red, Green, Refactor
    // Atenção quanto ao Invalid e Valid

    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("1234", EDocumentType.CNPJ);
        Assert.IsTrue(doc.Invalid); // .Valid é do pacote Flunt
    }

    [TestMethod]
    public void ShouldReturnSucessWhenCNPJIsValid()
    {
        var doc = new Document("63684451000105", EDocumentType.CNPJ);
        Assert.IsTrue(doc.Valid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
        var doc = new Document("1234", EDocumentType.CPF);
        Assert.IsTrue(doc.Invalid); 
    }

    [TestMethod]
    public void ShouldReturnSucessWhenCPFIsValid()
    {
        var doc = new Document("57869562025", EDocumentType.CPF);
        Assert.IsTrue(doc.Valid);
    }
}
