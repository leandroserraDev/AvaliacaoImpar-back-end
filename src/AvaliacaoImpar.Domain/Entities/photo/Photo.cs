using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.ValueObjects;

namespace AvaliacaoImpar.Domain.Entities.photo
{
    public class Photo : EntityValueObject
    {

        public string Base64 { get; private set; }

        public Photo(string base64)
        {
            Base64 = base64;
        }

        protected Photo()
        {
            
        }
    }
}
