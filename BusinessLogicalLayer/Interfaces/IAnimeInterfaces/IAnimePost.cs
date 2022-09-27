﻿using Entities.AnimeS;
using Shared.Responses;

namespace BusinessLogicalLayer.Interfaces.IAnimeInterfaces
{
    public interface IAnimePost
    {
        Task<Response> LeaveComentary(AnimeComentary Leave);
    }
}
