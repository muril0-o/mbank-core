using Infrastructure.Data;
using Model.Base;
using Model.Enum;
using MySqlConnector;
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
        var accountNumber = GenerateUniqueAccountNumber();

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

    public void TransferFunds(decimal transferValue, string fromAccountNumber, string toAccountNumber)
    {  
        using (var transaction =  _context.Database.BeginTransaction())
        {
            try
            {
                var fromAccount = _context.Account.FirstOrDefault(x => x.TxtNumber == fromAccountNumber);
                
                var toAccount = _context.Account.FirstOrDefault(x => x.TxtNumber == toAccountNumber);
                
                if(fromAccount is null || toAccount is null) 
                {
                    throw new Exception($"One or both the accounts do not exist.");
                }

                if(fromAccount.DecBalance < transferValue)
                { 
                    throw new Exception("Source account do not have enough funds");
                }
                
                fromAccount.DecBalance -= transferValue;
                toAccount.DecBalance += transferValue;

                _context.SaveChanges();
                transaction.Commit();
            }

            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception ($"Tranfer failed: {ex.Message}");
            }
        }
    }
}