using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class CertificateNotFoundException : NotFoundException
    {
        public CertificateNotFoundException(string id) : base($"The Certificate with the id {id} was not found.")
        {
        }
        public CertificateNotFoundException() : base($"The Certificate was not found.")
        {

        }
    }
}
