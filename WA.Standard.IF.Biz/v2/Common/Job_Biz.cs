using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WA.Standard.IF.Dac.v2.Common;
using WA.Standard.IF.Data.v2.Common.Common;
using WA.Standard.IF.Data.v2.Common.Job;

namespace WA.Standard.IF.Biz.v2.Common
{
    public class Job_Biz : WA.Standard.IF.Biz.v2.Base.BaseBiz
    {
        public JobGetResponse JobGet(JobGetRequest request)
        {
            JobGetResponse response = new JobGetResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.Common.Job_Proxy proxy = new Proxy.v2.Common.Job_Proxy();
                response = proxy.JobGet(request);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;
               
                #region For XML Process
                List<Job> Jobs = Util.DataHelper.GetListByElementName<Job>(System.Web.HttpContext.Current.Server.MapPath("/v2/Repository/Jobs.xml"), "Job");

                if (Jobs != null && Jobs.Count > 0)
                {
                    List<Job> resultlist = Jobs
                        .Where(item =>
                        (string.IsNullOrEmpty(request.JobGet.DMSAppointmentNo) || request.JobGet.DMSAppointmentNo == item.DMSAppointmentNo)
                        && (string.IsNullOrEmpty(request.JobGet.DMSJobNo) || request.JobGet.DMSJobNo == item.DMSJobNo)
                        && (string.IsNullOrEmpty(request.JobGet.DMSRONo) || request.JobGet.DMSRONo == item.DMSRONo)
                        && (request.JobGet.LastModifiedDateTimeFromUTC == null || request.JobGet.LastModifiedDateTimeFromUTC <= item.ManagementFields.LastModifiedDateTimeUTC)
                        && (request.JobGet.LastModifiedDateTimeToUTC == null || request.JobGet.LastModifiedDateTimeToUTC >= item.ManagementFields.LastModifiedDateTimeUTC)
                        //ScheduledDateTimeLocal From & To, DMSJobStatus
                        ).ToList<Job>();

                    response.Jobs = resultlist;

                    if (resultlist.Count > 0)
                        response.ResultMessage = GetResultMessageData(ResponseCode.Success, ResponseMessage.Success);
                    else
                        response.ResultMessage = GetResultMessageData(ResponseCode.NoResult, ResponseMessage.NoResult);
                }
                else
                {
                    response.ResultMessage = GetResultMessageData(ResponseCode.NoResult, ResponseMessage.NoResult);
                }
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.DBDMS))
            {
                #region For DB Process

                /*
                DataSet resultDS = new DataSet();
                using (Job_Dac dac = new Job_Dac())
                {
                    resultDS = dac.SelectJob(request.TransactionHeader.CountryID
                                                        , request.TransactionHeader.DistributorID
                                                        , request.TransactionHeader.GroupID
                                                        , request.TransactionHeader.DealerID
                                                        , request.TransactionHeader.Language // Need to check
                                                        , request.JobGet
                        );

                }

                if (resultDS.Tables != null && resultDS.Tables.Count == 0)
                {
                    List<Job> jobDataList = null;
                    if (resultDS.Tables[0].Rows.Count > 0)
                    {
                        #region Job Header
                        jobDataList = resultDS.Tables[0].AsEnumerable()
                            .Select(row =>
                        new Job
                        {
                            ActualHours = Util.DataHelper.ConvertObjectToDouble(row[""]),

                            DMSAppointmentNo = Util.DataHelper.ConvertObjectToString(row[""]), 
                            DMSJobNo = Util.DataHelper.ConvertObjectToString(row[""]), 
                            DMSRONo = Util.DataHelper.ConvertObjectToString(row[""]),
                            EstimatedHours = Util.DataHelper.ConvertObjectToDouble(row[""]), 
                            ServiceLineNumber = Util.DataHelper.ConvertObjectToString(row[""]), 
                            SkillLevel = Util.DataHelper.ConvertObjectToString(row[""]),

                            OPCodes = new List<Data.v2.Common.Job.OPCode>(),
                            ManagementFields = new ManagementFields(),
                            JobLogs = new List<JobLog>(),
                            Causes = new List<Cause>(),
                            Comments = new List<Comment>(),
                            Corrections = new List<Correction>(),
                            Descriptions = new List<Description>(),
                        }).ToList();
                        #endregion

                        if (jobDataList != null && jobDataList.Count > 0)
                        {
                            foreach (Job jobData in jobDataList)
                            {
                                #region Job Header
                                jobDataList = resultDS.Tables[0].AsEnumerable()
                                    .Select(row =>
                                new Job
                                {
                                    ActualHours = Util.DataHelper.ConvertObjectToDouble(row[""]),

                                    DMSAppointmentNo = Util.DataHelper.ConvertObjectToString(row[""]),
                                    DMSJobNo = Util.DataHelper.ConvertObjectToString(row[""]),
                                    DMSRONo = Util.DataHelper.ConvertObjectToString(row[""]),
                                    EstimatedHours = Util.DataHelper.ConvertObjectToDouble(row[""]),
                                    ServiceLineNumber = Util.DataHelper.ConvertObjectToString(row[""]),
                                    SkillLevel = Util.DataHelper.ConvertObjectToString(row[""]),

                                    OPCodes = new List<Data.v2.Common.Job.OPCode>(),
                                    ManagementFields = new ManagementFields(),
                                    JobLogs = new List<JobLog>(),
                                    Causes = new List<Cause>(),
                                    Comments = new List<Comment>(),
                                    Corrections = new List<Correction>(),
                                    Descriptions = new List<Description>(),
                                }).ToList();
                                #endregion
                            }
                        }



                        response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessDone, PredefinedMessage._SuccessDone);
                        response.Jobs = jobDataList;
                    }
                    else
                    {
                        response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessNoResult, PredefinedMessage._SuccessNoResult);
                    }
                }
                else
                {
                    response.ResultMessage = GetResultMessageData(PredefinedCode._SuccessNoResult, PredefinedMessage._SuccessNoResult);
                }
                 */
                #endregion
            }

            return response;
        }

        public JobChangeResponse JobChange(JobChangeRequest request)
        {
            JobChangeResponse response = new JobChangeResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.Common.Job_Proxy proxy = new Proxy.v2.Common.Job_Proxy();
                response = proxy.JobChange(request);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;
                
                #region For XML Process
                List<Job> Jobs = Util.DataHelper.GetListByElementName<Job>(System.Web.HttpContext.Current.Server.MapPath("/v2/Repository/Jobs.xml"), "Job");

                if (Jobs != null && Jobs.Count > 0)
                {
                    //response.Job = Jobs[0];
                    response.ResultMessage = GetResultMessageData(ResponseCode.Success, ResponseMessage.Success);
                }
                else
                {
                    response.ResultMessage = GetResultMessageData(ResponseCode.NoResult, ResponseMessage.NoResult);
                }
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.DBDMS))
            {
                #region For DB Process - Not Yet

                #endregion
            }

            return response;
        }
    }
}
