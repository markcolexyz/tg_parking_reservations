using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    [Column("employeeid")]
    public string? EmployeeId { get; set; }
    [Column("contact_id")]
    public int ContactId { get; set; }    
    public Contact? Contact { get; set; }
}