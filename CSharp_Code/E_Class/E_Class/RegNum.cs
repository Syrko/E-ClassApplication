using System;
using System.Collections.Generic;

namespace E_Class
{
	public class RegNum
	{
		// Initializing counters from database
		private static Dictionary<char, int> regNumCounters = new Dictionary<char, int>()
		{
			{'S', 0 } // TODO add calls to database
		};

		private char type;
		private int yearID;
		private int ID;

		// Constructor
		public RegNum(char type)
		{
			this.type = type;
			this.yearID = int.Parse(DateTime.Today.Year.ToString().Substring(2));
			this.ID = regNumCounters[type]++;
		}

		public string getRegNumString()
		{
			return type.ToString() + yearID.ToString() + ID.ToString();
		}

	}
}
