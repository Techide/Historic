using Historic.Api.Common.CQS;
using Historic.Api.Common.DTO;
using Historic.Api.Domain.Campaigns;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Historic.Api.Controllers {
    [Produces("application/json")]
    public class CampaignController : Controller {
        private readonly IQueryHandler<GetUserCampaignsQuery, IEnumerable<CampaignDTO>> _getCampaignsQueryHandler;

        public CampaignController(
            IQueryHandler<GetUserCampaignsQuery, IEnumerable<CampaignDTO>> getCampaignsQueryHandler) {
            _getCampaignsQueryHandler = getCampaignsQueryHandler;
        }

        [HttpGet("api/campaigns", Name = nameof(GetCampaigns))]
        public IActionResult GetCampaigns() {
            var data = _getCampaignsQueryHandler.Handle(new GetUserCampaignsQuery(0));
            return Ok(data);
        }

    }
}