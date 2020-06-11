using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Csvuploadapi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Csvuploadapi.Controllers {
    [ApiController]
    [Route ("api/csv")]
    public class CsvController : ControllerBase {
        private ICsvReaderRepo _csvReaderRepo;
        private IMapper _autoMapper;

        public CsvController (ICsvReaderRepo csvReaderRepo, IMapper mapper) {
            _csvReaderRepo = csvReaderRepo;
            _autoMapper = mapper;
        }

        [HttpPost ("Upload")]
        public IActionResult UploadCSV ([FromForm] UploadedFileDto uploadedFile) {
            if (uploadedFile != null) {
                var extractList = _csvReaderRepo.ExtractCsv (uploadedFile);
                // map default values to mandatory properties
                var mappedRecord = _autoMapper.Map<List<ReturnUploadedFileDto>, List<ReturnUploadedFileDto>> (extractList);
                // filter out records with duplicate user id
                var proceesedRecords = mappedRecord.GroupBy (x => x.UserId).Select (y => y.First ()).Where (r => r.Name != "");
                // filter record if it does not have name
                var rejectedRecords = mappedRecord.Where (r => r.Name == "");
                var objectToReturn = new MappedFiledAttribute
                {
                    lstProcessedRecords = proceesedRecords,
                    lstRejectedRecords =  rejectedRecords
                };
                return Ok (objectToReturn);
            }
           return BadRequest ("Problem in Uploading File");
        }
        
    }
}