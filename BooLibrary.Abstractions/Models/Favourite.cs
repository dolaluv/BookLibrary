﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooLibrary.Abstractions.Models
{
    public class Favourite
    {
        public int Id { get; set; } 

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book book { get; set; }
        public DateTime CurrentDate { get; set; } = DateTime.Now;
    }
}
