namespace University.Instructors.Core.ValueObjects;

public record OfficeLocation(string Address, string PostalCode, string City)
{
    public OfficeLocation CreateNew(string address, string postalCode, string city)
    {
        return new OfficeLocation(address, postalCode, city);
    }
}