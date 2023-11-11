using System;
using System.Collections.Generic;

namespace Trainee_3S_WebApi.Domains;

public partial class Setore
{
    public int IdSetor { get; set; }

    public string Titulo { get; set; } = null!;

    public virtual ICollection<Colaboradore> Colaboradores { get; set; } = new List<Colaboradore>();
}
