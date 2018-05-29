using DocSystEntities.DocumentStructure;
using DocSystEntities.StyleStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSystEntities.Generator
{
    public interface IGenerator
    {
        string Generate(Document document, Format format);
    }
}
