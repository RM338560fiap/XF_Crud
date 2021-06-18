using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace XF_Crud
{
    public class SQLiteHelper
    {
        readonly SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Alunos>().Wait();
        }

        //Insert and Update new record
        public Task<int> SaveItemAsync(Alunos person)
        {
            if (person.MatriculaId != 0)
            {
                return db.UpdateAsync(person);
            }
            else
            {
                return db.InsertAsync(person);
            }
        }

        public Task<int> DeleteItemAsync(Alunos person)
        {
            return db.DeleteAsync(person);
        }

        //Read All Items
        public Task<List<Alunos>> GetItemsAsync()
        {
            return db.Table<Alunos>().ToListAsync();
        }


        //Read Item
        public Task<Alunos> GetItemAsync(int personId)
        {
            return db.Table<Alunos>().Where(i => i.MatriculaId == personId).FirstOrDefaultAsync();
        }
    }
}