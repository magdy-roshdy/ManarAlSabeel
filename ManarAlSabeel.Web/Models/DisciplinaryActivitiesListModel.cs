using ManarAlSabeel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManarAlSabeel.Web.Models
{
    public class DisciplinaryActivitiesListModel
    {
        public IQueryable<DisciplinaryActivityLog> DisciplinaryActivities { get; set; }
    }
}