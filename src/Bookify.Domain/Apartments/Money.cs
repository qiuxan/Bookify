﻿namespace Bookify.Domain.Apartments;

public record Money(decimal Amount, Currency Currency)
{
    public static Money operator+(Money a, Money b)
    {
        if (a.Currency != b.Currency)
        {
            throw new InvalidOperationException("Cannot add money with different currencies");
        }
        return new Money(a.Amount + b.Amount, a.Currency);
    }

    public static Money Zero() => new Money(0, Currency.None);
}