# LSJ.
using System;
class BaseClass {
public BaseClass() {
Console.WriteLine("BaseClass Constructor ...");
}
}
class DerivedClass : BaseClass {
public DerivedClass() {
Console.WriteLine("DerivedClass Constructor ...");
}
}
class DerivedConstructorApp {
public static void Main() {
DerivedClass obj = new DerivedClass();
Console.WriteLine("in main ...");
}
}

.
.
.
.
.
.
.
.
.
using System;
class BaseClass {
protected int a = 1;
protected int b = 2;
}
class DerivedClass : BaseClass {
new int a = 3;
new double b = 4.5;
public void Output() {
Console.WriteLine("BaseClass:a={0}, DerivedClass:a={1}", base.a, a);
Console.WriteLine("BaseClass:b={0}, DerivedClass:b={1}", base.b, b);
}
}

class HiddenNameApp {
public static void Main() {
DerivedClass obj = new DerivedClass();
obj.Output();
}
}
.
.
.
.
.
.
.
.
