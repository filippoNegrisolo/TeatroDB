using System;
using System.Collections.Generic;

namespace TeatroDB.Models;

public partial class Edizionespettacolo
{
    public DateTime DataOra { get; set; }

    public int FkSpettacolo { get; set; }

    public virtual ICollection<Acquisto> Acquistos { get; set; } = new List<Acquisto>();

    public virtual Spettacolo FkSpettacoloNavigation { get; set; } = null!;

    public virtual ICollection<Posto> Postos { get; set; } = new List<Posto>();
}
