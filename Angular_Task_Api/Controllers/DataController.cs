using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Angular_Task_Api.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Angular_Task_Api.Repository;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace Angular_Task_Api.Controllers
{
	[EnableCors("AllowAll")]
	[Route("api/[controller]")]
	[ApiController]
	public class DataController : ControllerBase
	{
		public IDataRepository _repository { get; set; }
		public DataController(IDataRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public IEnumerable<SummaryDTO> Get()
		{
			var result = _repository.GetAll();
			if (result != null)
				return result;
			return null;
		}

		[HttpGet("{key}", Name = "GetData")]
		public IActionResult GetById(string key)
		{
			var item = _repository.Find(key);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPut]
		public IActionResult Put([FromBody] dynamic item)
		{
			var summary = JsonConvert.DeserializeObject<SummaryDTO>(item.ToString());
			_repository.Update(summary);

			return CreatedAtAction(nameof(GetById), new { key = summary.SamplingTime }, item);
		}
	}
}
