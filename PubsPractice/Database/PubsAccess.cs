using PubsPractice.Models;

namespace PubsPractice.Database
{
    public class PubsAccess : IPubsAccess
    {
        private readonly PubsContext _dbcontext;
        public PubsAccess(PubsContext pubsContext) 
        {
            _dbcontext = pubsContext;
        }

        public List<Employee> GetTestDatabase()
        {
            var data = _dbcontext.Employees.Take(10).ToList();
            Console.WriteLine("連線成功");

            return data;
        }
        #region books
        
        public List<Title> GetBook()
        {
            var data = _dbcontext.Titles.ToList();
            return data;
        }

        public Title GetBook(string id)
        {
            var data = _dbcontext.Titles
                                 .FirstOrDefault(x => x.TitleId == id);
            return data;
        }

        public void CreateTitle(Title title)
        {
            _dbcontext.Titles.Add(title);
            _dbcontext.SaveChanges();
        }

        public void CreateTitle(List<Title> titles)
        {
            _dbcontext.Titles.AddRange(titles);
            _dbcontext.SaveChanges();
        }

        public void UpdateTitle(Title title)
        {
            _dbcontext.Titles.Update(title);
            _dbcontext.SaveChanges();
        }

        public void UpdateTitle(List<Title> titles)
        {
            _dbcontext.Titles.UpdateRange(titles);
            _dbcontext.SaveChanges();
        }

        public void DeleteTitle(Title title)
        {
            _dbcontext.Titles.Remove(title);
            _dbcontext.SaveChanges();
        }

        public void DeleteTitle(List<Title> titles)
        {
            _dbcontext.Titles.RemoveRange(titles);
            _dbcontext.SaveChanges();
        }

        #endregion
    }
}
