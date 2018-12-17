using AWSmS.Service;
using System;

namespace AWSmS.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var message = new Message("1130444292", "5511954673640", "Olá Cássio, você tem 5 solicitações novas.", MessageType.Transactional);
            var result = SMSService.Send(message);

            if (result.IsValid)
                Console.WriteLine("SMS sent successful!");
            else
            {
                foreach (string error in result.Errors)
                    Console.WriteLine(error);
            }

        }
    }
}
