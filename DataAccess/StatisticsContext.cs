using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftApi.DataAccess
{
    public class StatisticsContext : DbContext
    {
        public DbSet<StatisticModel> Records { get; set; }

        public DbSet<FeedbackModel> Feedbacks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=wwwroot\\statistics.db");
        }
    }

}
