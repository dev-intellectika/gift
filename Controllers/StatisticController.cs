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
    public class StatisticController : ControllerBase
    {
        private StatisticsContext _db;

        public StatisticController(StatisticsContext db)
        {
            _db = db;
        }

        [HttpGet("list")]
        public ActionResult<IEnumerable<StatisticModel>> Get()
        {
            return _db.Records.ToList();
        }

        [HttpGet("get/{id}")]
        public ActionResult<StatisticModel> Get(int id)
        {
            return _db.Records.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("add")]
        public ActionResult<int> Add([FromForm] StatisticModel value)
        {
            _db.Records.Add(value);
            _db.SaveChanges();

            return value.Id;
        }

        [HttpPost("clear")]
        public ActionResult Clear()
        {
            _db.Records.RemoveRange(_db.Records);
            _db.SaveChanges();

            return Ok();
        }

        [HttpPost("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var model = _db.Records.FirstOrDefault(x => x.Id == id);

            if (model != null)
            {
                _db.Records.Remove(model);
                _db.SaveChanges();
            }

            return Ok();
        }
    }
}
