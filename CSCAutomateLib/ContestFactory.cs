﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSCAutomateLib
{
    public static class ContestFactory
    {
        #region "Public Methods"
        public static ContestRequest Default => new ContestRequest
        {
            Name = $"Automation Test {DateTime.Now.ToString("yyyyMMddhhmmss")}",
            ChallengeDescription = string.Format("Testing Challenge Automation {0}", string.Format("{0:MM-dd-yyyy hh:mm:ss}", DateTime.Now)),
            Type = "Growth",
            CollectionID = null,
            CollectionUrl = null,
            CollectionName = null,
            Country = "United States",
            ParticipantType = "Customer",
            Mstpid = "636852",
            Mpnid = null,
            TimeZone = "Dateline Standard Time",
            StartDateStr = string.Format("{0:MM-dd-yyyy hh:mm:ss}", DateTime.Now),
            EndDateStr = string.Format("{0:MM-dd-yyyy hh:mm:ss}", DateTime.Now.AddMonths(1)),
            SelfRegistrationEnabled = "true",
            CustomCss = @"body {
                    font-family: SegoeUI, sans-serif;
                    background-color: #ffffff;
                    }
                    header {
                    background-color: #ffffff;
                    color:#262626;
                    }
                    header .logo:before {
                    content: url('.. / .. / images / microsoft - theme0.png');
                    }",
            TemplateSelection = "theme0",
            MicrosoftAccountSponsor = "Frank Sposaro",
            Eou = "USA - Northeast",
            AccountType = "Strategic Commercial",
            Teams = "Team1,Team2",
            AllowTeams = "true",
            HasPrizes = "false",
            CreatedBy = "Frank Sposaro"
        };

        public static string CreateChallengeRequestJson()
        {
            StringBuilder sb = new StringBuilder();
            DateTime dt = DateTime.Now;

            sb.Append("{\"baseInputs\":{\"EndDateStr\":\"");
            sb.Append(string.Format("{0:MM-dd-yyyy hh:mm:ss}", dt.AddMonths(1)));
            sb.Append("\",\"StartDateStr\":\"");
            sb.Append(string.Format("{0:MM-dd-yyyy hh:mm:ss}", dt));
            sb.Append("\",\"accountType\":\"Strategic Commercial\",\"allowTeams\":\"true\",\"challengeDescription\":\"");
            sb.Append(string.Format("Testing Challenge Automation {0}", string.Format("{0:MM-dd-yyyy hh:mm:ss}", dt)));
            sb.Append("\",\"collectionUrl\":\"null\",\"country\":\"United States\",\"createdby\":\"srambati\",\"customCSS\":\"null\",\"eou\":\"null\",\"hasPrizes\":\"false\",\"microsoftAccountSponsor\":\"srambati\",\"mpnid\":\"null\",\"mstpid\":\"645147\",\"name\":\"");
            sb.Append($"Automation Test {dt.ToString("yyyyMMddhhmmss")}");
            sb.Append("\",\"participantType\":\"Customer\",\"selfRegistrationEnabled\":\"true\",\"teams\":\"Team1,Team2\",\"templateSelection\":\"theme0\",\"timeZone\":\"null\",\"type\":\"Growth\"},\"learningPaths\":[{\"collectionName\":\"AZ-900\",\"collectionUrl\":\"https://docs.microsoft.com/en-us/learn/paths/azure-fundamentals\"},{\"collectionName\":\"AZ-103\",\"collectionUrl\":\"https://docs.microsoft.com/en-us/users/drfrank/collections/704b82r0m6zn0\"},{\"collectionName\":\"AZ-120\",\"collectionUrl\":\"Needs Collection URL\"},{\"collectionName\":\"AZ-203\",\"collectionUrl\":\"Needs Collection URL\"},{\"collectionName\":\"AZ-220\",\"collectionUrl\":\"Needs Collection URL\"},{\"collectionName\":\"AZ-300/301\",\"collectionUrl\":\"Needs Collection URL\"},{\"collectionName\":\"AI-100\",\"collectionUrl\":\"Needs Collection URL\"},{\"collectionName\":\"DP-100\",\"collectionUrl\":\"Needs Collection URL\"},{\"collectionName\":\"AI-100\",\"collectionUrl\":\"Needs Collection URL\"},{\"collectionName\":\"DP-100\",\"collectionUrl\":\"Needs Collection URL\"},{\"collectionName\":\"DP-200/201\",\"collectionUrl\":\"Needs Collection URL\"},{\"collectionName\":\"AZ-400\",\"collectionUrl\":\"Needs Collection URL\"},{\"collectionName\":\"AZ-500\",\"collectionUrl\":\"Needs Collection URL\"}]}");

            return sb.ToString();

            //return "{\"baseInputs\":{\"EndDateStr\":\"03-30-2020 23:59:59\",\"StartDateStr\":\"03-30-2020 14:24:30\",\"accountType\":\"Customer\",\"allowTeams\":\"false\",\"challengeDescription\":\"Cloud Skills Challenge\",\"country\":\"United States\",\"createdby\":\"Srini Ambati\",\"eou\":\"Northeast\",\"hasPrizes\":\"false\",\"microsoftAccountSponsor\":\"srambati\",\"mstpid\":\"645147\",\"name\":\"UTC Challenge 001\",\"participantType\":\"Customer\",\"selfRegistrationEnabled\":\"true\",\"templateSelection\":\"theme0\",\"timeZone\":\"Dateline Standard Time\",\"type\":\"Collection\"},\"learningPaths\":[{\"collectionName\":\"Azure Fundamentals\",\"collectionUrl\":\"https://docs.microsoft.com/en-us/learn/paths/azure-fundamentals/\"},{\"collectionName\":\"Azure DevOps Engineer Expert\",\"collectionUrl\":\"https://docs.microsoft.com/en-us/users/drfrank/collections/584uq7y8ggnrr\"}]}";
        }
        public static string CreateLearnerRequestJson()
        {
            return "{\"contestId\":\"b95e57ea-61d1-4844-935e-7477e05d8f6a\",\"learnerId\":\"SriniAmbati-6212\"}";
        }
        public static ChallengeRequest CreateChallengeRequest(string jsonChallengeRequest)
        {
            ChallengeRequest request = JsonConvert.DeserializeObject<ChallengeRequest>(jsonChallengeRequest);

            if (request == null)
                throw new ArgumentException("Error parsing challenge request JSON");

            if (string.IsNullOrWhiteSpace(request.BaseInputs.Mstpid))
                throw new ArgumentNullException($"{nameof(request.BaseInputs.Mstpid)} must be valid");

            // Set the end date for +1 month
            DateTime startDate = DateTime.Parse(request.BaseInputs.StartDateStr);
            request.BaseInputs.EndDateStr = startDate.AddMonths(1).ToString("MM-dd-yyyy HH:mm:ss");

            return request;
        }
        #endregion
    }
}
