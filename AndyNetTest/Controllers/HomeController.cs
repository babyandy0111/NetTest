using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AndyNetTest.Models;
using AndyNetTest.DataAccess.Interface;
using AndyNetTest.Entities.Users;
using AndyNetTest.Entities.UserInfo;

namespace AndyNetTest.Controllers
{
    public class HomeController : Controller
    {
        private IUserDao UserDao;
        private IUserInfoDao UserInfoDao;

        // 初始化dao
        public HomeController(IUserDao userDao, IUserInfoDao userinfoDao)
        {
            UserDao = userDao;
            UserInfoDao = userinfoDao;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Index";
            return View();
        }

        // 直接用專案產生出的路由去改
        // 這邊只有撈出資料
        // CRUD可參考 entitles 和 interface的部分看dao&struct
        // 因為我這邊適用mac的環境, 所以沒有mssql, 我連的是mysql, mysql使用docker用的
         
        public IActionResult Privacy()
        {
            var users = UserDao.GetUsers();
            var names = "";
            var address = "";
            var id = 0;
            foreach (var s in users)
            {
                id = s.ID;
                names = s.Name;
                address = s.Address;
            }

            ViewData["Title"] = "Users";
            ViewData["Name"] = names;
            ViewData["Address"] = address;
            ViewData["Data"] = users;
            return View();
        }

        // https://localhost:5001/Home/Update?id=1&name=andywang
        // 另外因為...題目太多我就不多做linq 了, 但把sql寫出來
        // select id, name, address from users u left join user_info ui on u.id = ui.id where u.id = 1
        public string Update(int id, string name, string address)
        {
            if (id <= 0)
            {
                return "id 不能小於0";
            }

            if (string.IsNullOrEmpty(name.Trim()))
            {
                return "name不能為空";
            }

            if (string.IsNullOrEmpty(address.Trim()))
            {
                return "address不能為空";
            }

            var User = new Users()
            {
                ID = id,
                Name = name
            };

            UserInfo UserInfo = new UserInfo
            {
                ID = id,
                Address = address
            };

            var result1 = UserDao.UpdateUser(User);
            var result2 = UserInfoDao.UpdateUserInfo(UserInfo);

            if (result1 && result2)
            {
                return "更新成功";
            }
            else
            {
                return "更新失敗";
            }
        }

        public string AjaxCreateUser(string name, string address) {

            if (string.IsNullOrEmpty(name.Trim()))
            {
                return "name不能為空";
            }

            if (string.IsNullOrEmpty(address.Trim()))
            {
                return "address不能為空";
            }


            Users User = new Users
            {
                Name = name
            };

            UserInfo UserInfo = new UserInfo
            {
                Address = address
            };

            // 這邊其實不該這樣寫, 要一次更新
            var result1 = UserDao.CreateUser(User);
            var result2 = UserInfoDao.CreateUserInfo(UserInfo);

            if (result1 && result2)
            {
                return "成功";
            }
            else
            {
                return "失敗";
            }
        }

        // 弄出一個ajax 路由
        public string Ajax()
        {
            var users = UserDao.GetUsers();
            var names = "";
            foreach (var s in users)
            {
                names += $"{s.Name} \r\n";
            }

            return names;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
