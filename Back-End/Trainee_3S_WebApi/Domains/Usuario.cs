using System;
using System.Collections.Generic;

namespace Trainee_3S_WebApi.Domains;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int IdTipoUsuario { get; set; }

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public virtual ICollection<AcessoEspaco> AcessoEspacos { get; set; } = new List<AcessoEspaco>();

    public virtual ICollection<Colaboradore> Colaboradores { get; set; } = new List<Colaboradore>();

    public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Visitante> Visitantes { get; set; } = new List<Visitante>();
}
