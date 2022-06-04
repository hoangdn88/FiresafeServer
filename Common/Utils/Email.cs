using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Models;
using Common.MongoDbHelper.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Utilss
{
    public static class Email
    {


        public static async Task SendEmail(UserEmailOptions userEmailOptions, SMTPConfigModel _smtpConfig)
        {
            var message = new Message
            {
                Subject = userEmailOptions.Subject,
                Body = new ItemBody
                {
                    ContentType = BodyType.Html,
                    Content = userEmailOptions.Body
                },
                ToRecipients = new List<Recipient>()
                {
                    new Recipient
                    {
                        EmailAddress = new EmailAddress
                        {
                            Address = userEmailOptions.ToEmails[0]
                        }
                    }
                },
            };
            IConfidentialClientApplication confidentialClient = ConfidentialClientApplicationBuilder
                .Create(_smtpConfig.ClientId)
                .WithClientSecret(_smtpConfig.ClientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{_smtpConfig.TenanId}/v2.0"))
                .Build();

            // Retrieve an access token for Microsoft Graph (gets a fresh token if needed).
            var ewScope = new string[] { "https://graph.microsoft.com/.default" };
            var authResult = await confidentialClient
                    .AcquireTokenForClient(ewScope)
                    .ExecuteAsync().ConfigureAwait(false);

            var token = authResult.AccessToken;
            // Build the Microsoft Graph client. As the authentication provider, set an async lambda
            // which uses the MSAL client to obtain an app-only access token to Microsoft Graph,
            // and inserts this access token in the Authorization header of each API request. 
            GraphServiceClient graphServiceClient =
                new GraphServiceClient(new DelegateAuthenticationProvider(async (requestMessage) =>
                {
                    // Add the access token in the Authorization header of the API request.
                    requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("Bearer", token);
                })
                );
            await graphServiceClient.Users[_smtpConfig.UserId]
                  .SendMail(message, false)
                  .Request()
                  .PostAsync();
        }

    }



}
