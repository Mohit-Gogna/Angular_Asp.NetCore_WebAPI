using Angular_Task_Api.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_Task_Api.Repository
{
	public class DataRepository:IDataRepository		
	{
		private static IList<SummaryDTO> _summary;

		public DataRepository()
		{
			_summary = new List<SummaryDTO>();
			var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"{"Data\\data.json"}");
			var JSON = System.IO.File.ReadAllText(folderDetails);
			var consInfo = JsonConvert.DeserializeObject<ConstructionInfoDTO>(JSON);
			foreach (var prop in consInfo.Datas)
			{
				SummaryDTO item = new SummaryDTO();
				item.SamplingTime = prop.SamplingTime.ToString("dd-MM-yyyy hh:mm:ss tt");
				item.ProjectName = prop.Properties.Where(i => i.Label.ToLower() == "project name").FirstOrDefault().Value.ToString();
				var count = prop.Properties.Where(i => i.Label.ToLower() == "construction count").FirstOrDefault();
				if(count != null) { item.ConstructionCount = int.Parse(count.Value.ToString()); }
				item.IsConstructionCompleted = bool.Parse(prop.Properties.Where(i => i.Label.ToLower() == "is construction completed").FirstOrDefault()?.Value.ToString());
				var length = prop.Properties.Where(i => i.Label.ToLower() == "length of the road").FirstOrDefault();
				if (length != null) 
				{
					var json = JsonConvert.DeserializeObject<QuantityTypeDTO>(length.Value.ToString());
					item.LengthOfTheRoad = json.Value;
					item.Unit = json.Unit.Symbol;
				}
				_summary.Add(item);
			}
		}

		public void Add(SummaryDTO item)
		{
			throw new NotImplementedException();
		}

		public SummaryDTO Find(string key)
		{
			return _summary.Where(x => x.SamplingTime.ToString() == key).FirstOrDefault();
		}

		public IEnumerable<SummaryDTO> GetAll()
		{
			return _summary;
		}

		public void Update(SummaryDTO item)
		{
			var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"{"Data\\data.json"}");
			var json = File.ReadAllText(folderDetails);
			var jObject = JObject.Parse(json);
			JArray datasArray = (JArray)jObject["Datas"];
			var data = datasArray.Where(x => (DateTime.Parse(x["SamplingTime"].ToString()).ToString("dd-MM-yyyy hh:mm:ss tt") == item.SamplingTime)).FirstOrDefault();
			if(data != null)
			{
				JArray propArray = (JArray)data["Properties"];
				if(propArray!=null)
				{
					if(propArray.Any(x=>x["Label"] != null && x["Label"].ToString().ToLower() == "project name"))
					{
						var label = propArray.Where(i => i["Label"].ToString().ToLower() == "project name").FirstOrDefault();
						label["Value"] = item.ProjectName;
					}
					if (propArray.Any(x => x["Label"] != null && x["Label"].ToString().ToLower() == "construction count"))
					{
						var label = propArray.Where(i => i["Label"].ToString().ToLower() == "construction count").FirstOrDefault();
						label["Value"] = item.ConstructionCount;
					}
					if (propArray.Any(x => x["Label"] != null && x["Label"].ToString().ToLower() == "is construction completed"))
					{
						var label = propArray.Where(i => i["Label"].ToString().ToLower() == "is construction completed").FirstOrDefault();
						label["Value"] = item.IsConstructionCompleted;
					}
					if (propArray.Any(x => x["Label"] != null && x["Label"].ToString().ToLower() == "length of the road"))
					{
						var label = propArray.Where(i => i["Label"].ToString().ToLower() == "length of the road").FirstOrDefault();
						label["Value"]["Value"] = item.LengthOfTheRoad;
					}
					jObject["Properties"] = propArray;
				}
				jObject["Datas"] = datasArray;
			}
			string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
			File.WriteAllText(folderDetails, string.Empty);
			File.WriteAllText(folderDetails, output);
		}
	}
}
