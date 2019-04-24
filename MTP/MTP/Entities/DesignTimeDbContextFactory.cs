using System;
using System.Collections.Generic;
using System.Text;

namespace MTP.Entities
{
    using Microsoft.EntityFrameworkCore.Design;
    using System.Diagnostics;
    using System.IO;

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MoneyTrackerDataContext>
    {
        public MoneyTrackerDataContext CreateDbContext(string[] args)
        {
            Debug.WriteLine(Directory.GetCurrentDirectory() + @"\database.db");

            return new MoneyTrackerDataContext(Directory.GetCurrentDirectory() + @"\database.db");
        }
    }
}
