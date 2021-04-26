using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Task_Api.DTO
{
	public class SamplingInfoDTO
	{
		/// <Summary>
		/// Sampling time of the properties.
		/// </Summary>
		public DateTime SamplingTime { get; set; }

		/// <Summary>
		/// Collection of PropertyInfoDTO object.
		/// </Summary>
		public List<PropertyInfoDTO> Properties { get; set; }
	}
}
