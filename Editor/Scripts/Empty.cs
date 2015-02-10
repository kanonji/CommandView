using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace Kanonji.CommandView {
	public class Empty : ICommandStrategy {

		string[] commands = { "empty" };

		public List<string> getCommand() {
			return new List<string>(commands);
		}

		public void run(string[] commands) {
			if (2 == commands.Length) {
				createEmptyGameObject(commands[0], commands[1]);
				return;
			}
			createEmptyGameObject(commands[0]);
		}

		protected void createEmptyGameObject(string command, string name = "GameObject") {
			new GameObject(name);
		}
	}
}