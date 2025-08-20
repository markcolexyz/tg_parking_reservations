using System.ComponentModel.DataAnnotations.Schema;

public class Contact
{
    [Column("contactid")]
    public int ContactId { get; set; }
    [Column("firstname")]
    public string? Firstname { get; set; }
    [Column("lastname")]
    public string? Lastname { get; set; }
    [Column("contactinformation_id")]
    public int ContactInformationId { get; set; }
}
