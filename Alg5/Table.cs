using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg5
{
    class Table<T>
    {
        public T[] values;
        public Table() :
     this(new T[0])
        { }
        public Table(params T[] vs)
        {
            values = vs;
        }
        public T this[int index]
        {
            get 
            {
                if (index >= 0 && index < values.Length)
                    return values[index];
                else
                    return default(T);
            }
            set
            {
                values[index] = value;
            }
        }
        
          
                  
     }  
}

