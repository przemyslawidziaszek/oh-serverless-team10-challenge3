using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IceCreamRatingsApiProject
{
    public static class CreateRating
    {
        
        [FunctionName("CreateRating")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [Sql("ICECREAM.ratings", ConnectionStringSetting = "MSSQL_CONSTR")] IAsyncCollector<Rating> ratingItems,
            ILogger log)
        {
            log.LogInformation("C# HTTP CreateRating function processed a request.");

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                var data = JsonConvert.DeserializeObject<RatingModel>(requestBody);

                var rating = new Rating()
                {

                    locationName = data.locationName,
                    userId = data.userId,
                    userNotes = data.userNotes,
                    productId = data.productId,
                    rating = data.rating,

                };

                await ratingItems.AddAsync(rating);

                return new OkObjectResult(rating);

            }
            catch (Exception exc)
            {
                log.LogError(exc.Message);
                return new BadRequestObjectResult(exc.Message);
            }                        
        }
    }
}
