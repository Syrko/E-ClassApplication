using System;
using System.Collections.Generic;
using Types;

namespace E_Class
{
	public class RegNum
	{
		private char type;
		private int value;

		// Constructor
		public RegNum(char type, int value)
		{
			this.type = type;
			this.value = value;
		}

		public RegNum(string regNumString)
		{
			this.type = regNumString[0];
			this.value = int.Parse(regNumString.Substring(1));
		}

		public string getRegNumString()
		{
			return type.ToString() + value.ToString();
		}

		public static string getNextValue(string type)
		{
			int id;
			{
				List<int> ids = Database.GetIds(type + "s");

				ids.Sort();
				int counter = 0;
				while(true) {
					counter++;
					if(counter > ids.Count) {
						id = (ids[ids.Count - 1] + 1);
						break;
					}
					if (!(counter == ids[counter - 1])) {
						id = counter;
						break;
					}
				}
				
				switch (type)
				{
					case UserTypes.ADMIN:
						return "A" + id.ToString();
					case UserTypes.STUDENT:
						return "M" + id.ToString();
					case UserTypes.PROFESSOR:
						return "K" + id.ToString();
					case "Project":
						return "P" + id.ToString();
					default:
						return null;
				}
			}
		}
	}
}
