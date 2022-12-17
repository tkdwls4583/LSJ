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
.
.
using System;
class BaseClass {
public int a, b;
public BaseClass() { // 기본 생성자
a = 1; b = 1;
}
public BaseClass(int a, int b) { // 중복 정의된 생성자
this.a = a; this.b = b;
}
}
class DerivedClass : BaseClass {
public int c;
public DerivedClass() {
c = 1;
}
public DerivedClass(int a, int b, int c) : base(a, b) {
this.c = c;
}
}
class BaseCallApp {
public static void Main() {
DerivedClass obj1 = new DerivedClass();
DerivedClass obj2 = new DerivedClass(1, 2, 3);
Console.WriteLine("a={0}, b={1}, c={2}", obj1.a, obj1.b, obj1.c);
Console.WriteLine("a={0}, b={1}, c={2}", obj2.a, obj2.b, obj2.c);
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
.
.
.
.
.
using System;
class BaseClass {
public void MethodA() {
Console.WriteLine("In BaseClass ...");
}
}
class DerivedClass : BaseClass {
new public void MethodA() { // Overriding(재정의) : 시그니처가 동일
Console.WriteLine("In DerivedClass ... Overriding !!!");
}
public void MethodA(int i) { // Overloading(중복) : 시그니처가 다름
Console.WriteLine("In DerivedClass ... Overloading !!!");
}
}
class OverridingAndOverloadingApp {
public static void Main() {
BaseClass obj1 = new BaseClass();
DerivedClass obj2 = new DerivedClass();
obj1.MethodA();
obj2.MethodA(); // 인자 없는 호출
obj2.MethodA(1); // 인자 있는 호출
}
}
.
.
.
.
