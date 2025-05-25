public class Solution {
    public string RankTeams(string[] votes) {

        int n = votes[0].Length;

        // Dictionary to hold each team's vote counts by position
        var teamRanks = new Dictionary<char, int[]>();

        // Initialize the rank arrays for each team
        foreach (char team in votes[0])
            teamRanks[team] = new int[n];

        // Count how many times each team got each position
        foreach (string vote in votes)
        {
            for (int i = 0; i < n; i++)
            {
                teamRanks[vote[i]][i]++;
            }
        }

        // Get the list of teams to sort
        var teams = teamRanks.Keys.ToList();

        // Sort teams by vote count descending on each position, then alphabetically
        teams.Sort((a, b) =>
        {
            for (int i = 0; i < n; i++)
            {
                if (teamRanks[a][i] != teamRanks[b][i])
                    return teamRanks[b][i] - teamRanks[a][i];  // More votes = higher rank
            }
            return a.CompareTo(b);  // Alphabetical if tie
        });

        // Return as a string
        return new string(teams.ToArray());
        
    }
}