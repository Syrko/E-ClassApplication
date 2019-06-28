using System;
using System.Collections.Generic;

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

		public string getRegNumString()
		{
			return type.ToString() + value.ToString();
		}

		public static int getNextValue(char type)
		{
			int id;
			{
				List<int> ids = new List<int>();

				// TODO
				// get ids from database

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
				return id;
			}
		}
	}
}
