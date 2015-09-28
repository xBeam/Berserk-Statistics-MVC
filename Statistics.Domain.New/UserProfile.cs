﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Statistics.Domain
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Tournament> Tournaments { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
