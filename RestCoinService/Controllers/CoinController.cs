using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestCoinService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        private static List<Coin> coinList = new List<Coin>()
        {
            new Coin(1, "Gold DK 1640", 2500, "Mike"),
            new Coin(2, "Gold NL 1764", 5000, "Anbo"),
            new Coin(3, "Gold FR 1644", 35000, "Hammer"),
            new Coin(4, "Gold FR 1644", 0, "Auction"),
            new Coin(5, "Sliver GR 333", 2500, "Mike")
        };
        // GET: api/Coin
        [HttpGet]
        public List<Coin> Get()
        {
            return coinList;
        }

        // GET: api/Coin/5
        [HttpGet("{id}", Name = "Get")]
        public Coin Get(int id)
        {
            return coinList.SingleOrDefault(coin => coin.Id == id);
        }

        // POST: api/Coin
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Coin value)
        {
            if (coinList.Contains(value))
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
            else
            {
                Coin addingCoin = new Coin(value.Id, value.Genstand, value.Bud, value.Navn);
                coinList.Add(addingCoin);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
        }

        // PUT: api/Coin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
