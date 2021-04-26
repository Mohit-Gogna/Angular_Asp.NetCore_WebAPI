using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Task_Api.Entity
{
	public class EntityProperty
	{
		public enum EntityPropertyDataType : byte
		{
			/// <Summary>
			/// If this is set on PropertyType of PropertyInfoDTO, UI should render the input (type=text) field and place the value.
			/// </Summary>
			StringProperty = 0,

			/// <Summary>
			/// If this is set on PropertyType of PropertyInfoDTO, UI should render the input (type=number) field and place the value.Also, display unit after the input field.
			/// </Summary>
			QuantityProperty = 1,

			/// <Summary>
			/// If this is set on PropertyType of PropertyInfoDTO, UI should render the input (type= number) field and place the value.
			/// </Summary>
			NumericProperty = 2,

			/// <Summary>
			/// If this is set on PropertyType of PropertyInfoDTO, UI should render a checkbox field and assign the value
			/// </Summary>
			BooleanProperty = 3,

			GeometryProperty = 4
		}
	}
}
