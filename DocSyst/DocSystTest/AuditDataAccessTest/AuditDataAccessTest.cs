using System;
using System.Collections.Generic;
using System.Linq;
using DocSystDataAccessImplementation.AuditDataAccessImplementation;
using DocSystDataAccessInterface.AuditDataAccessInterface;
using DocSystEntities.Audit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocSystTest.AuditDataAccessTest
{
    [TestClass]
    public class AuditDataAccessTest
    {
        private IAuditLogDataAccess auditLogDataAccess;
        private AuditLog auditLog;

        [TestInitialize]
        public void TestInitialize()
        {
            auditLogDataAccess = new AuditLogDataAccess();
            auditLog = Utils.CreateAuditLogForTest();
        }

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestMethod]
        public void CreateAuditLogDataAccess_WithoutParameters_Ok()
        {
            Assert.IsNotNull(auditLogDataAccess);
        }

        [TestMethod]
        public void AddAuditLogToDb_ExpectedParameters_Ok()
        {
            auditLogDataAccess.Add(auditLog);

            AuditLog obtained = auditLogDataAccess.Get(auditLog.Id);
            Assert.AreEqual(auditLog, obtained);
        }

        [TestMethod]
        public void DeleteAuditLogFromDb_ExpectedParameters_Ok()
        {
            auditLogDataAccess.Add(auditLog);

            auditLogDataAccess.Delete(auditLog.Id);

            AuditLog obtained = auditLogDataAccess.Get(auditLog.Id);
            Assert.IsNull(obtained);
        }

        [TestMethod]
        public void ModifyAuditLogFromDb_ExpectedParameters_Ok()
        {
            auditLogDataAccess.Add(auditLog);
            auditLog.Action = ActionPerformed.CREATE;

            auditLogDataAccess.Modify(auditLog);

            AuditLog obtained = auditLogDataAccess.Get(auditLog.Id);
            Assert.AreEqual(auditLog.Action, obtained.Action);
        }

        [TestMethod]
        public void GetAllAuditLogsFromDb_ExpectedParameters_Ok()
        {
            auditLogDataAccess.Add(auditLog);

            IList<AuditLog> auditLogs = auditLogDataAccess.Get();

            Assert.IsTrue(auditLogs.Contains(auditLog));
        }

        [TestMethod]
        public void ExistAuditLogInDb_ExpectedParameters_Ok()
        {
            auditLogDataAccess.Add(auditLog);

            bool exists = auditLogDataAccess.Exists(auditLog.Id);

            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void GetLogsPerUserForAnAction_ExpectedParameters_Ok()
        {
            Guid document1 = Guid.NewGuid();
            Guid document2 = Guid.NewGuid();
            string user = Guid.NewGuid().ToString();

            AuditLog auditLog1 = new AuditLog("Document", document1, user, ActionPerformed.CREATE);
            AuditLog auditLog2 = new AuditLog("Document", document1, user, ActionPerformed.MODIFY);
            AuditLog auditLog3 = new AuditLog("Document", document1, user, ActionPerformed.MODIFY);
            AuditLog auditLog4 = new AuditLog("Document", document1, user, ActionPerformed.DELETE);

            AuditLog auditLog5 = new AuditLog("Document", document2, user, ActionPerformed.CREATE);
            AuditLog auditLog6 = new AuditLog("Document", document2, user, ActionPerformed.MODIFY);
            AuditLog auditLog7 = new AuditLog("Document", document2, user, ActionPerformed.MODIFY);
            AuditLog auditLog8 = new AuditLog("Document", document2, user, ActionPerformed.DELETE);

            auditLogDataAccess.Add(auditLog1);
            auditLogDataAccess.Add(auditLog2);
            auditLogDataAccess.Add(auditLog3);
            auditLogDataAccess.Add(auditLog4);
            auditLogDataAccess.Add(auditLog5);
            auditLogDataAccess.Add(auditLog6);
            auditLogDataAccess.Add(auditLog7);
            auditLogDataAccess.Add(auditLog8);

            DateTime dateFrom = DateTime.Today.Add(new TimeSpan(-7, 0, 0, 0, 0));
            DateTime dateTo = DateTime.Today.Add(new TimeSpan(7, 0, 0, 0, 0));

            IList<AuditLog> auditLogs1 = auditLogDataAccess.GetLogsPerUserForAnAction(user, dateFrom, dateTo, "Document", ActionPerformed.CREATE);
            IList<AuditLog> auditLogs2 = auditLogDataAccess.GetLogsPerUserForAnAction(user, dateFrom, dateTo, "Document", ActionPerformed.MODIFY);
            IList<AuditLog> auditLogs3 = auditLogDataAccess.GetLogsPerUserForAnAction(user, dateFrom, dateTo, "Document", ActionPerformed.DELETE);

            Assert.IsTrue(auditLogs1.Count == 2);
            Assert.IsTrue(auditLogs2.Count == 4);
            Assert.IsTrue(auditLogs3.Count == 2);

            Assert.IsTrue(auditLogs1.Contains(auditLog1));
            Assert.IsTrue(auditLogs1.Contains(auditLog5));
            Assert.IsTrue(auditLogs2.Contains(auditLog2));
            Assert.IsTrue(auditLogs2.Contains(auditLog3));
            Assert.IsTrue(auditLogs2.Contains(auditLog6));
            Assert.IsTrue(auditLogs2.Contains(auditLog7));
            Assert.IsTrue(auditLogs3.Contains(auditLog4));
            Assert.IsTrue(auditLogs3.Contains(auditLog8));
        }

        [TestMethod]
        public void GetLogsPerUserPerDay_ExpectedParameters_Ok()
        {
            Guid document1 = Guid.NewGuid();
            Guid document2 = Guid.NewGuid();
            string user = Guid.NewGuid().ToString();

            AuditLog auditLog1 = new AuditLog("Document", document1, user, ActionPerformed.CREATE);
            AuditLog auditLog2 = new AuditLog("Document", document1, user, ActionPerformed.MODIFY);
            AuditLog auditLog3 = new AuditLog("Document", document1, user, ActionPerformed.MODIFY);
            AuditLog auditLog4 = new AuditLog("Document", document1, user, ActionPerformed.DELETE);

            AuditLog auditLog5 = new AuditLog("Document", document2, user, ActionPerformed.CREATE);
            AuditLog auditLog6 = new AuditLog("Document", document2, user, ActionPerformed.MODIFY);
            AuditLog auditLog7 = new AuditLog("Document", document2, user, ActionPerformed.MODIFY);
            AuditLog auditLog8 = new AuditLog("Document", document2, user, ActionPerformed.DELETE);

            auditLog1.OperationDate = auditLog1.OperationDate.Add(new TimeSpan(-4, 0, 0, 0, 0));
            auditLog5.OperationDate = auditLog5.OperationDate.Add(new TimeSpan(-4, 0, 0, 0, 0));
            auditLog2.OperationDate = auditLog2.OperationDate.Add(new TimeSpan(-3, 0, 0, 0, 0));
            auditLog3.OperationDate = auditLog3.OperationDate.Add(new TimeSpan(-2, 0, 0, 0, 0));
            auditLog6.OperationDate = auditLog6.OperationDate.Add(new TimeSpan(-3, 0, 0, 0, 0));
            auditLog7.OperationDate = auditLog7.OperationDate.Add(new TimeSpan(-2, 0, 0, 0, 0));

            auditLogDataAccess.Add(auditLog1);
            auditLogDataAccess.Add(auditLog2);
            auditLogDataAccess.Add(auditLog3);
            auditLogDataAccess.Add(auditLog4);
            auditLogDataAccess.Add(auditLog5);
            auditLogDataAccess.Add(auditLog6);
            auditLogDataAccess.Add(auditLog7);
            auditLogDataAccess.Add(auditLog8);

            DateTime dateFrom = DateTime.Today.Add(new TimeSpan(-7, 0, 0, 0, 0));
            DateTime dateTo = DateTime.Today.Add(new TimeSpan(7, 0, 0, 0, 0));

            IList<IGrouping<DateTime, Guid>> auditLogsPerUserPerDay = auditLogDataAccess.GetLogsPerUserPerDay(user,dateFrom,dateTo,"Document");
            IList<Guid> logGroup1 = auditLogsPerUserPerDay[0].ToList<Guid>();
            IList<Guid> logGroup2 = auditLogsPerUserPerDay[1].ToList<Guid>();
            IList<Guid> logGroup3 = auditLogsPerUserPerDay[2].ToList<Guid>();
            IList<Guid> logGroup4 = auditLogsPerUserPerDay[3].ToList<Guid>();

            Assert.IsTrue(logGroup1.Contains(auditLog1.Id));
            Assert.IsTrue(logGroup1.Contains(auditLog5.Id));
            Assert.IsTrue(logGroup2.Contains(auditLog2.Id));
            Assert.IsTrue(logGroup2.Contains(auditLog6.Id));
            Assert.IsTrue(logGroup3.Contains(auditLog3.Id));
            Assert.IsTrue(logGroup3.Contains(auditLog7.Id));
            Assert.IsTrue(logGroup4.Contains(auditLog4.Id));
            Assert.IsTrue(logGroup4.Contains(auditLog8.Id));
        }
    }
}
