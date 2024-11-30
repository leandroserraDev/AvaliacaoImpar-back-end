using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AvaliacaoImpar.Domain.Validators
{
    public class BaseValidator<T> : AbstractValidator<T>
    {
        protected BaseValidator() { }
    }
}
