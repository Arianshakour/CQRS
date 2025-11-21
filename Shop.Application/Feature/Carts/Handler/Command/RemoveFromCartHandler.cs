using MediatR;
using Shop.Application.Feature.Carts.Request.Command;
using Shop.Common.ResultPattern;
using Shop.Domain.Entities.Cart;
using Shop.Domain.Interfaces.Cart;
using Shop.Domain.Interfaces.Product;
using Shop.Domain.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Feature.Carts.Handler.Command
{
    public class RemoveFromCartHandler : IRequestHandler<RemoveFromCartRequest, Result>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        public RemoveFromCartHandler(ICartItemRepository cartItemRepository, IShoppingCartRepository shoppingCartRepository
            , IProductRepository productRepository, IUserRepository userRepository)
        {
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _userRepository = userRepository;
        }
        public Task<Result> Handle(RemoveFromCartRequest request, CancellationToken cancellationToken)
        {
            string mes = "عملیات با موفقیت انجام شد";
            var product = _productRepository.Get(request.remove.ProductId);
            if (product == null)
            {
                mes = "محصول یافت نشد";
                return Task.FromResult(Result.Failure(mes));
            }
            var user = _userRepository.GetById(request.UserId);
            if (user == null)
            {
                mes = "کاربر یافت نشد";
                return Task.FromResult(Result.Failure(mes));
            }
            //بررسی وجود سبد خرید
            var cart = _shoppingCartRepository.CheckCartForUser(request.UserId);
            if (cart == null)
            {
                mes = "سبد خریدی یافت نشد";
                return Task.FromResult(Result.Failure(mes));
            }
            //بررسی وجود محصول در سبد خرید
            var cartitem = cart.items.FirstOrDefault(x => x.ProductId == request.remove.ProductId);

            if (cartitem == null)
            {
                mes = "محصول در سبد خرید یافت نشد";
                return Task.FromResult(Result.Failure(mes));
            }
            cart.items.Remove(cartitem);
            _shoppingCartRepository.update(cart);
            return Task.FromResult(Result.Success());
        }
    }
}
