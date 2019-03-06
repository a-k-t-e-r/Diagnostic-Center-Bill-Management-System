using System;
using System.Collections.Generic;
using DiagnosticCenterBillManagementSystem.DAL.Gateway;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TypeWiseReportManager
    {
        TypeWiseReportGateway twrGateway = new TypeWiseReportGateway();
        List<TypeWiseReportModel> twrModels = new List<TypeWiseReportModel>();

        public List<TypeWiseReportModel> GetAllTestNames(DateTime fromDate, DateTime toDate)
        {
            List<string> testNameList = twrGateway.GetAllTestNames(fromDate, toDate);

            // Seperate All Test Names
            List<string> testNameFilterList = TestNameFiltering(testNameList);

            // Remove Duplicate Value & Also Collect No. of Test
            string testNameDupRemoveList = TestNameDuplicates(testNameFilterList);
            while (testNameDupRemoveList == "Duplication Found")
            {
                testNameDupRemoveList = TestNameDuplicates(testNameFilterList);
            }

            // Remove Duplicate From Result Model
            string notify = ResultModelFilter();
            while (notify == "Not Done")
            {
                notify = ResultModelFilter();
            }

            // Omit Added Informations in Result Model
            string omit = OmitAdded(testNameFilterList);
            while (omit == "Not Done Yet")
            {
                omit = OmitAdded(testNameFilterList);
            }

            // Adding Others Informations
            foreach (string strName in testNameFilterList)
            {
                TypeWiseReportModel twrModel = new TypeWiseReportModel();
                twrModel.TestName = strName;
                twrModel.NoOfTest = 1;

                twrModels.Add(twrModel);
            }

            // Getting Test Type By Test Names
            foreach (TypeWiseReportModel twReportModel in twrModels)
            {
                string strType = twrGateway.GetTypeName(twReportModel.TestName);
                twReportModel.TypeName = strType;

                double strFee = twrGateway.GetFee(twReportModel.TestName);
                strFee = (strFee * twReportModel.NoOfTest);
                twReportModel.Amount = strFee;
            }

            // Final Filtering By Removing Duplicates
            string notification = FinalFilter();
            while (notification == "Not Done Yet")
            {
                notification = FinalFilter();
            }

            return twrModels;
        }

        private List<string> TestNameFiltering(List<string> testNameList)
        {
            char[] collect = new char[20];
            List<string> strCollection = new List<string>();

            foreach (string str in testNameList)
            {
                int k = 0;
                char[] cr = str.ToCharArray();
                for (int i = 0; i < cr.Length; i++)
                {
                    if ((cr[i] == ' ') && (k == 0))
                    {
                        continue;
                    }
                    else if (cr[i] != ',')
                    {
                        collect[k] = cr[i];
                        k++;
                        if (i == (cr.Length - 1))
                        {
                            int j = 0;
                            string st = "";
                            while (collect[j] != '\0')
                            {
                                st += collect[j];
                                j++;
                            }
                            strCollection.Add(st);
                        }
                    }
                    else if ((cr[i] == ','))
                    {
                        int j = 0;
                        string st = "";
                        while (collect[j] != '\0')
                        {
                            st += collect[j];
                            j++;
                        }
                        strCollection.Add(st);
                        collect = new char[20];
                        k = 0;
                        continue;
                    }
                    else
                    {
                        // Nothing To DO
                    }
                }
            }
            return strCollection;
        }

        private string TestNameDuplicates(List<string> testNameFilterList)
        {
            TypeWiseReportModel twrModel = new TypeWiseReportModel();
            int index = 0;
            int count = 1;
            twrModel.NoOfTest = 1;
            foreach (string str1 in testNameFilterList)
            {
                foreach (string str2 in testNameFilterList)
                {
                    if (str1.Equals(str2))
                    {
                        if (count == 1)
                        {
                            count++;
                            continue;
                        }
                        index++;

                        twrModel.NoOfTest++;
                        twrModel.TestName = str1;
                        testNameFilterList.RemoveAt(index);

                        twrModels.Add(twrModel);
                        return "Duplication Found";
                    }
                    else
                    {
                        index++;
                    }
                }
                index = 0;
                count = 1;
            }
            return "Duplicate Not Found";
        }

        private string ResultModelFilter()
        {
            int count = 0;
            foreach (TypeWiseReportModel twrM1 in twrModels)
            {
                foreach (TypeWiseReportModel twrM2 in twrModels)
                {
                    if (twrM2.Equals(twrM1))
                    {
                        continue;
                    }
                    else if (twrM2.TestName == twrM1.TestName)
                    {
                        count++;
                        twrM1.NoOfTest += (twrM2.NoOfTest - 1);
                        twrModels.RemoveAt(count);
                        return "Not Done";
                    }
                }
                count = 0;
            }
            return "Done";
        }

        private string OmitAdded(List<string> testNameFilterList)
        {
            TypeWiseReportModel twrModel = new TypeWiseReportModel();

            int index = 0;
            foreach (TypeWiseReportModel twrM in twrModels)
            {
                foreach (string s in testNameFilterList)
                {
                    if (twrM.TestName == s)
                    {
                        testNameFilterList.RemoveAt(index);
                        return "Not Done Yet";
                    }
                    else
                    {
                        index++;
                    }
                }
                index = 0;
            }
            return "DONE";
        }

        private string FinalFilter()
        {
            int index = 0;
            foreach (TypeWiseReportModel modelOne in twrModels)
            {
                foreach (TypeWiseReportModel modelTwo in twrModels)
                {
                    if (modelTwo.Equals(modelOne))
                    {
                        // Do Nothing, Index is in same position
                    }
                    else if (modelTwo.TypeName == modelOne.TypeName)
                    {
                        index++;
                        modelOne.TestName = modelOne.TestName + ", " + modelTwo.TestName;
                        modelOne.NoOfTest += modelTwo.NoOfTest;
                        modelOne.Amount += modelTwo.Amount;
                        twrModels.RemoveAt(index);
                        return "Not Done Yet";
                    }
                    else
                    {
                        index++;
                    }
                }
                index = 0;
            }
            return "Searching Complete";
        }
    }
}