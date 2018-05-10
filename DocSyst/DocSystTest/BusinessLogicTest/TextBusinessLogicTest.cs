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
    public class TextBusinessLogicTest
    {
        Mock<ITextDataAccess> mockTextDataAccess;
        ITextBusinessLogic textBusinessLogic;
        Text text;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            mockTextDataAccess = new Mock<ITextDataAccess>();
            textBusinessLogic = new TextBusinessLogic(mockTextDataAccess.Object);
            text = Utils.CreateTextForTest();
        }

        [TestMethod]
        public void CreateTextBL_WithoutParameters_Ok()
        {
            ITextBusinessLogic textBL = new TextBusinessLogic();

            Assert.IsNotNull(textBL);
        }

        [TestMethod]
        public void CreateTextBL_WithParameters_Ok()
        {
            ITextDataAccess textDataAccess = new TextDataAccess();
            IBodyDataAccess bodyDataAccess = new BodyDataAccess();

            ITextBusinessLogic textBL = new TextBusinessLogic(textDataAccess);

            Assert.IsNotNull(textBL);
        }

        [TestMethod]
        public void AddText_ExpectedParameters_Ok()
        {
            textBusinessLogic.AddText(text);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void AddText_TextAlreadyExists_DuplicateException()
        {
            mockTextDataAccess.Setup(b1 => b1.Exists(text.Id)).Returns(true);

            textBusinessLogic.AddText(text);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddText_DataAccessThrowException_ExceptionCatched()
        {
            mockTextDataAccess.Setup(b1 => b1.Add(text)).Throws(new Exception());

            textBusinessLogic.AddText(text);
        }

        [TestMethod]
        public void DeleteText_ExpectedParameters_Ok()
        {
            mockTextDataAccess.Setup(b1 => b1.Exists(text.Id)).Returns(true);

            textBusinessLogic.DeleteText(text.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteText_TextNotExists_DuplicateException()
        {
            mockTextDataAccess.Setup(b1 => b1.Exists(text.Id)).Returns(false);

            textBusinessLogic.DeleteText(text.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeleteText_DataAccessThrowException_ExceptionCatched()
        {
            mockTextDataAccess.Setup(b1 => b1.Exists(text.Id)).Returns(true);
            mockTextDataAccess.Setup(b1 => b1.Delete(text.Id)).Throws(new Exception());

            textBusinessLogic.DeleteText(text.Id);
        }

        [TestMethod]
        public void ModifyText_ExpectedParameters_Ok()
        {
            mockTextDataAccess.Setup(b1 => b1.Exists(text.Id)).Returns(true);

            textBusinessLogic.ModifyText(text);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyText_TextNotExists_DuplicateException()
        {
            mockTextDataAccess.Setup(b1 => b1.Exists(text.Id)).Returns(false);

            textBusinessLogic.ModifyText(text);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ModifyText_DataAccessThrowException_ExceptionCatched()
        {
            mockTextDataAccess.Setup(b1 => b1.Exists(text.Id)).Returns(true);
            mockTextDataAccess.Setup(b1 => b1.Modify(text)).Throws(new Exception());

            textBusinessLogic.ModifyText(text);
        }

        [TestMethod]
        public void GetTexts_ExpectedParameters_Ok()
        {
            textBusinessLogic.GetTexts();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetTexts_DataAccessThrowException_ExceptionCatched()
        {
            mockTextDataAccess.Setup(b1 => b1.Get()).Throws(new Exception());

            textBusinessLogic.GetTexts();
        }

        [TestMethod]
        public void GetText_ExpectedParameters_Ok()
        {
            mockTextDataAccess.Setup(b1 => b1.Exists(text.Id)).Returns(true);

            textBusinessLogic.GetText(text.Id);
        }

        [TestMethod]
        public void AreEqual_ExpectedParameters_Ok()
        {
            Text aSecondText = Utils.CreateTextForTest();
            aSecondText.Id = text.Id;
            mockTextDataAccess.Setup(b1 => b1.Exists(text.Id)).Returns(true);
            mockTextDataAccess.Setup(b1 => b1.Exists(aSecondText.Id)).Returns(true);
            mockTextDataAccess.Setup(b1 => b1.Get(text.Id)).Returns(new Text()
            {
                Id = text.Id
            });

            textBusinessLogic.AreEqual(text.Id,aSecondText.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AreEqual_FirstTextNotExist_ArgumentException()
        {
            Text aSecondText = Utils.CreateTextForTest();
            mockTextDataAccess.Setup(b1 => b1.Exists(text.Id)).Returns(false);
            mockTextDataAccess.Setup(b1 => b1.Exists(aSecondText.Id)).Returns(true);
            mockTextDataAccess.Setup(b1 => b1.Get(text.Id)).Returns(new Text()
            {
                Id = text.Id
            });

            textBusinessLogic.AreEqual(text.Id, aSecondText.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AreEqual_SecondTextNotExist_ArgumentException()
        {
            Text aSecondText = Utils.CreateTextForTest();
            mockTextDataAccess.Setup(b1 => b1.Exists(text.Id)).Returns(true);
            mockTextDataAccess.Setup(b1 => b1.Exists(aSecondText.Id)).Returns(false);

            textBusinessLogic.AreEqual(text.Id, aSecondText.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetText_TextNotExists_DuplicateException()
        {
            mockTextDataAccess.Setup(b1 => b1.Exists(text.Id)).Returns(false);

            textBusinessLogic.GetText(text.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetText_DataAccessThrowException_ExceptionCatched()
        {
            mockTextDataAccess.Setup(b1 => b1.Exists(text.Id)).Returns(true);
            mockTextDataAccess.Setup(b1 => b1.Get(text.Id)).Throws(new Exception());

            textBusinessLogic.GetText(text.Id);
        }

        [TestMethod]
        public void IsEmpty_ExpectedParameters_Ok()
        {
            mockTextDataAccess.Setup(b1 => b1.Exists(text.Id)).Returns(true);
            mockTextDataAccess.Setup(b1 => b1.Get(text.Id)).Returns(new Text()
            {
                Id = text.Id,
                TextContent = ""
            });

            Assert.IsTrue(textBusinessLogic.IsEmpty(text.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsEmpty_TextNotExist_ArgumentException()
        {
            mockTextDataAccess.Setup(b1 => b1.Exists(text.Id)).Returns(false);

            textBusinessLogic.IsEmpty(text.Id);
        }

        [TestMethod]
        public void IntegrationTest_ExpectedParameters_Ok()
        {
            TextDataAccess textDA = new TextDataAccess();
            BodyDataAccess bodyDA = new BodyDataAccess();
            TextBusinessLogic textBL = new TextBusinessLogic(textDA);
            Text text1 = Utils.CreateTextForTest();
            Text text2 = Utils.CreateTextForTest();
            textBL.AddText(text1);
            textBL.AddText(text2);

            text2.OwnStyleClass = "Other style";
            textBL.ModifyText(text2);

            textBL.DeleteText(text1.Id);

            Text text2Obtained = textBL.GetText(text2.Id);
            IList<Text> textsObtained = textBL.GetTexts();

            Assert.IsTrue(!textsObtained.Contains(text1) && textsObtained.Contains(text2Obtained));
        }
    }
}
