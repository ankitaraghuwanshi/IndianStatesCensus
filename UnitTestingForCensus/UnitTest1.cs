using NUnit.Framework;
using IndianCensus;

namespace CensusAnalyserTesting
{
    public class Tests
    {
        string folderPath = @"D:\VS\IndianCensusProgram\IndianStatesCensus\IndianCensusProgram\CSVFiles\";
        string validStateCensusFileState = "IndiaStateCensusData.csv";
        string invalidExtensionFileState = "IndiaStateCode.txt";
        string invalidDelimiterFileState = "DelimiterIndiaStateCensusData.csv";
        string invalidHeaderState = "WrongIndianStateCensusData.csv";
        string validCensusFileStateCode = "IndiaStateCode.csv";
        string invalidExtensionFileStateCode = "IndiaStateCode.txt";
        string invalidDelimiterFileStateCode = "DelimiterIndiaStateCode.csv";
        string invalidHeaderstateCode = "WrongIndiaStateCode.csv";
        CensusAnalyser censusAnalyser;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }
        //Tc1.1
        [Test]
        public void Given_DataRecord_CSVfileAreSame()
        {
            censusAnalyser.data = censusAnalyser.LoadCensusData(folderPath + validStateCensusFileState, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, censusAnalyser.data.Count);
        }
        
        // TC1.2
       
        [Test]
        public void Given_IncorrectFileName_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + validStateCensusFileState + "XYZ", "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.File_Not_Exist, exception.type);
        }
       
        // TC1.3
       
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
        
        // TC1.5
       
        [Test]
        public void Given_IncorrectHeader_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidHeaderState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Incorrect_Header, exception.type);
        }
       
        // TC2.1
       
        [Test]
        public void Given_StateCodeFile_TestRecordAreSame()
        {
            censusAnalyser.data = censusAnalyser.LoadCensusData(folderPath + validCensusFileStateCode, "SrNo,State Name,TIN,StateCode");
            Assert.AreEqual(37, censusAnalyser.data.Count);
        }
        
        // TC 2.2 
       
        [Test]
        public void Given_IncorrectStateCodeFileName_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + validCensusFileStateCode + "txt", "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.File_Not_Exist, exception.type);
        }
       
        // TC 2.3
        
        [Test]
        public void Given_IncorrectStateCodeFileType_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidExtensionFileStateCode, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Improper_Extension, exception.type);
        }
       
        // TC2.4
       
        [Test]
        public void GivenStateCodeFile_IncorrectDelimiter_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidDelimiterFileStateCode, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Deliminator_Not_Found, exception.type);
        }
        
        // TC2.5
        
        [Test]
        public void GivenStateCodeFile_IncorrectHeader_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidHeaderstateCode, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Incorrect_Header, exception.type);
        }
    }
}