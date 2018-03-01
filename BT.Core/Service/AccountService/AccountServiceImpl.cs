using AutoMapper;
using BT.Common;
using BT.Core.Filter;
using BT.Core.Repository.DbModel;
using BT.Model;
using BT.Model.ViewModel.Account;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BT.Core.Service.AccountService
{
    public class AccountServiceImpl : IAccountService
    {
        #region 构造函数注入

        protected InterfaceBaseService<Account> BaseService;

        protected IMapper MapperService;
        //log4net
        ILog Logger = log4net.LogManager.GetLogger(GlobalConfig.Log4netRepositoryName, typeof(HttpGlobalExceptionFilter));
        public AccountServiceImpl(InterfaceBaseService<Account> _baseService, IMapper _mapper)
        {
            BaseService = _baseService;
            MapperService = _mapper;
        }

        #endregion

        public ServiceResult<AccountEntity> GetAccountByWhere(Expression<Func<QueryAccount, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<AccountEntity> GetList()
        {
            //BaseService.FindListAsync


            throw new NotImplementedException();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginEntity"></param>
        /// <returns></returns>
        public ServiceResult<AccountEntity> UserLogin(AccountLoginEntity loginEntity)
        {
            var result = new ServiceResult<AccountEntity>();
            if (string.IsNullOrEmpty(loginEntity.UserName))
            {
                result.ErrorMessage = "账号为空";
                return result;
            }

            if (string.IsNullOrEmpty(loginEntity.Password))
            {
                result.ErrorMessage = "密码为空";
                return result;
            }

            if (loginEntity.Password.Length < 6 || loginEntity.Password.Length > 12)
            {
                result.ErrorMessage = "密码长度有误，请输入6-12位密码";
                return result;
            }
            try
            {
                var model = BaseService.FindNoTracking(x => x.UserName == loginEntity.UserName);
                if (model != null)
                {
                    if (!EncryptPwd.CheckSaltPwd(model.Salt, loginEntity.Password, model.Password))
                    {
                        result.ErrorMessage = "用户名或密码有误";
                        return result;
                    }
                    result.Result = MapperService.Map<AccountEntity>(model);
                    result.Success = true;
                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("异常：{0}", ex);
            }
            result.ErrorMessage = "用户名或密码有误";
            return result;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="accountRegisterEntity"></param>
        /// <returns></returns>
        public ServiceResult<AccountEntity> UserRegister(AccountRegisterEntity accountRegisterEntity)
        {
            var result = new ServiceResult<AccountEntity>();
            if (string.IsNullOrEmpty(accountRegisterEntity.UserName))
            {
                result.ErrorMessage = "账号为空";
                return result;
            }

            if (string.IsNullOrEmpty(accountRegisterEntity.Password))
            {
                result.ErrorMessage = "密码为空";
                return result;
            }

            if (accountRegisterEntity.Password.Length < 6 || accountRegisterEntity.Password.Length > 12)
            {
                result.ErrorMessage = "密码长度有误，请输入6-12位字符";
                return result;
            }
            //至少六位，加密更严谨
            var saltPwd = new Random().Next(3333333, 66666666).ToString();
            //获取加密后的密码
            accountRegisterEntity.Password = EncryptPwd.AddSaltPwd(ref saltPwd, accountRegisterEntity.Password);
            accountRegisterEntity.Salt = saltPwd;
            var model = MapperService.Map<Account>(accountRegisterEntity);
            try
            {
                BaseService.Add(model);
            }
            catch (Exception ex)
            {
                result.ErrorMessage = "注册失败，请稍后重试";
                return result;
            }
            result.ErrorMessage = "注册成功";
            return result;
        }
    }
}
