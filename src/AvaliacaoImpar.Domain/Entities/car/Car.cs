using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoImpar.Domain.Entities.photo;
using AvaliacaoImpar.Domain.Entities.ValueObjects;
using AvaliacaoImpar.Domain.Enums;

namespace AvaliacaoImpar.Domain.Entities.car
{
    public class Car : EntityValueObject
    {
        public Car(long photoId, string name, EStatusCar status)
        {
            PhotoId = photoId;
            Name = name;
            Status = status;
        }
        protected Car()
        {
            
        }
        public long PhotoId { get; private set; }
        public virtual Photo Photo { get; set; }
        public string Name { get; private set; }
        public EStatusCar Status { get; private set; }
    }
}
