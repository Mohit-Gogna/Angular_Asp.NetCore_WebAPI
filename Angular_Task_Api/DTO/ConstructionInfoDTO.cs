using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Task_Api.DTO
{
	public class ConstructionInfoDTO
	{
		/// <Summary>
		/// Identifier property.
		/// </Summary>
		public long Id { get; set; }

		/// <Summary>
		/// Name of the parent object.
		/// </Summary>
		public string Name { get; set; }

		/// <Summary>
		/// Collection of SamplingInfoDTO object.
		/// </Summary>
		public List<SamplingInfoDTO> Datas { get; set; }
	}
}
