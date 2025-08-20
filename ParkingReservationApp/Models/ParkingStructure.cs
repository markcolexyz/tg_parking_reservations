using System.ComponentModel.DataAnnotations.Schema;

public class ParkingStructure
{
    [Column("parkingstructure_id")]
    public int ParkingStructureId { get; set; }
    [Column("structurename")]
    public string? StructureName { get; set; }
}