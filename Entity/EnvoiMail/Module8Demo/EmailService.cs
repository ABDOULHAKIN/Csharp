namespace Module8Demo
{
    internal class EmailService : IEmaiService
    {
        public bool SendEmail(string email, string body)
        {
           var message = new { email, body };

          //  message.Send();
            return true;
        }
    }



}