public class CheckingAccount : Account, ITransaction
{
    private static double COST_PER_TRANSACTION = 0.05;
    private static double INTEREST_RATE = 0.005;
    private bool hasOverdraft;

    public CheckingAccount(double balance = 0, bool hasOverdraft = false):base(Utils.ACCOUNT_TYPES[AccountType.Checking], balance)
    {
        this.hasOverdraft = hasOverdraft;
    }

    public new void Deposit(double amount, Person person)
    {
        base.Deposit(amount, person);
        base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
    }
    public void Withdraw(double amount, Person person)
    {
        if(!IsUser(person.Name)){
            base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException(ExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
        }
        if(!person.IsAuthenticated){
            base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException(ExceptionType.USER_NOT_LOGGED_IN);
        }
        if(amount > Balance && !hasOverdraft){
            base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException(ExceptionType.NO_OVERDRAFT);
        }
        base.OnTransactionOccur(this, new TransactionEventArgs(person.Name, amount, true));
        base.Deposit(-amount, person);
    }
    public override void PrepareMonthlyReport()
    {
        double serviceCharge = transactions.Count * COST_PER_TRANSACTION;
        double interest = LowestBalance * INTEREST_RATE;
        Balance += interest - serviceCharge;
        transactions.Clear(); 
    }
}