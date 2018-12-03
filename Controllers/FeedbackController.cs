using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftApi.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private StatisticsContext _db;

        public FeedbackController(StatisticsContext db)
        {
            _db = db;
        }

        [HttpGet("list")]
        public ActionResult<IEnumerable<FeedbackModel>> Get()
        {
            return _db.Feedbacks.ToList();
        }

        [HttpGet("get/{id}")]
        public ActionResult<FeedbackModel> Get(int id)
        {
            return _db.Feedbacks.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("add")]
        public ActionResult<int> Add([FromForm] FeedbackModel value)
        {
            _db.Feedbacks.Add(value);
            _db.SaveChanges();

            return value.Id;
        }

        [HttpPost("clear")]
        public ActionResult Clear()
        {
            _db.Feedbacks.RemoveRange(_db.Feedbacks);
            _db.SaveChanges();

            return Ok();
        }

        [HttpPost("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var model = _db.Feedbacks.FirstOrDefault(x => x.Id == id);

            if (model != null)
            {
                _db.Feedbacks.Remove(model);
                _db.SaveChanges();
            }

            return Ok();
        }
    }
}
