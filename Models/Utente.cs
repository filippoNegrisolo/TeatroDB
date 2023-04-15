using System;
using System.Collections.Generic;

namespace TeatroDB.Models;

public partial class Utente
{
    public int CodiceFiscale { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Cap { get; set; }

    public string Via { get; set; } = null!;

    public string Citta { get; set; } = null!;

    public virtual ICollection<Acquisto> Acquistos { get; set; } = new List<Acquisto>();
}
