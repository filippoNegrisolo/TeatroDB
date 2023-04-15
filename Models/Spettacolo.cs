using System;
using System.Collections.Generic;

namespace TeatroDB.Models;

public partial class Spettacolo
{
    public int IdSpettacolo { get; set; }

    public string Titolo { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public string Foto { get; set; } = null!;

    public string Video { get; set; } = null!;

    public string Durata { get; set; } = null!;

    public string PrezzoBase { get; set; } = null!;

    public string Maggiorazione { get; set; } = null!;

    public virtual ICollection<Edizionespettacolo> Edizionespettacolos { get; set; } = new List<Edizionespettacolo>();
}
