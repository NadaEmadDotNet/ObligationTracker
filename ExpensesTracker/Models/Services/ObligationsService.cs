using ExpensesTracker.Models.Rpositories;

namespace ExpensesTracker.Models.Services
{
    public class ObligationsService : IObligationService
    {
        private readonly IObligation obligation;

        public ObligationsService(IObligation obligation)
        {
            this.obligation = obligation;
        }

        public void Add(Obligation obj)
        {
            obligation.Add(obj);
        }

        public void Delete(int id)
        {
            obligation.Delete(id);
        }

        public void Update(Obligation obj)
        {
            obligation.Update(obj);
        }

        public List<Obligation> GetAll()
        {
            return obligation.GetAll();
        }

        public double GetTotalAmount()
        {
            return obligation.GetAll().Sum(t => t.Amount);
        }

        public double GetTotalPaid()
        {
            return obligation.GetAll().Sum(t => t.PaidAmount);
        }

        public double GetTotalRemaining()
        {
            return obligation.GetAll().Sum(t => t.Amount - t.PaidAmount);
        }
       
        public void Save()
        {
            obligation.Save();
        }
    }
}
