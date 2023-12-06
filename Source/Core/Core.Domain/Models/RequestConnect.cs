namespace Core.Domain;

public class RequestConnect
{
  public int Id { get; set; }
  public bool Accepted { get; set; }

  //RELATIONS
  public int SenderId { get; set; }
  public User Sender { get; set; }

  public int ReceiverId { get; set; }
  public User Receiver { get; set; }
}
