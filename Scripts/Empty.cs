using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace Kanonji.CommandView{
	public class Empty : ICommandStrategy{

		string[] commands = { "empty" };

		public List<string> getCommand(){
			return new List<string>(commands);
		}

		public void run(string command){
			createEmptyGameObject (command);
		}

		protected void createEmptyGameObject (string command) {
			new GameObject ("GameObject");
		}
	}
}