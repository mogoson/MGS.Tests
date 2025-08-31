using NUnit.Framework;
using UnityEngine;

[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.reflection.typeattributes?view=netstandard-2.1#system-reflection-typeattributes-beforefieldinit")]
public class BeforeFieldInitTest
{
    //TypeAttributes/BeforeFieldInit

    #region BeforeFieldInit
    //C# compiler mark BeforeFieldInit for the static type that with default constructor.
    static class ClassWithDefaultConstructor
    {
        public static int int0 = GetInt0();

        static int GetInt0()
        {
            Debug.Log("static class init field.");
            return 0;
        }
    }

    [Test]
    public void BeforeFieldInitTest0()
    {
        Debug.Log("Visit static class that with default costructor.");
        var int0 = ClassWithDefaultConstructor.int0;
        Debug.Log("Init fields before visit static class that with default costructor.");
    }
    #endregion

    #region Not BeforeFieldInit
    //C# compiler do not mark BeforeFieldInit for the static type that with explicit define constructor.
    static class ClassWithExplicitConstructor
    {
        public static int int0 = GetInt0();

        static ClassWithExplicitConstructor()
        {
            Debug.Log("static class run explicit define constructor.");
        }

        static int GetInt0()
        {
            Debug.Log("static class init field.");
            return 0;
        }
    }

    [Test]
    public void NotBeforeFieldInitTest()
    {
        Debug.Log("Visit static class that with explicit define costructor.");
        var int0 = ClassWithExplicitConstructor.int0;
        Debug.Log("Init fields when visit static class that with explicit define costructor.");
    }
    #endregion
}