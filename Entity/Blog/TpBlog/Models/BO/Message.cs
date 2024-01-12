namespace TpBlog.Models.BO
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public MessageStatus Status { get; set; }
        //Id de l'utilisateur propriétaire du message (issu de la Table AspNetUser)
        public string? OwnerId { get; set; }
        
    }

    public enum MessageStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
