using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooLibrary.Abstractions.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public DateTime CurrentDate { get; set; } = DateTime.Now;    


       
    }
}
