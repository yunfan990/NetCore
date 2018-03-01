using System;
using System.Collections.Generic;
using System.Text;

namespace BT.Common
{
    public class EncryptPwd
    {
        /// <summary>
        /// 加盐最少6位
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static string AddSaltPwd(ref string salt, string pwd)
        {
            var newPwd = "";
            if (salt.Length > 6)
            {
                var RanNum = new Random().Next(0, 6);
                var salt1 = salt.Substring(0, RanNum);
                var salt2 = salt.Substring(RanNum, salt.Length - RanNum);
                newPwd = MySecurity.SEncryptString(MySecurity.MD5(string.Format("{0}{1}{2}", salt1, pwd, salt2)), "").ToLower();
                newPwd = newPwd.Substring(RanNum, (newPwd.Length - RanNum) / 2);
                salt = string.Format("{0}{1}", salt, RanNum);
            }
            else
            {
                newPwd = MySecurity.SEncryptString(MySecurity.MD5(string.Format("{0}{1}", salt, pwd)), "").ToLower();
                newPwd = newPwd.Substring(2, (newPwd.Length - 2) / 2);
            }

            return newPwd;
        }

        /// <summary>
        /// 验证密码是否正确
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="pwd"></param>
        /// <param name="oldPwd"></param>
        /// <returns></returns>
        public static bool CheckSaltPwd(string salt, string pwd, string oldPwd)
        {
            var newPwd = "";
            if (salt.Length > 6)
            {
                var len = int.Parse(salt.Substring(salt.Length - 1, 1) ?? "0");
                var salt1 = salt.Substring(0, len);
                var salt2 = salt.Substring(len, salt.Length - len - 1);
                newPwd = MySecurity.SEncryptString(MySecurity.MD5(string.Format("{0}{1}{2}", salt1, pwd, salt2)), "").ToLower();
                newPwd = newPwd.Substring(len, (newPwd.Length - len) / 2);
            }
            else
            {
                newPwd = MySecurity.SEncryptString(MySecurity.MD5(string.Format("{0}{1}", salt, pwd)), "").ToLower();
                newPwd = newPwd.Substring(2, (newPwd.Length - 2) / 2);
            }
            if (newPwd == oldPwd)
            {
                return true;
            }
            return false;
        }
    }
}
