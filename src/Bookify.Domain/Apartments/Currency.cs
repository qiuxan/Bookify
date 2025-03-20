namespace Bookify.Domain.Apartments;

public record Currency
{
    public static Currency None = new("");
    public static Currency USD = new("USD");
    public static Currency EUR = new("EUR");
    private Currency(string code) => Code = code;
    public string Code { get; init; }

    public static Currency FromCode(string code) => All.FirstOrDefault(c => c.Code == code) ?? throw new ArgumentException($"Currency with code {code} not found");

    public static readonly IReadOnlyCollection<Currency> All = new List<Currency>
    {
        USD,
        EUR
    };

};