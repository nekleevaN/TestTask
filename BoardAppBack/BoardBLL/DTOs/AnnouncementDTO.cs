﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardBLL.DTOs
{
    public class AnnouncementDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool Status { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
    }
}
