using Google.Protobuf;
using System.Collections.Generic;

//GENERATED CODE, DO NOT EDIT !
namespace Centurion.Services
{
    public partial class GuildService : BaseService
    {
        public static GuildService New()
        {
            return new GuildService();
        }

        public void OrderCoffee(ulong id, Centurion.Models.Data.CoffeeData.Types.CoffeeType coffeeType, OnProtoResponseSuccess<OrderCoffeeResponse> onSuccess, OnProtoResponseFailure onFailure)
        {
            OrderCoffeeRequest request = new OrderCoffeeRequest();
            request.Id = id;
            request.CoffeeType = coffeeType;
            
            GetProtoResponse<OrderCoffeeResponse>("Guild/OrderCoffee", request, OrderCoffeeResponse.Parser, onSuccess, onFailure);
        }

        public void ReturnCoffee(ulong id, Centurion.Models.Data.NestedA.Types.NestedB.Types.NestedC.Types.NestedEnumD enumD, OnProtoResponseSuccess<ReturnCoffeeResponse> onSuccess, OnProtoResponseFailure onFailure)
        {
            ReturnCoffeeRequest request = new ReturnCoffeeRequest();
            request.Id = id;
            request.EnumD = enumD;
            
            GetProtoResponse<ReturnCoffeeResponse>("Guild/ReturnCoffee", request, ReturnCoffeeResponse.Parser, onSuccess, onFailure);
        }
    }
    
}