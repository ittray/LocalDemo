using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Xml;

namespace XPathWithDotNet2_0
{
    public class XmlNameSpaceTest
    {
        //Why does this not work?"
        public static void DoesNotWork_TestSelectWithDefaultNamespace()
        {
            // xml to parse with defaultnamespace
            string xml = @"<a xmlns='urn:test.Schema'><b/><b/></a>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            // fails because xpath does not have the namespace
            //!!!!
            Debug.Assert(doc.SelectNodes("//b").Count == 2);

            // using XPath defaultnamespace 
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("", "urn:test.Schema");

            // This will fail. Why?
            //!!!!
            Debug.Assert(doc.SelectNodes("//b", nsmgr).Count == 2);
        }

        public static void TestSelectWithoutNamespaces_Ok()
        {
            // xml to parse without namespace
            string xml = @"<a><b/><b/></a>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            // works ok
            Debug.Assert(doc.SelectNodes("//b").Count == 2);

            // works ok
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            Debug.Assert(doc.SelectNodes("//b", nsmgr).Count == 2);
        }

        public static void TestSelectWithNamespacesPrefixed_Ok()
        {
            // xml to parse with defaultnamespace
            string xml = @"<a xmlns='urn:test.Schema'><b/><b/></a>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            // using XPath namespace via alias "t". works ok but xpath is to complicated
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("t", doc.DocumentElement.NamespaceURI);

            Debug.Assert(doc.SelectNodes("//t:b", nsmgr).Count == 2);
        }
    }
}
