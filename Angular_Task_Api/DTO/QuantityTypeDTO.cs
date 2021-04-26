using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Task_Api.DTO
{
	public class QuantityTypeDTO
	{
		/// <Summary>
		/// Quantity value
		/// </Summary>
		public double? Value { get; set; }

		/// <Summary>
		/// Quantity unit
		/// </Summary>
		public UnitTypeDTO Unit { get; set; }
	}
}
