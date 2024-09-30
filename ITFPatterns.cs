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


    public class RoundScore
    {
        public decimal HongScore;
        public bool IsHongZero;
        public decimal ChongScore;
        public bool IsChongZero;

        public RoundScore()
        {
            ResetScores();
        }

        public decimal GetEffectiveHongScore()
        {
            if (IsHongZero) return 0M;
            else return HongScore;
        }

        public decimal GetEffectiveChongScore()
        {
            if (IsChongZero) return 0M;
            else return ChongScore;
        }

        public void Deduct(bool IsChong)
        {
            if (IsChong)
            {
                if (ChongScore == 0) return;
                else ChongScore -= 0.2M;
            }
            else
            {
                if (HongScore == 0) return;
                else HongScore -= 0.2M;
            }
        }


        public void UndoDeduct(bool IsChong)
        {
            if (IsChong)
            {
                if (ChongScore == 10) return;
                else ChongScore += 0.2M;
            }
            else
            {
                if (HongScore == 10) return;
                else HongScore += 0.2M;
            }
        }

        public void ResetScores()
        {
            HongScore = 10.0M;
            ChongScore = 10.0M;
            IsHongZero = false;
            IsChongZero = false;
        }
    }

    /// <summary>
    /// Stores the state of the scoring tool
    /// Designed to be persisted globally in the app, so that it survives tab changes
    /// See https://stackoverflow.com/questions/71713761/how-can-i-declare-a-global-variables-model-in-blazor?rq=3
    /// </summary>
    public class ScoreToolState
    {
        public RoundScore[] RoundScores = new RoundScore[2];

        public ScoreToolState()
        {
            RoundScores[0] = new RoundScore();
            RoundScores[1] = new RoundScore();
        }

        public decimal GetTotalHongScore()
        {
            return RoundScores[0].GetEffectiveHongScore() + RoundScores[1].GetEffectiveHongScore();
        }

        public decimal GetTotalChongScore()
        {
            return RoundScores[0].GetEffectiveChongScore() + RoundScores[1].GetEffectiveChongScore();
        }
    }

    public class PatternSelectorState
    {
        public string Rank = "1st Dan";
        public bool Saju = false;
        public bool AddTwoPatterns = false;

        public List<SelectedPattern> SelectedPatterns = new List<SelectedPattern>();
    }

}

