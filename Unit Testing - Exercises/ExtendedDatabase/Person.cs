
namespace ExtendedDatabase
{
    public class Person
    {
        private long id;
        private string userName;
        public Person(long id, string userName)
        {
            this.id = id;
            this.userName = userName;
        }
        public string UserName
        {
            get { return userName; }
           private set
            {
                userName = value;
            }
        }
        public long Id
        {
            get { return id; }
            private set
            {
               id = value;
            }
        }
    }
}
