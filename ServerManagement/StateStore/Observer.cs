namespace ServerManagement.StateStore
{
    public class Observer
    {
        protected Action? _listeners;

        public void AddStateChangeListeners(Action? listeners)
        {
            if(listeners is not null)
            {
                _listeners += listeners;
            }
        }

        public void RemoveStateChangeListeners(Action? listeners)
        {
            if(listeners is not null)
            {
                _listeners -= listeners;
            }
        }

        public void BroadCastStateChange()
        {
            _listeners?.Invoke();
        }

    }
}
