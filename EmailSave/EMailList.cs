using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EmailSave
{
    [Serializable]
    class EMailList
    {
        public List<EMail> EMails
        {
            get; private set;
        }

        public EMailList()
        {
            EMails = Run();
        }

        private List<EMail> Run()
        {
            try
            {
                using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    var list = (List<EMail>)formatter.Deserialize(fs);
                    if (list != null)
                        return list;
                    else
                        return new List<EMail>();
                }
            }
            catch
            { return new List<EMail>(); }

        }

        private void Save()
        {
            try
            {
                using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, EMails);
                }
            }
            catch { }
        }

        public void Add(string em , string name)
        {
            var newEmail = new EMail(em , name);
            if (newEmail != null)
            {
                EMails.Add(newEmail);
                Save();
            }
        }

        public void Clear(EMail eMail)
        {
            EMails.Remove(eMail);
            Save();
        }

        public void ClearAll()
        {
            EMails.Clear();
            Save();
        }
    }
}