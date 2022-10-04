﻿using Entities.UserS;
using Shared;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IUserItem
{
    public interface IUserAnimeItemDAL : ICRUD<UserAnimeItem>
    {
        Task<DataResponse<UserAnimeItem>> GetByUser(int userid);
    }
}
