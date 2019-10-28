using Data.Api.ApplicactionDbContextSpace;
using Domain.Api.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Api.Repositories.User
{
    public class UserRepository
    {

        /// <summary>
        /// Permite obtener los usuarios de la aplicación
        /// </summary>
        /// <returns></returns>
        public async Task<List<ApplicationUserViewModel>> GetUsers()
        {
            using (ApplicactionDbContext Db = new ApplicactionDbContext())
            {

                var users = from u in Db.ApplicationUser
                            join ur in Db.UserRoles on u.Id equals ur.UserId
                            join r in Db.Roles on ur.RoleId equals r.Id
                            where u.Eliminado == false
                            select new ApplicationUserViewModel
                            {
                                UserName = u.UserName,
                                NombreCompleto = u.NombreCompleto,
                                Edad = u.Edad,
                                Genero = u.Genero,
                                Nacionalidad = u.Nacionalidad,
                                Rol = r.Name
                            };

                return await users.Distinct().ToListAsync();
            }
        }
    }
}
