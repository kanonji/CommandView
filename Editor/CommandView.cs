using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class CommandView : EditorWindow {

	string command = "";
	string[] primitives = { "sphere", "capsule", "cylinder", "cube", "plane", "quad" };
	Dictionary<string, LightData> lights = new Dictionary<string, LightData> {
		{ "directional", new LightData { Name = "Directional light", Type = LightType.Directional } },
		{ "point", new LightData { Name = "Point light", Type = LightType.Point } },
		{ "spot", new LightData { Name = "Spotlight", Type = LightType.Spot } },
		{ "area", new LightData { Name = "Area light", Type = LightType.Area } },
	};
	Dictionary<string, string> sprites = new Dictionary<string, string> {
		{ "sprite", "New Sprite" },
	};

	private class LightData {
		public string Name;
		public LightType Type;
	}

	[MenuItem ("MyMenus/CommandView")]
	public static void init () {
		EditorWindow.GetWindow<CommandView> (false, "Command View");
	}

	public void OnGUI () {
		command = EditorGUILayout.TextField (command);
		if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return) {
			if (-1 < ArrayUtility.IndexOf (primitives, command)) {
				createPrimitive (command);
			}
			if (lights.ContainsKey (command)) {
				createLight (command);
			}
			if (sprites.ContainsKey (command)) {
				createSprite (command);
			}
			if ("empty" == command) {
				new GameObject ("GameObject");
			}
			command = "";
		}
	}

	protected void createPrimitive (string command) {
		PrimitiveType? type = null;
		switch (command) {
		case "sphere":
			type = PrimitiveType.Sphere;
			break;
		case "capsule":
			type = PrimitiveType.Capsule;
			break;
		case "cylinder":
			type = PrimitiveType.Cylinder;
			break;
		case "cube":
			type = PrimitiveType.Cube;
			break;
		case "plane":
			type = PrimitiveType.Plane;
			break;
		case "quad":
			type = PrimitiveType.Quad;
			break;
		}
		if (type.HasValue) {
			GameObject.CreatePrimitive (type.Value);
		}
	}

	protected void createLight (string command) {
		LightData obj = lights [command];
		new GameObject (obj.Name).AddComponent<Light> ().light.type = obj.Type;
	}

	protected void createSprite (string command) {
		string name = sprites [command];
		new GameObject (name).AddComponent<SpriteRenderer> ();
	}
}