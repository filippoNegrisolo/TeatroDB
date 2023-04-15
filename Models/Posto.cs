using System;
using System.Collections.Generic;

namespace TeatroDB.Models;

public partial class Posto
{
    public int NumeroPoltrona { get; set; }

    public int Fila { get; set; }

    public string Settore { get; set; } = null!;

    public decimal Prezzo { get; set; }

    public int FkAcquisto { get; set; }

    public DateTime FkEdizioneSpettacoloP1 { get; set; }

    public int FkEdizioneSpettacoloP2 { get; set; }

    public virtual Acquisto FkAcquistoNavigation { get; set; } = null!;

    public virtual Edizionespettacolo FkEdizioneSpettacoloP { get; set; } = null!;
}
