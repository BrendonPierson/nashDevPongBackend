﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PingPong.Models
{
    public class DoublesTournament
    {
        [Key]
        public int TournamentId { get; set; }

        public string TournamentName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public List<DoublesTeam> Teams { get; set; }

        [Required]
        public List<DoublesMatch> DoublesMatches { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}