using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace Kanonji.CommandView {
	public class Sprites : ICommandStrategy {

		Dictionary<string, string> sprites = new Dictionary<string, string> {
			{ "sprite", "New Sprite" },
		};

		public List<string> getCommand() {
			return sprites.Keys.ToList();
		}

		public void run(string[] commands) {
			if (2 == commands.Length) {
				createSprite(commands[0], commands[1]);
				return;
			}
			createSprite(commands[0]);
		}

		protected void createSprite(string command, string name = null) {
			if (string.IsNullOrEmpty(name)) {
				name = sprites[command];
			}
			new GameObject(name).AddComponent<SpriteRenderer>();
		}
	}
}