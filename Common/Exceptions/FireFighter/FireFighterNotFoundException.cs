using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class FireFighterNotFoundException : NotFoundException
    {
        public FireFighterNotFoundException(string id) : base($"The fire prevention officer with the id {id} was not found.")
        {
        }
        public FireFighterNotFoundException() : base($"The fire prevention officer  was not found.")
        {

        }
    }
}
