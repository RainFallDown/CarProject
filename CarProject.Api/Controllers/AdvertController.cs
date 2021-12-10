using CarProject.Core.Abstract.Service;
using CarProject.Core.Dto;
using CarProject.Core.Entities;
using CarProject.Core.Model;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc;

namespace CarProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdvertController : BaseController
    {

        private readonly IAdvertService _advertService;
        private readonly IAdvertVisitService _advertVisitService;
        private readonly IBus _bus;
        public AdvertController(IAdvertService advertService, IAdvertVisitService advertVisitService, IBus bus)
        {
            _advertService = advertService;
            _advertVisitService = advertVisitService;
            _bus = bus;
        }

        [HttpPost]
        public async Task<ActionResult<QueryAdvertDto>> All(AdvertQueryParameters parameters)
        {
            var pagedResult = await _advertService.QueryAdverts(parameters);
            if(pagedResult.Adverts != null && pagedResult.Adverts.Count > 0)
            {
                return pagedResult;
            }
            else
            {
                SetMessage("No adverts found");
                return NoContent();
            }

        }
        [HttpGet]
        public async Task<ActionResult<AdvertDto>> Get(int id)
        {
            var result = await _advertService.GetAdvert(id);
            if (result != null)
            {
                return result;
            }
            else
            {
                SetMessage("No adverts found");
                return NoContent();
            }
        }
        [HttpGet]
        public async Task<List<AdvertVisitDto>> GetAllVisits()
        {
            return await _advertVisitService.GetAllVisits();
        }
        [HttpGet]
        public async Task Visit(string advertId)
        {
            //await _advertVisitService.AddVisit(advertId, RemoteIp);
            await _bus.PubSub.PublishAsync<AdvertVisit>(new AdvertVisit()
            {
                AdvertId = Convert.ToInt32(advertId),
                IPAdress = RemoteIp,
                VisitDate = DateTime.Now,
            });
        }
    }
}
