using System;
using System.Collections.Generic;
using System.Text;

namespace SureAppTest.Common.Models
{
    public class EventModel
    {
        public int? RowNum { get; set; }
        public string EventID { get; set; }
        public string EventTitle { get; set; }
        public string LocationDesc { get; set; }
        public string EventDetails { get; set; }
        public string CategoryID { get; set; }
        public string SiteUrl { get; set; }
        public string Email { get; set; }
        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public DateTime? EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public string EventLatitude { get; set; }
        public string EventLongitude { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string AgencyID { get; set; }
        public string EventStatusName { get; set; }
        public string ImagePath { get; set; }
        public string CityArName { get; set; }
        public string CityEnName { get; set; }
        public string RegionArName { get; set; }
        public string RegionEnName { get; set; }
        public int? TotalCount { get; set; }
    }
}
