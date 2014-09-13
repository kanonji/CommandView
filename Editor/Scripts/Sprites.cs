using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace Kanonji.CommandView{
	public class Sprites : ICommandStrategy{

		Dictionary<string, string> sprites = new Dictionary<string, string> {
			{ "sprite", "New Sprite" },
		};

		public List<string> getCommand(){
			return sprites.Keys.ToList();
		}

		public void run(string command){
			createSprite (command);
		}

		protected void createSprite (string command) {
			string name = sprites [command];
			new GameObject (name).AddComponent<SpriteRenderer> ();
		}
	}
}