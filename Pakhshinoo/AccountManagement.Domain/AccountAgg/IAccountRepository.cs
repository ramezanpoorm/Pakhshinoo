
using _0_Framework.Domain;
using AccountManagement.Application.Contract.Account;
using System.Collections.Generic;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<long, Account>
    {
        Account GetBy(string username);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        EditAccount GetDeatails(long id);
        List<AccountViewModel> GetAccounts();
    }
}
