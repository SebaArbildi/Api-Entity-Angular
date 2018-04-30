using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;

namespace DocSystBusinessLogicInterface.DocumentStructureLogicInterface
{
    public interface IMarginBusinessLogic
    {
        void AddMargin(Margin newMargin);
        void DeleteMargin(Guid aMarginId);
        void ModifyMargin(Margin newMargin);
        IList<Margin> GetMargins();
        Margin GetMargin(Guid aMarginId);
        void SetText(Guid aMarginId, Text aText);
        Text GetText(Guid aMarginId);
        void ClearText(Guid aMarginId);
        bool AreEqual(Guid firstMarginId, Guid secondMarginId);
    }
}
