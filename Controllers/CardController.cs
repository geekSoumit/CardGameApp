using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CardGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardManager cardManager;

        public CardController(ICardManager cardManager)
        {
            this.cardManager = cardManager ?? new CardManager();
        }

        [HttpPut("Sort")]
        public IActionResult SortCards([FromBody] List<string> cards)
        {
            List<string> result;
            try
            {
                cardManager.CreateDeck(cards);
                result = cardManager.SordCards();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}