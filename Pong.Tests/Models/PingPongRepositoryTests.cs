﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Models;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace Pong.Tests.Models
{
    [TestClass]
    public class PingPongRepositoryTests
    {
        private Mock<PingPongContext> mock_context;
        private Mock<DbSet<Player>> mock_player_set;
        private Mock<DbSet<DoublesTeam>> mock_team_set;
        private Mock<DbSet<SinglesMatch>> mock_sMatch_set;
        private Mock<DbSet<DoublesMatch>> mock_dMatch_set;
        private Mock<DbSet<SinglesTournament>> mock_sTourney_set;
        private Mock<DbSet<DoublesTournament>> mock_dTourney_set;
        private PingPongRepository repository;

        private void ConnectMocksToDataStore(IEnumerable<Player> data_store)
        {
            var data_source = data_store.AsQueryable<Player>();
            // HINT HINT: var data_source = (data_store as IEnumerable<JitterUser>).AsQueryable();
            // Convince LINQ that our Mock DbSet is a (relational) Data store.
            mock_player_set.As<IQueryable<Player>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_player_set.As<IQueryable<Player>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_player_set.As<IQueryable<Player>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_player_set.As<IQueryable<Player>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            // This is Stubbing the JitterUsers property getter
            mock_context.Setup(a => a.Players).Returns(mock_player_set.Object);
        }
        private void ConnectMocksToDataStore(IEnumerable<DoublesTeam> data_store)
        {
            var data_source = data_store.AsQueryable<DoublesTeam>();
            mock_team_set.As<IQueryable<DoublesTeam>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_team_set.As<IQueryable<DoublesTeam>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_team_set.As<IQueryable<DoublesTeam>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_team_set.As<IQueryable<DoublesTeam>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
            mock_context.Setup(a => a.DoublesTeams).Returns(mock_team_set.Object);
        }
        private void ConnectMocksToDataStore(IEnumerable<SinglesMatch> data_store)
        {
            var data_source = data_store.AsQueryable<SinglesMatch>();
            mock_sMatch_set.As<IQueryable<SinglesMatch>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_sMatch_set.As<IQueryable<SinglesMatch>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_sMatch_set.As<IQueryable<SinglesMatch>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_sMatch_set.As<IQueryable<SinglesMatch>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
            mock_context.Setup(a => a.SinglesMatches).Returns(mock_sMatch_set.Object);
        }
        private void ConnectMocksToDataStore(IEnumerable<DoublesMatch> data_store)
        {
            var data_source = data_store.AsQueryable<DoublesMatch>();
           mock_dMatch_set.As<IQueryable<DoublesMatch>>().Setup(data => data.Provider).Returns(data_source.Provider);
           mock_dMatch_set.As<IQueryable<DoublesMatch>>().Setup(data => data.Expression).Returns(data_source.Expression);
           mock_dMatch_set.As<IQueryable<DoublesMatch>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
           mock_dMatch_set.As<IQueryable<DoublesMatch>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
           mock_context.Setup(a => a.DoublesMatches).Returns(mock_dMatch_set.Object);
        }
        private void ConnectMocksToDataStore(IEnumerable<SinglesTournament> data_store)
        {
            var data_source = data_store.AsQueryable<SinglesTournament>();
            mock_sTourney_set.As<IQueryable<SinglesTournament>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_sTourney_set.As<IQueryable<SinglesTournament>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_sTourney_set.As<IQueryable<SinglesTournament>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_sTourney_set.As<IQueryable<SinglesTournament>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
            mock_context.Setup(a => a.SinglesTournaments).Returns(mock_sTourney_set.Object);
        }
        private void ConnectMocksToDataStore(IEnumerable<DoublesTournament> data_store)
        {
            var data_source = data_store.AsQueryable<DoublesTournament>();
            mock_dTourney_set.As<IQueryable<DoublesTournament>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_dTourney_set.As<IQueryable<DoublesTournament>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_dTourney_set.As<IQueryable<DoublesTournament>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_dTourney_set.As<IQueryable<DoublesTournament>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());
            mock_context.Setup(a => a.DoublesTournaments).Returns(mock_dTourney_set.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<PingPongContext>();
            mock_player_set  = new Mock<DbSet<Player>>();
            mock_team_set  = new Mock<DbSet<DoublesTeam>>();
            mock_sMatch_set  = new Mock<DbSet<SinglesMatch>>();
            mock_dMatch_set  = new Mock<DbSet<DoublesMatch>>();
            mock_sTourney_set  = new Mock<DbSet<SinglesTournament>>();
            mock_dTourney_set  = new Mock<DbSet<DoublesTournament>>();
            repository = new PingPongRepository(mock_context.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_player_set = null;
            mock_team_set = null;
            mock_sMatch_set = null;
            mock_dMatch_set = null;
            mock_sTourney_set = null;
            mock_dTourney_set = null;
            repository = null;
        }

        [TestMethod]
        public void PingPongContextEnsureICanInstantiate()
        {
            PingPongContext context = new PingPongContext();
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void PingPongRepoEnsureIcanCreateInstance()
        {
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void PingPongRepoEnsureICanGetAllPlayers()
        {
            var expected = new List<Player>
            {
                new Player { PlayerId = 1 },
                new Player { PlayerId = 2 },
            };
            mock_player_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            var actual = repository.GetAllUsers();

            Assert.AreEqual(1, actual.First().PlayerId);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PingPngRepoEnsureIcanGetAllDoublesTeams()
        {
            var expected = new List<DoublesTeam>
            {
                new DoublesTeam { TeamId = 1 },
                new DoublesTeam { TeamId = 2 },
            };
            mock_team_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            List<DoublesTeam> actual = repository.GetAllDoublesTeams();

            Assert.AreEqual(2, actual[1].TeamId);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PingPongRepoEnsureICanGetAllSinglesMatches()
        {
            var expected = new List<SinglesMatch>
            {
                new SinglesMatch { MatchId = 1 },
                new SinglesMatch { MatchId = 2 },
            };
            mock_sMatch_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            List<SinglesMatch> actual = repository.GetAllSinglesMatches();

            Assert.AreEqual(1, actual.First().MatchId);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PingPongRepoEnsureICanGetAllDoublesMatches()
        {
            var expected = new List<DoublesMatch>
            {
                new DoublesMatch { MatchId = 1 },
                new DoublesMatch { MatchId = 2 },
            };
            mock_dMatch_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            List<DoublesMatch> actual = repository.GetAllDoublesMatches();

            Assert.AreEqual(1, actual.First().MatchId);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PingPongRepoEnsureICanGetAllSinglesTournaments()
        {
            var expected = new List<SinglesTournament>
            {
                new SinglesTournament { TournamentId = 1 },
                new SinglesTournament { TournamentId = 2 },
            };
            mock_sTourney_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            List<SinglesTournament> actual = repository.GetAllSinglesTournaments();

            Assert.AreEqual(1, actual.First().TournamentId);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PingPongRepoEnsureICanGetAllDoublesTournaments()
        {
            var expected = new List<DoublesTournament>
            {
                new DoublesTournament { TournamentId = 1 },
                new DoublesTournament { TournamentId = 2 },
            };
            mock_dTourney_set.Object.AddRange(expected);
            ConnectMocksToDataStore(expected);

            List<DoublesTournament> actual = repository.GetAllDoublesTournaments();

            Assert.AreEqual(1, actual.First().TournamentId);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PingPongRepoEnsureICanGetUserByName()
        {
            var expected = new List<Player>
            {
                new Player { Handle = "pongMaster89", FirstName = "Joe" },
                new Player { Handle = "paddleN00b" }
            };
            mock_player_set.Object.AddRange(expected);

            ConnectMocksToDataStore(expected);
            string handle = "pongmaster89";
            Player actual_user = repository.GetPlayerByHandle(handle);
            Assert.AreEqual("Joe", actual_user.FirstName);
        }
    }
}