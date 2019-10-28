using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Api.ViewModels.Role
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
