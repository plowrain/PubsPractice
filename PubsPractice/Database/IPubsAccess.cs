using PubsPractice.Models;

namespace PubsPractice.Database
{
    public interface IPubsAccess
    {
        
        List<Employee> GetTestDatabase();

        #region Title 書局
        List<Title> GetBook();
        Title GetBook(string id);

        void CreateTitle(Title title);
        void CreateTitle(List<Title> titles);

        void UpdateTitle(Title title);
        void UpdateTitle(List<Title> titles);

        void DeleteTitle(string id);
        void DeleteTitle(List<Title> titles);


        #endregion
    }
}
