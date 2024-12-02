using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Enums;

namespace AvaliacaoImpar.Application.DTOS.card
{
    public class CardViewDTO
    {
        public CardViewDTO(long id, string name, string base64, EStatusCar eStatusCar)
        {
            this.id = id;
            this.name = name;
            this.base64 = base64;
            this.eStatusCar = eStatusCar;
        }

        public long id { get; set; }
        public string name { get; set; }
        public string base64 { get; set; }
        public EStatusCar eStatusCar { get; set; }
    }

}
