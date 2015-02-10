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
            if (2 == commands.Length){
                createLight (commands[0], commands[1]);
                return;
            }
			createLight (commands[0]);
		}

		protected void createLight (string command, string name = null) {
			LightData obj = lights [command];
            Debug.Log(string.IsNullOrEmpty(name));
            if (string.IsNullOrEmpty(name)) {
                name = obj.Name;
            }
			new GameObject (name).AddComponent<Light> ().light.type = obj.Type;
		}
	}
}