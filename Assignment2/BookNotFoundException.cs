using System;

namespace Bookrental;

public class BookNotFoundException : Exception
{
    public BookNotFoundException(string message) : base(message) { }
}
