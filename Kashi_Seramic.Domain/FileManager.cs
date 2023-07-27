using Kashi_Seramic.Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Domain
{
    public class FileManager : BaseDomainEntity
    {


        public string Path { get; set; }

        public string Title { get; set; }
        public string? Type { get; set; }
        public bool IsUploaderFile { get; set; }
        public ICollection<FileToBlog> FileToBlog { get; set; }
        public ICollection<FileToProduct> FileToProduct { get; set; }


    }
}
