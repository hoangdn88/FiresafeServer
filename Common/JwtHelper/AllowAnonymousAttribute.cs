using System;

namespace Common.JwtHelper
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    {
    }
}
