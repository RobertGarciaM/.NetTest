using Data.Api.Repositories.Historical;
using Domain.Api.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Api.Logic
{
    public class HistoricalLogic
    {
        private readonly HistoricalRepository _HistoricalRepository = new HistoricalRepository();
        public async Task<List<LogLoginViewModel>> GetHistorical()
        {
            try
            {
               return await _HistoricalRepository.GetHistorical();
            }
            catch (Exception e) { throw e; }
        }
    }
}
