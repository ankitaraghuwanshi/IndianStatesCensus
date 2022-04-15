﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianCensus
{
    public class CensusAnalyser
    {
        public Dictionary<string, StateCensusData> data;
        public Dictionary<string, StateCensusData> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            data = new Dictionary<string, StateCensusData>();

            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.File_Not_Exist, "File does not exist");
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.Improper_Extension, "Improper extension");
            }

            string[] censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.Incorrect_Header, "Incorrect Header");
            }

            foreach (string row in censusData.Skip(1))
            {
                if (!row.Contains(","))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.Deliminator_Not_Found, "Delimiter is not found");
                }
                string[] column = row.Split(',');
                data.Add(column[0], new StateCensusData(column[0], column[1], column[2], column[3]));
            }
            return data;
        }
    }
}
