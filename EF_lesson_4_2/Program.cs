using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PhoneContext db = new PhoneContext())
            {
                var phones = db.Phones.Where(p => p.Company.Name == "Samsung");
                foreach (Phone p in phones)
                    Console.WriteLine("{0}.{1} - {2}", p.Id, p.Name, p.Price);
                
                Phone myphone = db.Phones.Find(3); // выберем элемент с id=3
                Console.WriteLine("id = 3: {0}", myphone.Name);
                
                myphone = db.Phones.FirstOrDefault(p => p.Id == 4);
                if (myphone != null)
                    Console.WriteLine("id = 4: {0}", myphone.Name);
               
                var phones2 = db.Phones.Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Company = p.Company.Name
                });
                foreach (var p in phones2)
                    Console.WriteLine("{0} ({1}) - {2}", p.Name, p.Company, p.Price);

                var phones3 = db.Phones.Select(p => new Model
                {
                    Name = p.Name,
                    Price = p.Price,
                    Company = p.Company.Name
                });
                foreach (Model p in phones3)
                    Console.WriteLine("{0} ({1}) - {2}", p.Name, p.Company, p.Price);
            }
            

            Console.ReadLine();
        }
    }
}
