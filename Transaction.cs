struct Transaction
{
    public string AccountNumber { get; }
    public double Amount { get; }
    public Person Originator { get; }
    public DayTime Time { get; }

    public Transaction(string accountNumber, double amount, Person person)
    {
        AccountNumber = accountNumber;
        Amount = amount;
        Originator = person;
        Time = Utils.Time;
    }

    public override string ToString()
    {
        string transactionType = Amount >= 0 ? "Deposit" : "Withdraw";
        return $"Account Number: {AccountNumber}\n" +
               $"Person: {Originator.Name}\n" +
               $"Amount: {Amount}\n" +
               $"Time: {Time}\n" +
               $"Transaction Type: {transactionType}";
    }

}