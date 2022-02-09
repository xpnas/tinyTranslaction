using Microsoft.VisualStudio.TestTools.UnitTesting;
using tinyTransaction;
using tinyTransaction.Entites;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TDocument document = new TDocument();
            using (TTransaction t1 = document.GetTransaction("1������"))
            {
                var del = new GclZhu("��D", 1, 1, 1);

                document.AddEntity(del);

                using (TTransaction t2 = t1.GetTransaction("2������1"))
                {
                    document.AddEntity(new GclZhu("��2", 1, 1, 1));

                    using (TTransaction t3 = t2.GetTransaction("3������1"))
                    {
                        document.AddEntity(new GclZhu("��3", 1, 1, 1));

                        using (TTransaction t4 = t3.GetTransaction("4������"))
                        {
                            document.AddEntity(new GclZhu("��4", 1, 1, 1));

                            using (TTransaction t5 = t4.GetTransaction("5������"))
                            {
                                document.AddEntity(new GclZhu("��4", 1, 1, 1));

                                using (TTransaction t6 = t5.GetTransaction("6������"))
                                {
                                    document.AddEntity(new GclZhu("��4", 1, 1, 1));
                                }

                                document.RemoveEntity(del);
                                var zhuListInTrans = document.OfType<GclZhu>();
                                Assert.AreEqual(zhuListInTrans.Count, 5);
                            }

                            t4.RoalBack();

                            var t4List= document.OfType<GclZhu>();
                            Assert.AreEqual(t4List.Count, 3);
                        }
                    }

                    t2.RoalBack();
                    var zhuListInTransOnRoalBack = document.OfType<GclZhu>();
                    Assert.AreEqual(zhuListInTransOnRoalBack.Count, 1);
                }

                using (TTransaction t2 = t1.GetTransaction("2������2"))
                {
                    document.AddEntity(new GclZhu("��4", 1, 1, 1));

                    using (TTransaction t3 = t2.GetTransaction("2������2"))
                    {
                        document.AddEntity(new GclZhu("��5", 1, 1, 1));
                    }
                }

                using (TTransaction t2 = t1.GetTransaction("2������3"))
                {
                    document.AddEntity(new GclQiang("ǽ", 1));
                }
            }
            var qList = document.OfType<GclQiang>();
            var zhuList = document.OfType<GclZhu>();
            document.Save();
            Assert.AreEqual(qList.Count,1);
            Assert.AreEqual(zhuList.Count, 3);
        }
    }
}
