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
            // delete file if it exists
            if (File.Exists(filePath))
                File.Delete(filePath);

            LogHelper.Log(LogTarget.File, $"Saving contacts, displaying all contacts");

            foreach (ContactInfo data in contactData)
            {
                LogHelper.Log(LogTarget.File, $"Index: {data.ID}, FullName: {data.FullName}, Email: {data.Email} ");
            }

            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                foreach (ContactInfo contact in contactData)
                {
                    LogHelper.Log(LogTarget.File, $"Saving this data: {contact.ID.ToString()},{contact.FullName},{contact.Email}");
                    //streamWriter.WriteLine($"{contact.ID.ToString()},{contact.FullName},{contact.Email}");
                    streamWriter.WriteLine($"{contact.FullName},{contact.Email}");
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
            if (File.Exists(filePath))
            {
                LogHelper.Log(LogTarget.File, $"Loading Contacts data");

                using (StreamReader streamReader = new StreamReader(filePath))
                {

                    int counter = 0;

                    while (!streamReader.EndOfStream)
                    {
                        string line = streamReader.ReadLine();

                        string[] token = line.Split(',');


                        ContactInfo newContact = new ContactInfo()
                        {
                            ID = counter,
                            FullName = token[0],
                            Email = token[1]
                        };

                        LogHelper.Log(LogTarget.File, $"new Contact - ID: {newContact.ID}, Name: {newContact.FullName}, Email: {newContact.Email}");


                        contactData.Add(newContact);

                        counter++;
                    }

                    streamReader.Close();
                }

                LogHelper.Log(LogTarget.File, $"Contacts data Loaded Successfully");
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

        public ContactInfo(int id, string name, string email)
        {
            ID = id;
            FullName = name;
            Email = email;
        }
        public ContactInfo()
        {

        }
    }
}
