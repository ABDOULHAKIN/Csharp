namespace Module8Demo
{
    internal class FakeEmailService : IEmaiService
    {
        public bool SendEmail(string email, string body)
        {
          Console.WriteLine("simulation d'un envoi de mail " + email);
            return true;
        }
    }
}