using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftApi.DataAccess
{
    public class StatisticModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Geography { get; set; }

        public string Extra { get; set; }
    }
}
