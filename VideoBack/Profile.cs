﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VideoBack
{
    [Serializable]
    public class Profile
    {
        public string Cams { get; set; }
        public string DestFolder { get; set; }
        public string SourceUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsIntellect { get; set; }

        public Profile()
        {
        }

        public static Profile DefaultProfile()
        {
            return new Profile { Cams = "22", IsIntellect = true };
        }

        /// <summary>
        /// Saves this settings object to desired location
        /// </summary>
        /// <param name="fileName"></param>
        public void Save(string fileName)
        {
            // Insert code to set properties and fields of the object.
            XmlSerializer mySerializer = new XmlSerializer(typeof(Profile));
            // To write to a file, create a StreamWriter object.
            StreamWriter myWriter = new StreamWriter(fileName);
            mySerializer.Serialize(myWriter, this);
            myWriter.Close();
        }

        /// <summary>
        /// Returns a clsSettings object, loaded from a specific location
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Profile Load(string fileName)
        {
            // Constructs an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer = new XmlSerializer(typeof(Profile));
            // To read the file, creates a FileStream.
            FileStream myFileStream = new FileStream(fileName, FileMode.Open);
            // Calls the Deserialize method and casts to the object type.
            Profile pos = (Profile)mySerializer.Deserialize(myFileStream);
            myFileStream.Close();
            return pos;
        }

    }
}
