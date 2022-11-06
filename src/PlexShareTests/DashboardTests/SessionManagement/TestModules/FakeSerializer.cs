﻿using PlexShareNetwork.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace PlexShareTests.DashboardTests.SessionManagement.TestModules
{
    public class FakeSerializer : ISerializer
    {
        public string Serialize<T>(T genericObject)
        {
            XmlSerializer xmlSerializer;
            try
            {
                xmlSerializer = new XmlSerializer(typeof(T));
            }
            catch (InvalidOperationException e)
            {
                // Arises if the class 'T' does not have an empty constructor
                Trace.WriteLine($"{e.StackTrace}");
                return null;
            }

            // StringWriter deals with string data
            StringWriter stringWriter = new StringWriter();

            // The string data which is written by StringWriter is stored here
            XmlWriter xmlWriter = null;
            try
            {
                xmlWriter = XmlWriter.Create(stringWriter);
            }
            catch (ArgumentNullException e)
            {
                Trace.WriteLine($"{e.StackTrace}");
                return null;
            }

            // Serializing the provided object
            try
            {
                xmlSerializer.Serialize(xmlWriter, genericObject);
            }
            catch (InvalidOperationException e)
            {
                Trace.WriteLine($"{e.StackTrace}");
                return null;
            }

            return stringWriter.ToString();
        }

        /// <summary>
        /// Given a serialized string in XML format, the method converts it into the original object and returns it
        /// </summary>
        public T Deserialize<T>(string serializedString)
        {
            XmlSerializer xmlSerializer;
            try
            {
                xmlSerializer = new XmlSerializer(typeof(T));
            }
            catch (InvalidOperationException e)
            {
                // Arises if the class 'T' does not have an empty constructor
                Trace.WriteLine($"{e.StackTrace}");
                return default(T);
            }

            // To read the string
            StringReader stringReader;
            try
            {
                stringReader = new StringReader(serializedString);
            }
            catch (ArgumentNullException e)
            {
                Trace.WriteLine($"{e.StackTrace}");
                return default(T);
            }

            // The object to be returned
            T returnObject = default(T);
            try
            {
                returnObject = (T)xmlSerializer.Deserialize(stringReader);
            }
            catch (ArgumentNullException e)
            {
                Trace.WriteLine($"{e.StackTrace}");
                return default(T);
            }

            return returnObject;
        }
    }
}
