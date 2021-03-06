﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PingPong.Models
{
    public class PingPongContext : ApplicationDbContext
    {
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<DoublesTeam> DoublesTeams { get; set; }
        public virtual DbSet<SinglesMatch> SinglesMatches { get; set; }
        public virtual DbSet<DoublesMatch> DoublesMatches { get; set; }
        public virtual DbSet<SinglesTournament> SinglesTournaments { get; set; }
        public virtual DbSet<DoublesTournament> DoublesTournaments { get; set; }
    }
}