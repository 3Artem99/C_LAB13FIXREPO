using ResourcesAndDataBinding.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace ResourcesAndDataBinding.DataAccess
{
    public class JournalsDataAccess
    {
        public static SQLiteConnection Database;
        private static object collisionLock = new object();

        public JournalsDataAccess()
        {
            Database = new SQLiteConnection(DataAccessHelper.DatabasePath);
            Database.CreateTable<Journal>();
        }

        public List<Journal> GetFamilyMembers()
        {
            lock (collisionLock)
            {
                var contacts = Database.Table<Journal>();
                var result = contacts.Where(c => c.IsFamilyMember).ToList();
                return result;
            }
        }

        public void AddJournal(Journal journal)
        {
            lock (collisionLock)
            {
                Database.Insert(journal);
            }
        }

        public void DeleteJournal(Journal journal)
        {
            lock (collisionLock)
            {
                Database.Delete(journal);
            }
        }

        public void EditJournal(Journal journal)
        {
            lock (collisionLock)
            {
                Database.Update(journal);
            }
        }

        public void SaveAll(IEnumerable<Journal> journals)
        {
            lock (collisionLock)
            {
                var existingJournals = journals.Where(c => c.journalID != 0);
                var newJournals = journals.Where(c => c.journalID == 0);

                Database.UpdateAll(existingJournals);
                Database.InsertAll(newJournals);
            }
        }
    }
}
