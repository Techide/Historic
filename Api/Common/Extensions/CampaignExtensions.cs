using Historic.Api.Common.DTO;
using Historic.Api.Data;
using Historic.Api.Data.Models;
using System;
using System.Linq.Expressions;

namespace Historic.Api.Common.Extensions {
    internal class CampaignExtensions {
        public static Expression<Func<Campaign, CampaignDTO>> ToDTO = dto => new CampaignDTO {
            Id = dto.Id,
            Name = dto.Name,
            Status = Enum.GetName(typeof(CampaignStatus), dto.Status)
        };
    }
}
