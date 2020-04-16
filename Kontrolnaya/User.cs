using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kontrolnaya
{
    class User
    {
        public string Name { get; set; }
        public bool b1 { set; get; }
        string[] Adm = File.ReadAllLines("../../Adm.txt");
        string[] s1;
        public void GetName(string login, string pass)
        {
            b1 = false;
            for (int i = 0; i < Adm.Length; i++)
            {
                s1 = Adm[i].Split(' ');
                if (login == s1[0] && pass == s1[1])
                {
                    Name = s1[2];
                    b1 = true;
                }

               
            }
           // if (!b1)
              //  MessageBox.Show("Неверный логин или пароль");


        }
        public void ChangeData(string login, string pass, string Name)
        {
            StreamWriter str = new StreamWriter("../../Adm.txt");
            for (int i = 0; i < Adm.Length; i++)
            {
                s1 = Adm[i].Split(' ');
                if (s1[2] == Name)
                {
                    s1[0] = login;
                    s1[1] = pass;
                    Adm[i] = s1[0] + " " + s1[1] + " " + s1[2];
                }
                str.WriteLine(Adm[i]);
            }
            str.Close();
        }
    }
}
