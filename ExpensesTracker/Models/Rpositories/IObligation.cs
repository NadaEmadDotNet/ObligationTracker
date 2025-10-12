namespace ExpensesTracker.Models.Rpositories
{
    public interface IObligation
    {
        public void Add(Obligation obj);
        public void Delete(int id);
        public void Update(Obligation obj);
        public List<Obligation> GetAll();
        public void Save();

    }
}
