using System;
using System.Collections.Generic;

namespace TeatroDB.Models;

public partial class Acquisto
{
    public int IdAcquisto { get; set; }

    public int NumeroCarta { get; set; }

    public DateOnly? ScadenzaCarta { get; set; }

    public string Cvc { get; set; } = null!;

    public DateOnly Scadenza { get; set; }

    public int FkUtente { get; set; }

    public DateTime FkEdizioneSpettacoloA1 { get; set; }

    public int FkEdizioneSpettacoloA2 { get; set; }

    public virtual Edizionespettacolo FkEdizioneSpettacoloA { get; set; } = null!;

    public virtual Utente FkUtenteNavigation { get; set; } = null!;

    public virtual ICollection<Posto> Postos { get; set; } = new List<Posto>();
}
