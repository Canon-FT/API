using BLL.Agents;
using BLL.Customers;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class ServerTest
    {
        Server server;

        [SetUp]
        public void Setup()
        {
            server = new Server();
        }

        [Test]
        public void GivenServerWithHeartbeatAllowNewDate()
        {
            //Arange
            DateTime date1 = new DateTime(2024, 12, 31);
            server.HeartBeat = date1;

            //Act
            DateTime date2 = new DateTime(2025, 01, 01);
            server.HeartBeat = date2;

            //Assert
            Assert.That(server.HeartBeat, Is.EqualTo(date2));
        }

        [Test]
        public void GivenServerWithHeartbeatDoNotAllowToSetPriorDate()
        {
            //Arrange
            DateTime date1 = new DateTime(2025, 01, 01);
            server.HeartBeat = date1;

            //Act
            DateTime date2 = new DateTime(2024, 12, 31);
            server.HeartBeat = date2;

            //Assert
            Assert.That(server.HeartBeat, Is.EqualTo(date1));
        }


        [Test]
        public void GivenNewServerAllowToSetGUID()
        {
            //Act
            string GUID = "1111-1";
            server.GUID = GUID;

            //Assert
            Assert.That(server.GUID, Is.EqualTo(GUID));
        }

        [Test]
        public void GivenServerWithGUIDDoNotAllowToSetEmptyGUID()
        {
            //Arrange
            string GUID = "1111-1";
            server.GUID = GUID;

            //Act
            server.GUID = "";

            //Assert
            Assert.That(server.GUID, Is.EqualTo(GUID));
        }

        [Test]
        public void GivenNewServerAllowToSetHostname()
        {
            //Act
            string hostname = "testserver.local";
            server.Hostname = hostname;

            //Assert
            Assert.That(server.Hostname, Is.EqualTo(hostname));
        }

        [Test]
        public void GivenServerWithHostnameDoNotAllowToSetEmptyHostname()
        {
            //Arrange
            string hostname = "testserver.local";
            server.Hostname = hostname;

            //Act
            server.Hostname = "";

            //Assert
            Assert.That(server.Hostname, Is.EqualTo(hostname));
        }

        [Test]
        public void GivenNewServerAllowToSetIP()
        {
            //Act
            string ip = "192.168.1.1";
            server.IP = ip;

            //Assert
            Assert.That(server.IP, Is.EqualTo(ip));
        }

        [Test]
        public void GivenServerWithIPDoNotAllowToSetEmptyIP()
        {
            //Arrange
            string ip = "192.168.1.1";
            server.IP = ip;

            //Act
            server.IP = "";

            //Assert
            Assert.That(server.IP, Is.EqualTo(ip));
        }
    }
}
