using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using VAW_Utility;

namespace VAW_DataAccessLayer
{
    public class VAW_Dal
    {
       
            public string MySqlConnection;
            //  public ErrorLog errolog = new ErrorLog();
            public VAW_Dal()
            {
                MySqlConnection = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString.ToString();
            }
            public DataSet StudentLogin(double reg_no, DateTime dob, double roll_number)
            {
                string SelQuery = "SELECT registration_scrutiny.roll_no,registration_scrutiny.academic_term, student.id,student.reg_no,student.dob FROM registration_scrutiny left join student on registration_scrutiny.student= student.id where Roll_No =" + roll_number + " and reg_no = " + reg_no + " and dob = '" + dob.Date.ToString("yyyy-MM-dd") + "'";

                //string SelQuery = "SELECT registration.Roll_number,registration.academic_term_temp, student.id,student.registration_number,student.dob FROM registration left join student on registration.student_id = student.id where Roll_Number =" + rollno + " and registration_number = " + regno + " and dob = '" + dob.Date.ToString("yyyy-MM-dd")+"'";
                // string SelQuery = "SELECT registration_temp.Roll_number, student.id,student.registration_number,student.dob FROM registration_temp left join student on registration_temp.student_id = student.id where Roll_Number =" + rollno + " and registration_number = " + regno + " and dob = '" + dob.Date.ToString("yyyy-MM-dd") + "'";
                DataSet DS = new DataSet();
                try
                {
                    MySqlCommand cmd = new MySqlCommand();


                    DS = MySqlHelperCls.ExecuteDataset(MySqlConnection, CommandType.Text, SelQuery);

                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return DS;
            }

            public DataSet GetStudent(int studetnID, String rollno)
            {
                //string SelQuery = "SELECT student.id,student.email,student.mobile_number, student.first_name, student.middle_name, student.last_name, student.registration_number, student.dob, student.father_name,student.sex,student.Category,(select academic_term_temp from registration where registration.student_id = student.id) as academic_term,(select Roll_number from registration where registration.student_id = student.id) as RollNumber,(select id from registration where registration.student_id = student.id) as RegistraionId,(select name from institute where id = student.institute_id) as inst_name,(select name from program where id = student.program_id) as branchName FROM student where id =" + studetnID;
                string SelQuery = "SELECT student.id,student.email,student.mobile_number, student.first_name, student.middle_name, student.last_name, student.registration_number, student.dob, student.father_name,student.sex,student.Category,(select academic_term_temp from registration where roll_number='" + rollno + "' ) as academic_term,(select Roll_number from registration where roll_number='" + rollno + "') as RollNumber,(select id from registration  where roll_number='" + rollno + "') as RegistraionId,(select name from institute where id = student.institute_id) as inst_name,(select name from program where id = student.program_id) as branchName FROM student where id =" + studetnID;

                DataSet DS = new DataSet();
                try
                {
                    MySqlCommand cmd = new MySqlCommand();


                    DS = MySqlHelperCls.ExecuteDataset(MySqlConnection, CommandType.Text, SelQuery);

                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return DS;
            }

            public DataSet GetSubjectByRegID(int RegId)
            {
                string SelQuery = "select * from course_registration where registration_id =" + RegId + " order by code asc";
                DataSet DS = new DataSet();
                try
                {
                    MySqlCommand cmd = new MySqlCommand();


                    DS = MySqlHelperCls.ExecuteDataset(MySqlConnection, CommandType.Text, SelQuery);

                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return DS;
            }

            public DataSet GetSubjectMarksByStudentID(String Rollno)
            {
                // string SelQuery = "select * from course_registration where registration_id =" + StudentId + " order by code asc";
                string SelQuery = "select A.id,A.student_id,A.roll_number,A.new_task_id,A.marks_obtained ,B.course_title,B.term,B.type from new_marks A Left join new_task B on A.new_task_id=B.id where  A.roll_number='" + Rollno + "'";
                DataSet DS = new DataSet();
                try
                {
                    MySqlCommand cmd = new MySqlCommand();


                    DS = MySqlHelperCls.ExecuteDataset(MySqlConnection, CommandType.Text, SelQuery);

                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return DS;
            }

            public DataTable GetExamDetailByTerm(string Roll_Number)
            {
                // string SelQuery = "select * from course_registration where registration_id =" + StudentId + " order by code asc";
                int term = int.Parse(Roll_Number.Substring(0, 1).ToString());
                string SelQuery = "SELECT * FROM exams WHERE  term=" + term + " AND academic_term in (select academic_term_temp from registration where roll_number='" + Roll_Number + "')";
                //  string SelQuery = "select * from exams where term =" + term +"and ac";
                DataTable Dt = new DataTable();
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    Dt = MySqlHelperCls.ExecuteDataset(MySqlConnection, CommandType.Text, SelQuery).Tables[0];
                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return Dt;
            }



            public DataTable GetEmailidAndMobileNoByRollNO(string rollno)
            {
                // string SelQuery = "select * from course_registration where registration_id =" + StudentId + " order by code asc";
                string SelQuery = "select (select email from student where id = registration.student_id) as Emailid,(select mobile_number from student where id=registration.student_id) as MobNo,(select first_name from student where id = registration.student_id) as studentname, Student_id, roll_number from  registration where roll_number=" + rollno;
                DataTable Dt = new DataTable();
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    Dt = MySqlHelperCls.ExecuteDataset(MySqlConnection, CommandType.Text, SelQuery).Tables[0];
                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return Dt;
            }
            public int Fee_InsertNewOrderDetail(int studentid, String Order_Number, String RollNo, String PayAmount, String OrderCreationDate, String ExamName, String ExamHeldin, String PaymentType)
            {
                string SelQuery = "insert into paymentordertbl (studentid,Order_Number,RollNo,PayAmount,OrderCreationDate,ExamName,ExamHeldin,PaymentType,PaymentStatus,Tran_datetime)" +
                                "VALUES(" + studentid + ",'" + Order_Number + "', '" + RollNo + "', '" + PayAmount + "', '" + OrderCreationDate + "', '" + ExamName + "', '" + ExamHeldin + "', '" + PaymentType + "', '', '')";

                int result = 0;
                try
                {
                    MySqlCommand cmd = new MySqlCommand();


                    result = MySqlHelperCls.ExecuteNonQuery(MySqlConnection, CommandType.Text, SelQuery);

                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return result;
            }


            public int Fee_UpdateOrderDetail(int studentid, String Order_Number, String RollNo, String PayAmount, String OrderCreationDate, String ExamName, String ExamHeldin, String PaymentType)
            {
                string SelQuery = "UPDATE paymentordertbl set Order_Number ='" + Order_Number + "',OrderCreationDate='" + OrderCreationDate + "' WHERE studentid=" + studentid + " AND RollNo='" + RollNo + "'";

                int result = 0;
                try
                {
                    MySqlCommand cmd = new MySqlCommand();


                    result = MySqlHelperCls.ExecuteNonQuery(MySqlConnection, CommandType.Text, SelQuery);

                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return result;

            }
            public Boolean IsOrderNoExist(String Order_Number, int studentid)
            {
                Boolean _result = false;
                // string SelQuery = "select * from course_registration where registration_id =" + StudentId + " order by code asc";
                string SelQuery = " select count(*) as TotalID from paymentordertbl where Order_Number = '" + Order_Number + "' and studentid =" + studentid;
                DataTable Dt = new DataTable();
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    Dt = MySqlHelperCls.ExecuteDataset(MySqlConnection, CommandType.Text, SelQuery).Tables[0];
                    if (Dt.Rows.Count > 0)
                    {
                        if (int.Parse(Dt.Rows[0][0].ToString()) > 0)
                        {
                            _result = true;
                        }
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }


                return _result;
            }

            public Boolean IsRollnoExist(String Rollno)
            {
                Boolean _result = false;
                // string SelQuery = "select * from course_registration where registration_id =" + StudentId + " order by code asc";
                string SelQuery = " select count(*) as TotalID from paymentordertbl where RollNO = '" + Rollno + "' ";
                DataTable Dt = new DataTable();
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    Dt = MySqlHelperCls.ExecuteDataset(MySqlConnection, CommandType.Text, SelQuery).Tables[0];
                    if (Dt.Rows.Count > 0)
                    {
                        if (int.Parse(Dt.Rows[0][0].ToString()) > 0)
                        {
                            _result = true;
                        }
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }


                return _result;
            }



            public Boolean IsRollnoFeePaid(String Rollno)
            {
                Boolean _result = false;
                // string SelQuery = "select * from course_registration where registration_id =" + StudentId + " order by code asc";
                string SelQuery = " select count(*) as TotalID from payment_returnencsuccess where OtherDetails = '" + Rollno + "' ";
                DataTable Dt = new DataTable();
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    Dt = MySqlHelperCls.ExecuteDataset(MySqlConnection, CommandType.Text, SelQuery).Tables[0];
                    if (Dt.Rows.Count > 0)
                    {
                        if (int.Parse(Dt.Rows[0][0].ToString()) > 0)
                        {
                            _result = true;
                        }
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }


                return _result;
            }
            public int Fee_UpdateTrasStatus(string OrderNo, String Status, String TransDateTime)
            {
                string SelQuery = "update paymentordertbl set PaymentStatus ='" + Status + "',Tran_datetime='" + TransDateTime + "' where Order_Number='" + OrderNo + "'";
                int result = 0;
                try
                {
                    MySqlCommand cmd = new MySqlCommand();


                    result = MySqlHelperCls.ExecuteNonQuery(MySqlConnection, CommandType.Text, SelQuery);

                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return result;
            }
            public int Trans_InsertNewENC_Detail(String MerchantOrderNumber, String SBIePayRefID, String TransactionStatus, String PaidAmount,
                                                String MerchantCurrency, String Paymode, String OtherDetails, String Reason_Message, String Bank_Code,
                                                String Bank_Reference_Number, String Transaction_Date, String Transaction_Country, String CIN,
                                                String MerchantID, String Total_Fee_GST, String OperatingMode, String MerchantCountry, String AggregatorID,
                                                String MerchantCustomerID, String AccessMedium, String TransactionSource, String Ref1, String Ref2, String Ref3,
                                                String Ref4, String Ref5, String Ref6, String Ref7, String Ref8, String Ref9, String UpdatedBy,
                                                String ExamName, String ExamHeldIn, String PaymentType)
            {


                string SelQuery = "insert into payment_returnencdata (MerchantOrderNumber, SBIePayRefID, TransactionStatus, PaidAmount, MerchantCurrency, " +
                                  "Paymode, OtherDetails, Reason_Message, Bank_Code, Bank_Reference_Number, Transaction_Date, Transaction_Country, CIN,MerchantID, Total_Fee_GST, OperatingMode, MerchantCountry, AggregatorID, MerchantCustomerID, AccessMedium, TransactionSource, Ref1, Ref2, Ref3, Ref4, Ref5, Ref6, Ref7, Ref8, Ref9, UpdatedBy, ExamName, ExamHeldIn, PaymentType)" +
                                  "VALUES('" + MerchantOrderNumber + "','" + SBIePayRefID + "', '" + TransactionStatus + "', '" + PaidAmount + "', '" + MerchantCurrency + "', '" +
                                  Paymode + "', '" + OtherDetails + "', '" + Reason_Message + "', '" + Bank_Code +
                                  "', '" + Bank_Reference_Number + "', '" + Transaction_Date + "', '" + Transaction_Country + "', '" + CIN +
                                  "', '" + MerchantID + "', '" + Total_Fee_GST + "', '" + OperatingMode + "', '" + MerchantCountry + "', '" + AggregatorID +
                                  "', '" + MerchantCustomerID + "', '" + AccessMedium + "', '" + TransactionSource + "', '" + Ref1 + "', '" + Ref2 + "', '" + Ref3 +
                                  "', '" + Ref4 + "', '" + Ref5 + "', '" + Ref6 + "', '" + Ref7 + "', '" + Ref8 + "', '" + Ref9 + "', '" + UpdatedBy +
                                  "', '" + ExamName + "', '" + ExamHeldIn + "', '" + PaymentType + "')";

                int result = 0;
                try
                {
                    MySqlCommand cmd = new MySqlCommand();


                    result = MySqlHelperCls.ExecuteNonQuery(MySqlConnection, CommandType.Text, SelQuery);

                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return result;
            }




            public int Trans_InsertSuccess_Detail(String MerchantOrderNumber, String SBIePayRefID, String TransactionStatus, String PaidAmount,
                                              String MerchantCurrency, String Paymode, String OtherDetails, String Reason_Message, String Bank_Code,
                                              String Bank_Reference_Number, String Transaction_Date, String Transaction_Country, String CIN,
                                              String MerchantID, String Total_Fee_GST, String OperatingMode, String MerchantCountry, String AggregatorID,
                                              String MerchantCustomerID, String AccessMedium, String TransactionSource, String Ref1, String Ref2, String Ref3,
                                              String Ref4, String Ref5, String Ref6, String Ref7, String Ref8, String Ref9, String UpdatedBy,
                                              String ExamName, String ExamHeldIn, String PaymentType)
            {


                string SelQuery = "insert into payment_returnencsuccess (MerchantOrderNumber, SBIePayRefID, TransactionStatus, PaidAmount, MerchantCurrency, " +
                                  "Paymode, OtherDetails, Reason_Message, Bank_Code, Bank_Reference_Number, Transaction_Date, Transaction_Country, CIN,MerchantID, Total_Fee_GST, OperatingMode, MerchantCountry, AggregatorID, MerchantCustomerID, AccessMedium, TransactionSource, Ref1, Ref2, Ref3, Ref4, Ref5, Ref6, Ref7, Ref8, Ref9, UpdatedBy, ExamName, ExamHeldIn, PaymentType)" +
                                  "VALUES('" + MerchantOrderNumber + "','" + SBIePayRefID + "', '" + TransactionStatus + "', '" + PaidAmount + "', '" + MerchantCurrency + "', '" +
                                  Paymode + "', '" + OtherDetails + "', '" + Reason_Message + "', '" + Bank_Code +
                                  "', '" + Bank_Reference_Number + "', '" + Transaction_Date + "', '" + Transaction_Country + "', '" + CIN +
                                  "', '" + MerchantID + "', '" + Total_Fee_GST + "', '" + OperatingMode + "', '" + MerchantCountry + "', '" + AggregatorID +
                                  "', '" + MerchantCustomerID + "', '" + AccessMedium + "', '" + TransactionSource + "', '" + Ref1 + "', '" + Ref2 + "', '" + Ref3 +
                                  "', '" + Ref4 + "', '" + Ref5 + "', '" + Ref6 + "', '" + Ref7 + "', '" + Ref8 + "', '" + Ref9 + "', '" + UpdatedBy +
                                  "', '" + ExamName + "', '" + ExamHeldIn + "', '" + PaymentType + "')";

                int result = 0;
                try
                {
                    MySqlCommand cmd = new MySqlCommand();


                    result = MySqlHelperCls.ExecuteNonQuery(MySqlConnection, CommandType.Text, SelQuery);

                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return result;
            }


            public int Activate_FormEntry(string Rollno, String amount, string AmtUpdageDateTime)
            {
                string SelQuery = "update registration set academic_term =academic_term_temp,form_amount='" + amount + "',paymentUpdateDate='" + AmtUpdageDateTime + "' where roll_number=" + Rollno;
                int result = 0;
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    result = MySqlHelperCls.ExecuteNonQuery(MySqlConnection, CommandType.Text, SelQuery);
                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return result;
            }




            public DataTable GetPaymentSlip(string RollNumber)
            {
                // string SelQuery = "";
                string SelQuery = "select * from payment_returnencsuccess where OtherDetails =" + RollNumber;
                // string SelQuery = "select (select email from student where id = registration.student_id) as Emailid,(select mobile_number from student where id=registration.student_id) as MobNo,(select first_name from student where id = registration.student_id) as studentname, Student_id, roll_number from  registration where roll_number=" + rollno;
                DataTable Dt = new DataTable();
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    Dt = MySqlHelperCls.ExecuteDataset(MySqlConnection, CommandType.Text, SelQuery).Tables[0];
                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return Dt;
            }

            public DataTable GetMissedPayment()
            {
                string SelQuery = "select* from paymentordertbl WHERE PaymentStatus=' ' and rollno ='621412118010'";
                //string SelQuery = "select* from paymentordertbl WHERE PaymentStatus=' ' and Order_Number like 'SBTE-%' ORDER BY Order_Number";
                //string SelQuery = "select * from paymentordertbl WHERE PaymentStatus=' ' ORDER BY Order_Number DESC"; 
                // string SelQuery = "select * from course_registration where registration_id =" + StudentId + " order by code asc";
                // string SelQuery = "select (select email from student where id = registration.student_id) as Emailid,(select mobile_number from student where id=registration.student_id) as MobNo,(select first_name from student where id = registration.student_id) as studentname, Student_id, roll_number from  registration where roll_number=" + rollno;
                DataTable Dt = new DataTable();
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    Dt = MySqlHelperCls.ExecuteDataset(MySqlConnection, CommandType.Text, SelQuery).Tables[0];
                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return Dt;
            }


            public DataTable GetAppEvents(int eventid)
            {
                string SelQuery = "SELECT * FROM emsapp_event where eventid=" + eventid;
                DataTable Dt = new DataTable();
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    Dt = MySqlHelperCls.ExecuteDataset(MySqlConnection, CommandType.Text, SelQuery).Tables[0];
                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return Dt;
            }



            //payment_returnencsuccess
            public DataTable IsPaidFeeAmount(string Rollno)
            {
                string SelQuery = "SELECT * FROM emsapp_event where eventid=" + Rollno;
                DataTable Dt = new DataTable();
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    Dt = MySqlHelperCls.ExecuteDataset(MySqlConnection, CommandType.Text, SelQuery).Tables[0];
                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return Dt;
            }

            public DataTable GetAppDateOver(int term, string academic_term_temp)
            {
                string SelQuery = "SELECT id,version,academic_term,date_over,term,type FROM date_over WHERE type='EXAM_FEE' AND term=" + term + " AND academic_term='" + academic_term_temp + "'";
                DataTable Dt = new DataTable();
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    Dt = MySqlHelperCls.ExecuteDataset(MySqlConnection, CommandType.Text, SelQuery).Tables[0];
                }
                catch (Exception ex)
                {
                    //errolog.WriteErrorLog(ex);
                }
                return Dt;
            }
        }
    
}
