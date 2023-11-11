using System;
using System.Collections.Generic;

namespace Trainee_3S_WebApi.Domains;

public partial class Visitante
{
    public int IdVisitante { get; set; }

    public int IdUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
