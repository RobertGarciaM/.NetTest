using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.NetTest.Controllers.ControllerBase;
using Api.NetTest.Extensions;
using Api.NetTest.Helpers;
using Data.Api.ApplicationSettings;
using Data.Api.Models;
using Domain.Api.ViewModels.Role;
using Domain.Api.ViewModels.Users;
using Logic.Api.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static Api.NetTest.Enums.Enums;

namespace Api.NetTest.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementUsersController : BaseController
    {

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _applicationSettings;
        private readonly RoleManager<IdentityRole> _roleManager;


        public ManagementUsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IOptions<ApplicationSettings> appSettings, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationSettings = appSettings.Value;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Controlador utilizado para crear un usuario utilizando los servicios de identityFramework
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        // [Authorize(Roles = "Admin, Administrador")]
        //POST: /api/GestionUsuarios/Register
        public async Task<JsonResult> PostApplicationUser(ApplicationUserViewModel model)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName.Trim().ToLower(),
                NombreCompleto = model.NombreCompleto,
                Edad = (int)model.Edad,
                Genero = model.Genero,
                Nacionalidad = model.Nacionalidad
            };

            var response = new JsonResultBody
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {

                if (String.IsNullOrEmpty(applicationUser.UserName))
                {
                    applicationUser.UserName = applicationUser.NombreCompleto.Trim().ToLower();
                    var result = await _userManager.CreateAsync(applicationUser, applicationUser.UserName.Trim().ToLower());
                    if (!result.Succeeded)
                    {
                        response.Status = System.Net.HttpStatusCode.Conflict;
                    }
                    else
                    {
                        response.Data = result;
                        var user = await _userManager.FindByNameAsync(applicationUser.UserName);
                        var resultRoles = await _userManager.AddToRoleAsync(user, model.Rol);
                    }
                }
                else
                {

                    var usuario = await _userManager.FindByNameAsync(applicationUser.UserName);
                    if (usuario != null)
                    {
                        usuario.UserName = model.UserName.Trim().ToLower();
                        usuario.NombreCompleto = model.NombreCompleto;
                        usuario.Edad = (int)model.Edad;
                        usuario.Genero = model.Genero;
                        usuario.Nacionalidad = model.Nacionalidad;
                        await _userManager.UpdateAsync(usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Data = MensajesApplicacion.ErrorApplication.ToDescriptionString();
                response.Errors.Add(ex.Message);
            }

            return Json(response);
        }


        /// <summary>
        /// Acción que crea roles en la aplicación
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Role")]
        //[Authorize(Roles = "Admin")]
        //POST: /api/GestionUsuarios/CrearRole
        public async Task<JsonResult> CreateRole(RoleViewModel model)
        {
            var response = new JsonResultBody
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                await _roleManager.CreateAsync(new IdentityRole(model.Name));
            }
            catch (Exception ex)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Data = MensajesApplicacion.ErrorApplication.ToDescriptionString();
                response.Errors.Add(ex.Message);
            }

            return Json(response);
        }

        /// <summary>
        /// Realiza un eliminado logico de un usuario de la aplicacion
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteLogic")]
        //[Authorize(Roles = "Admin")]
        //POST: /api/GestionUsuarios/CrearRole
        public async Task<JsonResult> Delete(ApplicationUserViewModel model)
        {
            var response = new JsonResultBody
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                var usuario = await _userManager.FindByNameAsync(model.UserName);
                if (usuario != null)
                {
                    usuario.Eliminado = true;
                    await _userManager.UpdateAsync(usuario);
                }
            }
            catch (Exception ex)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Data = MensajesApplicacion.ErrorApplication.ToDescriptionString();
                response.Errors.Add(ex.Message);
            }

            return Json(response);
        }


        /// <summary>
        /// Retorna los usuarios de la aplicaci
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUsers")]
        //[Authorize(Roles = "Admin")]
        //POST: /api/GestionUsuarios/CrearRole
        public async Task<JsonResult> GetUsers()
        {
            var response = new JsonResultBody
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                UserLogic _UserLogic = new UserLogic();
                response.Data = await _UserLogic.GetUserApp();
            }
            catch (Exception ex)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Data = MensajesApplicacion.ErrorApplication.ToDescriptionString();
                response.Errors.Add(ex.Message);
            }

            return Json(response);
        }
    }
}