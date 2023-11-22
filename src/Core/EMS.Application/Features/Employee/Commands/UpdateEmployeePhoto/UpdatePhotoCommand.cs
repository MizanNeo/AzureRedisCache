using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employee.Commands.UpdateEmployeePhoto
{
    public class UpdatePhotoCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Stream ProfilePhoto {  get; set; }

    }
}
