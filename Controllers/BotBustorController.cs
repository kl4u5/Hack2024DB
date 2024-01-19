using BotBustorDB.Models;
using BotBustorDB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BotBustorDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotBustorController : ControllerBase
    {

        // GET api/<BotBustorController>/5
        [HttpGet()]
        public string Get()
        {
            return System.IO.File.ReadAllText(DBService.ReadMeFileName());
        }

        // GET api/<BotBustorController>/5
        [HttpGet("{id}")]
        public CustomerData Get(int id)
        {
            if (id == -666)
            {
                DBService.InitData();
                return null;
            }
            if (id > 0)
            {
                var fileName = DBService.GetDataFileName(id);
                if (System.IO.File.Exists(fileName))
                {
                    try
                    {
                        var res = DBService.LoadFromFile(fileName);
                        return res;
                    }
                    catch { }
                }
            }
            return null;
        }

        // POST api/<BotBustorController>
        [HttpPost]
        public int Post([FromBody] CustomerData value)
        {
            if (value.CustomerId == 0)
            {
                value.CustomerId = DBService.GenCustId(true);
            }

            DBService.StoreCustDate(value);
            return value.CustomerId;
        }

        // PUT api/<BotBustorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerData value)
        {
            if (id <= 0)
            {
                throw new ArgumentException("invalid Id");
            }
            if (id != value.CustomerId)
            {
                throw new ArgumentException("Id mismatch");
            }
            DBService.StoreCustDate(value);
        }

        // DELETE api/<BotBustorController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            var delCount = 0;
            if (id == -666)
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(DBService.GetDataFolder());

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                    delCount++;
                }
            }
            else
            {
                var fileName = DBService.GetDataFileName(id);
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                    delCount++;
                }
            }
            return delCount;
        }
    }
}
