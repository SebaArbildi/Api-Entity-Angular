using DocSystEntities.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocSystWebApi.Models.RerportModels
{
    public class PrinterModel : Model<List<string>, PrinterModel>
    {

        public Guid documentId { get; set; }
        public Guid formatId { get; set; }

    public PrinterModel() { }

    public override List<string> ToEntity()
    {
        throw new NotImplementedException();
    }

    protected override PrinterModel SetModel(List<string> entity)
    {
        throw new NotImplementedException();
    }
    }
}