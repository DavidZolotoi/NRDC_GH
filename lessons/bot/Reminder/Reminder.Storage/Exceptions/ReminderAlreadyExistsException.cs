using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Storage.Exceptions
{
    public class ReminderAlreadyExistsException : Exception
    {
        public ReminderAlreadyExistsException(Guid id) : 
            base($"Reminder item with id {id} already exists")
        {

        }
    }
}
