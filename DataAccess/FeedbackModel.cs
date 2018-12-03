using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftApi.DataAccess
{
    public class FeedbackModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Email { get; set; }

        public string Text { get; set; }
    }
}
