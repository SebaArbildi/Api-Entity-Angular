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
    public class TextBusinessLogic : ITextBusinessLogic
    {
        private ITextDataAccess textDataAccess;

        public TextBusinessLogic()
        {
        }

        public TextBusinessLogic(ITextDataAccess aTextDataAccess)
        {
            textDataAccess = aTextDataAccess;
        }

        public void AddText(Text newText)
        {
            if (textDataAccess.Exists(newText.Id))
            {
                throw new DuplicateWaitObjectException("newText.Id"
                    , "The text you want to enter already exists in the database.");
            }

            textDataAccess.Add(newText);
        }

        public bool AreEqual(Guid firstTextId, Guid secondTextId)
        {
            if (!textDataAccess.Exists(firstTextId))
            {
                throw new ArgumentException("The first text argument not exist in database."
                    , "firstTextId");
            }
            if (!textDataAccess.Exists(secondTextId))
            {
                throw new ArgumentException("The second text argument not exist in database."
                    , "secondTextId");
            }

            Text firstText = textDataAccess.Get(firstTextId);
            Text secondText = textDataAccess.Get(secondTextId);

            return firstText.Equals(secondText);
        }

        public void DeleteText(Guid aTextId)
        {
            if (!textDataAccess.Exists(aTextId))
            {
                throw new ArgumentException("The text argument not exist in database."
                    , "aTextId");
            }

            textDataAccess.Delete(aTextId);
        }

        public bool Exist(Guid aTextId)
        {
            return textDataAccess.Exists(aTextId);
        }

        public Guid GetDocumentId(Guid aTextId)
        {
            if (!textDataAccess.Exists(aTextId))
            {
                throw new ArgumentException("The text argument not exist in database."
                    , "aTextId");
            }

            return textDataAccess.GetDocumentId(aTextId);
        }

        public Text GetText(Guid aTextId)
        {
            if (!textDataAccess.Exists(aTextId))
            {
                throw new ArgumentException("The text argument not exist in database."
                    , "aTextId");
            }

            return textDataAccess.Get(aTextId);
        }

        public IList<Text> GetTexts()
        {
            return textDataAccess.Get();
        }

        public bool IsEmpty(Guid aTextId)
        {
            if (!textDataAccess.Exists(aTextId))
            {
                throw new ArgumentException("The text argument not exist in database."
                    , "aTextId");
            }

            Text text = textDataAccess.Get(aTextId);

            return text.IsEmpty();
        }

        public void ModifyText(Text newText)
        {
            if (!textDataAccess.Exists(newText.Id))
            {
                throw new ArgumentException("The text argument not exist in database."
                    , "newText");
            }

            textDataAccess.Modify(newText);
        }
    }
}
