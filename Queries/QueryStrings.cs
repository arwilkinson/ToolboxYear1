using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox_Year_1.Queries
{
    public static class QueryStrings
    {
        public static readonly string SelectAllPersonsSql = @"SELECT [First Name], [Last Name], [Age], [Id] 
                                                            FROM Persons 
                                                            WHERE IsActive not in (0)
                                                            ORDER BY [First Name], [Last Name]";

        public static readonly string QueryFirstNameSql = @"SELECT [First Name], [Last Name], [Age], [Id]
                                                            FROM Persons
                                                            WHERE [First Name] like @searchValue,
                                                                AND IsActive not in (0)
                                                            ORDER BY[First Name], [Last Name]";

        public static readonly string QueryLastNameSql = @"SELECT [First Name], [Last Name], [Age], [Id]
                                                        FROM Persons
                                                        WHERE [Last Name] like @searchValue,
                                                            AND IsActive not in (0)
                                                        ORDER BY[First Name], [Last Name]";

        public static readonly string QueryAgeSql = @"SELECT [First Name], [Last Name], [Age], [Id] 
                                                    FROM Persons 
                                                    WHERE [Age] like @searchValue,
                                                        AND IsActive not in (0)
                                                    ORDER BY[First Name], [Last Name]";

        public static readonly string QueryIdSql = @"SELECT [First Name], [Last Name], [Age], [Id] 
                                                    FROM Persons 
                                                    WHERE [Id] like @searchValue,
                                                         AND IsActive not in (0)
                                                    ORDER BY[First Name], [Last Name]";

        public static readonly string InsertSql = @"insert into Persons ([First Name], [Last Name], [Age]) 
                                                    OUTPUT INSERTED.Id 
                                                    values (@firstName, @lastName, @age)";

        public static readonly string UpdateSql = @"UPDATE Persons 
                                                SET [First Name] = @firstName, 
                                                    [Last Name] = @lastName, 
                                                    [Age] = @age 
                                                WHERE [Id] = @id";

        public static readonly string DeleteSql = @"UPDATE Persons 
                                                SET IsActive = 0
                                                WHERE [Id] = @id";

    }
}
