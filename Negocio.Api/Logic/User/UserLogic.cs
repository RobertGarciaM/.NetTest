using AutoMapper;
using Data.Api.Models;
using Data.Api.Repositories.LoginLog;
using Data.Api.Repositories.User;
using Domain.Api.ViewModels.Login;
using Domain.Api.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Api.Logic
{
    public class UserLogic
    {
        private readonly LoginRepository _LoginRepository = new LoginRepository();
        /// <summary>
        /// Almacena el log del login del usuario
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task SaveLogLogin(string userName)
        {
            try
            {
                LogLoginViewModel logLogin = new LogLoginViewModel
                {
                    userName = userName,
                    dateLogin = DateTime.Now
                };
                var logLoginModel = Mapper.Map<LogLoginViewModel, LoginLogModel>(logLogin);
                await _LoginRepository.SaveLogLogin(logLoginModel);               
            }
            catch (Exception e) { throw e; }
        }

        /// <summary>
        /// Retorna el listado de usuarios de la aplicación
        /// </summary>
        /// <returns></returns>
        public async Task<List<ApplicationUserViewModel>> GetUserApp()
        {
            try
            {
                UserRepository _UserRepository = new UserRepository();
                return await _UserRepository.GetUsers();
            }
            catch (Exception e) { throw e; }
        }
    }
}
