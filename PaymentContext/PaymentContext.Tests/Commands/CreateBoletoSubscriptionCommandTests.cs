using PaymentContext.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentContext.Tests.Commands;

[TestClass]
public class CreateBoletoSubscriptionCommandTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenNameIsInvalid()
    {
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "";

        command.Validate();
        Assert.IsTrue(command.Invalid);
    }
}
