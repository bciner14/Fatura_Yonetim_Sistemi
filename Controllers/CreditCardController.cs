using ApartmentManagement.Models;
using ApartmentManagement.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace ApartmentManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly MongoDbService _mongoDbService;

        public CreditCardController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<CreditCardInfo>> GetCreditCardInfo(string userId)
        {
            var collection = _mongoDbService.GetCollection<CreditCardInfo>("CreditCardInfo");
            var creditCardInfo = await collection.Find(c => c.UserId == userId).FirstOrDefaultAsync();
            if (creditCardInfo == null)
            {
                return NotFound();
            }
            return creditCardInfo;
        }

        [HttpPost]
        public async Task<ActionResult> AddCreditCardInfo(CreditCardInfo creditCardInfo)
        {
            var collection = _mongoDbService.GetCollection<CreditCardInfo>("CreditCardInfo");
            await collection.InsertOneAsync(creditCardInfo);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCreditCardInfo(CreditCardInfo creditCardInfo)
        {
            var collection = _mongoDbService.GetCollection<CreditCardInfo>("CreditCardInfo");
            var result = await collection.ReplaceOneAsync(c => c.UserId == creditCardInfo.UserId, creditCardInfo);
            if (result.MatchedCount == 0)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteCreditCardInfo(string userId)
        {
            var collection = _mongoDbService.GetCollection<CreditCardInfo>("CreditCardInfo");
            var result = await collection.DeleteOneAsync(c => c.UserId == userId);
            if (result.DeletedCount == 0)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
