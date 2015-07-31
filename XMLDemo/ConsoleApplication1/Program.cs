using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLDemos.XPath;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlNameSpaceTest.DoesNotWork_TestSelectWithDefaultNamespace();


            //test XPath demo
            XPathDemo.ParsePetsXml("./Xpath/Pets.xml");

            Console.ReadLine();
        }
    }
}
