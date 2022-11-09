namespace infrastructure.DTOs;
public record DateDTO
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public DateDTO(Date entity)
    {
        Year = entity.Year;
        Month = entity.Month;
        Day = entity.Day;
    }
}