using Angular_Task_Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Task_Api.Repository
{
	public interface IDataRepository
	{
		void Add(SummaryDTO item);
		IEnumerable<SummaryDTO> GetAll();
		SummaryDTO Find(string key);
		void Update(SummaryDTO item);
	}
}
