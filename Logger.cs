public static class Logger
{
   private static List<string> loginEvents = new List<string>();
    private static List<string> TransactionEvents = new List<string>();

    public static void LoginHandler(object sender, EventArgs args)
    {
        LoginEventArgs loginArgs = args as LoginEventArgs;
        if(loginArgs != null)
        {
            string logMessage = $"{loginArgs.PersonName} {(loginArgs.Success ? "successfully" : "unsuccessfully")} {Utils.Now}";
            loginEvents.Add(logMessage);
        }
        
    }

    public static void TransactionHandler(object sender, EventArgs args)
    {
        TransactionEventArgs transactionArgs = args as TransactionEventArgs;
        if (transactionArgs != null)
        {
            string logMessage = $"{transactionArgs.PersonName} {(transactionArgs.Amount>0 ? "deposit": "withdraw")} {transactionArgs.Amount:c2} {(transactionArgs.Success ? "successfully" : "unsuccessfully")} {Utils.Now}";
            TransactionEvents.Add(logMessage);
        }
    }

    public static void ShowLoginEvents()
    {
        int counter = 1;
        Console.WriteLine($"Login events as of {Utils.Now}");
        foreach (string loginEvent in loginEvents)
        {
            Console.WriteLine($"{counter} {loginEvent}");
            counter++;
        }
    }

    public static void ShowTransactionEvents()
    {
        int counter = 1;
        Console.WriteLine($"\nTransaction events as of {Utils.Now}");
        foreach (string transactionEvent in TransactionEvents)
        {
            Console.WriteLine($"{counter} {transactionEvent}");
            counter++;
        }
    }

    

}