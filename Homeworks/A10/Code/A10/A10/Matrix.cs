using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace A10
{
    public class Matrix<_Type> : 
            IEnumerable<Vector<_Type>>,
            IEquatable<Matrix<_Type>>
        where _Type : IEquatable<_Type>
    {
        public readonly int RowCount;
        public readonly int ColumnCount;

        protected readonly Vector<_Type>[] Rows;
        protected int RowAddIndex = 0;

       
        public Matrix(int rowCount, int columnCount)
        {
            this.RowCount = rowCount;
            this.ColumnCount = columnCount;
            Rows = new Vector<_Type>[rowCount];
            for (int i = 0; i < rowCount; i++)
                Rows[i] = new Vector<_Type>(columnCount);
        }

       
        public Matrix(IEnumerable<Vector<_Type>> rows):this(rows.Count(), rows.ToArray()[0].Size)
        {
            Rows = rows.ToArray();
        }
        

        public void Add(Vector<_Type> row)
        {
            this.Rows[RowAddIndex++] = row;
        }

        public IEnumerator<Vector<_Type>> GetEnumerator()
        {
            foreach (var c in Rows)
                yield return c;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var c in Rows)
                yield return c;
        }

        public Vector<_Type> this[int index]
        {
            get { return this.Rows[index]; }
            set { this.Rows[index] = value; }
        }

        public _Type this[int row, int col]
        {
            get { return this.Rows[row][col]; }
            set { this.Rows[row][col] = value; }
        }
        
        
        public static Matrix<_Type> operator +(Matrix<_Type> m1, Matrix<_Type> m2)
        {   
            if(m1.Rows.Length!= m2.Rows.Length || m1.Rows[0].Size!=m2.Rows[0].Size)
                throw new InvalidOperationException();
            Matrix<_Type> m = new Matrix<_Type>(m1.Rows.Length,m1.Rows[0].Size);
            int i = 0;
            foreach (var c in m1)
                m.Rows[i] = (dynamic)m1.Rows[i] + (dynamic)m2.Rows[i++];
            return m;
            
        }
        
        
        public static Matrix<_Type> operator *(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            if (m1.ColumnCount != m2.RowCount)
                throw new InvalidOperationException();
            Matrix<_Type> m = new Matrix<_Type>(m1.RowCount, m2.ColumnCount);
            for (int i = 0; i < m1.RowCount; i++)
            {
                m[i] = new Vector<_Type>(m2.ColumnCount);
                for (int j = 0; j < m2.ColumnCount; j++)
                    m[i][j] = m1[i] * m2.GetColumn(j);
            }
            return m;
        }               
        protected IEnumerable<_Type> GetColumnEnumerator(int col)
        {
            Vector<_Type> column = new Vector<_Type>(RowCount);
            for (int i = 0; i < RowCount; i++)
                column[i] = this[i][col];
            return column;
        }

        protected Vector<_Type> GetColumn(int col) => 
            new Vector<_Type>(GetColumnEnumerator(col));


        public bool Equals(Matrix<_Type> other)
        {
            if (Rows.Length != other.Rows.Length)
                return false;
            if (Rows[0].Size != other.Rows[0].Size)
                return false;

            for (int i = 0; i < other.Rows.Length; i++)
                if (Rows[i] != other.Rows[i])
                    return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            return (this.Equals(obj as Matrix<_Type>));
        }
        public static bool operator ==(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            if (m1.Rows.Length != m2.Rows.Length)
                return false;
            if (m1.Rows[0].Size != m2.Rows[0].Size)
                return false;

            for (int i = 0; i < m2.Rows.Length; i++)
                if (m1.Rows[i] != m2.Rows[i])
                    return false;
            return true;
        }



        public static bool operator !=(Matrix<_Type> v1, Matrix<_Type> v2)
            => !(v1 == v2);

        public override int GetHashCode()
        {
            int code = 0;
            foreach(var row in this.Rows)
                code ^= row.GetHashCode();

            return code;
        }

        public string ToString()
        {
            string s = "[\n";
            for (int i = 0; i < Rows.Length; i++)
            {
                s = s + Rows[i].ToString();
                if (i != Rows.Length - 1)
                    s = s + ",";
                s += "\n";
            }
            return s + "]";
        }

    }
}
