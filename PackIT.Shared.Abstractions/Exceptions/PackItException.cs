﻿namespace PackIT.Shared.Abstractions.Exceptions;

public class PackItException : Exception
{
    protected PackItException(string message): base(message)
    {
        
    }
}