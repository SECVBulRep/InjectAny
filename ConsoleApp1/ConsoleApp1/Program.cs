
using System.Reflection;
using System.Runtime.CompilerServices;

Test.Static();



var source =  typeof(C1).GetMethod("Method1");
var dest = typeof(C2).GetMethod("Method2");


IlligalOverride(source, dest);

unsafe void IlligalOverride(MethodBase source, MethodBase dest) {

    // для гарантированного jit
    RuntimeHelpers.PrepareMethod(source.MethodHandle);
    RuntimeHelpers.PrepareMethod(dest.MethodHandle);

    var fp1 = source.MethodHandle.GetFunctionPointer();
    var fp2 = source.MethodHandle.GetFunctionPointer();


    var f1Ptr = (byte*)fp1.ToPointer();
    var f2Ptr = (byte*)fp2.ToPointer();

}


sealed class C1 { 
    public  void Method1(int i) {
        Console.WriteLine("Method1");
    }
}


sealed class C2
{
    public void Method2(int i)
    {
        Console.WriteLine("Method2");
    }
}



public class Test() {

    public static void Static() { 
    }
}