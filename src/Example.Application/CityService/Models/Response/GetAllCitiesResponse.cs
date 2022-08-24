using System.Collections.Generic;
using Example.Application.CityService.Models.Dtos;
using Example.Application.Common;

namespace Example.Application.CityService.Models.Response
{
    public class GetAllCitiesResponse : BaseResponse
    {
        public List<CityDto> Cities { get; set; }
    }
}
