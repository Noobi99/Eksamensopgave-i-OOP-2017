using System;

namespace TestingEksamen
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Person isabella = new Person("Isabella")
                .WithFather(new Person("Frederik")
                    .WithFather(new Person("Torben"))
                    .WithMother(new Person("Kirsten")))
                .WithMother(new Person("Nina")
                    .WithFather(new Person("Ninas far"))
                    .WithMother(new Person("Ninas mor")));


            Person ole = new Person("ole").WithFather(new Person("Torben"));

            isabella.PrintTree();
            
            
        }
    }

    public class C
    {
        public C c { get; set; }


        public override string ToString()
        {
            return "c";
        }
    }


    public class Person
    {
        private string _name;

        public Person Father { get; set; }
        public Person Mother { get; set; }


        public Person WithFather(Person f)
        {
            Father = f;
            return this;
        }

        public Person WithMother(Person m)
        {
            Mother = m;
            return this;
        }

        
        public Person(string name)
        {
            _name = name;
        }


        public override string ToString()
        {
            return _name;
        }

        public void PrintTree()
        {
            if (Mother != null)
            {
                Console.WriteLine(Mother);
                Mother.PrintTree();
            }

            if (Father != null)
            {
                Console.WriteLine(Father);
                Father.PrintTree();
            }
            
            
            
        }
    }
    
}