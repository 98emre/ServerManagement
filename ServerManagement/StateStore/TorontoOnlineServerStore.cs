namespace ServerManagement.StateStore
{
    public class TorontoOnlineServerStore : Observer
    {
        private int _numServersOnline;

        public int GetNumbersServersOnline()
        {
            return _numServersOnline; 
        }

        public void SetNumbersServersOnline(int number)
        {
            _numServersOnline = number;
            
            BroadCastStateChange();
        }
    }
}
