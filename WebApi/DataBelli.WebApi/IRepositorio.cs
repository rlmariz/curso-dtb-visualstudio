﻿using DataBelli.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBelli.WebApi
{

    public interface IRepositorio
    {
        Pedido Get(Guid id);
    }
}
