using System.ComponentModel.DataAnnotations.Schema;

public class Bookee
{
    [Column("bookeeid")]
    public int BookeeId { get; set; }
    [Column("contactid")]
    public int ContactId { get; set; }
    public Contact? Contact { get; set; }
}
