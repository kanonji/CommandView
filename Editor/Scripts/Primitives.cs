using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Kanonji.CommandView{
	public class Primitives : ICommandStrategy{

		string[] primitives = { "sphere", "capsule", "cylinder", "cube", "plane", "quad" };

		public List<string> getCommand(){
			return new List<string>(primitives);
		}

		public void run(string[] commands){
			createPrimitive (commands[0]);
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
	}
}