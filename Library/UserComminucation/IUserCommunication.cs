namespace Library.UserComminucation;

public interface IUserCommunication
{
    void DisplayMenu();
    void ChoiceMenu();
    void DisplayBooks();
    void DisplayEmployees();
    void DisplayClients();
    void DisplayLibrarians();

    void DisplayMessage(string message);
    void DisplayError(string message);


}
