using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CustomEvent : EventArgs
    {
        public int Index1 { get; }
        public int Index2 { get; }

        public CustomEvent(int index1, int index2)
        {
            Index1 = index1;
            Index2 = index2;
        }
     }

    public class Changing
    {
        public event EventHandler<CustomEvent> Temp = delegate {};

        public virtual void OnChange(CustomEvent e)
        {
            Temp(this, e);
        }
    }
}
