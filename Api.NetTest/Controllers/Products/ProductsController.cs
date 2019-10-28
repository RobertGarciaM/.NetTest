using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.NetTest.Controllers.ControllerBase;
using Api.NetTest.Extensions;
using Api.NetTest.Helpers;
using Data.Api.ApplicationSettings;
using Data.Api.Models;
using Domain.Api.ViewModels.Products;
using Logic.Api.Logic.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static Api.NetTest.Enums.Enums;

namespace Api.NetTest.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : BaseController
    {

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _applicationSettings;

        public ProductsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationSettings = appSettings.Value;
        }

        /// <summary>
        /// Retorna el listado deproductos de la apliación
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetProducts")]
        [Authorize(Roles = "Admin, Regular")]
        //POST: /api/HistoricalLogin/Login
        public async Task<JsonResult> Products()
        {

            var response = new JsonResultBody
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                ProductsLogic _ProductsLogic = new ProductsLogic();
                response.Data = await _ProductsLogic.GetProducts();
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
        /// Reserva los productos de a 1 unidad
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ReserveProducts")]
        [Authorize(Roles = "Admin, Regular")]
        //POST: /api/HistoricalLogin/Login
        public async Task<JsonResult> ReserveProducts(ProductsViewModel model)
        {

            var response = new JsonResultBody
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                ProductsLogic _ProductsLogic = new ProductsLogic();
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                await _ProductsLogic.ReserveProducts(model, user.Id);
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
        /// Retorna el listado de reservas de la aplicacion
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetReserve")]
        [Authorize(Roles = "Admin, Regular")]
        //POST: /api/HistoricalLogin/Login
        public async Task<JsonResult> GetReserve()
        {

            var response = new JsonResultBody
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                ProductsLogic _ProductsLogic = new ProductsLogic();
                response.Data = await _ProductsLogic.GetReservePro();
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
