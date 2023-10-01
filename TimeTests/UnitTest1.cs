using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TimeLib;

namespace TimeTests
{
    [TestClass]
    public class UnitTest1
    {
        public class ConsoleRedirectionToStringWriter : IDisposable
        {
            private StringWriter stringWriter;
            private TextWriter originalOutput;

            public ConsoleRedirectionToStringWriter()
            {
                stringWriter = new StringWriter();
                originalOutput = Console.Out;
                Console.SetOut(stringWriter);
            }

            public string GetOutput()
            {
                return stringWriter.ToString();
            }

            public void Dispose()
            {
                Console.SetOut(originalOutput);
                stringWriter.Dispose();
            }
        }

        /*******Time***********/

        [TestMethod]
        public void TimeDifferentSyntaxTest()
        {
            Time t1 = new Time("15:00");
            Time t2 = new Time("15:00:00");
            Time t3 = new Time("15");
            Time t4 = new Time(15, 0, 0);
            Time t5 = new Time(15, 0);
            Time t6 = new Time(15);

            Assert.AreEqual(t1.ToString(), t2.ToString(), t3.ToString(),
                t4.ToString(), t5.ToString(), t6.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Wrong syntax")]
        public void WrongTimeByte()
        {
            Time t1 = new Time(25, 70, 60);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Wrong syntax")]
        public void WrongTimeString()
        {
            Time t1 = new Time("24:60:120");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Wrong syntax")]
        public void WrongTimeSyntax()
        {
            Time t1 = new Time("00000:-50:aaaa");
        }

        [TestMethod]
        public void TimeEquals()
        {
            Time t1 = new Time("14:39:28");
            Time t2 = new Time(14, 39, 28);

            Assert.IsTrue(t1 == t2);
        }

        [TestMethod]
        public void TimeRelations()
        {
            Time t1 = new Time("0:15:25");
            Time t2 = new Time(10, 10, 10);

            Assert.IsTrue(t1 < t2);
        }

        [TestMethod]
        public void TimeRelations2()
        {
            Time t1 = new Time("0:0:2");
            Time t2 = new Time(0,0,3);

            Assert.IsTrue(t1 < t2);
        }

        [TestMethod]
        public void TimePlusPeriod()
        {
            Time t1 = new Time("20:00:00");
            TimePeriod tp = new TimePeriod(30,30);
            Time t2 = t1.Plus(tp);

            Assert.IsTrue(t2.ToString().Contains("2:30"));
        }

        [TestMethod]
        public void TimeMinusPeriod()
        {
            Time t1 = new Time("8:00:00");
            TimePeriod tp = new TimePeriod(30, 30);
            Time t2 = t1.Minus(tp);

            Assert.IsTrue(t2.ToString().Contains("1:30"));
        }


        /*******TimePeriod***********/

        [TestMethod]
        public void TimePeriodDifferentSyntaxTest()
        {
            TimePeriod tp1 = new TimePeriod(3600);
            TimePeriod tp2 = new TimePeriod(1,0);
            TimePeriod tp3 = new TimePeriod(1,0,0);
            TimePeriod tp4 = new TimePeriod(new Time(1), new Time(2));
            TimePeriod tp5 = new TimePeriod("1:0");

            Assert.AreEqual(tp1.ToString(), tp2.ToString(), tp3.ToString(), tp4.ToString(), tp5.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Wrong syntax")]
        public void WrongTimePeriodSyntax()
        {
            TimePeriod tp = new TimePeriod("-5:-1:00");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Wrong syntax")]
        public void WrongTimePeriodSyntax2()
        {
            TimePeriod tp = new TimePeriod("aa:::00");
        }

        [TestMethod]
        public void TimePeriodRecalculation()
        {
            TimePeriod tp = new TimePeriod(120, 60, 70);

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();

            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                Console.WriteLine(tp.ToString());
                Assert.IsTrue(consoleOutput.GetOutput().Contains("121:01:10"));
            }
        }

        [TestMethod]
        public void TimePeriodEquals()
        {
            TimePeriod tp1 = new TimePeriod("75:33:56");
            TimePeriod tp2 = new TimePeriod(75,33,56);

            Assert.IsTrue(tp1 == tp2);
        }

        [TestMethod]
        public void TimePeriodRelations()
        {
            TimePeriod tp1 = new TimePeriod("15:30:00");
            TimePeriod tp2 = new TimePeriod(20, 10, 10);

            Assert.IsTrue(tp1 < tp2);
        }

        [TestMethod]
        public void TimePeriodRelations2()
        {
            TimePeriod tp1 = new TimePeriod("15:30:30");
            TimePeriod tp2 = new TimePeriod(15, 29, 100);

            Assert.IsTrue(tp1 < tp2);
        }

        [TestMethod]
        public void TimePeriodAdd()
        {
            TimePeriod tp1 = new TimePeriod(30, 50);
            TimePeriod tp2 = new TimePeriod("10:10:10");
            TimePeriod tp = tp1 + tp2;

            Assert.IsTrue(tp.ToString().Contains("41:00:10"));
        }


        [TestMethod]
        public void TimePeriodSub()
        {
            TimePeriod tp1 = new TimePeriod(30, 50);
            TimePeriod tp2 = new TimePeriod("10:60:10");
            TimePeriod tp = tp1 - tp2;

            Assert.IsTrue(tp.ToString().Contains("19:49:50"));
        }

        [TestMethod]
        public void TimePeriodSub2()
        {
            TimePeriod tp1 = new TimePeriod(0, 50);
            TimePeriod tp2 = new TimePeriod("10:60:10");
            TimePeriod tp = tp1 - tp2;

            Assert.IsTrue(tp.ToString().Contains("0:00:00"));
        }

        [TestMethod]
        public void TimePeriodDiv()
        {
            TimePeriod tp1 = new TimePeriod(30, 50);
            TimePeriod tp = tp1 / 5;

            Assert.IsTrue(tp.ToString().Contains("6:10"));
        }

        [TestMethod]
        public void TimePeriodMulti()
        {
            TimePeriod tp1 = new TimePeriod(30, 30);
            TimePeriod tp = tp1 * 5;

            Assert.IsTrue(tp.ToString().Contains("152:30"));
        }

        [TestMethod]
        public void TimePeriodMinus()
        {
            TimePeriod tp1 = new TimePeriod(30, 50);
            TimePeriod tp2 = tp1.Minus(new TimePeriod("10:60:10"));

            Assert.IsTrue(tp2.ToString().Contains("19:49:50"));
        }

        [TestMethod]
        public void TimePeriodPlus()
        {
            TimePeriod tp1 = new TimePeriod(30, 50);
            TimePeriod tp2 = tp1.Plus(new TimePeriod("10:10:10"));

            Assert.IsTrue(tp2.ToString().Contains("41:00:10"));
        }

        [TestMethod]
        public void TimePeriodPlusPlus()
        {
            TimePeriod tp1 = new TimePeriod(30, 50);
            tp1++;

            Assert.IsTrue(tp1.ToString().Contains("31:50"));
        }

        [TestMethod]
        public void TimePeriodMinusMinus()
        {
            TimePeriod tp1 = new TimePeriod(0, 30);
            tp1--;

            Assert.IsTrue(tp1.ToString().Contains("0:00:00"));
        }

    }
}