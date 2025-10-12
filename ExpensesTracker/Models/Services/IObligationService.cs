namespace ExpensesTracker.Models.Services
{
    public interface IObligationService
    {
       
            void Add(Obligation obj);
            void Delete(int id);
            void Update(Obligation obj);
            List<Obligation> GetAll();
            double GetTotalAmount();    // إجمالي كل الالتزامات
            double GetTotalPaid();      // إجمالي المدفوع
            double GetTotalRemaining(); // إجمالي الباقي

            void Save();
    }
}
