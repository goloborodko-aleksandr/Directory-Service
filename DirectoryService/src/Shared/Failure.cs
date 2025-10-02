﻿using System.Collections;

namespace Shared;

public sealed class Failure : IEnumerable<Error>
{
    private readonly List<Error> _errors;

    private Failure(IEnumerable<Error> errors)
    {
        _errors = [..errors];
    }

    public IEnumerator<Error> GetEnumerator() => _errors.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public static implicit operator Failure(Error[] errors) => new(errors);

    public static implicit operator Failure(Error error) => new([error]);
}