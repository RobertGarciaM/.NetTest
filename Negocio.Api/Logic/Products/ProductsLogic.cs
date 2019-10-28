using Data.Api.Models;
using Data.Api.Repositories.Products;
using Domain.Api.ViewModels.Products;
using Domain.Api.ViewModels.Reserve;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Api.Logic.Products
{
    public class ProductsLogic
    {
        private readonly ProductsRepository _ProductsRepository = new ProductsRepository();

        /// <summary>
        /// Permite obtener la lista de productos de la app
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductsViewModel>> GetProducts()
        {
            try
            {
                return await _ProductsRepository.GetProducts();
            }
            catch (Exception e) { throw e; }
        }

        //Retorna la lista de las reservas
        public async Task<List<ReserveViewModel>> GetReservePro()
        {
            try
            {
                return await _ProductsRepository.GetReserve();
            }
            catch (Exception e) { throw e; }
        }

        /// <summary>
        /// Reserva la produyctos de a unidad
        /// </summary>
        /// <returns></returns>
        public async Task ReserveProducts(ProductsViewModel model, string idUser)
        {
            try
            {
                var product =  await _ProductsRepository.GetProductsById(model);
                if (product != null && product.avalaible > 0) {
                    product.avalaible = product.avalaible - 1;
                     _ProductsRepository.UpdateProduct(product);
                    ReserveProductModel _ReserveProductModel = new ReserveProductModel {
                        delete = false,
                        idProducto = product.idProduct,
                        idUser = idUser
                    };

                    await _ProductsRepository.SaveReserveAync(_ReserveProductModel);
                }

            }
            catch (Exception e) { throw e; }
        }
    }
}
