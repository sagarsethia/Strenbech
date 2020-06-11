using System;
using Microsoft.AspNetCore.Http;

namespace Csvuploadapi.Dto
{
    public class UploadedFileDto
    {
        public IFormFile file {get; set;}
    }
}