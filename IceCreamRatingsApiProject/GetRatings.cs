using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IceCreamRatingsApiProject
{
    public static class GetRatings
    {
        [FunctionName("GetRatings")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetRatings/{userId}")]
            HttpRequest req,
            [Sql("SELECT [id],[userId],[productId],[timestamp],[locationName],[rating],[userNotes] FROM [ICECREAM].[ratings] where [userId] = @userId",
                CommandType = System.Data.CommandType.Text,
                Parameters = "@userId={userId}",
                ConnectionStringSetting = "MSSQL_CONSTR")]
            IEnumerable<Rating> ratingItems)
        {
            return new OkObjectResult(ratingItems);
        }
    }
}
