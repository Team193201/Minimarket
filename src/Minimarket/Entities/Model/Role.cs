﻿using Entities.Interface;
using Microsoft.AspNetCore.Identity;

namespace Entities.Model
{
    public class Role : IdentityRole<Guid>, IEntity
    {
    }
}
