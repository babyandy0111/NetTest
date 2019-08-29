using System;
using System.Collections.Generic;
using AndyNetTest.Entities.UserInfo;

namespace AndyNetTest.DataAccess.Interface
{
    public interface IUserInfoDao
    {
        //插入資料
        bool CreateUserInfo(UserInfo user);

        //取全部記錄
        IEnumerable<UserInfo> GetUserInfos();

        //取某id記錄
        UserInfo GetUserInfoByID(int id);

        //根據id更新整條記錄
        bool UpdateUserInfo(UserInfo user);

        //根據id更新名稱
        bool UpdateAddressByID(int id, string name);

        //根據id刪掉記錄
        bool DeleteUserInfoByID(int id);
    }
}
