using CSCAutomateLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
<<<<<<< HEAD
using System;
using System.IO;
=======
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.RegularExpressions;
>>>>>>> Added Http Trigger to the CreateChallenges Function App
using System.Threading.Tasks;


namespace CSCAutomateFunction
{
    public static class CreateChallenges
    {
        #region "Public Methods"
<<<<<<< HEAD
        [FunctionName("CreateChallengesFromHttp")]
        public static async Task<IActionResult> RunHttp(
=======
        [FunctionName("CreateChallengesFromQueue")]
        public static async Task Run(
            [QueueTrigger("stq-cloudskillschallenge1")]string myQueueItem, 
            ILogger log)
        {
            try
            {
                await CreateChallengesAsync(myQueueItem, log);
            }
            catch (Exception ex)
            {
                log.LogError(string.Format("Error in CreateChallenges: {0}", ex.Message));
                throw;
            }
        }

        [FunctionName("CreateChallengesFromHttp")]
        public static async Task<IActionResult> Run(
>>>>>>> Added Http Trigger to the CreateChallenges Function App
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
<<<<<<< HEAD

                if (string.IsNullOrWhiteSpace(requestBody))
                {
                    string warningMessage = "Expecting JSON post body. Recieved empty string.";
                    log.LogWarning(warningMessage);
                    return new BadRequestObjectResult(warningMessage);
                }

                await CreateChallengesAsync(requestBody, log);

                return new OkObjectResult(requestBody);
=======
                await CreateChallengesAsync(requestBody, log);
                string responseMessage = "This HTTP triggered function executed successfully.";
                return new OkObjectResult(responseMessage);
>>>>>>> Added Http Trigger to the CreateChallenges Function App
            }
            catch (Exception ex)
            {
                log.LogError(string.Format("Error in CreateChallenges: {0}", ex.Message));
                throw;
            }
        }
        #endregion

        #region "Private Methods"

<<<<<<< HEAD
        private static async Task CreateChallengesAsync(string json, ILogger log)
        {
            log.LogInformation($"C# CreateChallenges function processing async: {json}");
=======
        static async Task CreateChallengesAsync([QueueTrigger("stq-cloudskillschallenge1")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# CreateChallenges function processing async: {myQueueItem}");
            string jsonMessage = Regex.Unescape(myQueueItem);
            string doubleQuote = "\"";
            jsonMessage = jsonMessage.Remove(jsonMessage.IndexOf(doubleQuote), doubleQuote.Length);
            jsonMessage = jsonMessage.Remove(jsonMessage.LastIndexOf(doubleQuote));

>>>>>>> Added Http Trigger to the CreateChallenges Function App
            string environmentType = Environment.GetEnvironmentVariable("CSCAutomateEnvironment", EnvironmentVariableTarget.Process);
            string keyVaultName = Environment.GetEnvironmentVariable("CSCApiKeyVaultName", EnvironmentVariableTarget.Process);

            Configuration config = await ConfigurationFactory.CreateConfigurationAsync(environmentType, keyVaultName);
            BlobApi blobApi = new BlobApi(config);
            CloudSkillApi cscApi = new CloudSkillApi(config);

<<<<<<< HEAD
            await cscApi.CreateChallengesAsyc(blobApi, json);

            log.LogInformation($"C# Queue trigger function processed");
=======
            await cscApi.CreateChallengesAsyc(blobApi, jsonMessage);

            //string jsonConfig = JsonConvert.SerializeObject(config);
            //log.LogInformation($"Config: {jsonConfig}");
            log.LogInformation($"C# Queue trigger function processed: {jsonMessage}");
>>>>>>> Added Http Trigger to the CreateChallenges Function App
        }

        #endregion
    }
}
