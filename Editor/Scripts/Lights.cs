using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace Kanonji.CommandView{
	public class Lights : ICommandStrategy {

		Dictionary<string, LightData> lights = new Dictionary<string, LightData> {
			{ "directional", new LightData { Name = "Directional light", Type = LightType.Directional } },
			{ "point", new LightData { Name = "Point light", Type = LightType.Point } },
			{ "spot", new LightData { Name = "Spotlight", Type = LightType.Spot } },
			{ "area", new LightData { Name = "Area light", Type = LightType.Area } },
		};

		private class LightData {
			public string Name;
			public LightType Type;
		}

		public List<string> getCommand(){
			return lights.Keys.ToList();
		}

		public void run(string[] commands){
			createLight (commands[0]);
		}

		protected void createLight (string command) {
			LightData obj = lights [command];
			new GameObject (obj.Name).AddComponent<Light> ().light.type = obj.Type;
		}
	}
}