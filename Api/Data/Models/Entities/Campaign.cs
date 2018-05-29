using Historic.Api.Data;
using System;

namespace Historic.Api.Data.Models {
    public class Campaign
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Start { get; set; }

        public CampaignStatus Status { get; set; }
    }
}
