using System;
using System.Collections.Generic;

namespace Code
{
    public class EventDispatcherService : IEventDispatcherService
    {
        private readonly Dictionary<Type, dynamic> _events;

        public EventDispatcherService()
        {
            _events = new Dictionary<Type, dynamic>();
        }

        public void Subscribe<T>(Action<T> callback)
        {
            var type = typeof(T);
            if (!_events.ContainsKey(type))
            {
                _events.Add(type, null);
            }

            _events[type] += callback;
        }

        public void Unsubscribe<T>(Action<T> callback)
        {
            var type = typeof(T);
            if (_events.ContainsKey(type))
            {
                _events[type] -= callback;
            }
        }

        public void Dispatch<T>(T arg)
        {
            var type = typeof(T);
            if (_events.ContainsKey(type))
            {
                var callbakcs = _events[type];
                callbakcs(arg);
            }                  
        }
    }
}