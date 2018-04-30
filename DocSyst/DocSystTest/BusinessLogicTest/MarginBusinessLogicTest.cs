using DocSystBusinessLogicImplementation.DocumentStructureLogicImplementation;
using DocSystBusinessLogicInterface.DocumentStructureLogicInterface;
using DocSystDataAccessImplementation.DocumentStructureDataAccessImplementation;
using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DocSystTest.BusinessLogicTest
{
    [TestClass]
    public class MarginBusinessLogicTest
    {
        Mock<IMarginDataAccess> mockMarginDataAccess;
        IMarginBusinessLogic marginBusinessLogic;
        Margin margin;
        Text text;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            mockMarginDataAccess = new Mock<IMarginDataAccess>();
            marginBusinessLogic = new MarginBusinessLogic(mockMarginDataAccess.Object);
            margin = Utils.CreateMarginForTest();
            text = Utils.CreateTextForTest();
        }

        [TestMethod]
        public void CreateMarginBL_WithoutParameters_Ok()
        {
            IMarginBusinessLogic marginBL = new MarginBusinessLogic();

            Assert.IsNotNull(marginBL);
        }

        [TestMethod]
        public void CreateMarginBL_WithParameters_Ok()
        {
            IMarginDataAccess marginDataAccess = new MarginDataAccess();

            IMarginBusinessLogic marginBL = new MarginBusinessLogic(marginDataAccess);

            Assert.IsNotNull(marginBL);
        }

        [TestMethod]
        public void AddMargin_ExpectedParameters_Ok()
        {
            marginBusinessLogic.AddMargin(margin);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void AddMargin_MarginAlreadyExists_DuplicateException()
        {
            mockMarginDataAccess.Setup(b1 => b1.Exists(margin.Id)).Returns(true);

            marginBusinessLogic.AddMargin(margin);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddMargin_DataAccessThrowException_ExceptionCatched()
        {
            mockMarginDataAccess.Setup(b1 => b1.Add(margin)).Throws(new Exception());

            marginBusinessLogic.AddMargin(margin);
        }

        [TestMethod]
        public void DeleteMargin_ExpectedParameters_Ok()
        {
            mockMarginDataAccess.Setup(b1 => b1.Exists(margin.Id)).Returns(true);
            mockMarginDataAccess.Setup(b1 => b1.Delete(margin.Id)).Verifiable();

            marginBusinessLogic.DeleteMargin(margin.Id);
        }

        [TestMethod]
        public void ClearMarginText_ExpectedParameters_Ok()
        {
            mockMarginDataAccess.Setup(b1 => b1.Exists(margin.Id)).Returns(true);
            mockMarginDataAccess.Setup(b1 => b1.ClearText(margin.Id)).Verifiable();
            mockMarginDataAccess.Setup(b1 => b1.Get(margin.Id)).Returns(
                new Margin()
                {
                    Id = margin.Id,
                    Texts = new List<Text>()
                });

            marginBusinessLogic.ClearText(margin.Id);

            Assert.IsTrue((marginBusinessLogic.GetMargin(margin.Id)).Texts.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteMargin_MarginNotExists_DuplicateException()
        {
            mockMarginDataAccess.Setup(b1 => b1.Exists(margin.Id)).Returns(false);

            marginBusinessLogic.DeleteMargin(margin.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeleteMargin_DataAccessThrowException_ExceptionCatched()
        {
            mockMarginDataAccess.Setup(b1 => b1.Exists(margin.Id)).Returns(true);
            mockMarginDataAccess.Setup(b1 => b1.Delete(margin.Id)).Throws(new Exception());

            marginBusinessLogic.DeleteMargin(margin.Id);
        }

        [TestMethod]
        public void ModifyMargin_ExpectedParameters_Ok()
        {
            margin.SetText(text);
            mockMarginDataAccess.Setup(b1 => b1.Exists(margin.Id)).Returns(true);
            mockMarginDataAccess.Setup(b1 => b1.Modify(margin)).Verifiable();
            mockMarginDataAccess.Setup(b1 => b1.Get(margin.Id)).Returns(
                new Margin()
                {
                    Id = margin.Id,
                    Texts = new List<Text>() { text }
                });

            marginBusinessLogic.ModifyMargin(margin);

            Assert.AreEqual(margin, marginBusinessLogic.GetMargin(margin.Id));
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyMargin_MarginNotExists_DuplicateException()
        {
            mockMarginDataAccess.Setup(b1 => b1.Exists(margin.Id)).Returns(false);

            marginBusinessLogic.ModifyMargin(margin);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ModifyMargin_DataAccessThrowException_ExceptionCatched()
        {
            mockMarginDataAccess.Setup(b1 => b1.Exists(margin.Id)).Returns(true);
            mockMarginDataAccess.Setup(b1 => b1.Modify(margin)).Throws(new Exception());

            marginBusinessLogic.ModifyMargin(margin);
        }

        [TestMethod]
        public void GetMargins_ExpectedParameters_Ok()
        {
            mockMarginDataAccess.Setup(b1 => b1.Get()).Returns(new List<Margin>
            {
                margin
            });

            marginBusinessLogic.GetMargins();
        }

        [TestMethod]
        public void GetTextAndSetText_ExpectedParameters_Ok()
        {
            mockMarginDataAccess.Setup(b1 => b1.Exists(margin.Id)).Returns(true);   
            mockMarginDataAccess.Setup(b1 => b1.Modify(margin)).Verifiable();
            mockMarginDataAccess.Setup(b1 => b1.Get(margin.Id)).Returns(
                new Margin()
                {
                    Id = margin.Id,
                    Texts = new List<Text>() { text }
                });

            marginBusinessLogic.SetText(margin.Id, text);

            Text textObtained = marginBusinessLogic.GetText(margin.Id);

            Assert.AreEqual(textObtained, text);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void SetText_TextAlreadyExists_DuplicateException()
        {
            mockMarginDataAccess.Setup(b1 => b1.Exists(margin.Id)).Returns(false);
            marginBusinessLogic.SetText(margin.Id, text);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetText_TextNull_ArgumentNullException()
        {
            marginBusinessLogic.SetText(margin.Id, null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetMargins_DataAccessThrowException_ExceptionCatched()
        {
            mockMarginDataAccess.Setup(b1 => b1.Get()).Throws(new Exception());

            marginBusinessLogic.GetMargins();
        }

        [TestMethod]
        public void GetMargin_ExpectedParameters_Ok()
        {
            mockMarginDataAccess.Setup(b1 => b1.Exists(margin.Id)).Returns(true);
            mockMarginDataAccess.Setup(b1 => b1.Get(margin.Id)).Returns(new Margin()
            {
                Id = margin.Id
            });

            marginBusinessLogic.GetMargin(margin.Id);
        }

        [TestMethod]
        public void AreEqual_ExpectedParameters_Ok()
        {
            Margin aSecondMargin = Utils.CreateMarginForTest();
            aSecondMargin.Id = margin.Id;

            marginBusinessLogic.AreEqual(margin.Id, aSecondMargin.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetMargin_MarginNotExists_DuplicateException()
        {
            mockMarginDataAccess.Setup(b1 => b1.Exists(margin.Id)).Returns(false);

            marginBusinessLogic.GetMargin(margin.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetMargin_DataAccessThrowException_ExceptionCatched()
        {
            mockMarginDataAccess.Setup(b1 => b1.Exists(margin.Id)).Returns(true);
            mockMarginDataAccess.Setup(b1 => b1.Get(margin.Id)).Throws(new Exception());

            marginBusinessLogic.GetMargin(margin.Id);
        }

        [TestMethod]
        public void IntegrationTest_ExpectedParameters_Ok()
        {
            MarginDataAccess marginDA = new MarginDataAccess();
            MarginBusinessLogic marginBL = new MarginBusinessLogic(marginDA);
            Margin margin1 = Utils.CreateMarginForTest();
            Margin margin2 = Utils.CreateMarginForTest();
            marginBL.AddMargin(margin1);
            marginBL.AddMargin(margin2);

            margin2.SetText(text);
            marginBL.ModifyMargin(margin2);

            marginBL.DeleteMargin(margin1.Id);

            Margin margin2Obtained = marginBL.GetMargin(margin2.Id);
            IList<Margin> marginsObtained = marginBL.GetMargins();

            Assert.IsTrue(!marginsObtained.Contains(margin1) && marginsObtained.Contains(margin2Obtained));
        }
    }
}
