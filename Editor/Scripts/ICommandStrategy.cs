using System.Collections.Generic;

namespace Kanonji.CommandView{
	interface ICommandStrategy {

		 List<string> getCommand ();

		void run (string[] commands);
	}
}