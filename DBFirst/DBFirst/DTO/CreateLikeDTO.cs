﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBFirst.DTO
{
    public class CreateLikeDTO
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}