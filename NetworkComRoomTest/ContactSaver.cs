using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkComRoomTest
{
    public enum FileTarget
    {
        SaveFile,
        LoadFile
    }


    public abstract class ContactFS
    {
        public abstract void ContactInfo(List<ContactInfo> contactData);
    }


    public class SaveFile : ContactFS
    {
        public string filePath = @".\Contacts.csv";
        public override void ContactInfo(List<ContactInfo> contactData)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, false))
            {
                foreach (ContactInfo contact in contactData)
                {
                    streamWriter.WriteLine(contact.ID.ToString(), contact.FullName, contact.Email);
                }

                streamWriter.Close();
            }
        }
    }

    public class LoadFile : ContactFS
    {
        public string filePath = @".\Contacts.csv";
        public override void ContactInfo(List<ContactInfo> contactData)
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                while(!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();

                    string[] token = line.Split(',');

                    ContactInfo newContact = new ContactInfo
                    {
                        ID = int.Parse(token[0]),
                        FullName = token[1],
                        Email = token[2]
                    };

                    contactData.Add(newContact);
                }

                streamReader.Close();
            }
        }
    }


    // helper class
    public static class FileHelper
    {
        private static ContactFS contactFS = null;
        public static void Log(FileTarget target, string message)
        {
            switch (target)
            {
                case FileTarget.SaveFile:
                    {
                        contactFS = new SaveFile();

                        // add save file info here

                        //contactFS.Log(message);

                        break;
                    }
                case FileTarget.LoadFile:
                    {
                        contactFS = new LoadFile();

                        // add load file info here
                        
                        //contactFS.Log(message);

                        break;
                    }
                default:
                    break;
            }
        }
    }



    public class ContactInfo
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
