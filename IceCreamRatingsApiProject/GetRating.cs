using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System;

namespace IceCreamRatingsApiProject
{
    public static class GetRating
    {
        [FunctionName("GetRating")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetRating")]
            HttpRequest req,
            [Sql("SELECT [id],[userId],[productId],[timestamp],[locationName],[rating],[userNotes] FROM [ICECREAM].[ratings] where Id = @ratingId",
                CommandType = System.Data.CommandType.Text,
                Parameters = "@ratingId={Query.ratingId}",
                ConnectionStringSetting = "MSSQL_CONSTR")]
            IEnumerable<Rating> ratingItem)
        {
            try
            {
                return new OkObjectResult(ratingItem.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
