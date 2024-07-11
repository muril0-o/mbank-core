using Model.Base;

namespace Services.Interfaces;

public interface IAccount
{
    string GenerateUniqueAccountNumber();
}