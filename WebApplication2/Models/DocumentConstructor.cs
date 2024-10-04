using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class DocumentConstructor 
    {
        public int DocumentConstructorId { get; set; }
    }
    public class DocumentConstructorLeftData
    {
        public int DocumentConstructorLeftDataId { get; set; }
        public string Title { get; set; }
        public int Npp { get; set; }
        public int? SizeTitle { get; set; }
        public virtual ICollection<DocumentConstructorCenterData> Data { get; set; }
    }
    public class DocumentConstructorCenterData
    {
        public int DocumentConstructorCenterDataId { get; set; }
        public string Content { get; set; }
        public int LeftDataId { get; set; }
        public virtual DocumentConstructorLeftData Data { get; set; }
    }
}