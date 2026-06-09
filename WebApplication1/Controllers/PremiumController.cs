using PremiumCalculator.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace PremiumCalculator.Web.Controllers
{
    [RoutePrefix("api/premium")]
    public class PremiumController : ApiController
    {
        [HttpPost]
        [Route("calculate")]
        public IHttpActionResult CalculatePremium(PremiumRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("All fields are mandatory.");
            }

            var occupationFactors = new Dictionary<string, decimal>()
            {
                { "Professional", 1.5M },
                { "White Collar", 2.25M },
                { "Light Manual", 11.50M },
                { "Heavy Manual", 31.75M }
            };

            var occupationRatings = new Dictionary<string, string>()
            {
                { "Cleaner", "Light Manual" },
                { "Doctor", "Professional" },
                { "Author", "White Collar" },
                { "Farmer", "Heavy Manual" },
                { "Mechanic", "Heavy Manual" },
                { "Florist", "Light Manual" },
                { "Other", "Heavy Manual" }
            };

            string rating = occupationRatings[request.Occupation];
            decimal factor = occupationFactors[rating];

            decimal premium =
                (request.DeathSumInsured * factor * request.AgeNextBirthday)
                / 1000 * 12;

            return Ok(new PremiumResponse
            {
                MonthlyPremium = Math.Round(premium, 2)
            });
        }
    }
}