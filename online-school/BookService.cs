using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school
{
    public class BookService
    {
        private List<Book> _book;

        public BookService()
        {
            _book = new List<Book>();
            this.LoadData();
        }

        public void LoadData()
        {
            try
            {
                using (StreamReader sr = new StreamReader(this.GetFilePath()))
                {
                    string line = " ";
                    while ((line = sr.ReadLine()) != null)
                    {
                        Book book = new Book(line);
                        this._book.Add(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string GetFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string folder = Path.Combine(currentDirectory, "data");

            string file = Path.Combine(folder, "book");

            return file;
        }

        public string ToSaveAll()
        {
            String save = "";

            for (int i = 0; i < _book.Count; i++)
            {
                save += _book[i].ToSave() + "\n";
            }

            save += _book[_book.Count - 1].ToSave();

            return save;
        }

        public void SaveData()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(this.GetFilePath()))
                {
                    sw.Write(ToSaveAll());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine (ex);
            }
        }

        //CRUD
        public void AfisareBook()
        {
            foreach(Book x in _book)
            {
                Console.WriteLine(x.BookInfo());
            }
        }

        public int FindBookById(int BookId)
        {
            for(int i = 0; i < _book.Count;i++)
            {
                if (_book[i].Id == BookId)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool AddBook(Book book)
        {
            if(FindBookById(book.Id) == -1)
            {
                this._book.Add(book);
                return true;
            }
            return false;
        }

        public bool RemoveBook(Book book)
        {
            int wantedBook = FindBookById(book.Id);
            if(wantedBook != -1)
            {
                this._book.RemoveAt(wantedBook);
                return true;
            }
            return false;
        }

        public bool EditBookIdById(int BookId, int newIdAdd)
        {
            foreach (Book x in _book)
            {
                if (x.Id == BookId)
                {
                    x.Id = newIdAdd;
                    return true;
                }
            }
            return false;
        }

        public bool EditBookIdByName(string bookName, int newId)
        {
            foreach( Book x in _book)
            {
                if(x.Book_name == bookName)
                {
                    x.Id = newId;
                    return true;
                }
            }
            return false;
        }

        public bool EditRentedBook(int studentId, int idStudentBook)
        {
            foreach( Book x in _book)
            {
                if(x.Id == idStudentBook)
                {
                    x.Student_id = studentId;
                    return true;
                }
            }
            return false;
        }

        public int GenerateId()
        {
            Random rand = new Random();

            int id = rand.Next(1, 10000000);


            while (FindBookById(id) != -1)
            {
                id = rand.Next(1, 10000000);
            }


            return id;
        }

    }
}
