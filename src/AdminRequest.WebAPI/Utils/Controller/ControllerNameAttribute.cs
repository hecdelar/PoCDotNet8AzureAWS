using System;

namespace AdminRequest.poc.Utils.Controller
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ControllerNameAttribute : Attribute
    {
        public string Name { get; }

        public ControllerNameAttribute(string name)
        {
            Name = name;
        }
    }
}
