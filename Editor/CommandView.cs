using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using Kanonji.CommandView;

public class CommandView : EditorWindow {

	string command = "";
	static List<ICommandStrategy> strategies = new List<ICommandStrategy>();

	[MenuItem ("MyMenus/CommandView")]
	public static void Init () {
		EditorWindow.GetWindow<CommandView> (false, "Command View");
		if (0 == strategies.Count) {
			InitCommand ();
		}
	}

	public void OnGUI () {
		if (0 == strategies.Count) {
			InitCommand ();
		}
		command = EditorGUILayout.TextField (command);
		if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return) {
            string[] parsedCommand = ParseCommand(command);
			strategies.ForEach ((ICommandStrategy strategy) => {
				if(strategy.getCommand().Contains(parsedCommand[0])){
					strategy.run(parsedCommand);
				}
			});
			command = "";
		}
	}

	private static void InitCommand(){
		strategies.Clear ();
		strategies.Add (new Primitives ());
		strategies.Add (new Lights ());
		strategies.Add (new Sprites ());
		strategies.Add (new Empty ());
		strategies.Add (new Folder ());
	}

    private string[] ParseCommand(string command) {
        return command.Split(' ');
    }
}