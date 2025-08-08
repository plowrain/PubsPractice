using PubsPractice.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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
        
        public List<Title> GetSpecialBook(string storyName, string bookName)
        {
            //篩選這本書在哪些書局有上限
            var data = (from books in _dbcontext.Titles
                        join sales in _dbcontext.Sales on books.TitleId equals sales.TitleId
                        join story in _dbcontext.Stores on sales.StorId equals story.StorId
                        where story.StorName == storyName && books.Title1 == bookName
                        select books
                        ).ToList();

            return data;
        }

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

        public void DeleteTitle(string id)
        {
            var data = _dbcontext.Titles
                                 .FirstOrDefault(x => x.TitleId == id);
            _dbcontext.Titles.Remove(data);
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
