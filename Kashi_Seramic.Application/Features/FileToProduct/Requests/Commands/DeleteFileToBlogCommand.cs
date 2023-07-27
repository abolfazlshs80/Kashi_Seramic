using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.FileToProduct.Requests.Commands
{
    public class DeleteFileToProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
