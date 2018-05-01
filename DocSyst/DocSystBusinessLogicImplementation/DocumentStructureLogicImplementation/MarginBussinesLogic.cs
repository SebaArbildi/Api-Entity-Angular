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
    public class MarginBusinessLogic : IMarginBusinessLogic
    {
        private IMarginDataAccess marginDataAccess;

        public MarginBusinessLogic()
        {
        }

        public MarginBusinessLogic(IMarginDataAccess aMarginDataAccess)
        {
            marginDataAccess = aMarginDataAccess;
        }

        public void AddMargin(Margin newMargin)
        {
            if (marginDataAccess.Exists(newMargin.Id))
            {
                throw new DuplicateWaitObjectException("newMargin.Id"
                    , "The Margin you want to enter already exists in the database.");
            }

            marginDataAccess.Add(newMargin);
        }

        public bool AreEqual(Guid firstMarginId, Guid secondMarginId)
        {
            if (!marginDataAccess.Exists(firstMarginId))
            {
                throw new ArgumentException("The first margin argument not exist in database."
                    , "firstMarginId");
            }
            if (!marginDataAccess.Exists(secondMarginId))
            {
                throw new ArgumentException("The second margin argument not exist in database."
                    , "secondMarginId");
            }

            Margin firstMargin = marginDataAccess.Get(firstMarginId);
            Margin secondMargin = marginDataAccess.Get(secondMarginId);

            return firstMargin.Equals(secondMargin);
        }

        public void ClearText(Guid aMarginId)
        {
            if (!marginDataAccess.Exists(aMarginId))
            {
                throw new ArgumentException("The margin argument not exist in database."
                    , "aMarginId");
            }

            marginDataAccess.ClearText(aMarginId);
        }

        public void DeleteMargin(Guid aMarginId)
        {
            if (!marginDataAccess.Exists(aMarginId))
            {
                throw new ArgumentException("The margin argument not exist in database."
                    , "aMarginId");
            }

            marginDataAccess.Delete(aMarginId);
        }

        public bool Exist(Guid aMarginId)
        {
            return marginDataAccess.Exists(aMarginId);
        }

        public Margin GetMargin(Guid aMarginId)
        {
            if (!marginDataAccess.Exists(aMarginId))
            {
                throw new ArgumentException("The margin argument not exist in database."
                    , "aMarginId");
            }

            return marginDataAccess.Get(aMarginId);
        }

        public IList<Margin> GetMargins()
        {
            return marginDataAccess.Get();
        }

        public Text GetText(Guid aMarginId)
        {
            if (!marginDataAccess.Exists(aMarginId))
            {
                throw new ArgumentException("The margin argument not exist in database."
                    , "aMarginId");
            }

            Margin margin = marginDataAccess.Get(aMarginId);

            return margin.GetText();
        }

        public void ModifyMargin(Margin newMargin)
        {
            if (!marginDataAccess.Exists(newMargin.Id))
            {
                throw new ArgumentException("The margin argument not exist in database."
                    , "newMargin.Id");
            }

            marginDataAccess.Modify(newMargin);
        }

        public void SetText(Guid aMarginId, Text aText)
        {
            if (!marginDataAccess.Exists(aMarginId))
            {
                throw new ArgumentException("The margin argument not exist in database."
                    , "aMarginId");
            }

            Margin margin = marginDataAccess.Get(aMarginId);

            if (margin.ExistText(aText.Id))
            {
                throw new DuplicateWaitObjectException("aText"
                    , "The Text you want to enter already exists in the current Paragraph.");
            }

            margin.SetText(aText);

            marginDataAccess.Modify(margin);
        }
    }
}
