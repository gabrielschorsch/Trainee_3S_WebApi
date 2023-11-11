using System;
using System.Collections.Generic;

namespace Trainee_3S_WebApi.Domains;

public partial class Ponto
{
    public int IdPonto { get; set; }

    public int IdColaborador { get; set; }

    public string HorarioPonto { get; set; } = null!;

    public virtual Colaboradore IdColaboradorNavigation { get; set; } = null!;
}
