using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.LocationEntity;

public sealed record Address
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

    public static Result<Address, Failure> Create(
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
            return GeneralError.ValueIsInvalid("country").ToFailure();

        if (Regex.IsMatch(region, @"^([A-Z][a-zA-Z]*)(\s[A-Z][a-zA-Z]*)*$"))
            return GeneralError.ValueIsInvalid("region").ToFailure();

        if (!isLatin(city) || !char.IsUpper(city.First()))
            return GeneralError.ValueIsInvalid("city").ToFailure();

        if (!isLatin(street) || !char.IsUpper(street.First()))
            return GeneralError.ValueIsInvalid("street").ToFailure();

        if (district != null && (!isLatin(district) || !char.IsUpper(district.First())))
            return GeneralError.ValueIsInvalid("district").ToFailure();

        if (houseNumber != null && !isLatinNumbersSymbols(houseNumber))
            return GeneralError.ValueIsInvalid("houseNumber").ToFailure();

        if (building != null && !isLatinNumbersSymbols(building))
            return GeneralError.ValueIsInvalid("building").ToFailure();

        if (apartment != null && !isLatinNumbersSymbols(apartment))
            return GeneralError.ValueIsInvalid("apartment").ToFailure();

        if (zipCode != null && !Regex.IsMatch(zipCode, "^[a-zA-Z0-9-]+$"))
            return GeneralError.ValueIsInvalid("zipCode").ToFailure();

        return new Address(
            country, region, city, street,
            district, houseNumber, building, apartment,
            zipCode, additionalInfo);
    }
}