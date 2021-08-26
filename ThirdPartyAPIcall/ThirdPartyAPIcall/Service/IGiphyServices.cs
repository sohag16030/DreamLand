using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdPartyAPIcall.Model;

namespace ThirdPartyAPIcall.Service
{
    public interface IGiphyServices
    {
        Task<GiphyModel> GetRandomGifBasedOnSearchCritera(string searchCritera);
    }
}
