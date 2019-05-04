using System;

namespace Milestone.Dapper.Entities
{
    public class JobMilestone : BaseModel
    {
        public string veh_no { get; set; }

        public string jobno { get; set; }

        public string cont_no { get; set; }

        public string location_from { get; set; }

        public string location_to { get; set; }

        public DateTime mile_date { get; set; }

        public string mile_code { get; set; }

        public string mile_name { get; set; }

        public string mile_stage { get; set; }

        public string mile_type { get; set; }

        public string status_flag { get; set; }
    }
}
