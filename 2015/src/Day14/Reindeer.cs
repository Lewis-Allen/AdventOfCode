namespace Day14;

public record Reindeer(string Name, int Speed, int Stamina, int RestTime)
{
    public int Points { get; set; } = 0;
    public int CurrentTime { get; set; } = 0;
    public int DistanceTravelled { get; set; } = 0;

    public int Travel(int seconds)
    {
        var secondsSinceLastRest = CurrentTime % (Stamina + RestTime);
        if(secondsSinceLastRest < Stamina)
        {
            var travelTime = Math.Min(seconds, Stamina - secondsSinceLastRest);
            DistanceTravelled += Speed * travelTime;
        }

        CurrentTime += seconds;

        return DistanceTravelled;
    }


    public int GetDistanceTravelledAfterSecondsFromStart(int seconds)
    {
        int currentTime = 0;
        int distanceTravelled = 0;

        while(currentTime < seconds)
        {
            var secondsRemaining = seconds - currentTime;
            var travelTime = Math.Min(Stamina, secondsRemaining);

            distanceTravelled += Speed * travelTime;

            currentTime += travelTime + RestTime;
        }

        return distanceTravelled;
    }
}