using Microsoft.Identity.Client;
using SampleEFConsole.Models;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            display();
            Insert();
            display();
            Console.WriteLine("Enter Customer ID to find:");
            int id = Convert.ToInt32(Console.ReadLine());
            Find(id);
            Console.WriteLine("Enter Customer ID to update:");
            int ids = Convert.ToInt32(Console.ReadLine());
            Update(ids);
            display();
            Console.WriteLine("Enter Customer ID to be deleted:");
            int idss = Convert.ToInt32(Console.ReadLine());
            Delete(idss);
            display();
            Console.WriteLine("CRUD Performed Successfully");
        }
        public static void display()
        {
            using (Kanini23Context con = new Kanini23Context())
            {
                List<Customer> res = con.Customers.ToList();
                foreach (var item in res)
                {
                    Console.WriteLine(item.Custid + " " + item.Custname + " " + item.City + " " + item.Age);
                }
            }
        }
        public static void Insert()
        {
            Console.WriteLine("Enter Customer ID:");
            int id=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Customer Name:");
            string name=Console.ReadLine();
            Console.WriteLine("Enter City:");
            string cty=Console.ReadLine();
            Console.WriteLine("Enter Age:");
            int age=Convert.ToInt32(Console.ReadLine());
            using(Kanini23Context context = new Kanini23Context())
            {
                Customer cust = new Customer()
                {
                    Custid = id,
                    Custname = name,
                    City = cty,
                    Age = age
                };
                context.Add(cust);
                context.SaveChanges();

            }
        }
        public static void Find(int id)
        {
            using(Kanini23Context conn=new Kanini23Context())
            {
                Customer cust = conn.Customers.First(x=>x.Custid==id);
                Console.WriteLine(cust.Custid+" "+cust.Custname+" "+cust.City+" "+cust.Age);
            }
        }
        public static void Update(int id)
        {
            using (Kanini23Context conn = new Kanini23Context())
            {
                Customer cust = conn.Customers.First(x => x.Custid == id);
                

                Console.WriteLine(cust.Custid + " " + cust.Custname + " " + cust.City + " " + cust.Age);
                after(cust);
            }
            
        }
        public static void after(Customer cst)
        {
            Console.WriteLine("Enter which one to update(1.name/2.city/3.age)");
            int op = Convert.ToInt32(Console.ReadLine());
            using (Kanini23Context conn = new Kanini23Context())
            {
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Enter the name to be updated:");
                        string nme = Console.ReadLine();
                        cst.Custname = nme;
                        conn.Update(cst);
                        conn.SaveChanges();

                        break;
                    case 2:
                        Console.WriteLine("Enter the city to be updated:");
                        string cty = Console.ReadLine();
                        cst.City = cty;
                        conn.Update(cst);
                        conn.SaveChanges();
                        break;

                   case 3:
                        Console.WriteLine("Enter the AGe to be updated:");
                       int age =Convert.ToInt32(Console.ReadLine());
                        cst.Age=age;
                        conn.Update(cst);
                        conn.SaveChanges();
                        break;

                }
            }

        }
        public static void Delete(int id)
        {
            using (Kanini23Context conn = new Kanini23Context())
            {
                Customer cust = conn.Customers.First(x => x.Custid == id);
                conn.Remove(cust);
                conn.SaveChanges();

               // Console.WriteLine(cust.Custid + " " + cust.Custname + " " + cust.City + " " + cust.Age);
                
            }


        }

    }
}
