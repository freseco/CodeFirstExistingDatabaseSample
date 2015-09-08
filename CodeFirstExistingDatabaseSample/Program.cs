using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExistingDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new BloggingContext())
            {

                Console.WriteLine("Enter a name for a new blog");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();
                //creamos la clase, add class to the database

                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in database:");
                foreach(var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();


            }
        }
    }
}
