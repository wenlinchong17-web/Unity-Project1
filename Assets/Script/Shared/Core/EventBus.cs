using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Shared.Core
{
    public class EventBus
    {
        private readonly Dictionary<Type, Action<object>> _events = new();
            //new Dictionary<Type, Action<object>>();

        private readonly Dictionary<Delegate, Action<object>> _lookup = new();
        private readonly Queue<object> _eventQueue = new();
         
        // 同步事件
        public void Publish<T>(T evt)
        {
            var type = typeof(T);

            if (_events.TryGetValue(type, out var action))
                action?.Invoke(evt);
        }

        // 异步事件
        public void PublishAsync<T>(T evt)
        {
            _eventQueue.Enqueue(evt);
        }

        // 每帧调用
        public void ProcessEvents()
        {
            while (_eventQueue.Count > 0)
            {
                var evt = _eventQueue.Dequeue();
                var type = evt.GetType();

                if (_events.TryGetValue(type, out var action))
                    action?.Invoke(evt);
            }
        }

        public void Subscribe<T>(Action<T> listener)
        {
            Type type = typeof(T);

            Action<object> wrapper = (e) => listener((T)e);

            _lookup[listener] = wrapper;

            if (_events.ContainsKey(type))
                _events[type] += wrapper;
            else
                _events[type] = wrapper;
            /*if (_events.ContainsKey(type))
                _events[type] += (e) => listener((T)e);
            else
                _events[type] = (e) => listener((T)e);*/
        }
       
        public void Unsubscribe<T>(Action<T> listener)
        {
            var type = typeof(T);

            if (_lookup.TryGetValue(listener, out var wrapper))
            {
                if (_events.ContainsKey(type))
                {
                    _events[type] -= wrapper;

                    if (_events[type] == null)
                        _events.Remove(type);
                }

                _lookup.Remove(listener);
            }
        }
        // 一次性监听
        public void SubscribeOnce<T>(Action<T> listener)
        {
            Action<T> wrapper = null;
            wrapper = (e) =>
            {
                listener(e);
                Unsubscribe(wrapper);
            };
            Subscribe(wrapper);
        }
    }
}