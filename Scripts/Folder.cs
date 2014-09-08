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

		public void run(string command){
			createFolder (command);
		}

		protected void createFolder (string command) {
			string guid = AssetDatabase.CreateFolder("Assets", "CreatedFolder");
			string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
			if (String.IsNullOrEmpty (newFolderPath)) {
				Debug.Log ("TODO: something wrong");
			}
		}
	}
}