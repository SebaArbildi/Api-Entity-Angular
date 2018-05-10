using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;

namespace DocSystBusinessLogicInterface.DocumentStructureLogicInterface
{
    public interface ITextBusinessLogic
    {
        void AddText(Text newText);
        void DeleteText(Guid aTextId);
        void ModifyText(Text newText);
        IList<Text> GetTexts();
        Text GetText(Guid aTextId);
        bool Exist(Guid aTextId);
        bool IsEmpty(Guid aTextId);
        bool AreEqual(Guid firstTextId, Guid secondTextId);
    }
}
