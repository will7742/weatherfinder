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
using WeatherFinder.Api.Interfaces;
using WeatherFinder.Api.Models.Responses;
using WeatherFinder.Api.Extensions;
using WeatherFinder.Api.Models.Requests;

namespace WeatherFinder.Api.Endpoints
{
    public class WeatherEndpoint
    {
        protected readonly IWeatherService weatherSvc;

        public WeatherEndpoint(IWeatherService weatherSvc)
        {
            this.weatherSvc = weatherSvc;
        }


        [FunctionName("Weather")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "POST")] HttpRequest req,
            ILogger log)
        {
            try
            {
                switch (req.Method)
                {
                    case "POST":
                        var request = await req.GetBodyAsync<WeatherRequest>();


                        return new OkObjectResult(await weatherSvc.Get(request.Value));
                }
            }
            catch (Exception e)
            {
                log.LogError("{e}", e);
                return new OkObjectResult(new Response<WeatherResponse>().AppendErrors(new List<string> { "Unknown Error" }));
            }

            return new OkObjectResult(new Response<WeatherResponse>().AppendErrors(new List<string> { "Unknown Error" }));
        }
    }

}
