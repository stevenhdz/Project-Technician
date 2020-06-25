using LoginTemplate.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginTemplate.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboRoles()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var item in _dataContext.Roles.OrderBy(r => r.Name))
            {
                list.Add(new SelectListItem { Value = item.Name, Text = item.Name.ToUpper() });
            }

            return list;
        }
    }
}
