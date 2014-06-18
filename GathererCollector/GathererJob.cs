using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Infrastructure.Dto.Card;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Quartz;

namespace GathererCollector
{
    public class GathererJob : IJob
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "http://api.mtgdb.info/cards/";

        protected GathererJob()
        {
            _httpClient = new HttpClient();
        }

        public async void Execute(IJobExecutionContext context)
        {
            var getTask = await _httpClient.GetAsync(ApiUrl);

            if (getTask.StatusCode == HttpStatusCode.OK)
            {
                var content = await getTask.Content.ReadAsStringAsync();

                var cards = Deserialize(content);

                // deserialize content to cardDto's and send those to the cardfactory

            }
            else
            {
                // Log that the status code is NOK and pass this update, retry next update
            }
        }

        protected IEnumerable<CardDto> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<CardDto>>(json, new IsoDateTimeConverter{DateTimeFormat = "yyyy/MM/dd"});
        } 
    }
}