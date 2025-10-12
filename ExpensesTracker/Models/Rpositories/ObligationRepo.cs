namespace ExpensesTracker.Models.Rpositories
{
    public class ObligationRepo: IObligation
    {
        public readonly ApplicationDbContext Context;
        public ObligationRepo(ApplicationDbContext context)
        {

            Context = context;
        }
        public void Add(Obligation obligation)
        {
            Context.Obligations.Add(obligation);
        }
        public void Delete(int id)
        {
            var obj = Context.Obligations.FirstOrDefault(o => o.Id == id);
            if (obj != null)
            {
                Context.Obligations.Remove(obj);
            }
        }
        public void Update(Obligation obligation)
        {
            Context.Obligations.Update(obligation);

        }
        public List<Obligation> GetAll()
        {
            return Context.Obligations.ToList();
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
