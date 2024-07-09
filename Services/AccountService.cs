using Infrastructure.Data;
using Model.Base;
using Model.Enum;
using Services.Interfaces;

namespace Services;
public class AccountService : IAccount
{
    private readonly Context _context;

    public AccountService(Context context)
    {
        _context = context;
    }

    public string GenerateAccountNumber()
    {
        var random = new Random();
        int randomNumber = random.Next(1000, 9999);

        return $"{randomNumber}";
    }
    public string GenerateUniqueAccountNumber()
    {
        string accountNumber = GenerateAccountNumber();
        bool isUnique = false;

        do
        {
            isUnique = !_context.Account.Any(x => x.TxtNumber ==accountNumber);
        } while (!isUnique);

        return accountNumber;
    }
    public async Task CreateAccount(User user)
    {
        var accountNumber = GenerateAccountNumber();

        var account = new Account
        {
            TxtNumber = accountNumber,
            TxtType = AccountType.Corrente,
            DtOpened = DateTime.Now,
            TxtStatus = AccountStatus.Ativa,
        };

        _context.Account.Add(account);
        await _context.SaveChangesAsync(); 

        user.FkAccountId = account.Id;
        await _context.SaveChangesAsync();
    }
}