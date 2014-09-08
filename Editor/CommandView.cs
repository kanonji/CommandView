using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using Kanonji.CommandView;

public class CommandView : EditorWindow {

	string command = "";
	static List<ICommandStrategy> strategies = new List<ICommandStrategy>();

	[MenuItem ("MyMenus/CommandView")]
	public static void init () {
		EditorWindow.GetWindow<CommandView> (false, "Command View");
		if (0 == strategies.Count) {
			strategies.Add (new Primitives ());
			strategies.Add (new Lights ());
			strategies.Add (new Sprites ());
			strategies.Add (new Empty ());
			strategies.Add (new Folder ());
		}
	}

	public void OnGUI () {
		command = EditorGUILayout.TextField (command);
		if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return) {
			strategies.ForEach ((ICommandStrategy strategy) => {
				if(strategy.getCommand().Contains(command)){
					strategy.run(command);
				}
			});
			command = "";
		}
	}
}