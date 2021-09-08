using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Toolbox_Year_1.Queries;
using Toolbox_Year_1.Views;

namespace Toolbox_Year_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();

            menu.MainMenu();
        }
    }
}
