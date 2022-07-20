﻿using Entities.Interface;
using Microsoft.AspNetCore.Identity;

namespace Entities.Model
{
    public class UserRole : IdentityUserRole<Guid>, IEntity
    {
    }
}