using Historic.Api.Common;
using Historic.Api.Common.DTO;
using Historic.Api.Common.Extensions;
using Historic.Api.Data.Models;
using Historic.Api.Domain.Campaigns;
using System.Collections.Generic;
using System.Linq;

namespace Api.Domain.Campaigns {
    public class GetUserCampaignsQueryHandler : ADbQueryHandler<GetUserCampaignsQuery, IEnumerable<CampaignDTO>> {

        public GetUserCampaignsQueryHandler(HistoricContext context) : base(context) {
        }

        public override IEnumerable<CampaignDTO> Handle(GetUserCampaignsQuery query) {
            return Context.Campaigns.Select(CampaignExtensions.ToDTO);
        }
    }
}
