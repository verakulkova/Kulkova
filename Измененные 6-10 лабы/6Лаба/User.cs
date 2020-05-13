using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace _6Лаба
{
    class User
    {
        public string Name { get; set; }
        public bool b1 { set; get; }
        string[] UserData = File.ReadAllLines("../../UserData.txt");
        string[] str1;
        public void GetName(string login, string password)
        { 
            b1 = false;
            for (int i = 0; i < UserData.Length; i++)
            {
                str1 = UserData[i].Split(' ');
                if (login == str1[0] && password == str1[1])
                {
                    Name = str1[2];
                    b1 = true;
                }
            }

            if (!b1)
                MessageBox.Show("Неверный логин или пароль");

        }
        public void ChangeData(string login, string pass, string Name)
        {
            StreamWriter str = new StreamWriter("../../UserData.txt");
            for (int i = 0; i < UserData.Length; i++)
            {
                str1 = UserData[i].Split(' ');
                if (str1[2] == Name)
                {
                    str1[0] = login;
                    str1[1] = pass;
                    UserData[i] = str1[0] + " " + str1[1] + " " + str1[2];
                }
                str.WriteLine(UserData[i]);
            }
            str.Close();
        }
    }
}