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
    public class ParagraphBusinessLogicTest
    {
        Mock<IParagraphDataAccess> mockParagraphDataAccess;
        IParagraphBusinessLogic paragraphBusinessLogic;
        Paragraph paragraph;
        Text text;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            mockParagraphDataAccess = new Mock<IParagraphDataAccess>();
            paragraphBusinessLogic = new ParagraphBusinessLogic(mockParagraphDataAccess.Object);
            paragraph = Utils.CreateParagraphForTest();
            text = Utils.CreateTextForTest();
        }

        [TestMethod]
        public void CreateParagraphBL_WithoutParameters_Ok()
        {
            IParagraphBusinessLogic paragraphBL = new ParagraphBusinessLogic();

            Assert.IsNotNull(paragraphBL);
        }

        [TestMethod]
        public void CreateParagraphBL_WithParameters_Ok()
        {
            IParagraphDataAccess paragraphDataAccess = new ParagraphDataAccess();

            IParagraphBusinessLogic paragraphBL = new ParagraphBusinessLogic(paragraphDataAccess);

            Assert.IsNotNull(paragraphBL);
        }

        [TestMethod]
        public void AddParagraph_ExpectedParameters_Ok()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Add(paragraph)).Verifiable();

            paragraphBusinessLogic.AddParagraph(paragraph);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void AddParagraph_ParagraphAlreadyExists_DuplicateException()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(true);

            paragraphBusinessLogic.AddParagraph(paragraph);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddParagraph_DataAccessThrowException_ExceptionCatched()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Add(paragraph)).Throws(new Exception());

            paragraphBusinessLogic.AddParagraph(paragraph);
        }

        [TestMethod]
        public void DeleteParagraph_ExpectedParameters_Ok()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(true);
            mockParagraphDataAccess.Setup(b1 => b1.Delete(paragraph.Id)).Verifiable();

            paragraphBusinessLogic.DeleteParagraph(paragraph.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteParagraph_ParagraphNotExists_DuplicateException()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(false);

            paragraphBusinessLogic.DeleteParagraph(paragraph.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeleteParagraph_DataAccessThrowException_ExceptionCatched()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(true);
            mockParagraphDataAccess.Setup(b1 => b1.Delete(paragraph.Id)).Throws(new Exception());

            paragraphBusinessLogic.DeleteParagraph(paragraph.Id);
        }

        [TestMethod]
        public void ModifyParagraph_ExpectedParameters_Ok()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(true);
            mockParagraphDataAccess.Setup(b1 => b1.Modify(paragraph)).Verifiable();
            mockParagraphDataAccess.Setup(b1 => b1.Get(paragraph.Id)).Returns(
                new Paragraph()
                {
                    Id = paragraph.Id,
                    Texts = new List<Text>() { text }
                }
                );

            paragraph.PutTextAtLast(text);
            paragraphBusinessLogic.ModifyParagraph(paragraph);

            Assert.AreEqual(paragraph.GetText(text.Id), paragraphBusinessLogic.GetText(paragraph.Id, text.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyParagraph_ParagraphNotExists_DuplicateException()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(false);

            paragraphBusinessLogic.ModifyParagraph(paragraph);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ModifyParagraph_DataAccessThrowException_ExceptionCatched()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(true);
            mockParagraphDataAccess.Setup(b1 => b1.Modify(paragraph)).Throws(new Exception());

            paragraphBusinessLogic.ModifyParagraph(paragraph);
        }

        [TestMethod]
        public void GetParagraphs_ExpectedParameters_Ok()
        {
            paragraphBusinessLogic.GetParagraphs();
        }

        [TestMethod]
        public void GetTextAndPutTextAtLast_ExpectedParameters_Ok()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(true);
            mockParagraphDataAccess.Setup(b1 => b1.Modify(paragraph)).Verifiable();
            mockParagraphDataAccess.Setup(b1 => b1.Get(paragraph.Id)).Returns(
                new Paragraph()
                {
                    Id = paragraph.Id,
                    Texts = new List<Text>()
                });

            paragraphBusinessLogic.PutTextAtLast(paragraph.Id, text);

            Text textObtained = paragraphBusinessLogic.GetText(paragraph.Id, text.Id);

            Assert.AreEqual(textObtained, text);
        }

        [TestMethod]
        public void GetTextAt_ExpectedParameters_Ok()
        {
            Text otherText = new Text();
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(true);
            mockParagraphDataAccess.Setup(b1 => b1.Modify(paragraph)).Verifiable();
            mockParagraphDataAccess.Setup(b1 => b1.Get(paragraph.Id)).Returns(
                new Paragraph()
                {
                    Id = paragraph.Id,
                    Texts = new List<Text>()
                });

            paragraphBusinessLogic.PutTextAtLast(paragraph.Id,text);
            paragraphBusinessLogic.PutTextAtLast(paragraph.Id,otherText);

            Text textObtained1 = paragraphBusinessLogic.GetTextAt(paragraph.Id, 0);
            Text textObtained2 = paragraphBusinessLogic.GetTextAt(paragraph.Id, 1);

            Assert.AreEqual(textObtained1, text);
            Assert.AreEqual(textObtained2, otherText);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void PutTextAtLast_TextAlreadyExists_DuplicateException()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(true);
            mockParagraphDataAccess.Setup(b1 => b1.Get(paragraph.Id)).Returns(
                new Paragraph()
                {
                    Id = paragraph.Id,
                    Texts = new List<Text>() { text }
                });

            paragraphBusinessLogic.PutTextAtLast(paragraph.Id, text);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void PutTextAtLast_TextNull_NullReferenceException()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(true);
            mockParagraphDataAccess.Setup(b1 => b1.Get(paragraph.Id)).Returns(
                new Paragraph()
                {
                    Id = paragraph.Id,
                    Texts = new List<Text>()
                });

            paragraphBusinessLogic.PutTextAtLast(paragraph.Id, null);
        }

        [TestMethod]
        public void PutTextAtPos_ExpectedParameters_Ok()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(true);
            mockParagraphDataAccess.Setup(b1 => b1.Modify(paragraph)).Verifiable();
            mockParagraphDataAccess.Setup(b1 => b1.Get(paragraph.Id)).Returns(
                new Paragraph()
                {
                    Id = paragraph.Id,
                    Texts = new List<Text>()
                });

            paragraphBusinessLogic.PutTextAt(paragraph.Id, text, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void PutTextAtPos_TextAlreadyExists_DuplicateException()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(true);
            mockParagraphDataAccess.Setup(b1 => b1.Get(paragraph.Id)).Returns(
                new Paragraph()
                {
                    Id = paragraph.Id,
                    Texts = new List<Text>() { text }
                });

            paragraphBusinessLogic.PutTextAt(paragraph.Id, text, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void PutTextAtPos_TextNull_ArgumentNullException()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(true);
            mockParagraphDataAccess.Setup(b1 => b1.Get(paragraph.Id)).Returns(
                new Paragraph()
                {
                    Id = paragraph.Id,
                    Texts = new List<Text>() { text }
                });

            paragraphBusinessLogic.PutTextAt(paragraph.Id, null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetParagraphs_DataAccessThrowException_ExceptionCatched()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Get()).Throws(new Exception());

            paragraphBusinessLogic.GetParagraphs();
        }

        [TestMethod]
        public void GetParagraph_ExpectedParameters_Ok()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(true);
            mockParagraphDataAccess.Setup(b1 => b1.Get(paragraph.Id)).Returns(new Paragraph()
            {
                Id = paragraph.Id
            });

            paragraphBusinessLogic.GetParagraph(paragraph.Id);
        }

        [TestMethod]
        public void AreEqual_ExpectedParameters_Ok()
        {
            Paragraph aSecondParagraph = Utils.CreateParagraphForTest();
            aSecondParagraph.Id = paragraph.Id;

            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(true);
            mockParagraphDataAccess.Setup(b1 => b1.Exists(aSecondParagraph.Id)).Returns(true);
            mockParagraphDataAccess.Setup(b1 => b1.Get(paragraph.Id)).Returns(new Paragraph()
            {
                Id = paragraph.Id
            });

            paragraphBusinessLogic.AreEqual(paragraph.Id, aSecondParagraph.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetParagraph_ParagraphNotExists_DuplicateException()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(false);

            paragraphBusinessLogic.GetParagraph(paragraph.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetParagraph_DataAccessThrowException_ExceptionCatched()
        {
            mockParagraphDataAccess.Setup(b1 => b1.Exists(paragraph.Id)).Returns(true);
            mockParagraphDataAccess.Setup(b1 => b1.Get(paragraph.Id)).Throws(new Exception());

            paragraphBusinessLogic.GetParagraph(paragraph.Id);
        }

        [TestMethod]
        public void IntegrationTest_ExpectedParameters_Ok()
        {
            ParagraphDataAccess paragraphDA = new ParagraphDataAccess();
            ParagraphBusinessLogic paragraphBL = new ParagraphBusinessLogic(paragraphDA);
            Paragraph paragraph1 = Utils.CreateParagraphForTest();
            Paragraph paragraph2 = Utils.CreateParagraphForTest();
            paragraphBL.AddParagraph(paragraph1);
            paragraphBL.AddParagraph(paragraph2);

            paragraph2.PutTextAtLast(text);
            paragraphBL.ModifyParagraph(paragraph2);

            paragraphBL.DeleteParagraph(paragraph1.Id);

            Paragraph paragraph2Obtained = paragraphBL.GetParagraph(paragraph2.Id);
            IList<Paragraph> paragraphsObtained = paragraphBL.GetParagraphs();

            Assert.IsTrue(!paragraphsObtained.Contains(paragraph1) && paragraphsObtained.Contains(paragraph2Obtained));
        }
    }
}
