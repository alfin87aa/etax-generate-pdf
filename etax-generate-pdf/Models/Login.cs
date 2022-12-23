using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class Login
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
