namespace Bankapplication
{
    public interface IBankServices
    {
        void GetBankAccountByName();
        BankAccount CreateBankAccount(string name);
    }
}