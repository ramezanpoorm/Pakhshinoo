
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.Account
{
    public interface IAccountApplication
    {
        OpretaionResult Create(CreateAccount command);
        OpretaionResult Edit(EditAccount command);
        OpretaionResult ChangePassword(ChangePassword command);
        OperationResult Login(Login command);
        void Logout();
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        EditAccount GetDeatails(long id);
    }
}
