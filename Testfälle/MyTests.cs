using NUnit.Framework;

namespace Testfälle
{

    // Ausführen von Test über den Testexplorer: Ctrl + E, T


    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TryToConvertText()
        {
            string sourceValue = "Max, True";


            Student studentInstance = null; // null hier nur als Standardinitialisierung

            // .. das soll in eine Instanz von Student umgewandelt werden ...

            Assert.IsNotNull(studentInstance); // hier wird ein Fehler angezeigt, weil studentInstance = null ist.

        }
    }
}