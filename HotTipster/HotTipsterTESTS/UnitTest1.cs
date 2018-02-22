﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using HotTipster;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;



namespace HotTipsterTESTS
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // Test to confirm bool true if file exists
        public void Test_BinaryWriter_1_ExistingFile()
        {
            //arrange            
            File.Create(@"C:\dbs\my1stBinaryFile.bin");

            // act         
            bool result = MyFileIO.CheckFileExists("my1stBinaryFile.bin");

            //assert
            bool expected = true;
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        // Test to confirm bool false if no file exists
        public void Test_BinaryWriter_2_NonexistentFile()
        {
            //arrange            

            // act         
            bool result = MyFileIO.CheckFileExists("myNonexistentFile.bin");

            //assert
            bool expected = false;
            Assert.AreEqual(expected, result);
        }
       


        [TestMethod]
        // Test to confirm bool true if new file has been created
        public void Test_BinaryWriter_3_TestForFileCreated()
        {
            //arrange      
            if (File.Exists(@"C:\dbs\testBinary1.bin"))
            {
                File.Delete(@"C:\dbs\testBinary1.bin");
            }
            // act         
            bool result = MyFileIO.CreateFileStream("testBinary1.bin");

            //assert
            bool expected = true;
            Assert.AreEqual(expected, result);
        }
        

        [TestMethod]
        // not working - [ExpectedException(typeof(System.NotSupportedException))]        
        // Test to confirm bool true if new file has been created
        public void Test_BinaryWriter_4_TestForFileCreatedExceptionThrown()
        {
            // act                     
            bool result = MyFileIO.CreateFileStream(@"Z:\dbs\testBinary1.bin");

            //assert(not working)
            // provided above by including   [ExpectedException(typeof(System.NotSupportedException))]

            //assert(working)
            bool expected = false;
            Assert.AreEqual(expected, result);
        }
        

        [TestMethod]
        public void HorseBet_1_Constructor()
        {
            //arrange          
            HorseBet horseBetTest = new HorseBet("Sandown", new DateTime(2017, 08, 07), 25.00m, false);

            // act         
            object result = horseBetTest.GetType();

            //assert
            object expected = typeof(HorseBet);
            Assert.AreEqual(expected, result);
        }
        

        [TestMethod]
        public void HorseBet_2_ToString()
        {
            //arrange          
            HorseBet horseBetTest = new HorseBet("Sandown", new DateTime(2017, 08, 07), 25.00m, false);

            // act         
            string result = "Sandown  07/08/2017  25.00  False";

            //assert
            string expected = horseBetTest.ToString();
            Assert.AreEqual(expected, result);
        }
        


        [TestMethod]
        public void Utility_ScreenDisplay()
        {
            //arrange 
            // act           
            bool result = Utility.ScreenDisplay();

            //assert
            bool expected = true;

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void SwitchMainLoop_1()
        {
            //arrange 
            // act           
            bool result = SwitchLoop.MainLoop("E");

            //assert
            bool expected = false;

            Assert.AreEqual(expected, result);
        }

        
        [TestMethod]
        public void SwitchMainLoop_2()
        {
            //arrange 
            // act           
            bool result = SwitchLoop.MainLoop("e");

            //assert
            bool expected = false;

            Assert.AreEqual(expected, result);
        }

        
        [TestMethod]
        public void SwitchMainLoop_3()
        {
            //arrange 
            // act           
            bool result = SwitchLoop.MainLoop("3");

            //assert
            bool expected = true;

            Assert.AreEqual(expected, result);
        }
        

        [TestMethod]
        public void SwitchMainLoop_4()
        {
            //arrange 
            // act           
            bool result = SwitchLoop.MainLoop("5");

            //assert
            bool expected = true;

            Assert.AreEqual(expected, result);
        }


        //-------------------------------------------------------------------------------------
        
        //Create list for result horsebetlist 
        public static List<HorseBet> horseBetList = new List<HorseBet>();
        //public static List<HorseBet> actual = new List<HorseBet>();

       [TestInitialize()]
        public void Initialize()           //CreateHorseBetListForTestClasses()
        {
            // clear horseBetList before reinitializing (otherwise list is appended AGAIN for each test!)
            horseBetList.Clear();
            HorseBet horseBet1 = new HorseBet("Goodwood", new DateTime(2016, 10, 25), 34.12m, true);
            HorseBet horseBet2 = new HorseBet("Dundalk", new DateTime(2016, 11, 09), 20.00m, false);
            HorseBet horseBet3 = new HorseBet("Haydock", new DateTime(2017, 01, 20), 15.00m, false);
            HorseBet horseBet4 = new HorseBet("Dublin", new DateTime(2017, 03, 06), 200, false);
            HorseBet horseBet5 = new HorseBet("Dublin", new DateTime(2018, 03, 06), 101.25m, true);
            HorseBet horseBet6 = new HorseBet("Galway", new DateTime(2018, 07, 06), 200, true);

            // Add horsebets to list
            horseBetList.Add(horseBet1);
            horseBetList.Add(horseBet2);
            horseBetList.Add(horseBet3);
            horseBetList.Add(horseBet4);
            horseBetList.Add(horseBet5);
            horseBetList.Add(horseBet6);
        }
        [TestMethod]
        public void DisplayAllBetsInDateOrder_1()
        {
            // Arrange  
            List<HorseBet> expectedList = new List<HorseBet>();

            // Create 6 new horsebets (same as above)
            //HorseBet horseBet6 = new HorseBet("Goodwood", new DateTime(2016, 10, 25), 34.12m, true);
            HorseBet horseBet5 = new HorseBet("Goodwood", new DateTime(2016, 10, 25), 34.12m, true);
            HorseBet horseBet6 = new HorseBet("Dundalk", new DateTime(2016, 11, 09), 20.00m, false);
            HorseBet horseBet7 = new HorseBet("Haydock", new DateTime(2017, 01, 20), 15.00m, false);
            HorseBet horseBet8 = new HorseBet("Dublin", new DateTime(2017, 03, 06), 200, false);
            HorseBet horseBet9 = new HorseBet("Dublin", new DateTime(2018, 03, 06), 101.25m, true);
            HorseBet horseBet10 = new HorseBet("Galway", new DateTime(2018, 07, 06), 200, true);

            // this time use chronological order (oldest to newest) to add horsebets to list
            expectedList.Add(horseBet5);
            expectedList.Add(horseBet6);
            expectedList.Add(horseBet7);
            expectedList.Add(horseBet8);
            expectedList.Add(horseBet9);
            expectedList.Add(horseBet10);

            //Act 
            List<HorseBet> actualList = (ReportingMethods.DisplayAllBetsInDateOrder(horseBetList));
            //actual = ReportingMethods.DisplayAllBetsInDateOrder(horseBetList);    // list instantiated from [TEST INITIALIZER]

            // Assert
            //CollectionAssert.AreEqual(expected, actual);  // same elements & same order
            //CollectionAssert.AreEquivalent(expected, actual);  // contains same elements
            //CollectionAssert.Equals (expected, actual); 
            Assert.IsTrue(expectedList.SequenceEqual(actualList));
        }





















        //[TestCleanup()]
        //public void Cleanup()
        //{
        //}


        [TestMethod]
        public void ReportingMethods_ListOfYears()
        {
            // Arrange
            List<int> expected = new List<int>() { 2017, 2018, 2016 };
            //Act 
            List<int> result = new List<int>();
            result = ReportingMethods.ListOfYears(horseBetList);
            // Assert
            //CollectionAssert.AreEqual(expected, result);  // same elements & same order
            CollectionAssert.AreEquivalent(expected, result);  // contains same elements
        }


        [TestMethod]
        public void ReportingMethods_GetAnnualResult_1()
        {
            // Arrange           
            int year = 2016;
            decimal totalAnnualResult = 34.12m;   // expected shoould be 34.12m;
            bool winLoseStatus = true;
            string expected = string.Format
                            ("Annual result for year: {0} total: {1} {2}", year, totalAnnualResult,
                                winLoseStatus ? "Profit" : "Loss");


            //Act 
            string result = ReportingMethods.GetAnnualResult(horseBetList, 2016, true);            
            // Assert
            StringAssert.Contains(result,  expected);
        }


        [TestMethod]
        public void ReportingMethods_GetAnnualResult_2()
        {
            // Arrange           
            int year = 2017;
            decimal totalAnnualResult = 215.00m;   // 
            bool winLoseStatus = false;
            string expected = string.Format
                            ("Annual result for year: {0} total: {1} {2}", year, totalAnnualResult,
                                winLoseStatus ? "Profit" : "Loss");
            //Act 
            string result = ReportingMethods.GetAnnualResult(horseBetList, 2017, false); 
            // Assert
            StringAssert.Contains(result, expected);
        }


        [TestMethod]
        public void ReportingMethods_GetAnnualResult_nullVersion()
        {
            // Arrange            
            List<HorseBet> aNullList = null;
            string expected = "Error Option 8 - Please load in default data before running report queries.";

            //Act 
            // Passes a null list to the method
            string result = ReportingMethods.GetAnnualResult(aNullList, 2017, false);

            // Assert
            StringAssert.Contains(expected, result);
        }


        [TestMethod]
        public void ReportingMethods_GetMostPopularRaceCourse_1()
        {
            // Arrange            
            string raceCourse = "Dublin";
            int totalBetsPerCourse = 2;

            string expected = string.Format("\nRacecourse: {0} - No of bets placed: {1}",
                    raceCourse, totalBetsPerCourse);

            //Act 
            string result = ReportingMethods.GetMostPopularRaceCourse(horseBetList);
            

            // Assert
            StringAssert.Contains( result, expected);
        }





        [TestMethod]
        public void ReportingMethods_HighestAmountWonOrLostOnARace_1_WIN()
        {
            // Arrange
            bool wonRace = true;
            decimal highestAmountWonOrLostOnARace = 200m;

            string expected = string.Format("{0} on a race: {1}   ",
                  wonRace? "WON" : "LOST", highestAmountWonOrLostOnARace.ToString());

            //Act 
            string actual = ReportingMethods.HighestAmountWonOrLostOnARace(horseBetList, true);
           
            // Assert
            StringAssert.Contains(actual, expected);
        }




        [TestMethod]
        public void ReportingMethods_HighestAmountWonOrLostOnARace_2_LOSS()
        {
            // Arrange
            bool wonRace = false;
            decimal highestAmountWonOrLostOnARace = 200m;

            string expected = string.Format("{0} on a race: {1}   ",
                  wonRace ? "WON" : "LOST", highestAmountWonOrLostOnARace.ToString());

            //Act 
            string actual = ReportingMethods.HighestAmountWonOrLostOnARace(horseBetList, false);

            // Assert
            StringAssert.Contains(actual, expected);
        }




        [TestMethod]
        public void HotTipsterSuccessLevel_1()
        {
            int noOfWinningRaces = 3;
            int totalNoOfRaces = 6;
            decimal winningRatio = 50;
            // Arrange
            string expected = string.Format("Total number of winning bets: {0}", noOfWinningRaces);
            expected += string.Format("\n  Out of {0} races", totalNoOfRaces);
            expected += string.Format("\n  Win / Lose Ratio: {0}%", winningRatio);

            //Act 
            string actual = ReportingMethods.HotTipsterSuccessLevel(horseBetList);
            
            // Assert
            StringAssert.Contains(actual, expected);
        }


        



       










        ////Where your method SHOULD throw an exception for given input, use the 
        ////following annotation to specify this:
        ////[TestMethod]
        ////[ExpectedException(typeof(ArgumentOutOfRangeException))]


    }// end class UnitTest1
}// end Namespace
