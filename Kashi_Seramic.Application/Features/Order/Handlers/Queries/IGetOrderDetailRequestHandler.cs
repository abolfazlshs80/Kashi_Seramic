using Kashi_Seramic.Application.DTOs.Order;
using Kashi_Seramic.Application.Features.Order.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.Features.Order.Handlers.Queries
{
    public interface IGetOrderDetailRequestHandler
    {
        Task<OrdersDto> Handle(GetOrderDetailRequest request, CancellationToken cancellationToken);
    }
}