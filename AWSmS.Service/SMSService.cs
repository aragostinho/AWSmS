using Amazon;
using Amazon.SimpleNotificationService.Model;
using AWSmS.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSmS.Service
{
    public static class SMSService
    {
        public static ServiceResponse Send(Message message)
        {
            ServiceResponse response = new ServiceResponse();
            if (message.IsValid())
            {
                var snsService = new Amazon.SimpleNotificationService.AmazonSimpleNotificationServiceClient(AWSCredentials.AccessKey, AWSCredentials.SecretKey, RegionEndpoint.USEast1);

                var attributes = new Dictionary<string, MessageAttributeValue>();
                attributes.Add("AWS.SNS.SMS.SenderID", new MessageAttributeValue() { StringValue = message.SenderId, DataType = "String" });
                attributes.Add("AWS.SNS.SMS.SMSType", new MessageAttributeValue() { StringValue = message.Type.GetDescription(), DataType = "String" });

                var request = new Amazon.SimpleNotificationService.Model.PublishRequest();
                request.PhoneNumber = $"+{message.PhoneNumber}";
                request.Message = message.TextMessage;
                request.MessageAttributes = attributes;

                var result = snsService.PublishAsync(request).Result;
                if (result.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    response.IsValid = true;
                else
                {
                    response.Errors.Add("SMS failed!");
                    response.IsValid = false;
                }
            }
            else
            {
                response.Errors = message.Errors;
                response.IsValid = false;
            }
            return response;
        }
    }
}
