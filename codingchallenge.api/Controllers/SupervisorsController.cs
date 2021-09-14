using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using codingchallenge.api.Data;
using codingchallenge.api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace codingchallenge.api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class SupervisorsController : ControllerBase
    {
        private readonly IConfiguration configure;
        private readonly INotificationRepo _repository;
        private readonly IMapper _mapper;

        public SupervisorsController(IConfiguration Configure, INotificationRepo repository, IMapper mapper)
        {
            configure = Configure;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<SupervisorReadDto>> GetSupervisors()
        {
            Console.WriteLine("Getting Supervisors");
            IEnumerable<SupervisorGetDto> supervisors = GetSupervisorList().Result.Where(s => !Char.IsNumber(s.jurisdiction[0]))
                .OrderBy(s => s.jurisdiction)
                .OrderBy(s => s.lastName)
                .OrderBy(s => s.lastName);

            List<SupervisorReadDto> supes = new List<SupervisorReadDto>();

            foreach (var s in supervisors)
            {
                supes.Add(new SupervisorReadDto
                {
                    id = s.id,
                    Supervisor = s.jurisdiction + " - " + s.lastName + ", " + s.firstName
                });
            }

            return Ok(supes.OrderBy(s => s.Supervisor));
        }

        private async Task<IEnumerable<SupervisorGetDto>> GetSupervisorList()
        {
            IEnumerable<SupervisorGetDto> supervisorItems = null;
            using (var client = new HttpClient())
            {
                Console.WriteLine("Starting Supervisor call:");
                client.BaseAddress = new Uri(configure["ManagerApi"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage ManagerResponse = await client.GetAsync("lightfeather/managers");

                if (ManagerResponse.IsSuccessStatusCode)
                {
                    var supResponse = ManagerResponse.Content.ReadAsStringAsync().Result;
                    supervisorItems = JsonConvert.DeserializeObject<IEnumerable<SupervisorGetDto>>(supResponse);
                }

                //returning the employee list to view
                return supervisorItems;
            }
        }
    }
}