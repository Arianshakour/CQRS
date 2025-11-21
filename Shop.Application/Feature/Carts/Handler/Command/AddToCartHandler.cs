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
    public class AddToCartHandler : IRequestHandler<AddToCartRequest, Result>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        public AddToCartHandler(ICartItemRepository cartItemRepository, IShoppingCartRepository shoppingCartRepository
            , IProductRepository productRepository, IUserRepository userRepository)
        {
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _userRepository = userRepository;
        }
        public Task<Result> Handle(AddToCartRequest request, CancellationToken cancellationToken)
        {
            string mes = "عملیات با موفقیت انجام شد";
            var product = _productRepository.Get(request.add.ProductId);
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
                cart = new ShoppingCart()
                {
                    UserId = request.UserId,
                    items = new List<CartItem>()
                };
            }
            //بررسی وجود محصول در سبد خرید
            var cartitem = cart.items.FirstOrDefault(x => x.ProductId == request.add.ProductId);

            if (cartitem == null)
            {
                cartitem = new CartItem()
                {
                    ProductId = request.add.ProductId,
                    Quantity = request.add.Quantity,
                    product = product
                };
                cart.items.Add(cartitem);
            }
            else
            {
                cartitem.Quantity += request.add.Quantity;
            }
            //بررسی اینکه باید درج کند یا اپدیت کند
            if (cart.Id == 0) // یعنی تازه ساخته شده
                _shoppingCartRepository.Create(cart);
            else
                _shoppingCartRepository.update(cart);

            return Task.FromResult(Result.Success());
        }
    }
}
