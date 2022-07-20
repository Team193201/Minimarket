﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ProductApplication.Query
{
    public class GetProductNameQuery:IRequest<string> 
    {
        public Guid ProductId { get; set; }
    }
}