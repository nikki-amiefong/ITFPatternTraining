namespace ITFPatternTraining
{
	public class ITFPatterns
	{
		public static readonly string[] colourBeltPatterns = {
			"Saju-Jirigi",
			"Saji-Maki",
			"Chon-Ji",
			"Dan-Gun",
			"Do-San",
			"Won-Hyo",
			"Joong-Gun",
			"Toi-Gye",
			"Hwa-rang",
			"Choong-Moo"
		};

		public static readonly string[] Dan1Patterns = {
			"Kwang-Gae",
			"Po-Eun",
			"Ge-Baek"
		};

		public static readonly string[] Dan2Patterns = {
			"Eui-Am",
			"Choong-Jang",
			"Juche"
		};

		public static readonly string[] Dan3Patterns = {
			"Sam-Il",
			"Yoo-Sin",
			"Choi-Yong"
		};

		public static readonly string[] Dan4Patterns = {
			 "Yon-Gae",
			"Ul-Ji",
			"Moon-Moo"
		};

		public static readonly string[] Dan5Patterns = {
			"So-San",
			"Se-Jong"
		};

		public static readonly string[] Dan6Patterns = {
			"Tong-Il"
		};


		public static readonly string[] ranks = {
			"1st Dan",
			"2nd Dan",
			"3rd Dan",
			"4th Dan",
			"5th Dan",
			"6th Dan"
		};


		/// <summary>
		/// Get the combined list of patterns that can be selected for a given rank
		/// </summary>
		/// <param name="rank">The dan number of the competitor - i.e. 1 for 1st Dan, 2 for 2nd Dan...</param>
		/// <returns>List of patterns (named as strings) that could be selected for that rank</returns>
		public static List<string> GetPatternsList(int rank)
		{
			var possiblePatterns = new List<string>();
			possiblePatterns.AddRange(colourBeltPatterns);

			if (rank >= 1) possiblePatterns.AddRange(Dan1Patterns);
			if (rank >= 2) possiblePatterns.AddRange(Dan2Patterns);
			if (rank >= 3) possiblePatterns.AddRange(Dan3Patterns);
			if (rank >= 4) possiblePatterns.AddRange(Dan4Patterns);
			if (rank >= 5) possiblePatterns.AddRange(Dan5Patterns);
			if (rank >= 6) possiblePatterns.AddRange(Dan6Patterns);

			return possiblePatterns;
		}

		public static List<string> GetRankPatterns(int rank)
		{
			var possiblePatterns = new List<string>();
			if (rank == 1) possiblePatterns.AddRange(Dan1Patterns);
			if (rank == 2) possiblePatterns.AddRange(Dan2Patterns);
			if (rank == 3) possiblePatterns.AddRange(Dan3Patterns);
			if (rank == 4) possiblePatterns.AddRange(Dan4Patterns);
			if (rank == 5) possiblePatterns.AddRange(Dan5Patterns);
			if (rank == 6) possiblePatterns.AddRange(Dan6Patterns);

			return possiblePatterns;
		}
	}

    public struct SelectedPattern
    {
        public string Label { get; set; }
        public string Pattern { get; set; }
    }

}
