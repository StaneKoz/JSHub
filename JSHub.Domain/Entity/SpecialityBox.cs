using JSHub.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSHub.Domain.Entity
{
    public class SpecialityBox
    {
        public bool WebDesign { get; set; }
        public bool AnimationDesign { get; set; }
        public bool ArtDirector { get; set; }

        public SpecialityBox(List<Speciality> speciality) 
        {

        }
    }
}
