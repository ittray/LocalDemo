using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLDemos.XmlSerialize
{
    [XmlRoot("cats")]
    [Serializable]
    public class CatCollection
    {
        [XmlArray("items"), XmlArrayItem("item")]
        public Cat[] Cats { get; set; }
    }

    [XmlRoot("cat")]
    [Serializable]
    public class Cat
    {
        //定义Color属性的序列化为cat节点的属性
        [XmlAttribute("color")]
        public string Color { get; set; }

        //要求不序列化Speed属性
        [XmlIgnore]
        public int Speed { get; set; }

        //设置Saying属性序列化为Xml子元素
        [XmlElement("saying")]
        public string Saying { get; set; }
    }

    public class Model2XML
    {
        public static void Obj2Xml()
        {
            //声明一个猫咪对象
            var cWhite = new Cat { Color = "White", Speed = 10, Saying = "White or black,  so long as the cat can catch mice,  it is a good cat" };
            var cBlack = new Cat { Color = "Black", Speed = 10, Saying = "White or black,  so long as the cat can catch mice,  it is a good cat" };

            CatCollection cc = new CatCollection { Cats = new Cat[] { cWhite, cBlack } };

            //序列化这个对象
            XmlSerializer serializer = new XmlSerializer(typeof(CatCollection));

            //将对象序列化输出到控制台
            serializer.Serialize(Console.Out, cc);
//<? xml version = "1.0" encoding = "gb2312" ?>
//   < cats xmlns:xsi = "http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd = "http://www.w3.org/2001/XMLSchema" >
//    < items >
//        < item color = "White" >
//            < saying > White or black, so long as the cat can catch mice,  it is a good cat</ saying >
//        </ item >
//        < item color = "Black" >
//            < saying > White or black, so long as the cat can catch mice,  it is a good cat</ saying >
//        </ item >
//    </ items >
//</ cats >


Console.ReadLine();
        }
    }
}
