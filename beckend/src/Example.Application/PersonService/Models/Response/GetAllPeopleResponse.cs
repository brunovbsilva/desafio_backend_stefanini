using System.Collections.Generic;
using Example.Application.Common;
using Example.Application.PersonService.Models.Dtos;

namespace Example.Application.PersonService.Models.Response
{
    public class GetAllPeopleResponse : BaseResponse
    {
        public List<PersonDto> People { get; set; }
    }
}
