public static class Logger 
{
    private static List<string> loginEvents = new List<string>();
    private static List<string> transactionEvents = new List<string>();

    public static void LoginHandler(object sender, EventArgs args)
    {
        LoginEventArgs? loginEvent = args as LoginEventArgs;
        string data = $"{loginEvent?.PersonName} {(loginEvent.Success ? "successfully" : "unsuccessfully")} {Utils.Now}";
        loginEvents.Add(data);
    }
    public static void TransactionHandler(object sender, EventArgs args)
    {
        TransactionEventArgs? transactionEvent = args as TransactionEventArgs;
        string data = $"{transactionEvent?.PersonName} {(transactionEvent?.Amount > 0 ? "deposit" : "withdraw")} {transactionEvent?.Amount:c2} {(transactionEvent.Success ?  "successfully" : "unsuccessfully")} {Utils.Now}";
        transactionEvents.Add(data);
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
        foreach (string transactionEvent in transactionEvents)
        {
            Console.WriteLine($"{counter} {transactionEvent}");
            counter++;
        }
    }
}