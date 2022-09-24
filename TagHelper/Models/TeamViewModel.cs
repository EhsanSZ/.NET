using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelper.Models
{
    public class TeamViewModel
    {
        public string Team { get; set; }

        public IEnumerable<string> TeamMltiple { get; set; }
        public List<SelectListItem> TeamOptionGroup { get; set; }
        public List<SelectListItem> Teams { get; set; }
        public TeamEnum TeamEnum { get; set; }

        public List<SelectListItem> TeamMltipleItem { get; set; }

    }


    public enum TeamEnum
    {
        [Display(Name ="پرسپولیس")]
       Perspolis,
       Sepahan,
       Esteghlal,

    }
}
