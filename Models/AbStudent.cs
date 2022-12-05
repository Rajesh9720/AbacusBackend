using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class AbStudent
{
    public int Id { get; set; }

    public string StudentsName { get; set; } = null!;

    public string? Age { get; set; }

    public string? Grade { get; set; }

    public string? ContactNumber { get; set; }

    public string Email { get; set; } = null!;

    public string? Password { get; set; }
}
