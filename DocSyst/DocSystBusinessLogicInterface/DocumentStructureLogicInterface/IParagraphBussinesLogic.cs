using DocSystEntities.DocumentStructure;
using System;
using System.Collections.Generic;

namespace DocSystBusinessLogicInterface.DocumentStructureLogicInterface
{
    public interface IParagraphBusinessLogic
    {
        void AddParagraph(Paragraph newParagraph);
        void DeleteParagraph(Guid aParagraphId);
        void ModifyParagraph(Paragraph newParagraph);
        IList<Paragraph> GetParagraphs();
        Paragraph GetParagraph(Guid aParagraphId);
        List<Text> GetTextsInParagraph(Guid aParagraphId);
        Text GetText(Guid aParagraphId, Guid aTextId);
        Text GetTextAt(Guid aParagraphId, int position);
        void PutTextAtLast(Guid aParagraphId, Text aText);
        void PutTextAt(Guid aParagraphId, Text aText, int position);
        void MoveTextTo(Guid aParagraphId, Guid textId, int newPosition);
        void ClearText(Guid aParagraphId);
        bool AreEqual(Guid firstParagraphId, Guid secondParagraphId);
        bool Exist(Guid aParagraphId);
    }
}
