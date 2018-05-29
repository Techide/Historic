using Historic.Api.Common.CQS;
using Historic.Api.Common.DTO;
using System.Collections.Generic;

namespace Historic.Api.Domain.Campaigns {
    public class GetUserCampaignsQuery : IQuery<IEnumerable<CampaignDTO>> {
        public int UserId { get; }

        public GetUserCampaignsQuery(int userId) {
            UserId = userId;
        }
    }
}
