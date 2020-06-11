using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
namespace Csvuploadapi.Dto

{
    public class MappedFiledAttribute
    {
      public IEnumerable<ReturnUploadedFileDto> lstProcessedRecords { get; set; }
      public IEnumerable<ReturnUploadedFileDto> lstRejectedRecords { get; set; }
    }
}
