using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Common
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male =1,
        [Display(Name = "Female")]
        Female =2,
        [Display(Name = "Third Gender")]
        ThirdGender =3
    }
}
