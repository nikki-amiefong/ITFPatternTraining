namespace ITFPatternTraining
{

    public class SparringRoundScore
    {
        public decimal HongScore;
        public int HongWarnings;
        public decimal ChongScore;
        public int ChongWarnings;

        public SparringRoundScore()
        {
            ResetScores();
        }

        public decimal GetEffectiveHongScore()
        {
            return HongScore - (int)float.Floor(HongWarnings / 3.0f);
        }

        public decimal GetEffectiveChongScore()
        {
            return ChongScore - (int)float.Floor(ChongWarnings / 3.0f);
        }

        public void AddWarning(bool IsChong)
        {
            if (IsChong)
            {
                ChongWarnings++;
            }
            else
            {
                HongWarnings++;
            }
        }


        public void UndoWarning(bool IsChong)
        {
            if (IsChong)
            {
                ChongWarnings--;
            }
            else
            {
                HongWarnings--;
            }
        }

        public void ResetScores()
        {
            HongScore = 0M;
            ChongScore = 0M;
            HongWarnings = 0;
            ChongWarnings = 0;
        }
    }

    /// <summary>
    /// Stores the state of the sparring scoring tool
    /// Designed to be persisted globally in the app, so that it survives tab changes
    /// See https://stackoverflow.com/questions/71713761/how-can-i-declare-a-global-variables-model-in-blazor?rq=3
    /// 
    /// This sparring tool doesn't account for rounds separately but can remember a previous ones! This allows for infinite undo's
    /// </summary>
    public class SparringScoreToolState
    {
        public Stack<SparringRoundScore> Rounds = new Stack<SparringRoundScore>();

        public SparringScoreToolState()
        {
            Rounds.Push(new SparringRoundScore());
        }

        public decimal GetHongScore()
        {
            return Rounds.Peek().GetEffectiveHongScore();
        }

        public decimal GetChongScore()
        {
            return Rounds.Peek().GetEffectiveChongScore();
        }

        public void GetLastRound()
        {
            if (Rounds.Count > 1)
                Rounds.Pop();
        }

        public void NewRound()
        {
            Rounds.Push(new SparringRoundScore());
        }
    }

}
