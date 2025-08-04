using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(X => X.Name).NotEmpty().WithMessage("Ürün adını boş geçemezsiniz");
            RuleFor(X => X.Name).MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır");
            RuleFor(X => X.Stock).NotEmpty().WithMessage("Stok sayısı boş geçilemez");
            RuleFor(X => X.Price).NotEmpty().WithMessage("Fiyat boş geçilemez");

        }
    }
}
