
using System;
using System.Collections.Generic;
using System.Text;
using DapperExt;
using DapperTemplate.Model;

namespace DapperTemplate.Dao
{
    public class UserDao
    {
        //

        public int Add(User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [User](");
            strSql.Append("Username,PasswordHash,Email,PhoneNumber,IsFirstTimeLogin,AccessFailedCount,CreationDate,IsActive)");
            strSql.Append(" values (");
            strSql.Append("@Username,@PasswordHash,@Email,@PhoneNumber,@IsFirstTimeLogin,@AccessFailedCount,@CreationDate,@IsActive)");
            //
            var id = DbHelperSql.InsertReturnId(strSql.ToString(), model);
            return id;
        }
        //

        public bool DeleteById(Int32 userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [User] ");
            strSql.Append("where  UserId=@userId  ");
            //
            var flag = DbHelperSql.Delete(strSql.ToString(), new User { UserId = userId });
            return flag;
        }
        //

        public bool UpdateById(User model, Int32 userId)
        {
            model.UserId = userId;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [User] set ");
            if (model.@Username != null)
                strSql.Append("Username=@Username,");
            if (model.@PasswordHash != null)
                strSql.Append("PasswordHash=@PasswordHash,");
            if (model.@Email != null)
                strSql.Append("Email=@Email,");
            if (model.@PhoneNumber != null)
                strSql.Append("PhoneNumber=@PhoneNumber,");
            if (model.@IsFirstTimeLogin != null)
                strSql.Append("IsFirstTimeLogin=@IsFirstTimeLogin,");
            if (model.@AccessFailedCount != null)
                strSql.Append("AccessFailedCount=@AccessFailedCount,");
            if (model.@CreationDate != null)
                strSql.Append("CreationDate=@CreationDate,");
            if (model.@IsActive != null)
                strSql.Append("IsActive=@IsActive,");
            int n = strSql.ToString().LastIndexOf(",", StringComparison.Ordinal);
            if (n > 0) strSql.Remove(n, 1);
            strSql.Append(" where  UserId=@userId  ");
            var flag = DbHelperSql.Update(strSql.ToString(), model);
            return flag;
        }
        //

        public User FindById(Int32 userId)
        {
            //Ä¬ÈÏtop 1--1Ìõ¼ÇÂ¼
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ");
            strSql.Append("userId,username,passwordHash,email,phoneNumber,isFirstTimeLogin,accessFailedCount,creationDate,isActive,lastTimestamp  ");
            strSql.Append("from [User] ");
            strSql.Append("where  UserId=@userId  ");
            //
            var result = DbHelperSql.Find(strSql.ToString(), new User { UserId = userId });
            return result;
        }
        //
        public IList<User> FindList(User whereModel, string where, int top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select top {0} ", top);
            strSql.Append("userId,username,passwordHash,email,phoneNumber,isFirstTimeLogin,accessFailedCount,creationDate,isActive,lastTimestamp  ");
            strSql.Append("from [User] ");
            strSql.AppendFormat("where 1=1 and {0} ", where);
            var result = DbHelperSql.FindList<User>
        (strSql.ToString(), whereModel);
            return result;
        }
        //
        public IList<User> FindListByPage(User whereModel, string where, string orderBy, int pageIndex, int pageSize)
        {
            var startIndex = pageIndex * pageSize;
            var size = pageSize;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append("userId,username,passwordHash,email,phoneNumber,isFirstTimeLogin,accessFailedCount,creationDate,isActive,lastTimestamp ");
            strSql.Append("from [User] ");
            strSql.AppendFormat("where 1=1 and {0} ", where);
            strSql.AppendFormat("ORDER BY {0} OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY", orderBy, startIndex, size);
            var result = DbHelperSql.FindList<User>(strSql.ToString(), whereModel);
            return result;
        }
        //
        public int Count(User whereModel, string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  count(*) from [User] ");
            strSql.AppendFormat("where 1=1 and {0} ", where);
            var result = DbHelperSql.Count(strSql.ToString(), whereModel);
            return result;
        }
        //
    }
}
