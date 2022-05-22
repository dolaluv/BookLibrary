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

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category StaffUser { get; set; }
    }
}
