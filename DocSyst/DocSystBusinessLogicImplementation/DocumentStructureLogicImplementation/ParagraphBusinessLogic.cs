using DocSystBusinessLogicInterface.DocumentStructureLogicInterface;
using DocSystDataAccessInterface.DocumentStructureDataAccessInterface;
using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystBusinessLogicImplementation.DocumentStructureLogicImplementation
{
    public class ParagraphBusinessLogic : IParagraphBusinessLogic
    {
        private IParagraphDataAccess paragraphDataAccess;

        public ParagraphBusinessLogic()
        {
        }

        public ParagraphBusinessLogic(IParagraphDataAccess aParagraphDataAccess)
        {
            paragraphDataAccess = aParagraphDataAccess;
        }

        public void AddParagraph(Paragraph newParagraph)
        {
            if (paragraphDataAccess.Exists(newParagraph.Id))
            {
                throw new DuplicateWaitObjectException("newParagraph.Id"
                    , "The Paragraph you want to enter already exists in the database.");
            }

            paragraphDataAccess.Add(newParagraph);
        }

        public bool AreEqual(Guid firstParagraphId, Guid secondParagraphId)
        {
            if (!paragraphDataAccess.Exists(firstParagraphId))
            {
                throw new ArgumentException("The first paragraph argument not exist in database."
                    , "firstParagraphId");
            }
            if (!paragraphDataAccess.Exists(secondParagraphId))
            {
                throw new ArgumentException("The second paragraph argument not exist in database."
                    , "secondParagraphId");
            }

            Paragraph firstParagraph = paragraphDataAccess.Get(firstParagraphId);
            Paragraph secondParagraph = paragraphDataAccess.Get(secondParagraphId);

            return firstParagraph.Equals(secondParagraph);
        }

        public void ClearText(Guid aParagraphId)
        {
            if (!paragraphDataAccess.Exists(aParagraphId))
            {
                throw new ArgumentException("The paragraph argument not exist in database."
                    , "aParagraphId");
            }

            paragraphDataAccess.ClearText(aParagraphId);
        }

        public void DeleteParagraph(Guid aParagraphId)
        {
            if (!paragraphDataAccess.Exists(aParagraphId))
            {
                throw new ArgumentException("The paragraph argument not exist in database."
                    , "aParagraphId");
            }

            paragraphDataAccess.Delete(aParagraphId);
        }

        public bool Exist(Guid aParagraphId)
        {
            return paragraphDataAccess.Exists(aParagraphId);
        }

        public Paragraph GetParagraph(Guid aParagraphId)
        {
            if (!paragraphDataAccess.Exists(aParagraphId))
            {
                throw new ArgumentException("The paragraph argument not exist in database."
                    , "aParagraphId");
            }

            return paragraphDataAccess.Get(aParagraphId);
        }

        public IList<Paragraph> GetParagraphs()
        {
            return paragraphDataAccess.Get();
        }

        public Text GetText(Guid aParagraphId, Guid aTextId)
        {
            if (!paragraphDataAccess.Exists(aParagraphId))
            {
                throw new ArgumentException("The paragraph argument not exist in database."
                    , "aParagraphId");
            }

            Paragraph paragraph = paragraphDataAccess.Get(aParagraphId);

            if (!paragraph.ExistText(aTextId))
            {
                throw new ArgumentException("The text argument not exist in the actual paragraph."
                    , "aTextId");
            }

            return paragraph.GetText(aTextId);
        }

        public Text GetTextAt(Guid aParagraphId, int position)
        {
            if (!paragraphDataAccess.Exists(aParagraphId))
            {
                throw new ArgumentException("The paragraph argument not exist in database."
                    , "aParagraphId");
            }

            Paragraph paragraph = paragraphDataAccess.Get(aParagraphId);

            return paragraph.GetTextAt(position);
        }

        public List<Text> GetTextsInParagraph(Guid aParagraphId)
        {
            if (!paragraphDataAccess.Exists(aParagraphId))
            {
                throw new ArgumentException("The paragraph argument not exist in database."
                    , "aParagraphId");
            }

            Paragraph paragraph = paragraphDataAccess.Get(aParagraphId);

            if (!paragraph.HasText())
            {
                throw new ArgumentException("The text list are empty in actual paragraph.");
            }

            return paragraph.Texts;
        }

        public void ModifyParagraph(Paragraph newParagraph)
        {
            if (!paragraphDataAccess.Exists(newParagraph.Id))
            {
                throw new ArgumentException("The paragraph argument not exist in database."
                    , "newParagraph.Id");
            }

            paragraphDataAccess.Modify(newParagraph);
        }

        public void MoveTextTo(Guid aParagraphId, Guid textId, int newPosition)
        {
            if (!paragraphDataAccess.Exists(aParagraphId))
            {
                throw new ArgumentException("The paragraph argument not exist in database."
                    , "aParagraphId");
            }

            Paragraph paragraph = paragraphDataAccess.Get(aParagraphId);

            if (!paragraph.ExistText(textId))
            {
                throw new ArgumentException("The text argument not exist in the actual paragraph."
                    , "textId");
            }

            paragraph.MoveTextTo(newPosition, textId);

            paragraphDataAccess.Modify(paragraph);
        }

        public void PutTextAt(Guid aParagraphId, Text aText, int position)
        {
            if (!paragraphDataAccess.Exists(aParagraphId))
            {
                throw new ArgumentException("The paragraph argument not exist in database."
                    , "aParagraphId");
            }

            Paragraph paragraph = paragraphDataAccess.Get(aParagraphId);

            if (paragraph.ExistText(aText.Id))
            {
                throw new DuplicateWaitObjectException("aText"
                    , "The Text you want to enter already exists in the current Paragraph.");
            }

            paragraph.PutTextAt(position,aText);

            paragraphDataAccess.Modify(paragraph);
        }

        public void PutTextAtLast(Guid aParagraphId, Text aText)
        {
            if (!paragraphDataAccess.Exists(aParagraphId))
            {
                throw new ArgumentException("The paragraph argument not exist in database."
                    , "aParagraphId");
            }

            Paragraph paragraph = paragraphDataAccess.Get(aParagraphId);

            if (paragraph.ExistText(aText.Id))
            {
                throw new DuplicateWaitObjectException("aText"
                    , "The Text you want to enter already exists in the current Paragraph.");
            }

            paragraph.PutTextAtLast(aText);

            paragraphDataAccess.Modify(paragraph);
        }
    }
}
