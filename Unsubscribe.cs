﻿using System;
using System.Collections.Generic;

namespace Microwave
{
    public class Unsubscribe : IDisposable
    {
        private List<IObserver<Stare>> _observers;
        private IObserver<Stare> _observer;

        public Unsubscribe(List<IObserver<Stare>> observers, IObserver<Stare> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if(_observer != null) _observers.Remove(_observer);
        }
    }
}
