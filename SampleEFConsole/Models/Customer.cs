using System;
using System.Collections.Generic;

namespace SampleEFConsole.Models;

public partial class Customer
{
    public int Custid { get; set; }

    public string Custname { get; set; } = null!;

    public string? City { get; set; }

    public int? Age { get; set; }
}
