using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace A6
{
    public struct TypeOfSize5
    {        
        public byte b1;
        public byte b2;
        public byte b3;
        public byte b4;
        public byte b5;
    }
    public struct TypeOfSize22
    {
        public TypeOfSize5 i1;
        public TypeOfSize5 i2;
        public TypeOfSize5 i3;
        public TypeOfSize5 i4;        
        public byte b1;
        public byte b2;
    }
    public struct TypeOfSize125
    {
        TypeOfSize22 t1;
        TypeOfSize22 t2;
        TypeOfSize22 t3;
        TypeOfSize22 t4;
        TypeOfSize22 t5;         
        public TypeOfSize5 b1;
        public TypeOfSize5 b2;
        public TypeOfSize5 b3;
    }
    public struct TypeOfSize1024
    {                       
        TypeOfSize125 t1;
        TypeOfSize125 t2;
        TypeOfSize125 t3;
        TypeOfSize125 t4;
        TypeOfSize125 t5;
        TypeOfSize125 t6;
        TypeOfSize125 t7;
        TypeOfSize125 t8;
        TypeOfSize22 t122;
        public byte b1;
        public byte b2;
    }
    public struct TypeOfSize2048
    {
        TypeOfSize1024 t1;
        TypeOfSize1024 t2;
    }
    public struct TypeOfSize4096
    {
        TypeOfSize2048 t1;
        TypeOfSize2048 t2;
    }
    public struct TypeOfSize8192
    {
        TypeOfSize2048 t1;
        TypeOfSize2048 t2;
    }
    public struct TypeOfSize1000
    {
        TypeOfSize125 t1;
        TypeOfSize125 t2;
        TypeOfSize125 t3;
        TypeOfSize125 t4;
        TypeOfSize125 t5;
        TypeOfSize125 t6;
        TypeOfSize125 t7;
        TypeOfSize125 t8;
    }
    public struct TypeOfSize10000
    {
        TypeOfSize1000 t1;
        TypeOfSize1000 t2;
        TypeOfSize1000 t3;
        TypeOfSize1000 t4;
        TypeOfSize1000 t5;
        TypeOfSize1000 t6;
        TypeOfSize1000 t7;
        TypeOfSize1000 t8;
        TypeOfSize1000 t9;
        TypeOfSize1000 t10;
    }
    public struct TypeOfSize32768
    {
        TypeOfSize10000 t100001;
        TypeOfSize10000 t100002;
        TypeOfSize10000 t100003;
        TypeOfSize1000 t10001;
        TypeOfSize1000 t10002;
        TypeOfSize125 t125_1;
        TypeOfSize125 t125_2;
        TypeOfSize125 t125_3;
        TypeOfSize125 t125_4;
        TypeOfSize125 t125_5;
        TypeOfSize125 t125_6;
        TypeOfSize5 t1;
        TypeOfSize5 t2;
        TypeOfSize5 t3;
        public byte b1;
        public byte b2;
        public byte b3;
    }
    public struct TypeForMaxStackOfDepth10
    {
        TypeOfSize32768 t1;
        TypeOfSize8192 t2;
        TypeOfSize4096 t3;

    }
    public struct TypeForMaxStackOfDepth100
    {
        TypeOfSize1000 t1;
        TypeOfSize1000 t2;
        TypeOfSize1000 t3;
        TypeOfSize1000 t4;
        TypeOfSize1000 t5;
    }
    public struct TypeForMaxStackOfDepth1000
    {
        TypeOfSize125 a;
        TypeOfSize125 b;
        TypeOfSize125 c;
        TypeOfSize125 d;
    }
    public struct TypeForMaxStackOfDepth3000
    {
        TypeOfSize125 a;        
    }
    public struct StructOrClass1
    {
        public int X;
    }
    public class StructOrClass2
    {
        public int X;
    }
    public class StructOrClass3
    {
        public StructOrClass2 X;
    }
    public enum FutureHusbandType : int
    {
        None = 0,
        HasBigNose = 1,
        IsBald = 2,
        IsShort = 4
    }    
    public class TypeWithMemoryOnHeap
    {
        List<object> a = new List<object>();        
        public void Allocate()
        {
            for (int i = 0; i < 250000; i++)
                a.Add(new object());
        }
        public void DeAllocate()
        {
            a = null;
        }
    }
    public class Program
    {
        public static int GetObjectType(object o)
        {
            
            if (o is string)
                return 0;
            else if (o is int)
                return 2;
           else
                return 1;
        }
        public static bool IdealHusband(FutureHusbandType fht)
        {
            int t = 0;
            if ((fht & FutureHusbandType.HasBigNose) == FutureHusbandType.HasBigNose)
                t++;
            if ((fht & FutureHusbandType.IsBald) == FutureHusbandType.IsBald)
                t++;
            if ((fht & FutureHusbandType.IsShort) == FutureHusbandType.IsShort)
                t++;                                        
            if (t == 2)
                return true;            
            return false;
        }
        public static void Main(string[] args)
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            var memSize = GC.GetTotalMemory(true);
            TypeWithMemoryOnHeap r = new TypeWithMemoryOnHeap();
            r.Allocate();
            Console.WriteLine(memSize);


            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);

            Console.WriteLine(GC.GetTotalMemory(true));
        }
    }
}
