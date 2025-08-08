using PubsPractice.Models;

namespace PubsPractice.Database
{
    public interface IPubsAccess
    {
        
        List<Employee> GetTestDatabase();

        #region Title 書局
        /// <summary>
        /// 搜尋書局
        /// </summary>
        /// <param name="storyName"></param>
        /// <returns></returns>
        List<Title> GetSpecialBook(string storyName, string bookName);

        List<Title> GetBook();
        Title GetBook(string id);

        void CreateTitle(Title title);
        void CreateTitle(List<Title> titles);

        void UpdateTitle(Title title);
        void UpdateTitle(List<Title> titles);

        void DeleteTitle(string id);
        void DeleteTitle(Title title);
        void DeleteTitle(List<Title> titles);


        #endregion
    }
}
