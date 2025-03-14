﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }

        [StringLength(200)]
        public string ContentText { get; set; }
        public DateTime ContentDate { get; set; }

        public bool ContentStatus { get; set; }

        //Writer
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; } 

        //Heading
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }
    }
}
