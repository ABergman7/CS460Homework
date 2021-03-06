---
title: Homework 3
layout: default
---

# Software Engineering Homework
## Homework 3



For this homework we are tasked with downloading and setting up Visual Studios Community edition, followed with translating a Java program to C#. This particular program does a binary translation of a given integer n, and print the value in binary as well as the binary values of previous integers before n. The importance of this this project was to learn C# and it's similarities, but also it differences, with Java.

1. [Assignment](http://www.wou.edu/~morses/classes/cs46x/assignments/HW3_1819.html)
2. [Repo](https://github.com/ABergman7/ABergman7.github.io/tree/master/HW3)





## Branching
Just like homework 2, for this homework (and for the rest) we were tasked with creating another feature branch.
```bash
git branch HW3
git checkout master
git add .
git commit -m "setting up merge for hw3"
git push origin master
```


## .gitignore
 
 Since there are quite a bit of things popping up while working with visual studios, we were tasked with making a .gitignore. That way we could see the actual code that we were working on during our commits, rather than all of the adjustments and compilations from visual studios.


## Installing Visual Studios

I took the liberty of not only installing the .NET desktop development workload but as well as some of the other workloads that I think I will need for web development later on. For example, the Node.js development.


## The Java Program

 I used the Eclipse IDE that I already had from Java programming in previous classes. I ran the program, however, from the command line since I am a bit more comfortable with compiling and running programs from there. Here is an example of the Java code executing: 
 
 ![Picture](Pictures/JavaExe.PNG)
 

 
## Translating
 
 It's important to note that before I started I went and took a look at the [Naming Guidlines](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines) and the [Code Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions) prior to translating. 
 
 After reviewing the code, I began to hammer out the Node class. Below is the Java code of the Node class and the translation to C#.
 
### Java:
 ```java
    /** Singly linked node class. */

    public class Node<T>
    {
	   public T data;
	   public Node<T> next;
	
	   public Node( T data, Node<T> next )
	   {
		  this.data = data;
		  this.next = next;
	   }
    }

```
### C#
```csharp
    /// <summary>
    /// The class for the Node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public T data;
        public Node<T> next;

        /// <summary>
        /// Setting up the Node with the inputs
        /// </summary>
        /// <param name="data"></param>
        /// <param name="next"></param>
        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }
    }
    
```
Not too much of a difference here, and as a person coming from a Java background it was quite relieving. What is nice to note here is the XML short cut is incredibly handy and easy to use for documentaiton all it takes to generate is typing ///


Well enough of the similarities lets look at the differences! One specific class that I want to talk about is the LinkedQueue class, and to save space lets look at the push() method.

### Java

```java
    public T push(T element)
	   { 
		  if( element == null )
          {
			 throw new NullPointerException();
		  }
		
		  if( isEmpty() )
		  {
			 Node<T> tmp = new Node<T>( element, null );
			 rear = front = tmp;
		  }
		  else
		  {		
			 // General case
			 Node<T> tmp = new Node<T>( element, null );
			 rear.next = tmp;
			 rear = tmp;
          }
        return element;
	}
```
### C#

```csharp
    public T Push(T element)
    {
        if (element == null)
        {
            throw new NullReferenceException();
        }
        if (IsEmpty())
        {
            Node<T> tmp = new Node<T>(element, null);
            rear = front = tmp;
        }
        else
        {
            Node<T> tmp = new Node<T>(element, null);
            rear.next = tmp;
            rear = tmp;
        }
        return element;
    }
 ```
 Let's start with the the name of the method. In C#'s naming conventions it is important for programmers to name their methods,  Classes, and Interface's with captal letters. As stated from our naming conventions guide, "This distinguishes type names from methods"
 
 Now let's take a look at the exceptions, Java and C# have differently used Exceptions, in this case Java is throwing a NullPointerException, whereas C# is throwing a NullReferenceException. 
 
 Since we are talking about exceptions, lets take a look at the custum exception classes: 
### Java
```java
public class QueueUnderflowException extends RuntimeException
{
  public QueueUnderflowException()
  {
    super();
  }

  public QueueUnderflowException(String message)
  {
    super(message);
  }
}
```
### C#
```csharp
/// <summary>
/// The class that handles underflow for the queue
/// </summary>
public class QueueUnderflowException : Exception
{
    public  QueueUnderflowException(string message) : base(message) { }

}
```

As you can tell, the Java class looks way more tedious to write up than the C# class! With C# instead of writing "extends" you get to simply use the : operator. Which does a broad spectrum of nifty things. In this case the : operator is used twice, but for different reasons. In the class name it is used to extend the Exception class, whereas the second time it is being used as a "goto" label.

To knock out two birds with one stone I want to take a look at the for-each loop in Main.java and TestClass.cs, and focus on the syntax and of the different loops, as well as printing. 

### Java
```java
for(String s : output)
        {
            for(int i = 0; i < maxLength - s.length(); ++i)
            {
                System.out.print(" ");
            }
            System.out.println(s);
        }
```
### C#
```csharp
foreach(string s in output)
        {
            for(int i = 0; i < maxLength - s.Length; ++i)
            {
                Console.Write(" ");
            }
            Console.WriteLine(s);
        }
```

Looking at the above code, the first thing I noticed was how amazingly readable the "for-each" loop in C# was compared to Java's. Stepping inside, the for loop almost looks completly identical. There is, however, a difference in using the .length() method for the string. In order for c# to manipulate any kind of comparison the method doesn't use the () at the end. Also, for printing output C# uses Console.Write() and Console.WriteLine().


## Final Output

![Picture](Pictures/CSharpExe.PNG)



## Closing Thoughts

I had an amazing time learning C#. It helps that I came from a Java background since the two share so many simularities. My favorite thing about C# is the readability, I find it easier to step through than any other language that I have coded so far. (Except SQL :)).
 
 
 