using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox_Year_1.Queries
{
    public class QueryStrings
    {
        public string SelectAllPersons { get; private set; }
        public string QueryFirstName { get; private set; }
        public string QueryLastName { get; private set; }
        public string QueryAge { get; private set; }
        public string QueryId { get; set; }
        public string Insert { get; set; }

        public QueryStrings()
        {
            SelectAllPersons = "SELECT [First Name], [Last Name], [Age], [Id] from Persons ORDER BY [First Name], [Last Name]";

            QueryFirstName = "SELECT [First Name], [Last Name], [Age], [Id] "
                                        + "FROM Persons "
                                        + "WHERE [First Name] like @searchValue "
                                        + "ORDER BY[First Name], [Last Name]";

            QueryLastName = "SELECT [First Name], [Last Name], [Age], [Id] "
                                        + "FROM Persons "
                                        + "WHERE [Last Name] like @searchValue "
                                        + "ORDER BY[First Name], [Last Name]";

            QueryAge = "SELECT [First Name], [Last Name], [Age], [Id] "
                                        + "FROM Persons "
                                        + "WHERE [Age] like @searchValue "
                                        + "ORDER BY[First Name], [Last Name]";

            QueryId = "SELECT [First Name], [Last Name], [Age], [Id] "
                                        + "FROM Persons "
                                        + "WHERE [Id] like @searchValue "
                                        + "ORDER BY[First Name], [Last Name]";

            Insert = "insert into Persons ([First Name], [Last Name], [Age]) OUTPUT INSERTED.Id values (@firstName, @lastName, @age)";

        }
    }
}
