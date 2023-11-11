using System;
using System.Collections.Generic;

namespace Trainee_3S_WebApi.Domains;

public partial class Colaboradore
{
    public int IdColaborador { get; set; }

    public int IdUsuario { get; set; }

    public int? IdSetor { get; set; }

    public string Nome { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual Setore? IdSetorNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Ponto> Pontos { get; set; } = new List<Ponto>();
}
