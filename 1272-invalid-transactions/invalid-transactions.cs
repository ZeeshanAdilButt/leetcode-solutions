
public class Solution {
    // Define a Transaction class to store transaction details
    class Transaction {
        public string Name { get; set; }
        public int Time { get; set; }
        public int Amount { get; set; }
        public string City { get; set; }

        // Constructor to parse the transaction string
        public Transaction(string line) {
            var split = line.Split(',');
            Name = split[0];
            Time = int.Parse(split[1]);
            Amount = int.Parse(split[2]);
            City = split[3];
        }
    }

    // Method to find invalid transactions
    public IList<string> InvalidTransactions(string[] transactions) {
        var invalid = new List<string>();
        var map = new Dictionary<string, List<Transaction>>();

        // Parse and store transactions in a map using 'name' as key
        foreach (var transaction in transactions) {
            var t = new Transaction(transaction);
            if (!map.ContainsKey(t.Name)) {
                map[t.Name] = new List<Transaction>();
            }
            map[t.Name].Add(t);
        }

        // Check each transaction for validity
        foreach (var transaction in transactions) {
            var t = new Transaction(transaction);
            if (!IsValid(t, map[t.Name])) {
                invalid.Add(transaction);
            }
        }

        return invalid;
    }

    // Method to check if a transaction is valid
    bool IsValid(Transaction t, List<Transaction> list) {
        if (t.Amount > 1000) {
            return false;
        }

        foreach (var ta in list) {
            if (Math.Abs(ta.Time - t.Time) <= 60 && !ta.City.Equals(t.City)) {
                return false;
            }
        }

        return true;
    }
}
