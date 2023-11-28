﻿using System;

namespace ProductsProject.Domain.Commons
{
    public class Auditable
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
    }
}
