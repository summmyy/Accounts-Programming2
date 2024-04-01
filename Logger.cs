public static class Logger
{
   private static List<string> loginEvents;
    private static List<string> TransactionEvents;

    public static void LoginHandler(object sender, EventArgs args)
    {
        LoginEventArgs loginArgs = args as LoginEventArgs;
        if (loginArgs != null)
        {
            string logMessage = $"{loginArgs.PersonName} - {loginArgs.Success} - {Utils.Now}";
            loginEvents.Add(logMessage);
        }
    }

    public static void TransactionHandler(object sender, EventArgs args)
    {
        TransactionEventArgs transactionArgs = args as TransactionEventArgs;
        if (transactionArgs != null)
        {
            string logMessage = $"{transactionArgs.PersonName} - {transactionArgs.Amount} - {transactionArgs.Operation} - {transactionArgs.Success} - {Utils.Now}";
            TransactionEvents.Add(logMessage);
        }
    }

    public static void ShowLoginEvents()
    {
        Console.WriteLine(Utils.Now);
        for (int i = 0; i < loginEvents.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {loginEvents[i]}");
        }
    }

    public static void ShowTransactionEvents()
    {
        Console.WriteLine(Utils.Now);
        for (int i = 0; i < TransactionEvents.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {TransactionEvents[i]}");
        }
    }

    

}