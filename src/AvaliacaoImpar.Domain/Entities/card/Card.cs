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
    public class Card : EntityValueObject
    {
        public Card( string name, Photo photo, EStatusCar status)
        {
            Photo = photo;
            Name = name;
            Status = status;
        }

        //construtor para edição
        public Card(long id,string name, Photo photo, EStatusCar status)
        {
            Id = id;
            Photo = photo;
            Name = name;
            Status = status;
        }




        protected Card()
        {
            
        }
        public virtual Photo Photo { get;private set; }
        public string Name { get; private set; }
        public EStatusCar Status { get; private set; }


        public  void UpdateData(Card cardToUpdate)
        {
            Name = cardToUpdate.Name;
            Photo = cardToUpdate.Photo;
            Status = cardToUpdate.Status;

        }


    }
}
