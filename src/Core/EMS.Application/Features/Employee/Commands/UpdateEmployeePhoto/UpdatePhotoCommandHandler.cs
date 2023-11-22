using AutoMapper;
using Azure.Storage.Blobs;
using EMS.Application.Contracts;
using EMS.Application.Features.Employee.Commands.AddEmployee;
using EMS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employee.Commands.UpdateEmployeePhoto
{
    public class UpdatePhotoCommandHandler : IRequestHandler<UpdatePhotoCommand, Response<string>>
    {
        private IAsyncRepository<Domain.Entities.Employee> empRepo;
        private IMapper mapper;
        private IConfiguration config;
        public UpdatePhotoCommandHandler(IAsyncRepository<Domain.Entities.Employee> repository, IMapper mapper, IConfiguration config)
        {
            this.empRepo = repository;
            this.mapper = mapper;
            this.config = config;
        }
        public async Task<Response<string>> Handle(UpdatePhotoCommand request, CancellationToken cancellationToken)
        {
            var employee = await empRepo.GetByIdAsync(request.Id);
            if (employee == null)
            {
                return new Response<string>("Data not found for given id.");
            }
            string fileName = employee.Pan + Path.GetExtension(request.FileName).ToLower();
            var res= await UpdateFileToBlob(fileName, request.ProfilePhoto);
            employee.ProfileImage = fileName;
            await empRepo.UpdateAsync(employee);
            return new Response<string>(fileName,"Profile Photo uploaded successfully.");
        }
        private async Task<Azure.Response> UpdateFileToBlob(string fileName, Stream file)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(config.GetConnectionString("AzureBlobStorageConStr"));
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(config.GetSection("BlobStorage:ContainerName").Value);
            BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);
            var res=await blobClient.UploadAsync(file, true);
            return res.GetRawResponse();
        }
    }
}
