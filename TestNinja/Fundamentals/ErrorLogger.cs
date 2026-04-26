
using System;

namespace TestNinja.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged; 
        
        public void Log(string error)
        {
            //null
            //""
            //"   "
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();
                
            LastError = error;

            // Write the log to a storage
            // ...

            //Replaced the below line with the OnErrorLogged
            //method to make it more testable and maintainable.

            //ErrorLogged?.Invoke(this, Guid.NewGuid());

            OnErrorLogged(Guid.NewGuid());
        }

        protected virtual void OnErrorLogged(Guid errorId)
        {
            ErrorLogged?.Invoke(this, errorId);
        }
    }
}