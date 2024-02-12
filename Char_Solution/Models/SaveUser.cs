using Char_Solution.Db_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Char_Solution.Models
{
    public class SaveUser
    {

        public void Save()
        {
            var user = new User();

            Console.WriteLine("Create Username");
            string Name = Console.ReadLine();
            Console.WriteLine("Create Password");
            string Password = Console.ReadLine();

            List<User> users = Data.GetReader();

            var find = users.Where(user => user.Name == Name);
            if( find is not null)
            {
                Console.WriteLine("qalesa");
            }
            else
            {
                user.Name ==

            }


        }




    }
}
