using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace Kanonji.CommandView{
	public class Folder : ICommandStrategy{

		string[] commands = { "folder" };

		public List<string> getCommand(){
			return new List<string>(commands);
		}

		public void run(string[] commands){
            if (2 == commands.Length){
                createFolder (commands[0], commands[1]);
                return;
            }
			createFolder (commands[0]);
		}

		protected void createFolder (string command, string name = "CreatedFolder") {
			string guid = AssetDatabase.CreateFolder("Assets", name);
			string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
			if (String.IsNullOrEmpty (newFolderPath)) {
				Debug.Log ("TODO: something wrong");
			}
		}
	}
}