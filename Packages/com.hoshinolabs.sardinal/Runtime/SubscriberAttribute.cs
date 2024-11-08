using System;

namespace HoshinoLabs.Sardinal {
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class SubscriberAttribute : Attribute {
        public Type Topic { get; }
        public object Channel { get; }

        public SubscriberAttribute(Type topic, object channel = null) {
            Topic = topic;
            Channel = channel;
        }
    }
}
