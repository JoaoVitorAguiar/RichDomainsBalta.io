using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Repositories
{
    public interface IEstudentRepository
    {
        bool DocumentExists(string document);
        bool EmailExists(string email);
        void CrateSubscription(Student student);
    }
}
