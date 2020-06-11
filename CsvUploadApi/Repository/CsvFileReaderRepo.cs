
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using CsvHelper;
using Csvuploadapi.Dto;
using System.Net.Http.Headers;
using System;

public class CsvFileReaderRepo : ICsvReaderRepo
 {
    public List<ReturnUploadedFileDto> ExtractCsv(UploadedFileDto uploadedFile)
    {
       List<ReturnUploadedFileDto> records;
       using (var reader = new StreamReader(uploadedFile.file.OpenReadStream())){
                using (var csv = new CsvReader(reader,CultureInfo.InvariantCulture))
                {   
                    csv.Configuration.MissingFieldFound = null;
                    csv.Configuration.HeaderValidated = null;
                    records = csv.GetRecords<ReturnUploadedFileDto>().ToList();
                }
            }
            return records;
    }

}