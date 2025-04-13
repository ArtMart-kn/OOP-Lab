using System;
class Clas{
    public virtual string Override=>"Class: Override";
    public string Hide=>"Class: Hide";
}

class Diff : Clas{
    public override string Override=>"DiffClass: Override";
    public new string Hide=>"DiffClass: Hide";
}
class Program{
    static void Main(){
        Clas clasObj=new Clas();
        Diff diffObj=new Diff();
        Clas refclasObj=new Diff();
        Console.WriteLine(clasObj.Override);
        Console.WriteLine(clasObj.Hide);
        
        Console.WriteLine(diffObj.Override);
        Console.WriteLine(diffObj.Hide);
        
        Console.WriteLine(refclasObj.Override);
        Console.WriteLine(refclasObj.Hide);
    }
}
