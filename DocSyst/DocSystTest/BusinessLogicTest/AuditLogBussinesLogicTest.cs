using DocSystBusinessLogicImplementation.AuditLogBussinesLogicImplementation;
using DocSystBusinessLogicInterface.AuditLogBussinesLogicInterface;
using DocSystDataAccessImplementation.AuditDataAccessImplementation;
using DocSystDataAccessInterface.AuditDataAccessInterface;
using DocSystEntities.Audit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocSystTest.BusinessLogicTest
{
    [TestClass]
    public class AuditLogBussinesLogicTest
    {
        Mock<IAuditLogDataAccess> mockAuditLogDataAccess;
        IAuditLogBussinesLogic auditLogBussinesLogic;
        AuditLog auditLog;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            mockAuditLogDataAccess = new Mock<IAuditLogDataAccess>();
            auditLogBussinesLogic = new AuditLogBussinesLogic(mockAuditLogDataAccess.Object);
            auditLog = Utils.CreateAuditLogForTest();
        }

        [TestMethod]
        public void CreateAuditLogBL_WithoutParameters_Ok()
        {
            IAuditLogBussinesLogic auditLogBL = new AuditLogBussinesLogic();

            Assert.IsNotNull(auditLogBL);
        }

        [TestMethod]
        public void CreateAuditLogBL_WithParameters_Ok()
        {
            IAuditLogDataAccess auditLogDataAccess = new AuditLogDataAccess();

            IAuditLogBussinesLogic auditLogBL = new AuditLogBussinesLogic(auditLogDataAccess);

            Assert.IsNotNull(auditLogBL);
        }

        [TestMethod]
        public void GetAuditLogs_ExpectedParameters_Ok()
        {
            mockAuditLogDataAccess.Setup(b1 => b1.Get()).Returns(new List<AuditLog>
            {
                auditLog
            });

            Assert.AreEqual(auditLogBussinesLogic.GetAuditLogs()[0], auditLog);
        }

        [TestMethod]
        public void GetAuditLog_ExpectedParameters_Ok()
        {
            mockAuditLogDataAccess.Setup(b1 => b1.Get(auditLog.Id)).Returns(auditLog);

            Assert.AreEqual(auditLogBussinesLogic.GetAuditLog(auditLog.Id), auditLog);
        }

        [TestMethod]
        public void GetLogsPerUserForAnAction_ExpectedParameters_Ok()
        {
            string user1 = Guid.NewGuid().ToString();
            string user2 = Guid.NewGuid().ToString();
            string user3 = Guid.NewGuid().ToString();
            string user4 = Guid.NewGuid().ToString();

            List<string> userList = new List<string>();
            userList.Add(user1);
            userList.Add(user2);
            userList.Add(user3);
            userList.Add(user4);

            Guid document1 = Guid.NewGuid();
            Guid document2 = Guid.NewGuid();
            Guid document3 = Guid.NewGuid();
            Guid document4 = Guid.NewGuid();
            Guid document5 = Guid.NewGuid();
            Guid document6 = Guid.NewGuid();
            
            AuditLog auditLog1 = new AuditLog("Document", document1, user1, ActionPerformed.CREATE);
            AuditLog auditLog2 = new AuditLog("Document", document1, user1, ActionPerformed.MODIFY);
            AuditLog auditLog3 = new AuditLog("Document", document2, user2, ActionPerformed.CREATE);
            AuditLog auditLog4 = new AuditLog("Document", document3, user3, ActionPerformed.CREATE);

            AuditLog auditLog5 = new AuditLog("Document", document4, user3, ActionPerformed.MODIFY);
            AuditLog auditLog6 = new AuditLog("Document", document4, user3, ActionPerformed.DELETE);
            AuditLog auditLog7 = new AuditLog("Document", document5, user4, ActionPerformed.CREATE);
            AuditLog auditLog8 = new AuditLog("Document", document6, user4, ActionPerformed.DELETE);

            auditLog1.OperationDate = auditLog1.OperationDate.Add(new TimeSpan(-4, 0, 0, 0, 0));
            auditLog5.OperationDate = auditLog5.OperationDate.Add(new TimeSpan(-4, 0, 0, 0, 0));
            auditLog2.OperationDate = auditLog2.OperationDate.Add(new TimeSpan(-3, 0, 0, 0, 0));
            auditLog3.OperationDate = auditLog3.OperationDate.Add(new TimeSpan(-2, 0, 0, 0, 0));
            auditLog6.OperationDate = auditLog6.OperationDate.Add(new TimeSpan(-3, 0, 0, 0, 0));
            auditLog7.OperationDate = auditLog7.OperationDate.Add(new TimeSpan(-2, 0, 0, 0, 0));

            DateTime dateFrom = DateTime.Today.Add(new TimeSpan(-7, 0, 0, 0, 0));
            DateTime dateTo = DateTime.Today.Add(new TimeSpan(7, 0, 0, 0, 0));

            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserForAnAction(user1, dateFrom, dateTo, "Document", ActionPerformed.CREATE))
                .Returns(new List<AuditLog>()
                {
                    auditLog1
                });
            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserForAnAction(user2, dateFrom, dateTo, "Document", ActionPerformed.CREATE))
                .Returns(new List<AuditLog>()
                {
                    auditLog3
                });
            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserForAnAction(user3, dateFrom, dateTo, "Document", ActionPerformed.CREATE))
                .Returns(new List<AuditLog>()
                {
                    auditLog4
                });
            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserForAnAction(user4, dateFrom, dateTo, "Document", ActionPerformed.CREATE))
                .Returns(new List<AuditLog>()
                {
                    auditLog7
                });

            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserForAnAction(user1, dateFrom, dateTo, "Document", ActionPerformed.MODIFY))
                .Returns(new List<AuditLog>()
                {
                    auditLog2
                });
            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserForAnAction(user2, dateFrom, dateTo, "Document", ActionPerformed.MODIFY))
                .Returns(new List<AuditLog>());
            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserForAnAction(user3, dateFrom, dateTo, "Document", ActionPerformed.MODIFY))
                .Returns(new List<AuditLog>()
                {
                    auditLog5
                });
            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserForAnAction(user4, dateFrom, dateTo, "Document", ActionPerformed.MODIFY))
                .Returns(new List<AuditLog>());

            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserForAnAction(user1, dateFrom, dateTo, "Document", ActionPerformed.DELETE))
                .Returns(new List<AuditLog>());
            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserForAnAction(user2, dateFrom, dateTo, "Document", ActionPerformed.DELETE))
                .Returns(new List<AuditLog>());
            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserForAnAction(user3, dateFrom, dateTo, "Document", ActionPerformed.DELETE))
                .Returns(new List<AuditLog>()
                {
                    auditLog6
                });
            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserForAnAction(user4, dateFrom, dateTo, "Document", ActionPerformed.DELETE))
                .Returns(new List<AuditLog>()
                {
                    auditLog8
                });

            Dictionary<string, int> creates = auditLogBussinesLogic.
                GetLogsPerUserForAnAction(userList, dateFrom, dateTo, "Document", ActionPerformed.CREATE);
            Dictionary<string, int> modifys = auditLogBussinesLogic.
                GetLogsPerUserForAnAction(userList, dateFrom, dateTo, "Document", ActionPerformed.MODIFY);
            Dictionary<string, int> deletes = auditLogBussinesLogic.
                GetLogsPerUserForAnAction(userList, dateFrom, dateTo, "Document", ActionPerformed.DELETE);

            int countUser1Creates;
            int countUser2Creates;
            int countUser3Creates;
            int countUser4Creates;
            int countUser1Modifys;
            int countUser2Modifys;
            int countUser3Modifys;
            int countUser4Modifys;
            int countUser1Deletes;
            int countUser2Deletes;
            int countUser3Deletes;
            int countUser4Deletes;

            creates.TryGetValue(user1, out countUser1Creates);
            creates.TryGetValue(user2, out countUser2Creates);
            creates.TryGetValue(user3, out countUser3Creates);
            creates.TryGetValue(user4, out countUser4Creates);

            modifys.TryGetValue(user1, out countUser1Modifys);
            modifys.TryGetValue(user2, out countUser2Modifys);
            modifys.TryGetValue(user3, out countUser3Modifys);
            modifys.TryGetValue(user4, out countUser4Modifys);

            deletes.TryGetValue(user1, out countUser1Deletes);
            deletes.TryGetValue(user2, out countUser2Deletes);
            deletes.TryGetValue(user3, out countUser3Deletes);
            deletes.TryGetValue(user4, out countUser4Deletes);

            Assert.IsTrue(countUser1Creates == 1);
            Assert.IsTrue(countUser2Creates == 1);
            Assert.IsTrue(countUser3Creates == 1);
            Assert.IsTrue(countUser4Creates == 1);
            Assert.IsTrue(countUser1Modifys == 1);
            Assert.IsTrue(countUser2Modifys == 0);
            Assert.IsTrue(countUser3Modifys == 1);
            Assert.IsTrue(countUser4Modifys == 0);
            Assert.IsTrue(countUser1Deletes == 0);
            Assert.IsTrue(countUser2Deletes == 0);
            Assert.IsTrue(countUser3Deletes == 1);
            Assert.IsTrue(countUser4Deletes == 1);
        }

        [TestMethod]
        public void GetLogsPerUserPerDay_ExpectedParameters_Ok()
        {
            string user1 = Guid.NewGuid().ToString();
            string user2 = Guid.NewGuid().ToString();
            string user3 = Guid.NewGuid().ToString();
            string user4 = Guid.NewGuid().ToString();

            List<string> userList = new List<string>();
            userList.Add(user1);
            userList.Add(user2);
            userList.Add(user3);
            userList.Add(user4);

            Guid document1 = Guid.NewGuid();
            Guid document2 = Guid.NewGuid();
            Guid document3 = Guid.NewGuid();
            Guid document4 = Guid.NewGuid();
            Guid document5 = Guid.NewGuid();
            Guid document6 = Guid.NewGuid();

            AuditLog auditLog1 = new AuditLog("Document", document1, user1, ActionPerformed.CREATE);
            AuditLog auditLog2 = new AuditLog("Document", document1, user1, ActionPerformed.MODIFY);
            AuditLog auditLog3 = new AuditLog("Document", document2, user2, ActionPerformed.CREATE);
            AuditLog auditLog4 = new AuditLog("Document", document3, user3, ActionPerformed.CREATE);

            AuditLog auditLog5 = new AuditLog("Document", document4, user3, ActionPerformed.MODIFY);
            AuditLog auditLog6 = new AuditLog("Document", document4, user3, ActionPerformed.DELETE);
            AuditLog auditLog7 = new AuditLog("Document", document5, user4, ActionPerformed.CREATE);
            AuditLog auditLog8 = new AuditLog("Document", document6, user4, ActionPerformed.DELETE);

            auditLog1.OperationDate = auditLog1.OperationDate.Add(new TimeSpan(-4, 0, 0, 0, 0));
            auditLog5.OperationDate = auditLog5.OperationDate.Add(new TimeSpan(-4, 0, 0, 0, 0));
            auditLog2.OperationDate = auditLog2.OperationDate.Add(new TimeSpan(-3, 0, 0, 0, 0));
            auditLog6.OperationDate = auditLog6.OperationDate.Add(new TimeSpan(-3, 0, 0, 0, 0));
            auditLog3.OperationDate = auditLog3.OperationDate.Add(new TimeSpan(-2, 0, 0, 0, 0));
            auditLog7.OperationDate = auditLog7.OperationDate.Add(new TimeSpan(-2, 0, 0, 0, 0));

            DateTime dateFrom = DateTime.Today.Add(new TimeSpan(-7, 0, 0, 0, 0));
            DateTime dateTo = DateTime.Today.Add(new TimeSpan(7, 0, 0, 0, 0));

            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserPerDay(user1, dateFrom, dateTo, "Document"))
                .Returns(new List<AuditLog>()
                {
                    auditLog1,
                    auditLog2
                }
                .GroupBy(auditLogDb => auditLogDb.OperationDate, auditLogDb => auditLogDb.Id).ToList());
            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserPerDay(user2, dateFrom, dateTo, "Document"))
                .Returns(new List<AuditLog>()
                {
                    auditLog3
                }
                .GroupBy(auditLogDb => auditLogDb.OperationDate, auditLogDb => auditLogDb.Id).ToList());
            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserPerDay(user3, dateFrom, dateTo, "Document"))
                .Returns(new List<AuditLog>()
                {
                    auditLog4,
                    auditLog5,
                    auditLog6
                }
                .GroupBy(auditLogDb => auditLogDb.OperationDate, auditLogDb => auditLogDb.Id).ToList());
            mockAuditLogDataAccess.Setup(b1 => b1.GetLogsPerUserPerDay(user4, dateFrom, dateTo, "Document"))
                .Returns(new List<AuditLog>()
                {
                    auditLog7,
                    auditLog8
                }
                .GroupBy(auditLogDb => auditLogDb.OperationDate, auditLogDb => auditLogDb.Id).ToList());

            Dictionary<string, Dictionary<DateTime, int>> actionesPerDay = auditLogBussinesLogic.
                GetLogsPerUserPerDay(userList, dateFrom, dateTo, "Document");

            Dictionary<DateTime, int> user1ActionesPerDay;
            Dictionary<DateTime, int> user2ActionesPerDay;
            Dictionary<DateTime, int> user3ActionesPerDay;
            Dictionary<DateTime, int> user4ActionesPerDay;

            actionesPerDay.TryGetValue(user1, out user1ActionesPerDay);
            actionesPerDay.TryGetValue(user2, out user2ActionesPerDay);
            actionesPerDay.TryGetValue(user3, out user3ActionesPerDay);
            actionesPerDay.TryGetValue(user4, out user4ActionesPerDay);

            Assert.IsTrue(user1ActionesPerDay.Count == 2);
            Assert.IsTrue(user2ActionesPerDay.Count == 1);
            Assert.IsTrue(user3ActionesPerDay.Count == 3);
            Assert.IsTrue(user4ActionesPerDay.Count == 2);
        }
    }
}
