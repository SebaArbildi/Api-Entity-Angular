using DocSystEntities.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocSystWebApi.Models.RerportModels
{
    public class DocumentsActionedPerUserPerDayBetweenDates : Model<List<string>, DocumentsActionedPerUserPerDayBetweenDates>
    {

    public IList<string> UsersId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public string EntityType { get; set; }

    public DocumentsActionedPerUserPerDayBetweenDates() { }

    public override List<string> ToEntity()
    {
        throw new NotImplementedException();
    }

    protected override DocumentsActionedPerUserPerDayBetweenDates SetModel(List<string> entity)
    {
        throw new NotImplementedException();
    }
    }
}