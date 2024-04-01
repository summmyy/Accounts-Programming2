class Person
{
    private string Password;
    public event EventHandler OnLogin;

    public string SIN { get; private set; }
    public string Name { get; private set; }
    public bool IsAuthenticated { get; private set; }

    public Person(string name, string sin)
    {
        Name = name;
        SIN = sin;
        Password = sin.Substring(0, 3);
    }
    public void Login(string password)
    {
        if (password != Password)
        {
            IsAuthenticated = false;
            OnLogin?.Invoke(this, new LoginEventArgs(Name, false));
            throw new AccountException(ExceptionType.PASSWORD_INCORRECT);
        }
        else
        {
            IsAuthenticated = true;
            OnLogin?.Invoke(this, new LoginEventArgs(Name, true));
        }
    }
    public void Logout()
    {
        IsAuthenticated = false;
    }
    public override string ToString()
    {
        return $"{Name} - Authenticated: {IsAuthenticated}";
    }
}

    