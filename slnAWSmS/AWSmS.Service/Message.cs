using AWSmS.Utils;
using System;

namespace AWSmS.Service
{
    public class Message : MessageContract
    {
        public string SenderId { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string TextMessage { get; protected set; }
        public MessageType Type { get; protected set; }


        public Message(string senderId, string phoneNumber, string textMessage, MessageType type)
        {
            this.SenderId = senderId;
            this.PhoneNumber = phoneNumber;
            this.TextMessage = textMessage;
            this.Type = type; 

        }

        public override bool IsValid()
        {

            if (this.SenderId.IsNullOrEmpty())
            {
                base.Errors.Add("SenderId is empty");
                return false;
            }

            if (this.PhoneNumber.IsNullOrEmpty())
            {
                base.Errors.Add("Phone number is empty");
                return false;
            }

            if (!this.PhoneNumber.IsNumber())
            {
                base.Errors.Add("Phone number is not a number");
                return false;
            }

            if (this.TextMessage.IsNullOrEmpty())
            {
                base.Errors.Add("The message is empty");
                return false;
            }

            if (this.TextMessage.Length > 160)
            {
                base.Errors.Add("The message exceeded 160 characters");
                return false;
            }

            return true;
        }


    }
}
