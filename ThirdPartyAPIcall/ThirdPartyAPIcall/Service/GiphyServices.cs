using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdPartyAPIcall.Model;

namespace ThirdPartyAPIcall.Service
{
    public class GiphyServices : IGiphyServices
    {
        private static IGetRandomGif _getRandomGif;
        public GiphyServices(IGetRandomGif getRandomGif)
        {
            _getRandomGif = getRandomGif;
        }
        public async Task<GiphyModel> GetRandomGifBasedOnSearchCritera(string searchCritera)
        {
            return await _getRandomGif.ReturnRandomGifBasedOnTag(searchCritera);
        }
    }
}
