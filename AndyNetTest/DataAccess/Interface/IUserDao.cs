﻿using System.Collections.Generic;
using AndyNetTest.Entities.Users;
using AndyNetTest.Entities.UsersAndInfo;

namespace AndyNetTest.DataAccess.Interface
{
    public interface IUserDao
    {
        //插入資料
        bool CreateUser(Users user);

        //取全部記錄
        IEnumerable<UsersAndInfo> GetUsers();

        //取某id記錄
        Users GetUserByID(int id);

        //根據id更新整條記錄
        bool UpdateUser(Users user);

        //根據id更新名稱
        bool UpdateNameByID(int id, string name);

        //根據id刪掉記錄
        bool DeleteUserByID(int id);
    }
}
