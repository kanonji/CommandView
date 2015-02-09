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

		public void run(string[] commands){
			createEmptyGameObject (commands[0]);
		}

		protected void createEmptyGameObject (string command) {
			new GameObject ("GameObject");
		}
	}
}