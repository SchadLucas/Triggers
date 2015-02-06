namespace Triggers.Common.Plugin
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PluginTypeAttribute : Attribute
    {
        public PluginTypeAttribute(Type type)
        {
            Type = type;
        }

        public Type Type;
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PluginPropertyAttribute : Attribute
    {
        public PluginPropertyAttribute(bool required)
        {
            Required = required;
        }

        public bool Required;
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PluginModelTypeAttribute : Attribute
    {
        public PluginModelTypeAttribute(Type model)
        {
            Model = model;
        }

        public Type Model;
    }
}