# AW SMS
.Core project to send SMS using Amazon AWS

# AWS SNS (Simple Notification Service)
This program uses AWSSDK.Core and AWSSDK.SimpleNotificationService.

# Service Layer
In AWSmS.Service project there are the following objects:

- Message: The message containing the properties MessageText, PhoneNumber, MessageType and SenderId.  The SenderId depends on each country, please check if your country can use SenderId on: https://docs.aws.amazon.com/sns/latest/dg/sms_supported-countries.html

- MessageContract: DesignContract to verify well filled properties 
- MessageType: Promotional or Transacion SMS
- SMSService: The class responsible for send SMS

- ServiceResponse: The class responsible for obtain result after sending.

# Configuring secret key and access key
In AWSmS.Utils project, open AWSCredentials.cs and define the variables:

        public static string AccessKey = "";
        public static string SecretKey = "";

