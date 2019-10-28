using Data.Api.ApplicactionDbContextSpace;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Domain.Api.ViewModels.Products;
using Data.Api.Models;
using Domain.Api.ViewModels.Reserve;

namespace Data.Api.Repositories.Products
{
    public class ProductsRepository
    {
        /// <summary>
        /// Permite obtener el listado de productos
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductsViewModel>> GetProducts()
        {

            using (ApplicactionDbContext Db = new ApplicactionDbContext())
            {

                var products = from u in Db.ProductsModel
                                 select new ProductsViewModel {
                                     ProductoId = u.idProduct,
                                     Descripcion = u.Descripcion,
                                     amount = u.amount,
                                     avalaible = u.avalaible
                                 };
                                

                return await products.ToListAsync();
            }
        }

        /// <summary>
        /// Consulta los productos por id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductsModel> GetProductsById(ProductsViewModel model)
        {

            using (ApplicactionDbContext Db = new ApplicactionDbContext())
            {

                var products = from u in Db.ProductsModel
                               where u.idProduct == model.ProductoId
                               select u;


                return await products.FirstOrDefaultAsync();
            }
        }

        /// <summary>
        /// Obtiene las reservas de la aplicación
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReserveViewModel>> GetReserve()
        {

            using (ApplicactionDbContext Db = new ApplicactionDbContext())
            {

                var reserve = from u in Db.ReserveProductModel
                               join p in Db.ApplicationUser on u.idUser equals p.Id
                               join pp in Db.ProductsModel on u.idProducto equals pp.idProduct
                               select new ReserveViewModel {
                                   UserName = p.NombreCompleto,
                                   Description = pp.Descripcion
                               };


                return await reserve.ToListAsync();
            }
        }

        /// <summary>
        /// AQctuaqliza un producto
        /// </summary>
        /// <param name="model"></param>
        public async void UpdateProduct(ProductsModel model)
        {
            using (ApplicactionDbContext Db = new ApplicactionDbContext())
            {

                Db.Entry(model).State = EntityState.Modified;
                await Db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Permite almacenar la reserva
        /// </summary>
        /// <param name="reserve"></param>
        /// <returns></returns>
        public async Task SaveReserveAync(ReserveProductModel reserve)
        {
            using (ApplicactionDbContext Db = new ApplicactionDbContext())
            {
                await Db.AddAsync(reserve);
                await Db.SaveChangesAsync();
            }
        }
    }
}
