using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAW_DataAccessLayer;

namespace VAW_BusinessAccessLayer
{
    public class VAW_BAL
    {

        VAW_Dal SbteFeeDAL = new VAW_Dal();

            
            public DataSet StudentLogin(double regno, DateTime dob, double rollno)
            {
                return SbteFeeDAL.StudentLogin(regno, dob, rollno);
            }

            public DataSet GetStudent(int studetnID, String Rollno)
            {
                return SbteFeeDAL.GetStudent(studetnID, Rollno);
            }
            public DataSet GetSubjectByRegId(int RegID)
            {
                return SbteFeeDAL.GetSubjectByRegID(RegID);
            }

            public DataSet GetSubjectMarksByStudentID(String Rollno)
            {
                return SbteFeeDAL.GetSubjectMarksByStudentID(Rollno);
            }
            public DataTable GetExamDetailByTerm(string Roll_Number)
            {
                return SbteFeeDAL.GetExamDetailByTerm(Roll_Number);
            }

            public int Fee_InsertNewOrderDetail(int studentid, String Order_Number, String RollNo, String PayAmount, String OrderCreationDate, String ExamName, String ExamHeldin, String PaymentType)
            {
                return SbteFeeDAL.Fee_InsertNewOrderDetail(studentid, Order_Number, RollNo, PayAmount, OrderCreationDate, ExamName, ExamHeldin, PaymentType);
            }

            public int Fee_UpdateOrderDetail(int studentid, String Order_Number, String RollNo, String PayAmount, String OrderCreationDate, String ExamName, String ExamHeldin, String PaymentType)
            {
                return SbteFeeDAL.Fee_UpdateOrderDetail(studentid, Order_Number, RollNo, PayAmount, OrderCreationDate, ExamName, ExamHeldin, PaymentType);
            }

            public Boolean IsOrderNoExist(String Order_Number, int studentid)
            {
                return SbteFeeDAL.IsOrderNoExist(Order_Number, studentid);
            }

            public Boolean IsRollnoExist(String Rollno)
            {
                return SbteFeeDAL.IsRollnoExist(Rollno);
            }

            public Boolean IsRollnoFeePaid(String Rollno)
            {
                return SbteFeeDAL.IsRollnoFeePaid(Rollno);
            }

            public int Fee_UpdateTrasStatus(string OrderNo, String Status, String TransDateTime)
            {
                return SbteFeeDAL.Fee_UpdateTrasStatus(OrderNo, Status, TransDateTime);
            }

            public int Trans_InsertNewENC_Detail(String MerchantOrderNumber, String SBIePayRefID, String TransactionStatus, String PaidAmount,
                                              String MerchantCurrency, String Paymode, String OtherDetails, String Reason_Message, String Bank_Code,
                                              String Bank_Reference_Number, String Transaction_Date, String Transaction_Country, String CIN,
                                              String MerchantID, String Total_Fee_GST, String OperatingMode, String MerchantCountry, String AggregatorID,
                                              String MerchantCustomerID, String AccessMedium, String TransactionSource, String Ref1, String Ref2, String Ref3,
                                              String Ref4, String Ref5, String Ref6, String Ref7, String Ref8, String Ref9, String UpdatedBy,
                                              String ExamName, String ExamHeldIn, String PaymentType)
            {
                return SbteFeeDAL.Trans_InsertNewENC_Detail(MerchantOrderNumber, SBIePayRefID, TransactionStatus, PaidAmount,
                                                MerchantCurrency, Paymode, OtherDetails, Reason_Message, Bank_Code, Bank_Reference_Number, Transaction_Date,
                                                Transaction_Country, CIN, MerchantID, Total_Fee_GST, OperatingMode, MerchantCountry, AggregatorID,
                                                MerchantCustomerID, AccessMedium, TransactionSource, Ref1, Ref2, Ref3,
                                                Ref4, Ref5, Ref6, Ref7, Ref8, Ref9, UpdatedBy, ExamName, ExamHeldIn, PaymentType);
            }


            public int Trans_InsertSuccess_Detail(String MerchantOrderNumber, String SBIePayRefID, String TransactionStatus, String PaidAmount,
                                              String MerchantCurrency, String Paymode, String OtherDetails, String Reason_Message, String Bank_Code,
                                              String Bank_Reference_Number, String Transaction_Date, String Transaction_Country, String CIN,
                                              String MerchantID, String Total_Fee_GST, String OperatingMode, String MerchantCountry, String AggregatorID,
                                              String MerchantCustomerID, String AccessMedium, String TransactionSource, String Ref1, String Ref2, String Ref3,
                                              String Ref4, String Ref5, String Ref6, String Ref7, String Ref8, String Ref9, String UpdatedBy,
                                              String ExamName, String ExamHeldIn, String PaymentType)
            {
                return SbteFeeDAL.Trans_InsertSuccess_Detail(MerchantOrderNumber, SBIePayRefID, TransactionStatus, PaidAmount,
                                                MerchantCurrency, Paymode, OtherDetails, Reason_Message, Bank_Code, Bank_Reference_Number, Transaction_Date,
                                                Transaction_Country, CIN, MerchantID, Total_Fee_GST, OperatingMode, MerchantCountry, AggregatorID,
                                                MerchantCustomerID, AccessMedium, TransactionSource, Ref1, Ref2, Ref3,
                                                Ref4, Ref5, Ref6, Ref7, Ref8, Ref9, UpdatedBy, ExamName, ExamHeldIn, PaymentType);
            }
            public int Activate_FormEntry(string Rollno, String amount, string AmtUpdageDateTime)
            {
                return SbteFeeDAL.Activate_FormEntry(Rollno, amount, AmtUpdageDateTime);
            }

            public DataTable GetEmailidAndMobileNoByRollNO(string rollno)
            {
                return SbteFeeDAL.GetEmailidAndMobileNoByRollNO(rollno);
            }

            public DataTable GetPaymentSlip(string RollNumber)
            {
                return SbteFeeDAL.GetPaymentSlip(RollNumber);
            }
            public DataTable GetMissedPayment()
            {
                return SbteFeeDAL.GetMissedPayment();
            }

            public DataTable GetAppEvents(int eventid)
            {
                return SbteFeeDAL.GetAppEvents(eventid);
            }

            public DataTable GetAppDateOver(int term, string academic_term_temp)
            {
                return SbteFeeDAL.GetAppDateOver(term, academic_term_temp);
            }
        }
    
}
