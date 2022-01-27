using Microsoft.VisualStudio.TestTools.UnitTesting;
using tinyTransaction;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TDocument document = new TDocument();
            var trans = document.GetTransaction(" ¬ŒÒ≤‚ ‘");
            trans.Start();
            if (1 == 1)
            {
                trans.Commit();
            }
            else
            {
                trans.RoalBack();
            }
        }
    }
}
