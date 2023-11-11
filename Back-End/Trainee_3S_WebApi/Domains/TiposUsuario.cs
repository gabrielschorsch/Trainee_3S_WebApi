using System;
using System.Collections.Generic;

namespace Trainee_3S_WebApi.Domains;

public partial class TiposUsuario
{
    public int IdTipoUsuario { get; set; }

    public string Titulo { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
