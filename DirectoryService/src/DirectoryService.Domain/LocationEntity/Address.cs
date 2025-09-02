using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.LocationEntity;

public record Address
{
    public string Country { get; } // Страна

    public string Region { get; } // Область / Штат / Провинция

    public string City { get; } // Город / Населённый пункт

    public string? District { get; } // Район / Округ (опционально)

    public string Street { get; } // Улица / Проспект / Переулок

    public string? HouseNumber { get; } // Дом (строка, т.к. бывают дроби и буквы: 10A, 12/1)

    public string? Building { get; } // Корпус / Строение

    public string? Apartment { get; } // Квартира / Офис

    public string? ZipCode { get; } // Почтовый индекс

    public string? AdditionalInfo { get; } // Дополнительно: подъезд, этаж, ориентиры и т.д.

    private Address(
        string country,
        string region,
        string city,
        string street,
        string? district,
        string? houseNumber,
        string? building,
        string? apartment,
        string? zipCode,
        string? additionalInfo)
    {
        Country = country;
        Region = region;
        City = city;
        Street = street;
        District = district;
        HouseNumber = houseNumber;
        Building = building;
        Apartment = apartment;
        ZipCode = zipCode;
        AdditionalInfo = additionalInfo;
    }

    public static Result<Address> Create(
        string country,
        string region,
        string city,
        string street,
        string? district,
        string? houseNumber,
        string? building,
        string? apartment,
        string? zipCode,
        string? additionalInfo)
    {
        var isLatin = new Func<string, bool>(value =>
            !string.IsNullOrEmpty(value) && Regex.IsMatch(value, "^[a-zA-Z]+$"));

        var isLatinNumbersSymbols = new Func<string, bool>(value =>
            !string.IsNullOrEmpty(value) && Regex.IsMatch(value, "^[a-zA-Z0-9./-]+$"));

        if (!isLatin(country) || !char.IsUpper(country.First()))
            return Result.Failure<Address>("Country name should be in Latin and start with uppercase letter");

        if (!isLatin(region) || !char.IsUpper(region.First()))
            return Result.Failure<Address>("Region name should be in Latin and start with uppercase letter");

        if (!isLatin(city) || !char.IsUpper(city.First()))
            return Result.Failure<Address>("City name should be in Latin and start with uppercase letter");

        if (!isLatin(street) || !char.IsUpper(street.First()))
            return Result.Failure<Address>("Street name should be in Latin and start with uppercase letter");

        if (district != null && (!isLatin(district) || !char.IsUpper(district.First())))
            return Result.Failure<Address>("District name should be in Latin and start with uppercase letter");

        if (houseNumber != null && !isLatinNumbersSymbols(houseNumber))
            return Result.Failure<Address>("HouseNumber should contain only Latin letters, numbers or ./-");

        if (building != null && !isLatinNumbersSymbols(building))
            return Result.Failure<Address>("Building should contain only Latin letters, numbers or ./-");

        if (apartment != null && !isLatinNumbersSymbols(apartment))
            return Result.Failure<Address>("Apartment should contain only Latin letters, numbers or ./-");

        if (zipCode != null && !Regex.IsMatch(zipCode, "^[a-zA-Z0-9]+$"))
            return Result.Failure<Address>("ZipCode should contain only numbers and Latin letters");

        return Result.Success(new Address(
            country, region, city, street,
            district, houseNumber, building, apartment,
            zipCode, additionalInfo));
    }
}