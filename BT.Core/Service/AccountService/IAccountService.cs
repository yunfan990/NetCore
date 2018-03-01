using BT.Model;
using BT.Model.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using BT.Model.ViewModel;

namespace BT.Core.Service.AccountService
{
    public interface IAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        ServiceResult<AccountEntity> GetAccountByWhere(Expression<Func<QueryAccount, bool>> expression);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginEntity"></param>
        /// <returns></returns>
        ServiceResult<AccountEntity> UserLogin(AccountLoginEntity loginEntity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountEntity"></param>
        /// <returns></returns>
        ServiceResult<AccountEntity> UserRegister(AccountRegisterEntity accountRegisterEntity);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<AccountEntity> GetList();
    }
}
