using BLL.Agents;
using BLL.Customers;

namespace UnitTests
{
    internal class AgentTest
    {
        Server server;
        Agent agent;

        [SetUp]
        public void Setup()
        {
            server = new Server();
            agent = new Agent("AG-1", server);
        }

        [Test]
        public void GivenEmptyAgentInstallationdateShouldBeNull()
        {
            //Act
            DateTime? expectation = null;
            DateTime? result = agent.InstallationDate;

            //Assert
            Assert.That(result, Is.EqualTo(expectation));
        }

        [Test]
        public void GivenEmptyAgentDoNotAllowInstallationDateInTheFuture()
        {
            //Act
            DateTime? future = DateTime.Now.AddMonths(1);
            agent.InstallationDate = future;

            //Assert
            Assert.That(agent.InstallationDate, Is.EqualTo(null));
        }

        [Test]
        public void GivenAgentWithHeartbeatDoNotAllowToSetPriorDate()
        {
            //Arrange
            DateTime date1 = new DateTime(2025, 01, 01);
            agent.HeartBeat = date1;

            //Act
            DateTime date2 = new DateTime(2024, 12, 31);
            agent.HeartBeat = date2;

            //Assert
            Assert.That(agent.HeartBeat, Is.EqualTo(date1));
        }

        [Test]
        public void GivenAgentWithHeartbeatAllowNewDate()
        {
            //Arange
            DateTime date1 = new DateTime(2024, 12, 31);
            agent.HeartBeat = date1;

            //Act
            DateTime date2 = new DateTime(2025, 01, 01);
            agent.HeartBeat = date2;

            //Assert
            Assert.That(agent.HeartBeat, Is.EqualTo(date2));
        }

        [Test]
        public void GivenEmptyHeartbeatEnsureStatusIsUnknown()
        {
            // Assert
            Assert.That(agent.Status, Is.EqualTo(AgentStatus.Unknown));
        }

        [Test]
        public void GivenRecentHeartBeatEnsureStatusIsOnline()
        {
            //Act
            agent.HeartBeat = DateTime.Now;

            //Assert
            Assert.That(agent.Status, Is.EqualTo(AgentStatus.Online));
        }

        [Test]
        public void GivenHeartBeatFromYesterdayEnsureStatusIsOffline()
        {
            //Act
            agent.HeartBeat = DateTime.Now.AddDays(-1);

            //Assert
            Assert.That(agent.Status, Is.EqualTo(AgentStatus.Offline));
        }
    }

}
