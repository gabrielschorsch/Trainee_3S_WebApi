﻿using System;
using System.Collections.Generic;

namespace Trainee_3S_WebApi.Domains;

public partial class AcessoEspaco
{
    public int IdAcessoEspaco { get; set; }

    public int IdUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
