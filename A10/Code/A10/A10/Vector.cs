using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10
{
    
    public class Vector<_Type> : 
        IEnumerable<_Type>,
        IEquatable<Vector<_Type>>
        where _Type: IEquatable<_Type>        
    {
        
        public readonly _Type[] Data;

       
        protected int AddIndex = 0;

       
        public int Size => Data.Length;

       
        public void Add(_Type v)
        {
            Data[AddIndex++] = v;
        }

        
       
        public Vector(int length)
        {
            this.Data = new _Type[length];
        }


       
        public Vector(Vector<_Type> other)
            : this(other.Size)
        {
            int i = 0;
            foreach (var c in other.Data)
            {
                Data[i++] = c;
            }
        }

       
        public Vector(IEnumerable<_Type> list)
            : this(list.Count())
        {
            int i = 0;
            foreach(var c in list)
            {
                Data[i++] = c;
            }
        }
        
        public _Type this[int index]
        {
            get { return this.Data[index]; }
            set { this.Data[index] = value; }
        }
        
        public static Vector<_Type> operator +(Vector<_Type> v1, Vector<_Type> v2)
        {
            Vector<_Type> v = new Vector<_Type>(v1.Size);
            int i = 0;
            foreach (var c in v1)                
                v.Data[i] = (dynamic)v1.Data[i] + (dynamic)v2.Data[i++];
            return v;
        }
       
        
        public static _Type operator *(Vector<_Type> v1, Vector<_Type> v2)
        {
            _Type result = (dynamic)0;
            int i = 0;
            foreach (var c in v1)
                result += (dynamic)v1.Data[i] * (dynamic)v2.Data[i++];
            return result;
        }



        
        public static bool operator ==(Vector<_Type> v1, Vector<_Type> v2)
        {
            if (v1.Size != v2.Size)
                return false;
            int i = 0;
            foreach (var c in v1)
                if ((dynamic)v1.Data[i] != (dynamic)v2.Data[i++])
                    return false;
            return true;                
        }


        
        public static bool operator !=(Vector<_Type> v1, Vector<_Type> v2)
            => !(v1 == v2);
        
        public override bool Equals(object obj)
        {
            return (this == (obj as Vector<_Type>));
        }
        
        
        public bool Equals(Vector<_Type> other)
        {
            return (this == other);                                   
        }
        
        public IEnumerator<_Type> GetEnumerator()
        {
            foreach (var c in Data)
                yield return c;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var c in Data)
                yield return c;
        }

        
        public override int GetHashCode()
        {
            int i = 1;
            foreach (var c in Data)
                i = i * c.GetHashCode();
            return i;
        }
        public string ToString()
        {
            string s = "[";
            for (int i = 0; i < Data.Length; i++)
            {
                s = s + Data[i].ToString();
                if (i < Data.Length - 1)
                    s = s + ",";
            }
            return s+"]";
        }

    }
}
