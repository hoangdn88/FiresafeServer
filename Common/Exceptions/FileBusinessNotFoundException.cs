using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class FileBusinessNotFoundException : NotFoundException
    {
        public FileBusinessNotFoundException(string id) : base($"The file with the id {id} was not found.")
        {
        }
        public FileBusinessNotFoundException() : base($"The file was not found.")
        {

        }
    }
}
