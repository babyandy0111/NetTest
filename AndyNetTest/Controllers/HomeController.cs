using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AndyNetTest.Models;
using AndyNetTest.DataAccess.Interface;
using Snai.Mysql.Entities;

namespace AndyNetTest.Controllers
{
    public class HomeController : Controller
    {
        private IUserDao UserDao;

        // 初始化dao
        public HomeController(IUserDao userDao)
        {
            UserDao = userDao;
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
            foreach (var s in users)
            {
                names += $"{s.Name} \r\n";
            }

            ViewData["Title"] = "Users";
            ViewData["Name"] = names;
            return View();
        }

        // https://localhost:5001/Home/Update?id=1&name=andywang
        // 另外因為...題目太多我就不多做linq 了, 但把sql寫出來
        // select id, name, address from users u left join user_info ui on u.id = ui.id where u.id = 1
        public string Update(int id, string name)
        {
            if (id <= 0)
            {
                return "id 不能小於0";
            }

            if (string.IsNullOrEmpty(name.Trim()))
            {
                return "姓名不能為空";
            }

            var User = new Users()
            {
                ID = id,
                Name = name
            };

            var result = UserDao.UpdateUser(User);

            if (result)
            {
                return "更新成功";
            }
            else
            {
                return "更新失敗";
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
