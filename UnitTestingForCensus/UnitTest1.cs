using NUnit.Framework;
using IndianCensus;

namespace CensusAnalyserTesting
{
    public class Tests
    {
        string folderPath = @"D:\VS\IndianCensusProgram\IndianCensusProgram\CSVFiles\";
        string validStateCensusFileState = "IndiaStateCensusData.csv";
        string invalidExtensionFileState = "IndiaStateCode.txt";
        string invalidDelimiterFileState = "DelimiterIndiaStateCensusData.csv";
        string invalidHeaderState = "WrongIndianStateCensusData.csv";
        CensusAnalyser censusAnalyser;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }
      
        /// TC 1.1 
        
        [Test]
        public void Given_CSVFile_TestRecordAreSame()
        {
            censusAnalyser.data = censusAnalyser.LoadCensusData(folderPath + validStateCensusFileState, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, censusAnalyser.data.Count);
        }

        /// TC1.2
        /// TC1.3

        [Test]
        public void Given_IncorrectFileType_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidExtensionFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Improper_Extension, exception.type);
        }

        // TC1.4

        [Test]
        public void Given_IncorrectDelimiter_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidDelimiterFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Deliminator_Not_Found, exception.type);
        }
        //TC1.5
        [Test]
        public void Given_IncorrectHeader_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidHeaderState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Incorrect_Header, exception.type);
        }
    }
}


