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
    }
}
