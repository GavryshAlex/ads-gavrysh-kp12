using System;
using static System.Console;
using System.Collections.Generic;

namespace Lab06
{
    
    class Logins
    {
        public string login;
        public string email;
        public Date dateOfBirth;
        public Logins() { }
        public Logins(string login, string email, Date dateOfBirth)
        {
            this.login = login;
            this.email = email;
            this.dateOfBirth = dateOfBirth;
        }
    }
    class AgeHashTable
    {
        private List<string>[] usersAndAge;
        public AgeHashTable()
        {
            usersAndAge = new List<string>[4];
            for (int i = 0; i < usersAndAge.Length; i++)
                usersAndAge[i] = new List<string>();
        }
        private int defineCategory(int age)
        {
            if (age <= 25)
                return 0;
            else if (age <= 35)
                return 1;
            else if (age <= 50)
                return 2;
            return 3;
        }

        public void insertUser(string username, int age)
        {
            usersAndAge[defineCategory(age)].Add(username);
        }
        public void removeUser(string username, int age)
        {
            usersAndAge[defineCategory(age)].Remove(username);
        }
        public void identifyAgeCategories()
        {
            string[] groupusernames = { "18-25:", "\n26-35:", "\n36-50:", "\n50+:" };
            for (int i = 0; i < groupusernames.Length; i++)
            {
                Write(groupusernames[i] + " ");
                WriteLine($"{Math.Round(usersAndAge[i].Count * 100.0 / (usersAndAge[0].Count + usersAndAge[1].Count + usersAndAge[2].Count + usersAndAge[3].Count), 1)}%");
                WriteLine("Users: " + String.Join(", ", usersAndAge[i]));
            }
        }
    }
    class hashTable
    {
        private string[] usernames;
        private Logins[] values;
        private string[] months;
        public int usersCount;
        public hashTable(int length, string[] months)
        {
            usernames = new string[length];
            values = new Logins[length];
            this.months = months;
            usersCount = 0;
        }
        public bool insertUser(string pass, string username)
        {
            int h = f(pass);
            int i = 1;
            while (usernames[h] != null && usernames[h] != username)
            {
                h = (h + 2 * i - 1) % usernames.Length;
                i++;
            }
            int h1 = f(username);
            i = 1;
            while (values[h1] == null || values[h1].login != username)
            {
                if (values[h1] == null || values[h1].login == null)
                {
                    usernames[h] = username;
                    return true;
                }
                h1 = (h1 + 2 * i - 1) % values.Length;
                i++;
            }
            WriteLine("User already exists");
            return false;
        }
        public void userInfo(string username, string email, Date dateOfBirth)
        {

            usersCount++;
            if (usersCount >= usernames.Length / 2)
                rehashing();
            int h = f(username);
            int i = 1;
            while (values[h] != null && values[h].email != null)
            {
                h = (h + 2 * i - 1) % values.Length;
                i++;
            }
            values[h] = new Logins(username, email, dateOfBirth);
            //Clear();
            //Show(h);
        }
        private int f(string x)
        {
            int index = 0;
            for (int i = 0; i < x.Length; i++)
            {
                index += ((int)x[i] - 31) * (int)Math.Pow(27, x.Length - i - 1);
                index = index % usernames.Length;
            }
            return index;
        }
        private void rehashing()
        {
            usernames = new string[usernames.Length * 2];
            values = new Logins[values.Length * 2];
        }
        public void tryToLogin(string pass, string username)
        {
            int h = f(pass);
            int i = 1;
            while (usernames[h] != username)
            {
                if (usernames[h] == null)
                {
                    WriteLine("Wrong login or password");
                    return;
                }
                h = (h + 2 * i - 1) % usernames.Length;
                i++;
            }
            h = f(username);
            i = 1;
            while (values[h].login != username)
            {
                h = (h + 2 * i - 1) % values.Length;
                i++;
            }
            Clear();
            Show(h);
        }
        public void tryRemove(string pass, string username, AgeHashTable AgeHash)
        {
            int h = f(pass);
            int i = 1;
            while (usernames[h] != username)
            {
                if (usernames[h] == null)
                {
                    WriteLine("Wrong login or password");
                    return;
                }
                h = (h + 2 * i - 1) % usernames.Length;
                i++;
            }
            usernames[h] = null;
            h = f(username);
            i = 1;
            while (values[h].login != username)
            {
                h = (h + 2 * i - 1) % values.Length;
                i++;
            }
            AgeHash.removeUser(username, ageCalculate(values[h].dateOfBirth));
            values[h] = new Logins();
            WriteLine($"User '{username}' was removed");
            usersCount--;
        }
        public void underage(string pass, string username)
        {
            int h = f(pass);
            int i = 1;
            while (usernames[h] != username)
            {
                if (usernames[h] == null)
                    return;
                h = (h + 2 * i - 1) % usernames.Length;
                i++;
            }
            usernames[h] = null;
        }
        public void Show(int index)
        {
            int years = ageCalculate(values[index].dateOfBirth);
            WriteLine("Info about user '" + values[index].login + "':\n" +
                "Email: " + values[index].email + "\n" +
                "Date of birth: " + values[index].dateOfBirth.day + " " + values[index].dateOfBirth.month + " " + values[index].dateOfBirth.year + " (Зараз " + years + " років)");
        }
        public void printUsers()
        {
            int num = 1;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] != null && values[i].login != null)
                {
                    WriteLine($"{num}. Login: {values[i].login},\nEmail: {values[i].email},\nDate of birth: {values[i].dateOfBirth.ToString()};\n");
                    num++;
                }
            }
        }
        public int ageCalculate(Date dateOfBirth)
        {
            int years = DateTime.Today.Year - dateOfBirth.year - 1;
            int month = 1;
            for (int i = 0; i < months.Length; i++)
            {
                if (months[i] == dateOfBirth.month)
                {
                    month = i + 1;
                    break;
                }
            }
            if (month < DateTime.Now.Month || (month == DateTime.Now.Month && dateOfBirth.day <= DateTime.Today.Day))
                years++;
            return years;
        }
    }
    class Date
    {
        public int year;
        public string month;
        public int day;
        public Date(int day, string month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        public override string ToString() { return day + " " + month + " " + year; }
    }
    class Program
    {
        static string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sept", "Oct", "Nov", "Dec" };

        static void Main(string[] args)
        {
            OutputEncoding = System.Text.Encoding.UTF8;
            hashTable HashTable = new hashTable(100, months);
            AgeHashTable AgeHash = new AgeHashTable();
            string login, pass, email, date;
            Date dateOfBirth;
            DateTime dateTime = DateTime.Today;
            Random rand = new Random();
            bool contin = false;
            while (!contin)
            {
                Write("1. Generate data\n2. Empty system\n3. Exit\nChoice: ");
                switch (ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Clear();
                        string newEmail;
                        Date dateBirth;
                        for (int i = 1; i <= 5; i++)
                        {
                            int numOfChars = rand.Next(1, 10);
                            newEmail = "";
                            for (int j = 0; j < numOfChars; j++)
                            {
                                newEmail += "" + (char)rand.Next(97, 122);
                            }
                            newEmail += "@gmail.com";
                            dateBirth = new Date(rand.Next(1, 28), months[rand.Next(12)], rand.Next(1960, 2003));
                            string password = rand.Next(1000).ToString();
                            HashTable.insertUser(password, i.ToString());
                            HashTable.userInfo(i.ToString(), newEmail, dateBirth);
                            AgeHash.insertUser(i.ToString(), HashTable.ageCalculate(dateBirth));
                            WriteLine($"{i}. login: {i} password: {password}");

                        }
                        contin = true;
                        WriteLine("\nPress any key to continue...");
                        ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Clear();
                        contin = true;
                        break;
                    case ConsoleKey.D3:
                        return;
                    default:
                        Clear();
                        continue;
                }
            }

            while (true)
            {
                Clear();
                Write("1. Sign up\n2. Sign in\n3. Remove user\n4. Age statistic\n5. Users' information\n6. Exit\nChoice: ");

                switch (ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        login = ""; pass = "";
                        while (login == null || login == "")
                        {
                            Clear();
                            Write("Signing up.\nEnter login: ");
                            login = ReadLine();
                        }

                        while (pass == null || pass == "")
                        {
                            Clear();
                            WriteLine("Signing up.\nEnter login: " + login);
                            Write("Enter password: ");
                            pass = ReadLine();
                        }
                        email = "";
                        if (HashTable.insertUser(pass, login))
                        {
                            while (email == null || email == "")
                            {
                                Clear();
                                Write("Email: "); email = ReadLine();
                            }
                            bool flag = false;

                            dateOfBirth = new Date(dateTime.Day, months[dateTime.Month - 1], dateTime.Year);
                            while (!flag)
                            {
                                try
                                {
                                    Write("Date of birth (DD.MM.YYYY): ");
                                    date = ReadLine();
                                    dateOfBirth = new Date(Convert.ToInt32(date.Split(".")[0]), months[Convert.ToInt32(date.Split(".")[1]) - 1], Convert.ToInt32(date.Split(".")[2]));
                                    flag = true;
                                }
                                catch
                                {
                                    Clear();
                                    WriteLine("Email: " + email);
                                }
                            }
                            if (HashTable.ageCalculate(dateOfBirth) >= 18)
                            {
                                HashTable.userInfo(login, email, dateOfBirth);
                                AgeHash.insertUser(login, HashTable.ageCalculate(dateOfBirth));
                            }
                            else
                            {
                                WriteLine("Underage");
                                HashTable.underage(pass, login);
                            }
                        }
                        WriteLine("\nPress any key to continue...");
                        ReadKey();
                        break;
                    case ConsoleKey.D2:
                        login = ""; pass = "";
                        while (login == null || login == "")
						{
                            Clear();
                            Write("Sign in.\nEnter login: ");
                            login = ReadLine();
                        }
                        while (pass == null || pass == "")
                        {
                            Clear();
                            WriteLine("Sign in.\nEnter login: " + login);
                            Write("Enter password: ");
                            pass = ReadLine();
                        }
                        HashTable.tryToLogin(pass, login);
                        WriteLine("\nPress any key to continue...");
                        ReadKey();
                        break;
                    case ConsoleKey.D3:
                        if (HashTable.usersCount > 0)
                        {
                            login = ""; pass = "";

                            while (login == null || login == "")
                            {
                                Clear();
                                Write("Remove user.\nEnter login: ");
                                login = ReadLine();
                            }
                            while (pass == null || pass == "")
                            {
                                Clear();
                                WriteLine("Remove user.\nEnter login: " + login);
                                Write("Enter password: ");
                                pass = ReadLine();
                            }
                            HashTable.tryRemove(pass, login, AgeHash);
                            WriteLine("\nPress any key to continue...");
                            ReadKey();
                        }
                        break;
                    case ConsoleKey.D4:
                        if (HashTable.usersCount > 0)
                        {
                            Clear();
                            WriteLine("Users by age groups.");
                            AgeHash.identifyAgeCategories();
                            WriteLine("\nPress any key to continue...");
                            ReadKey();
                        }
                        break;
                    case ConsoleKey.D5:
                        if (HashTable.usersCount > 0)
                        {
                            Clear();
                            WriteLine("Signed up users:");
                            HashTable.printUsers();
                            WriteLine("\nPress any key to continue...");
                            ReadKey();
                        }
                        break;
                    case ConsoleKey.D6:
                        return;
                }
            }
        }
    }
}