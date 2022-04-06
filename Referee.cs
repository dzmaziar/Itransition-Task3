using System.Reflection.Metadata;

namespace Task3
{

    public class Referee
    {
        private int CountOfSteps;

        public Referee(int Count)
        {
            CountOfSteps = Count;
        }

        public Result Solution(int human, int computer)
        {
            if (human == computer)
                return Result.DRAW;

            if ((computer > human && computer - human <= CountOfSteps / 2) ||
                (computer < human && human - computer > CountOfSteps / 2))
            {
                return Result.WON;
            }

            return Result.LOSE;
        }

    }
    public enum Result
    {
        WON,
        LOSE,
        DRAW
    }
}