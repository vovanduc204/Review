﻿using MC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Service
{
    public interface IUserProfileService
    {
        UserProfile GetUserProfile(long id);
    }
}
