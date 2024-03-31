public class LoginEventArgs : EventArgs {
    public string PersonName { get; }
    public bool Success { get; }
    public LoginEventArgs(string name, bool success) : base() {
        PersonName = name;
        Success = success;
    }
}