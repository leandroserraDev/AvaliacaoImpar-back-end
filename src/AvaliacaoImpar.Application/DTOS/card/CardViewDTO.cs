using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Enums;

namespace AvaliacaoImpar.Application.DTOS.card
{
    public record CardViewDTO(long id,string name, string base64, EStatusCar eStatusCar);

}
