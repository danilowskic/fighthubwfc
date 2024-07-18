namespace WebAppBackend.DTOs;

public class EventDTO
{
    public string Name { get; set; }
    public string Street { get; set; }
    public int BuildingNumber { get; set; }
    public string ApartmentNumber { get; set; }
    public string City { get; set; }
    public string Zipcode { get; set; }
    public string DateTime { get; set; }
}