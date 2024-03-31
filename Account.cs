public abstract class Account
{
    protected readonly List<Person> users;
    public readonly List<Transaction> transactions;
    private static int LAST_NUMBER = 100000;

    public double Balance { get; protected set;}
    public double LowestBalance { get; protected set;}
    public string Number { get; }

    public virtual event EventHandler<EventArgs> OnTransaction;

    public Account(string type, double balance){
        Number = type + LAST_NUMBER;
        LAST_NUMBER++;
        Balance = balance;
        LowestBalance = balance;
        transactions = new List<Transaction>();
        users = new List<Person>();
    }

    public void Deposit(double amount, Person person){
        Balance += amount;
        LowestBalance = Balance > LowestBalance ? LowestBalance : Balance;
        Transaction transaction = new Transaction(Number, amount, person);
        transactions.Add(transaction);
    }
    public void AddUser(Person person){
        users.Add(person);
    }
    public bool IsUser(string name){
        var userExist = from user in users where user.Name == name select user;
        foreach (var user in userExist)
        {
            if(user.Name == name)
            {
                return true;
            }
        }
        return false;
        /* bool userExist = users.Exists(user => user.Name == name);
        if(userExist){
            return true;
        }
        return false; */
    }
    public abstract void PrepareMonthlyReport();
    public virtual void OnTransactionOccur(object sender, EventArgs args){
        OnTransaction?.Invoke(sender, args);
    }
    public override string ToString()
    {
        return  $"{Number}, {string.Join(", ", users)} {Balance:c2} - transactions ({transactions.Count}) \n  {string.Join(" \n  ", transactions)}";
    }
}