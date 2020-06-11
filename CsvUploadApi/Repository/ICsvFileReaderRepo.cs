using System;
using System.Collections.Generic;

using Csvuploadapi.Dto;

public interface ICsvReaderRepo
{
   List<ReturnUploadedFileDto> ExtractCsv(UploadedFileDto uploadedFile);
}