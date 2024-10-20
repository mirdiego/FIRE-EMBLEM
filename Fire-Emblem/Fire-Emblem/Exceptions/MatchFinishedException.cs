using Fire_Emblem_View;

namespace Fire_Emblem.Exceptions;

public class MatchFinishedException : ApplicationException
{
    public MatchFinishedException(string message, View view) : base(message)
    {
        view.WriteLine(message);
    }
}