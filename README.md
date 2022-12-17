# LSJ.
using System;
abstract class AbstractClass {
public abstract void MethodA(); // virtual 수정자 의미 포함
public void MethodB() {
Console.WriteLine("Implementation of MethodB()");
}
}
class ImpClass : AbstractClass {
override public void MethodA () { // 추상 메소드 구현
Console.WriteLine("Implementation of MethodA()");
}
}
class AbstractClassApp {
public static void Main() {
ImpClass obj = new ImpClass();
obj.MethodA();
obj.MethodB();
}
}

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

using System;
class BaseClass {
virtual public void MethodA() {
Console.WriteLine("Base MethodA");
}
virtual public void MethodB() {
Console.WriteLine("Base MethodB");
}
virtual public void MethodC() {
Console.WriteLine("Base MethodC");
}
}
class DerivedClass : BaseClass {
new public void MethodA() {
Console.WriteLine("Derived MethodA");
}
override public void MethodB() {
Console.WriteLine("Derived MethodB");
}
public void MethodC() {
Console.WriteLine("Derived MethodC");
}
}
class VirtualMethodApp {
public static void Main() {
BaseClass s = new DerivedClass(); // 부모 클래스 참조 변수 = 파생클래스 객체
s.MethodA(); // s 객체의 MathodA()가 호출 (new로 재정의 경우)
s.MethodB(); // s가 가리키는 객체(파생클래스)의 MethodB()가 호출 (다형성)(override로 재정의)
s.MethodC(); // s 객체의 MathodC()가 호출
}
}.
.
.
.
.
.
.
using System;
class BaseClass
{
virtual public void MethodA()
// public void MethodA()
{
Console.WriteLine("do BaseClass Task.");
}
}
class DerivedClass : BaseClass
{
// new public void MethodA()
override public void MethodA()
{
base.MethodA(); // 부모 클래스의 Method A()호출
Console.WriteLine("do DerivedClass Task.");
}
}
class AddendumApp
{
public static void Main()
{
DerivedClass obj = new DerivedClass(); // up casting 이 아님
obj.MethodA(); // DerivedClass의 methodA()호출
}
}

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
class Program
{
static void Main(string[] args)
{
Employee employee=null;
employee = new Manager(); // upcasting
Console.WriteLine(employee.GetType().ToString());
employee.Work();
// employee.Manage(); // can't access Manage()
Manager manager = (Manager)employee; // downcasting
manager.Manage(); // can access Manage()
Console.ReadKey();
}
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

using System;
class BaseClass {
public virtual void Output() {
Console.WriteLine("In the Base class ...");
}
}
class DerivedClass : BaseClass {
public override void Output() {
Console.WriteLine("In the Derived class ...");
}
}
class PolymorphismApp {
static void Print(BaseClass obj) {
obj.Output();
}
public static void Main() {
BaseClass obj1 = new BaseClass();
DerivedClass obj2 = new DerivedClass();
Print(obj1);
Print(obj2);
}
}.
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
.
.
.
.
.
using System;
namespace overriding_console_1
{
class Parent
{
// public virtual int variable = 273; // // 오류 : override 사용 불가
public int variable = 273;
public virtual void Method()
{
Console.WriteLine("부모의 메소드");
Console.WriteLine("variable ={0}", variable);
}
}
..
.
.
.
.
..
.
class Child : Parent
{
// public override string variable = "overriding"; // 오류 : override 사용 불가
public new string variable = "overriding"; // default : new
public override void Method()
{
Console.WriteLine("자식의 메소드");
base.Method();
Console.WriteLine("base: variable ={0}", base.variable);
Console.WriteLine("variable ={0}", variable);
}
static void Main(string[] args)
{
Child child = new Child();
child.Method();
((Parent)child).Method(); // parent가 아닌 child의 method()가 호출됨
}
}
}
override
..
.
.
.
.


using System;
class BaseClass {
public virtual void Output() {
Console.WriteLine("In the Base class ...");
}
}
class DerivedClass : BaseClass {
public override void Output() {
Console.WriteLine("In the Derived class ...");
}
}
class PolymorphismApp {
static void Print(BaseClass obj) {
obj.Output();
}
public static void Main() {
BaseClass obj1 = new BaseClass();
DerivedClass obj2 = new DerivedClass();
Print(obj1);
Print(obj2);
}
}.
.
.
.
.
.
.
using System;
class BaseClass {
public void MethodA() {
Console.WriteLine("do BaseClass Task.");
}
}
class DerivedClass : BaseClass {
new public void MethodA() {
base.MethodA(); // 부모 클래스의 Method A()호출
Console.WriteLine("do DerivedClass Task.");
}
}
class AddendumApp {
public static void Main() {
DerivedClass obj = new DerivedClass();
obj.MethodA(); // DerivedClass의 methodA()호출
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
using System;
class CLanguage {
public bool Equal(object obj) {
if (obj is CLanguage) return true;
else return false;
}
}
class CSharp : CLanguage {
new public bool Equal(object obj) {
return (obj is CSharp) ? true : false;
}
}
public class ClassTypeConversionApp {
public static void Main() {
CLanguage c = new CLanguage();
CSharp cs = new CSharp();
if (c.Equal(cs)) Console.WriteLine("casting up is valid.");
else Console.WriteLine("casting up is not valid.");
if (cs.Equal(c)) Console.WriteLine("casting down is valid.");
else Console.WriteLine("casting down is not valid.");
}
}

.
.
.
.
using System;
class CLanguage {
virtual public void Print() {
Console.WriteLine("In the Clanguage class ...");
}
}
class Java : CLanguage {
override public void Print() {
Console.WriteLine("In the Java class ...");
}
}
class VirtualAndOverrideApp {
public static void Main() {
CLanguage c = new Java(); // base class 참조 = derived class 객체(상향 캐스팅)
c.Print();
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
namespace polymorphism_1
{
class Employee
{
public virtual void Work()
{
Console.WriteLine("I am an employere.");
}
}
class Manager : Employee
{
public override void Work()
{
Console.WriteLine("I am a manager.");
}
public void Manage()
{
Console.WriteLine("Managing ....");
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
using System;
public interface IControl
{
void Paint();
}
public interface ISurface
{
void Paint();
}
public class SampleClass : IControl, ISurface
{
// Both ISurface.Paint and IControl.Paint call this method.
public void Paint()
{
Console.WriteLine("Paint method in SampleClass");
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
using System;
public interface IControl
{
void Paint();
}
public interface ISurface
{
void Paint();
}
public class SampleClass : IControl, ISurface
{
void IControl.Paint()
{
System.Console.WriteLine("IControl.Paint");
}
void ISurface.Paint()
{
System.Console.WriteLine("ISurface.Paint");
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
