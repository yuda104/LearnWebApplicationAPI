﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
