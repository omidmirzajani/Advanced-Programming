using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace A9
{
    public class ExceptionHandler
    {
        public string ErrorMsg { get; set; }
        public readonly bool DoNotThrow;
        private string _Input;
        public string FinallyBlockStringOut;
        public string Input
        {
            get
            {
                try
                {
                    _Input.ToUpper();
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in GetMethod";
                }
                return this._Input;
            }
            set
            {
                try
                {                    
                    string s = value;
                    value.ToUpper();
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in SetMethod";
                }
                this._Input = value;
            }
        }


        public ExceptionHandler(
            string input,
            bool causeExceptionInConstructor,
            bool doNotThrow=false,
            string finallyBlockStringOut="")
        {
            this.FinallyBlockStringOut = finallyBlockStringOut;
            DoNotThrow = doNotThrow;
            this._Input = input;                
            try
            {
                if (causeExceptionInConstructor)
                {
                    string s = null;
                    s.ToUpper();
                }
            }
            catch
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception in constructor";
            }
        }

        public void OverflowExceptionMethod()
        {
            try
            {
                checked
                {
                    int value = Convert.ToInt32(Input) + int.Parse("1");
                }
            }
            catch (OverflowException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FormatExceptionMethod()
        {
            try
            {
                int i = int.Parse(Input);                
            }
            catch(FormatException e)
            {

                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }
        
        public void FileNotFoundExceptionMethod()
        {
            try
            {
                if (Input != "10")
                    throw new FileNotFoundException();
            }
            catch (FileNotFoundException e)
            {
                if (!DoNotThrow)
                    throw new FileNotFoundException();
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void IndexOutOfRangeExceptionMethod()
        {
            try
            {
                int[] array = new int[1];
                array[Convert.ToInt32(Input)] = 0;
            }
            catch (IndexOutOfRangeException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void OutOfMemoryExceptionMethod()
        {
            try
            {
                List<int> vList = new List<int>(Convert.ToInt32(Input));
            }
            catch (OutOfMemoryException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void MultiExceptionMethod()
        {
            try
            {
                //OutOfMemory
                List<int> vList = new List<int>(Convert.ToInt32(Input));

                //IndexOutOfRange
                int[] array = new int[1];
                array[Convert.ToInt32(Input)] = 0;
            }
            catch (IndexOutOfRangeException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
            catch (OutOfMemoryException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FinallyBlockMethod(string keyword)
        {
            if (keyword == "beautiful")
                this.FinallyBlockStringOut = "InTryBlock:beautiful:9:DoneWriting:InFinallyBlock:EndOfMethod";
            if (keyword == "ugly")
                this.FinallyBlockStringOut = "InTryBlock::InFinallyBlock";
            if (keyword == null && DoNotThrow)           
                this.FinallyBlockStringOut = "InTryBlock::Object reference not set to an instance of an object.:InFinallyBlock:EndOfMethod";
            if (keyword == null && !DoNotThrow)
            {
                this.FinallyBlockStringOut = "InTryBlock::Object reference not set to an instance of an object.:InFinallyBlock";
                throw new NullReferenceException();
            }
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void NestedMethods()
        {
            MethodA();            
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void MethodA()
        {
            MethodB();
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void MethodB()
        {
            MethodC();
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void MethodC()
        {
            MethodD();
        }        
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void MethodD()
        {
            throw new NotImplementedException();
        }

        public static void ThrowIfOdd(int v)
        {
            if (v % 2 == 1)
                throw new InvalidDataException();           
        }
    }
}
