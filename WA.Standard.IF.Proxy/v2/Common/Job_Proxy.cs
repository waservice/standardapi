using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using WA.Standard.IF.Data.v2.Common.Job;
using WA.Standard.IF.Data.v2.Common.Common;

namespace WA.Standard.IF.Proxy.v2.Common
{
    public class Job_Proxy : Base.BaseProxy
    {
        public JobGetResponse JobGet(JobGetRequest request)
        {
            JobGetResponse response = new JobGetResponse();

            //DMS information set by dealer information
            string proxypath = string.Format("{0}.{1}.{2}.{3}",
                request.TransactionHeader.DocumentVersion,
                request.TransactionHeader.DistributorID,
                request.TransactionHeader.DMSCode,
                request.TransactionHeader.DMSVersion);

            switch (proxypath)
            {
                case "v2.Common.WA.v2":
                    {
                        #region v2.Common.WA.v2 - Standard (Proxy Class Dll Name : _WA.Mapper.v2)

                        #region JobGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _WA.Mapper.v2.Job.Job proxyws = new _WA.Mapper.v2.Job.Job(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with jobget and transaction
                        _WA.Mapper.v2.Job.JobGetRequest proxyrequest = new _WA.Mapper.v2.Job.JobGetRequest();

                        //Create proxy transaction
                        _WA.Mapper.v2.Job.TransactionHeader proxytransactionheader = new _WA.Mapper.v2.Job.TransactionHeader();
                        if (request.TransactionHeader != null)
                        {
                            #region//TransactionHeader Set
                            proxytransactionheader.CountryID = request.TransactionHeader.CountryID;
                            proxytransactionheader.DealerID = request.TransactionHeader.DealerID;
                            proxytransactionheader.DistributorID = request.TransactionHeader.DistributorID;
                            proxytransactionheader.DMSCode = request.TransactionHeader.DMSCode;
                            proxytransactionheader.DMSServerUrl = request.TransactionHeader.DMSServerUrl;
                            proxytransactionheader.DMSVersion = request.TransactionHeader.DMSVersion;
                            proxytransactionheader.DocumentVersion = request.TransactionHeader.DocumentVersion;
                            proxytransactionheader.GroupID = request.TransactionHeader.GroupID;
                            proxytransactionheader.IneterfaceID = request.TransactionHeader.IneterfaceID;
                            proxytransactionheader.Password = request.TransactionHeader.Password;
                            proxytransactionheader.PollingToken = request.TransactionHeader.PollingToken;
                            proxytransactionheader.RequestPollingToken = request.TransactionHeader.RequestPollingToken;
                            proxytransactionheader.RequestType = request.TransactionHeader.RequestType;
                            proxytransactionheader.TransactionId = request.TransactionHeader.TransactionId;
                            proxytransactionheader.TransactionDateTimeLocal = request.TransactionHeader.TransactionDateTimeLocal;
                            proxytransactionheader.TransactionDateTimeUTC = request.TransactionHeader.TransactionDateTimeUTC;
                            proxytransactionheader.TransactionType = request.TransactionHeader.TransactionType;
                            proxytransactionheader.Username = request.TransactionHeader.Username;
                            proxytransactionheader.VenderTrackingCode = request.TransactionHeader.VenderTrackingCode;
                            proxyrequest.TransactionHeader = proxytransactionheader;
                            #endregion
                        }

                        //Create proxy jobget
                        _WA.Mapper.v2.Job.JobGet proxyjobget = new _WA.Mapper.v2.Job.JobGet();
                        if (request.JobGet != null)
                        {
                            #region//JobGet Set
                            proxyjobget.DMSJobNo = request.JobGet.DMSJobNo;
                            proxyjobget.DMSJobNo = request.JobGet.DMSJobNo;
                            proxyjobget.DMSJobStatus = request.JobGet.DMSJobStatus;
                            proxyjobget.DMSRONo = request.JobGet.DMSRONo;
                            proxyjobget.LastModifiedDateTimeFromUTC = request.JobGet.LastModifiedDateTimeFromUTC;
                            proxyjobget.LastModifiedDateTimeToUTC = request.JobGet.LastModifiedDateTimeToUTC;
                            proxyjobget.ScheduledDateTimeFromLocal = request.JobGet.ScheduledDateTimeFromLocal;
                            proxyjobget.ScheduledDateTimeToLocal = request.JobGet.ScheduledDateTimeToLocal;
                            proxyrequest.JobGet = proxyjobget;
                            #endregion
                        }

                        #endregion

                        //Run proxy web method with proxy request
                        _WA.Mapper.v2.Job.JobGetResponse proxyresponse = proxyws.JobGet(proxyrequest);

                        //Mapping with Standard Interface Specification Object
                        if (proxyresponse != null)
                        {
                            if (proxyresponse.TransactionHeader != null)
                            {
                                #region//TransactionHeader Set
                                TransactionHeader transactionheader = new TransactionHeader();
                                transactionheader.CountryID = proxyresponse.TransactionHeader.CountryID;
                                transactionheader.DealerID = proxyresponse.TransactionHeader.DealerID;
                                transactionheader.DistributorID = proxyresponse.TransactionHeader.DistributorID;
                                transactionheader.DMSCode = proxyresponse.TransactionHeader.DMSCode;
                                transactionheader.DMSServerUrl = proxyresponse.TransactionHeader.DMSServerUrl;
                                transactionheader.DMSVersion = proxyresponse.TransactionHeader.DMSVersion;
                                transactionheader.DocumentVersion = proxyresponse.TransactionHeader.DocumentVersion;
                                transactionheader.GroupID = proxyresponse.TransactionHeader.GroupID;
                                transactionheader.IneterfaceID = proxyresponse.TransactionHeader.IneterfaceID;
                                transactionheader.Password = proxyresponse.TransactionHeader.Password;
                                transactionheader.PollingToken = proxyresponse.TransactionHeader.PollingToken;
                                transactionheader.RequestPollingToken = proxyresponse.TransactionHeader.RequestPollingToken;
                                transactionheader.RequestType = proxyresponse.TransactionHeader.RequestType;
                                transactionheader.TransactionId = proxyresponse.TransactionHeader.TransactionId;
                                transactionheader.TransactionDateTimeLocal = proxyresponse.TransactionHeader.TransactionDateTimeLocal;
                                transactionheader.TransactionDateTimeUTC = proxyresponse.TransactionHeader.TransactionDateTimeUTC;
                                transactionheader.TransactionType = proxyresponse.TransactionHeader.TransactionType;
                                transactionheader.Username = proxyresponse.TransactionHeader.Username;
                                transactionheader.VenderTrackingCode = proxyresponse.TransactionHeader.VenderTrackingCode;
                                response.TransactionHeader = transactionheader;
                                #endregion
                            }

                            //ResultMessage Set
                            if (proxyresponse.ResultMessage != null)
                            {
                                response.ResultMessage = GetResultMessageData(proxyresponse.ResultMessage.Code, proxyresponse.ResultMessage.Message);
                            }

                            if (proxyresponse.Errors != null)
                            {
                                //Error List Set
                                foreach (_WA.Mapper.v2.Job.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region//JobGetResponse Set

                                if (proxyresponse.Jobs != null && proxyresponse.Jobs.Length > 0)
                                {
                                    response.Jobs = new List<Job>();
                                    foreach (_WA.Mapper.v2.Job.Job1 proxyjob in proxyresponse.Jobs)
                                    {
                                        #region//Job Header
                                        Job job = new Job();
                                        job.ActualHours = proxyjob.ActualHours;
                                        job.DMSJobNo = proxyjob.DMSJobNo;
                                        job.DMSJobNo = proxyjob.DMSJobNo;
                                        job.DMSRONo = proxyjob.DMSRONo;
                                        job.ServiceLineNumber = proxyjob.ServiceLineNumber;
                                        job.SkillLevel = proxyjob.SkillLevel;
                                        #endregion

                                        #region //Job ManagementFields
                                        if (proxyjob.ManagementFields != null)
                                        {
                                            ManagementFields managementfields = new ManagementFields();
                                            managementfields.CreateDateTimeUTC = proxyjob.ManagementFields.CreateDateTimeUTC;
                                            managementfields.LastModifiedDateTimeUTC = proxyjob.ManagementFields.LastModifiedDateTimeUTC;
                                            job.ManagementFields = managementfields;
                                        }
                                        #endregion

                                        #region//Job Comments
                                        if (proxyjob.Comments != null && proxyjob.Comments.Length > 0)
                                        {
                                            job.Comments = new List<Comment>();
                                            foreach (_WA.Mapper.v2.Job.Comment proxycomment in proxyjob.Comments)
                                            {
                                                Comment comment = new Comment();
                                                comment.DescriptionComment = proxycomment.DescriptionComment;
                                                comment.SequenceNumber = proxycomment.SequenceNumber;
                                                job.Comments.Add(comment);
                                            }
                                        }
                                        #endregion

                                        #region//Job Descriptions
                                        if (proxyjob.Descriptions != null && proxyjob.Descriptions.Length > 0)
                                        {
                                            job.Descriptions = new List<Description>();
                                            foreach (_WA.Mapper.v2.Job.Description proxydescription in proxyjob.Descriptions)
                                            {
                                                Description description = new Description();
                                                description.DescriptionComment = proxydescription.DescriptionComment;
                                                description.SequenceNumber = proxydescription.SequenceNumber;
                                                job.Descriptions.Add(description);
                                            }
                                        }
                                        #endregion

                                        #region//Job Causes
                                        if (proxyjob.Causes != null && proxyjob.Causes.Length > 0)
                                        {
                                            job.Causes = new List<Cause>();
                                            foreach (_WA.Mapper.v2.Job.Cause proxycause in proxyjob.Causes)
                                            {
                                                Cause cause = new Cause();
                                                cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                                cause.Comment = proxycause.Comment;
                                                cause.SequenceNumber = proxycause.SequenceNumber;
                                                job.Causes.Add(cause);
                                            }
                                        }
                                        #endregion

                                        #region//Job Corrections
                                        if (proxyjob.Corrections != null && proxyjob.Corrections.Length > 0)
                                        {
                                            job.Corrections = new List<Correction>();
                                            foreach (_WA.Mapper.v2.Job.Correction proxycorrection in proxyjob.Corrections)
                                            {
                                                Correction cause = new Correction();
                                                cause.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                                cause.Comment = proxycorrection.Comment;
                                                cause.SequenceNumber = proxycorrection.SequenceNumber;
                                                job.Corrections.Add(cause);
                                            }
                                        }
                                        #endregion

                                        #region//Job OPCodes
                                        if (proxyjob.OPCodes != null && proxyjob.OPCodes.Length > 0)
                                        {
                                            job.OPCodes = new List<Data.v2.Common.Job.OPCode>();
                                            foreach (_WA.Mapper.v2.Job.OPCode proxyopcode in proxyjob.OPCodes)
                                            {
                                                #region//Job OPCode Header
                                                Data.v2.Common.Job.OPCode opcode = new Data.v2.Common.Job.OPCode();
                                                opcode.ActualHours = proxyopcode.ActualHours;
                                                opcode.Code = proxyopcode.Code;
                                                opcode.Description = proxyopcode.Description;
                                                opcode.EstimatedHours = proxyopcode.EstimatedHours;
                                                opcode.SkillLevel = proxyopcode.SkillLevel;
                                                #endregion

                                                #region//Job OPCode Comments
                                                if (proxyopcode.Comments != null && proxyopcode.Comments.Length > 0)
                                                {
                                                    opcode.Comments = new List<Comment>();
                                                    foreach (_WA.Mapper.v2.Job.Comment proxycomment in proxyopcode.Comments)
                                                    {
                                                        Comment comment = new Comment();
                                                        comment.DescriptionComment = proxycomment.DescriptionComment;
                                                        comment.SequenceNumber = proxycomment.SequenceNumber;
                                                        opcode.Comments.Add(comment);
                                                    }
                                                }
                                                #endregion

                                                #region//Job OPCode Descriptions
                                                if (proxyopcode.Descriptions != null && proxyopcode.Descriptions.Length > 0)
                                                {
                                                    opcode.Descriptions = new List<Description>();
                                                    foreach (_WA.Mapper.v2.Job.Description proxydescription in proxyopcode.Descriptions)
                                                    {
                                                        Description description = new Description();
                                                        description.DescriptionComment = proxydescription.DescriptionComment;
                                                        description.SequenceNumber = proxydescription.SequenceNumber;
                                                        opcode.Descriptions.Add(description);
                                                    }
                                                }
                                                #endregion

                                                #region//Job OPCode Causes
                                                if (proxyopcode.Causes != null && proxyopcode.Causes.Length > 0)
                                                {
                                                    opcode.Causes = new List<Cause>();
                                                    foreach (_WA.Mapper.v2.Job.Cause proxycause in proxyopcode.Causes)
                                                    {
                                                        Cause cause = new Cause();
                                                        cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                                        cause.Comment = proxycause.Comment;
                                                        cause.SequenceNumber = proxycause.SequenceNumber;
                                                        opcode.Causes.Add(cause);
                                                    }
                                                }
                                                #endregion

                                                #region//Job OPCode Corrections
                                                if (proxyopcode.Corrections != null && proxyopcode.Corrections.Length > 0)
                                                {
                                                    opcode.Corrections = new List<Correction>();
                                                    foreach (_WA.Mapper.v2.Job.Correction proxycorrection in proxyopcode.Corrections)
                                                    {
                                                        Correction correction = new Correction();
                                                        correction.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                                        correction.Comment = proxycorrection.Comment;
                                                        correction.SequenceNumber = proxycorrection.SequenceNumber;
                                                        opcode.Corrections.Add(correction);
                                                    }
                                                }
                                                #endregion

                                                job.OPCodes.Add(opcode);
                                            }
                                        }
                                        #endregion

                                        #region//Job JobLogs
                                        if (proxyjob.JobLogs != null && proxyjob.JobLogs.Length > 0)
                                        {
                                            job.JobLogs = new List<JobLog>();
                                            foreach (_WA.Mapper.v2.Job.JobLog proxyjoblog in proxyjob.JobLogs)
                                            {
                                                #region//Job JobLogs Header
                                                JobLog joblog = new JobLog();
                                                joblog.DMSJobStatus = proxyjoblog.DMSJobStatus;
                                                joblog.EstimatedLaborHour = proxyjoblog.EstimatedLaborHour;
                                                joblog.LogType = proxyjoblog.LogType;
                                                joblog.ScheduledDateTimeFromLocal = proxyjoblog.ScheduledDateTimeFromLocal;
                                                joblog.ScheduledDateTimeToLocal = proxyjoblog.ScheduledDateTimeToLocal;
                                                joblog.Stall = proxyjoblog.Stall;
                                                #endregion

                                                #region//Job Technicians
                                                if (proxyjoblog.Technicians != null && proxyjoblog.Technicians.Length > 0)
                                                {
                                                    joblog.Technicians = new List<Technician>();
                                                    foreach (_WA.Mapper.v2.Job.Technician proxytechnician in proxyjoblog.Technicians)
                                                    {
                                                        Technician technician = new Technician();
                                                        technician.TCEmployeeID = proxytechnician.TCEmployeeID;
                                                        technician.TCEmployeeName = proxytechnician.TCEmployeeName;
                                                        joblog.Technicians.Add(technician);
                                                    }
                                                }
                                                #endregion

                                                #region//Job ActualTimeLogs
                                                if (proxyjoblog.ActualTimeLogs != null && proxyjoblog.ActualTimeLogs.Length > 0)
                                                {
                                                    joblog.ActualTimeLogs = new List<ActualTimeLog>();
                                                    foreach (_WA.Mapper.v2.Job.ActualTimeLog proxyactualtimelog in proxyjoblog.ActualTimeLogs)
                                                    {
                                                        ActualTimeLog actualtimelog = new ActualTimeLog();
                                                        actualtimelog.EndDateTimeLocal = proxyactualtimelog.EndDateTimeLocal;
                                                        actualtimelog.PauseReasonCode = proxyactualtimelog.PauseReasonCode;
                                                        actualtimelog.PauseReasonComment = proxyactualtimelog.PauseReasonComment;
                                                        actualtimelog.StartDateTimeLocal = proxyactualtimelog.StartDateTimeLocal;
                                                        actualtimelog.Status = proxyactualtimelog.Status;
                                                        actualtimelog.TCEmployeeID = proxyactualtimelog.TCEmployeeID;
                                                        actualtimelog.TCEmployeeName = proxyactualtimelog.TCEmployeeName;
                                                        joblog.ActualTimeLogs.Add(actualtimelog);
                                                    }
                                                }
                                                #endregion

                                                #region//Job JobComments
                                                if (proxyjoblog.JobComments != null && proxyjoblog.JobComments.Length > 0)
                                                {
                                                    joblog.JobComments = new List<JobComment>();
                                                    foreach (_WA.Mapper.v2.Job.JobComment proxyjobcomment in proxyjoblog.JobComments)
                                                    {
                                                        JobComment jobcomment = new JobComment();
                                                        jobcomment.ActualWorkHour = proxyjobcomment.ActualWorkHour;
                                                        jobcomment.SubStatus = proxyjobcomment.SubStatus;
                                                        joblog.JobComments.Add(jobcomment);
                                                    }
                                                }
                                                #endregion

                                                job.JobLogs.Add(joblog);
                                            }
                                        }
                                        #endregion

                                        response.Jobs.Add(job);
                                    }
                                }
                                else
                                {
                                    response.ResultMessage = GetResultMessageData(ResponseCode.NoResult, ResponseMessage.NoResult);
                                }
                                #endregion
                            }
                        }
                        else
                        {
                            if (response.Errors != null)
                                response.Errors.Add(GetErrorData(ResponseCode.Fail, ResponseMessage.Fail));
                            else
                                response.Errors = GetErrorDataList(ResponseCode.Fail, ResponseMessage.Fail);
                        }
                        #endregion
                    }
                    break;
                case "v2.HMCIS.1C.v4":
                    {
                        #region v2.HMCIS.1C.v4 - RTR (Proxy Class Dll Name : _1C.v4)

                        #region JobGet Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _1C.v4.Job.Job proxyws = new _1C.v4.Job.Job(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with jobget and transaction
                        _1C.v4.Job.JobGetRequest proxyrequest = new _1C.v4.Job.JobGetRequest();

                        //Create proxy transaction
                        _1C.v4.Job.TransactionHeader proxytransactionheader = new _1C.v4.Job.TransactionHeader();
                        if (request.TransactionHeader != null)
                        {
                            #region//TransactionHeader Set
                            proxytransactionheader.CountryID = request.TransactionHeader.CountryID;
                            proxytransactionheader.DealerID = request.TransactionHeader.DealerID;
                            proxytransactionheader.DistributorID = request.TransactionHeader.DistributorID;
                            proxytransactionheader.DMSCode = request.TransactionHeader.DMSCode;
                            proxytransactionheader.DMSServerUrl = request.TransactionHeader.DMSServerUrl;
                            proxytransactionheader.DMSVersion = request.TransactionHeader.DMSVersion;
                            proxytransactionheader.DocumentVersion = request.TransactionHeader.DocumentVersion;
                            proxytransactionheader.GroupID = request.TransactionHeader.GroupID;
                            proxytransactionheader.IneterfaceID = request.TransactionHeader.IneterfaceID;
                            proxytransactionheader.Password = request.TransactionHeader.Password;
                            proxytransactionheader.PollingToken = request.TransactionHeader.PollingToken;
                            proxytransactionheader.RequestPollingToken = request.TransactionHeader.RequestPollingToken;
                            proxytransactionheader.RequestType = request.TransactionHeader.RequestType;
                            proxytransactionheader.TransactionId = request.TransactionHeader.TransactionId;
                            proxytransactionheader.TransactionDateTimeLocal = request.TransactionHeader.TransactionDateTimeLocal;
                            proxytransactionheader.TransactionDateTimeUTC = request.TransactionHeader.TransactionDateTimeUTC;
                            proxytransactionheader.TransactionType = request.TransactionHeader.TransactionType;
                            proxytransactionheader.Username = request.TransactionHeader.Username;
                            proxytransactionheader.VenderTrackingCode = request.TransactionHeader.VenderTrackingCode;
                            proxyrequest.TransactionHeader = proxytransactionheader;
                            #endregion
                        }

                        //Create proxy jobget
                        _1C.v4.Job.JobGet proxyjobget = new _1C.v4.Job.JobGet();
                        if (request.JobGet != null)
                        {
                            #region//JobGet Set
                            proxyjobget.DMSJobNo = request.JobGet.DMSJobNo;
                            proxyjobget.DMSJobNo = request.JobGet.DMSJobNo;
                            proxyjobget.DMSJobStatus = request.JobGet.DMSJobStatus;
                            proxyjobget.DMSRONo = request.JobGet.DMSRONo;
                            proxyjobget.LastModifiedDateTimeFromUTC = request.JobGet.LastModifiedDateTimeFromUTC;
                            proxyjobget.LastModifiedDateTimeToUTC = request.JobGet.LastModifiedDateTimeToUTC;
                            proxyjobget.ScheduledDateTimeFromLocal = request.JobGet.ScheduledDateTimeFromLocal;
                            proxyjobget.ScheduledDateTimeToLocal = request.JobGet.ScheduledDateTimeToLocal;
                            proxyrequest.JobGet = proxyjobget;
                            #endregion
                        }

                        #endregion

                        //Run proxy web method with proxy request
                        _1C.v4.Job.JobGetResponse proxyresponse = proxyws.JobGet(proxyrequest);

                        //Mapping with Standard Interface Specification Object
                        if (proxyresponse != null)
                        {
                            if (proxyresponse.TransactionHeader != null)
                            {
                                #region//TransactionHeader Set
                                TransactionHeader transactionheader = new TransactionHeader();
                                transactionheader.CountryID = proxyresponse.TransactionHeader.CountryID;
                                transactionheader.DealerID = proxyresponse.TransactionHeader.DealerID;
                                transactionheader.DistributorID = proxyresponse.TransactionHeader.DistributorID;
                                transactionheader.DMSCode = proxyresponse.TransactionHeader.DMSCode;
                                transactionheader.DMSServerUrl = proxyresponse.TransactionHeader.DMSServerUrl;
                                transactionheader.DMSVersion = proxyresponse.TransactionHeader.DMSVersion;
                                transactionheader.DocumentVersion = proxyresponse.TransactionHeader.DocumentVersion;
                                transactionheader.GroupID = proxyresponse.TransactionHeader.GroupID;
                                transactionheader.IneterfaceID = proxyresponse.TransactionHeader.IneterfaceID;
                                transactionheader.Password = proxyresponse.TransactionHeader.Password;
                                transactionheader.PollingToken = proxyresponse.TransactionHeader.PollingToken;
                                transactionheader.RequestPollingToken = proxyresponse.TransactionHeader.RequestPollingToken;
                                transactionheader.RequestType = proxyresponse.TransactionHeader.RequestType;
                                transactionheader.TransactionId = proxyresponse.TransactionHeader.TransactionId;
                                transactionheader.TransactionDateTimeLocal = proxyresponse.TransactionHeader.TransactionDateTimeLocal;
                                transactionheader.TransactionDateTimeUTC = proxyresponse.TransactionHeader.TransactionDateTimeUTC;
                                transactionheader.TransactionType = proxyresponse.TransactionHeader.TransactionType;
                                transactionheader.Username = proxyresponse.TransactionHeader.Username;
                                transactionheader.VenderTrackingCode = proxyresponse.TransactionHeader.VenderTrackingCode;
                                response.TransactionHeader = transactionheader;
                                #endregion
                            }

                            //ResultMessage Set
                            if (proxyresponse.ResultMessage != null)
                            {
                                response.ResultMessage = GetResultMessageData(proxyresponse.ResultMessage.Code, proxyresponse.ResultMessage.Message);
                            }

                            if (proxyresponse.Errors != null)
                            {
                                //Error List Set
                                foreach (_1C.v4.Job.Error proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region//JobGetResponse Set

                                if (proxyresponse.Jobs != null && proxyresponse.Jobs.Length > 0)
                                {
                                    response.Jobs = new List<Job>();
                                    foreach (_1C.v4.Job.Job1 proxyjob in proxyresponse.Jobs)
                                    {
                                        #region//Job Header
                                        Job job = new Job();
                                        job.ActualHours = proxyjob.ActualHours;
                                        job.DMSJobNo = proxyjob.DMSJobNo;
                                        job.DMSJobNo = proxyjob.DMSJobNo;
                                        job.DMSRONo = proxyjob.DMSRONo;
                                        job.ServiceLineNumber = proxyjob.ServiceLineNumber;
                                        job.SkillLevel = proxyjob.SkillLevel;
                                        #endregion

                                        #region //Job ManagementFields
                                        if (proxyjob.ManagementFields != null)
                                        {
                                            ManagementFields managementfields = new ManagementFields();
                                            managementfields.CreateDateTimeUTC = proxyjob.ManagementFields.CreateDateTimeUTC;
                                            managementfields.LastModifiedDateTimeUTC = proxyjob.ManagementFields.LastModifiedDateTimeUTC;
                                            job.ManagementFields = managementfields;
                                        }
                                        #endregion

                                        #region//Job Comments
                                        if (proxyjob.Comments != null && proxyjob.Comments.Length > 0)
                                        {
                                            job.Comments = new List<Comment>();
                                            foreach (_1C.v4.Job.Comment proxycomment in proxyjob.Comments)
                                            {
                                                Comment comment = new Comment();
                                                comment.DescriptionComment = proxycomment.DescriptionComment;
                                                comment.SequenceNumber = proxycomment.SequenceNumber;
                                                job.Comments.Add(comment);
                                            }
                                        }
                                        #endregion

                                        #region//Job Descriptions
                                        if (proxyjob.Descriptions != null && proxyjob.Descriptions.Length > 0)
                                        {
                                            job.Descriptions = new List<Description>();
                                            foreach (_1C.v4.Job.Description proxydescription in proxyjob.Descriptions)
                                            {
                                                Description description = new Description();
                                                description.DescriptionComment = proxydescription.DescriptionComment;
                                                description.SequenceNumber = proxydescription.SequenceNumber;
                                                job.Descriptions.Add(description);
                                            }
                                        }
                                        #endregion

                                        #region//Job Causes
                                        if (proxyjob.Causes != null && proxyjob.Causes.Length > 0)
                                        {
                                            job.Causes = new List<Cause>();
                                            foreach (_1C.v4.Job.Cause proxycause in proxyjob.Causes)
                                            {
                                                Cause cause = new Cause();
                                                cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                                cause.Comment = proxycause.Comment;
                                                cause.SequenceNumber = proxycause.SequenceNumber;
                                                job.Causes.Add(cause);
                                            }
                                        }
                                        #endregion

                                        #region//Job Corrections
                                        if (proxyjob.Corrections != null && proxyjob.Corrections.Length > 0)
                                        {
                                            job.Corrections = new List<Correction>();
                                            foreach (_1C.v4.Job.Correction proxycorrection in proxyjob.Corrections)
                                            {
                                                Correction cause = new Correction();
                                                cause.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                                cause.Comment = proxycorrection.Comment;
                                                cause.SequenceNumber = proxycorrection.SequenceNumber;
                                                job.Corrections.Add(cause);
                                            }
                                        }
                                        #endregion

                                        #region//Job OPCodes
                                        if (proxyjob.OPCodes != null && proxyjob.OPCodes.Length > 0)
                                        {
                                            job.OPCodes = new List<Data.v2.Common.Job.OPCode>();
                                            foreach (_1C.v4.Job.OPCode proxyopcode in proxyjob.OPCodes)
                                            {
                                                #region//Job OPCode Header
                                                Data.v2.Common.Job.OPCode opcode = new Data.v2.Common.Job.OPCode();
                                                opcode.ActualHours = proxyopcode.ActualHours;
                                                opcode.Code = proxyopcode.Code;
                                                opcode.Description = proxyopcode.Description;
                                                opcode.EstimatedHours = proxyopcode.EstimatedHours;
                                                opcode.SkillLevel = proxyopcode.SkillLevel;
                                                #endregion

                                                #region//Job OPCode Comments
                                                if (proxyopcode.Comments != null && proxyopcode.Comments.Length > 0)
                                                {
                                                    opcode.Comments = new List<Comment>();
                                                    foreach (_1C.v4.Job.Comment proxycomment in proxyopcode.Comments)
                                                    {
                                                        Comment comment = new Comment();
                                                        comment.DescriptionComment = proxycomment.DescriptionComment;
                                                        comment.SequenceNumber = proxycomment.SequenceNumber;
                                                        opcode.Comments.Add(comment);
                                                    }
                                                }
                                                #endregion

                                                #region//Job OPCode Descriptions
                                                if (proxyopcode.Descriptions != null && proxyopcode.Descriptions.Length > 0)
                                                {
                                                    opcode.Descriptions = new List<Description>();
                                                    foreach (_1C.v4.Job.Description proxydescription in proxyopcode.Descriptions)
                                                    {
                                                        Description description = new Description();
                                                        description.DescriptionComment = proxydescription.DescriptionComment;
                                                        description.SequenceNumber = proxydescription.SequenceNumber;
                                                        opcode.Descriptions.Add(description);
                                                    }
                                                }
                                                #endregion

                                                #region//Job OPCode Causes
                                                if (proxyopcode.Causes != null && proxyopcode.Causes.Length > 0)
                                                {
                                                    opcode.Causes = new List<Cause>();
                                                    foreach (_1C.v4.Job.Cause proxycause in proxyopcode.Causes)
                                                    {
                                                        Cause cause = new Cause();
                                                        cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                                        cause.Comment = proxycause.Comment;
                                                        cause.SequenceNumber = proxycause.SequenceNumber;
                                                        opcode.Causes.Add(cause);
                                                    }
                                                }
                                                #endregion

                                                #region//Job OPCode Corrections
                                                if (proxyopcode.Corrections != null && proxyopcode.Corrections.Length > 0)
                                                {
                                                    opcode.Corrections = new List<Correction>();
                                                    foreach (_1C.v4.Job.Correction proxycorrection in proxyopcode.Corrections)
                                                    {
                                                        Correction correction = new Correction();
                                                        correction.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                                        correction.Comment = proxycorrection.Comment;
                                                        correction.SequenceNumber = proxycorrection.SequenceNumber;
                                                        opcode.Corrections.Add(correction);
                                                    }
                                                }
                                                #endregion

                                                job.OPCodes.Add(opcode);
                                            }
                                        }
                                        #endregion

                                        #region//Job JobLogs
                                        if (proxyjob.JobLogs != null && proxyjob.JobLogs.Length > 0)
                                        {
                                            job.JobLogs = new List<JobLog>();
                                            foreach (_1C.v4.Job.JobLog proxyjoblog in proxyjob.JobLogs)
                                            {
                                                #region//Job JobLogs Header
                                                JobLog joblog = new JobLog();
                                                joblog.DMSJobStatus = proxyjoblog.DMSJobStatus;
                                                joblog.EstimatedLaborHour = proxyjoblog.EstimatedLaborHour;
                                                joblog.LogType = proxyjoblog.LogType;
                                                joblog.ScheduledDateTimeFromLocal = proxyjoblog.ScheduledDateTimeFromLocal;
                                                joblog.ScheduledDateTimeToLocal = proxyjoblog.ScheduledDateTimeToLocal;
                                                joblog.Stall = proxyjoblog.Stall;
                                                #endregion

                                                #region//Job Technicians
                                                if (proxyjoblog.Technicians != null && proxyjoblog.Technicians.Length > 0)
                                                {
                                                    joblog.Technicians = new List<Technician>();
                                                    foreach (_1C.v4.Job.Technician proxytechnician in proxyjoblog.Technicians)
                                                    {
                                                        Technician technician = new Technician();
                                                        technician.TCEmployeeID = proxytechnician.TCEmployeeID;
                                                        technician.TCEmployeeName = proxytechnician.TCEmployeeName;
                                                        joblog.Technicians.Add(technician);
                                                    }
                                                }
                                                #endregion

                                                #region//Job ActualTimeLogs
                                                if (proxyjoblog.ActualTimeLogs != null && proxyjoblog.ActualTimeLogs.Length > 0)
                                                {
                                                    joblog.ActualTimeLogs = new List<ActualTimeLog>();
                                                    foreach (_1C.v4.Job.ActualTimeLog proxyactualtimelog in proxyjoblog.ActualTimeLogs)
                                                    {
                                                        ActualTimeLog actualtimelog = new ActualTimeLog();
                                                        actualtimelog.EndDateTimeLocal = proxyactualtimelog.EndDateTimeLocal;
                                                        actualtimelog.PauseReasonCode = proxyactualtimelog.PauseReasonCode;
                                                        actualtimelog.PauseReasonComment = proxyactualtimelog.PauseReasonComment;
                                                        actualtimelog.StartDateTimeLocal = proxyactualtimelog.StartDateTimeLocal;
                                                        actualtimelog.Status = proxyactualtimelog.Status;
                                                        actualtimelog.TCEmployeeID = proxyactualtimelog.TCEmployeeID;
                                                        actualtimelog.TCEmployeeName = proxyactualtimelog.TCEmployeeName;
                                                        joblog.ActualTimeLogs.Add(actualtimelog);
                                                    }
                                                }
                                                #endregion

                                                #region//Job JobComments
                                                if (proxyjoblog.JobComments != null && proxyjoblog.JobComments.Length > 0)
                                                {
                                                    joblog.JobComments = new List<JobComment>();
                                                    foreach (_1C.v4.Job.JobComment proxyjobcomment in proxyjoblog.JobComments)
                                                    {
                                                        JobComment jobcomment = new JobComment();
                                                        jobcomment.ActualWorkHour = proxyjobcomment.ActualWorkHour;
                                                        jobcomment.SubStatus = proxyjobcomment.SubStatus;
                                                        joblog.JobComments.Add(jobcomment);
                                                    }
                                                }
                                                #endregion

                                                job.JobLogs.Add(joblog);
                                            }
                                        }
                                        #endregion

                                        response.Jobs.Add(job);
                                    }
                                }
                                else
                                {
                                    response.ResultMessage = GetResultMessageData(ResponseCode.NoResult, ResponseMessage.NoResult);
                                }
                                #endregion
                            }
                        }
                        else
                        {
                            if (response.Errors != null)
                                response.Errors.Add(GetErrorData(ResponseCode.Fail, ResponseMessage.Fail));
                            else
                                response.Errors = GetErrorDataList(ResponseCode.Fail, ResponseMessage.Fail);
                        }
                        #endregion
                    }
                    break;
                default: response.Errors = new List<Error>() { new Error() { Code = ResponseCode.NoMatchedProxy, Message = ResponseMessage.NoMatchedProxy } };
                    break;
            }

            return response;
        }

        public JobChangeResponse JobChange(JobChangeRequest request)
        {
            JobChangeResponse response = new JobChangeResponse();

            //DMS information set by dealer information
            string proxypath = string.Format("{0}.{1}.{2}.{3}",
                request.TransactionHeader.DocumentVersion,
                request.TransactionHeader.DistributorID,
                request.TransactionHeader.DMSCode,
                request.TransactionHeader.DMSVersion);

            switch (proxypath)
            {
                case "v2.Common.WA.v2":
                    {
                        #region v2.Common.WA.v2 - Standard (Proxy Class Dll Name : _WA.Mapper.v2)

                        #region JobChange Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _WA.Mapper.v2.Job.Job proxyws = new _WA.Mapper.v2.Job.Job(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with jobchange and transaction
                        _WA.Mapper.v2.Job.JobChangeRequest proxyrequest = new _WA.Mapper.v2.Job.JobChangeRequest();

                        //Create proxy transaction
                        _WA.Mapper.v2.Job.TransactionHeader2 proxytransactionheader = new _WA.Mapper.v2.Job.TransactionHeader2();
                        if (request.TransactionHeader != null)
                        {
                            #region//TransactionHeader Set
                            proxytransactionheader.CountryID = request.TransactionHeader.CountryID;
                            proxytransactionheader.DealerID = request.TransactionHeader.DealerID;
                            proxytransactionheader.DistributorID = request.TransactionHeader.DistributorID;
                            proxytransactionheader.DMSCode = request.TransactionHeader.DMSCode;
                            proxytransactionheader.DMSServerUrl = request.TransactionHeader.DMSServerUrl;
                            proxytransactionheader.DMSVersion = request.TransactionHeader.DMSVersion;
                            proxytransactionheader.DocumentVersion = request.TransactionHeader.DocumentVersion;
                            proxytransactionheader.GroupID = request.TransactionHeader.GroupID;
                            proxytransactionheader.IneterfaceID = request.TransactionHeader.IneterfaceID;
                            proxytransactionheader.Password = request.TransactionHeader.Password;
                            proxytransactionheader.PollingToken = request.TransactionHeader.PollingToken;
                            proxytransactionheader.RequestPollingToken = request.TransactionHeader.RequestPollingToken;
                            proxytransactionheader.RequestType = request.TransactionHeader.RequestType;
                            proxytransactionheader.TransactionId = request.TransactionHeader.TransactionId;
                            proxytransactionheader.TransactionDateTimeLocal = request.TransactionHeader.TransactionDateTimeLocal;
                            proxytransactionheader.TransactionDateTimeUTC = request.TransactionHeader.TransactionDateTimeUTC;
                            proxytransactionheader.TransactionType = request.TransactionHeader.TransactionType;
                            proxytransactionheader.Username = request.TransactionHeader.Username;
                            proxytransactionheader.VenderTrackingCode = request.TransactionHeader.VenderTrackingCode;
                            proxyrequest.TransactionHeader = proxytransactionheader;
                            #endregion
                        }

                        //Create proxy jobchange
                        _WA.Mapper.v2.Job.JobChange proxyjobchange = new _WA.Mapper.v2.Job.JobChange();
                        if (request.JobChange != null)
                        {
                            #region//JobChange Header
                            proxyjobchange.ActualHours = request.JobChange.ActualHours;
                            proxyjobchange.DMSJobNo = request.JobChange.DMSJobNo;
                            proxyjobchange.DMSJobNo = request.JobChange.DMSJobNo;
                            proxyjobchange.DMSRONo = request.JobChange.DMSRONo;
                            proxyjobchange.EstimatedHours = request.JobChange.EstimatedHours;
                            proxyjobchange.ServiceLineNumber = request.JobChange.ServiceLineNumber;
                            proxyjobchange.SkillLevel = request.JobChange.SkillLevel;
                            #endregion

                            #region//JobChange Comments
                            if (request.JobChange.Comments != null && request.JobChange.Comments.Count > 0)
                            {
                                int commentscnt = 0;
                                _WA.Mapper.v2.Job.Comment1[] proxycomments = new _WA.Mapper.v2.Job.Comment1[request.JobChange.Comments.Count];
                                foreach (Comment Comment in request.JobChange.Comments)
                                {
                                    _WA.Mapper.v2.Job.Comment1 proxycomment = new _WA.Mapper.v2.Job.Comment1();
                                    proxycomment.DescriptionComment = Comment.DescriptionComment;
                                    proxycomment.SequenceNumber = Comment.SequenceNumber;
                                    proxycomments[commentscnt] = proxycomment;
                                    commentscnt++;
                                }
                                proxyjobchange.Comments = proxycomments;
                            }
                            #endregion

                            #region//JobChange Descriptions
                            if (request.JobChange.Descriptions != null && request.JobChange.Descriptions.Count > 0)
                            {
                                int descriptionscnt = 0;
                                _WA.Mapper.v2.Job.Description1[] proxydescriptions = new _WA.Mapper.v2.Job.Description1[request.JobChange.Descriptions.Count];
                                foreach (Description description in request.JobChange.Descriptions)
                                {
                                    _WA.Mapper.v2.Job.Description1 proxydescription = new _WA.Mapper.v2.Job.Description1();
                                    proxydescription.DescriptionComment = description.DescriptionComment;
                                    proxydescription.SequenceNumber = description.SequenceNumber;
                                    proxydescriptions[descriptionscnt] = proxydescription;
                                    descriptionscnt++;
                                }
                                proxyjobchange.Descriptions = proxydescriptions;
                            }
                            #endregion

                            #region//JobChange Causes
                            if (request.JobChange.Causes != null && request.JobChange.Causes.Count > 0)
                            {
                                int causescnt = 0;
                                _WA.Mapper.v2.Job.Cause1[] proxycauses = new _WA.Mapper.v2.Job.Cause1[request.JobChange.Causes.Count];
                                foreach (Cause cause in request.JobChange.Causes)
                                {
                                    _WA.Mapper.v2.Job.Cause1 proxycause = new _WA.Mapper.v2.Job.Cause1();
                                    proxycause.CauseLaborOpCode = cause.CauseLaborOpCode;
                                    proxycause.Comment = cause.Comment;
                                    proxycause.SequenceNumber = cause.SequenceNumber;
                                    proxycauses[causescnt] = proxycause;
                                    causescnt++;
                                }
                                proxyjobchange.Causes = proxycauses;
                            }
                            #endregion

                            #region//JobChange Corrections
                            if (request.JobChange.Corrections != null && request.JobChange.Corrections.Count > 0)
                            {
                                int correctionscnt = 0;
                                _WA.Mapper.v2.Job.Correction1[] proxycorrections = new _WA.Mapper.v2.Job.Correction1[request.JobChange.Corrections.Count];
                                foreach (Correction correction in request.JobChange.Corrections)
                                {
                                    _WA.Mapper.v2.Job.Correction1 proxycorrection = new _WA.Mapper.v2.Job.Correction1();
                                    proxycorrection.CorrectionLaborOpCode = correction.CorrectionLaborOpCode;
                                    proxycorrection.Comment = correction.Comment;
                                    proxycorrection.SequenceNumber = correction.SequenceNumber;
                                    proxycorrections[correctionscnt] = proxycorrection;
                                    correctionscnt++;
                                }
                                proxyjobchange.Corrections = proxycorrections;
                            }
                            #endregion

                            #region//JobChange OPCodes
                            if (request.JobChange.OPCodes != null && request.JobChange.OPCodes.Count > 0)
                            {
                                int opcodescnt = 0;
                                _WA.Mapper.v2.Job.OPCode1[] proxyopcodes = new _WA.Mapper.v2.Job.OPCode1[request.JobChange.OPCodes.Count];
                                foreach (WA.Standard.IF.Data.v2.Common.Job.OPCode opcode in request.JobChange.OPCodes)
                                {
                                    #region//JobChange OPCode Header
                                    _WA.Mapper.v2.Job.OPCode1 proxyopcode = new _WA.Mapper.v2.Job.OPCode1();
                                    proxyopcode.ActualHours = opcode.ActualHours;
                                    proxyopcode.Code = opcode.Code;
                                    proxyopcode.Description = opcode.Description;
                                    proxyopcode.EstimatedHours = opcode.EstimatedHours;
                                    proxyopcode.SkillLevel = opcode.SkillLevel;
                                    #endregion

                                    #region//JobChange OPCode Comments
                                    if (opcode.Comments != null && opcode.Comments.Count > 0)
                                    {
                                        int commentscnt = 0;
                                        _WA.Mapper.v2.Job.Comment1[] proxycomments = new _WA.Mapper.v2.Job.Comment1[opcode.Comments.Count];
                                        foreach (Comment comment in opcode.Comments)
                                        {
                                            _WA.Mapper.v2.Job.Comment1 proxycomment = new _WA.Mapper.v2.Job.Comment1();
                                            proxycomment.DescriptionComment = comment.DescriptionComment;
                                            proxycomment.SequenceNumber = comment.SequenceNumber;
                                            proxycomments[commentscnt] = proxycomment;
                                            commentscnt++;
                                        }
                                        proxyopcode.Comments = proxycomments;
                                    }
                                    #endregion

                                    #region//JobChange OPCode Descriptions
                                    if (opcode.Descriptions != null && opcode.Descriptions.Count > 0)
                                    {
                                        int descriptionscnt = 0;
                                        _WA.Mapper.v2.Job.Description1[] proxydescriptions = new _WA.Mapper.v2.Job.Description1[opcode.Descriptions.Count];
                                        foreach (Description description in opcode.Descriptions)
                                        {
                                            _WA.Mapper.v2.Job.Description1 proxydescription = new _WA.Mapper.v2.Job.Description1();
                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                            proxydescriptions[descriptionscnt] = proxydescription;
                                            descriptionscnt++;
                                        }
                                        proxyopcode.Descriptions = proxydescriptions;
                                    }
                                    #endregion

                                    #region//JobChange OPCode Causes
                                    if (opcode.Causes != null && opcode.Causes.Count > 0)
                                    {
                                        int causescnt = 0;
                                        _WA.Mapper.v2.Job.Cause1[] proxycauses = new _WA.Mapper.v2.Job.Cause1[opcode.Causes.Count];
                                        foreach (Cause cause in opcode.Causes)
                                        {
                                            _WA.Mapper.v2.Job.Cause1 proxycause = new _WA.Mapper.v2.Job.Cause1();
                                            proxycause.CauseLaborOpCode = cause.CauseLaborOpCode;
                                            proxycause.Comment = cause.Comment;
                                            proxycause.SequenceNumber = cause.SequenceNumber;
                                            proxycauses[causescnt] = proxycause;
                                            causescnt++;
                                        }
                                        proxyopcode.Causes = proxycauses;
                                    }
                                    #endregion

                                    #region//JobChange OPCode Corrections
                                    if (opcode.Corrections != null && opcode.Corrections.Count > 0)
                                    {
                                        int correctionscnt = 0;
                                        _WA.Mapper.v2.Job.Correction1[] proxycorrections = new _WA.Mapper.v2.Job.Correction1[opcode.Corrections.Count];
                                        foreach (Correction correction in opcode.Corrections)
                                        {
                                            _WA.Mapper.v2.Job.Correction1 proxycorrection = new _WA.Mapper.v2.Job.Correction1();
                                            proxycorrection.CorrectionLaborOpCode = correction.CorrectionLaborOpCode;
                                            proxycorrection.Comment = correction.Comment;
                                            proxycorrection.SequenceNumber = correction.SequenceNumber;
                                            proxycorrections[correctionscnt] = proxycorrection;
                                            correctionscnt++;
                                        }
                                        proxyopcode.Corrections = proxycorrections;
                                    }
                                    #endregion

                                    proxyopcodes[opcodescnt] = proxyopcode;
                                    opcodescnt++;
                                }
                                proxyjobchange.OPCodes = proxyopcodes;
                            }
                            #endregion

                            #region//JobChange JobLogs
                            if (request.JobChange.JobLogs != null && request.JobChange.JobLogs.Count > 0)
                            {
                                int joblogsscnt = 0;
                                _WA.Mapper.v2.Job.JobLog1[] proxyjoblogs = new _WA.Mapper.v2.Job.JobLog1[request.JobChange.JobLogs.Count];
                                foreach (WA.Standard.IF.Data.v2.Common.Job.JobLog joblog in request.JobChange.JobLogs)
                                {
                                    #region//JobChange JobLogs Header
                                    _WA.Mapper.v2.Job.JobLog1 proxyjoblog = new _WA.Mapper.v2.Job.JobLog1();
                                    proxyjoblog.DMSJobStatus = joblog.DMSJobStatus;
                                    proxyjoblog.EstimatedLaborHour = joblog.EstimatedLaborHour;
                                    proxyjoblog.LogType = joblog.LogType;
                                    proxyjoblog.ScheduledDateTimeFromLocal = joblog.ScheduledDateTimeFromLocal;
                                    proxyjoblog.ScheduledDateTimeToLocal = joblog.ScheduledDateTimeToLocal;
                                    proxyjoblog.Stall = joblog.Stall;
                                    #endregion

                                    #region//JobChange JobLogs Technicians
                                    if (joblog.Technicians != null && joblog.Technicians.Count > 0)
                                    {
                                        int technicianscnt = 0;
                                        _WA.Mapper.v2.Job.Technician1[] proxytechnicians = new _WA.Mapper.v2.Job.Technician1[joblog.Technicians.Count];
                                        foreach (Technician technician in joblog.Technicians)
                                        {
                                            _WA.Mapper.v2.Job.Technician1 proxytechnician = new _WA.Mapper.v2.Job.Technician1();
                                            proxytechnician.TCEmployeeID = technician.TCEmployeeID;
                                            proxytechnician.TCEmployeeName = technician.TCEmployeeName;
                                            proxytechnicians[technicianscnt] = proxytechnician;
                                            technicianscnt++;
                                        }
                                        proxyjoblog.Technicians = proxytechnicians;
                                    }
                                    #endregion

                                    #region//JobChange JobLogs ActualTimeLogs
                                    if (joblog.ActualTimeLogs != null && joblog.ActualTimeLogs.Count > 0)
                                    {
                                        int actualtimelogscnt = 0;
                                        _WA.Mapper.v2.Job.ActualTimeLog1[] proxyactualtimelogs = new _WA.Mapper.v2.Job.ActualTimeLog1[joblog.ActualTimeLogs.Count];
                                        foreach (ActualTimeLog actualtimelog in joblog.ActualTimeLogs)
                                        {
                                            _WA.Mapper.v2.Job.ActualTimeLog1 proxyactualtimelog = new _WA.Mapper.v2.Job.ActualTimeLog1();
                                            proxyactualtimelog.EndDateTimeLocal = actualtimelog.EndDateTimeLocal;
                                            proxyactualtimelog.PauseReasonCode = actualtimelog.PauseReasonCode;
                                            proxyactualtimelog.PauseReasonComment = actualtimelog.PauseReasonComment;
                                            proxyactualtimelog.StartDateTimeLocal = actualtimelog.StartDateTimeLocal;
                                            proxyactualtimelog.Status = actualtimelog.Status;
                                            proxyactualtimelog.TCEmployeeID = actualtimelog.TCEmployeeID;
                                            proxyactualtimelog.TCEmployeeName = actualtimelog.TCEmployeeName;
                                            proxyactualtimelogs[actualtimelogscnt] = proxyactualtimelog;
                                            actualtimelogscnt++;
                                        }
                                        proxyjoblog.ActualTimeLogs = proxyactualtimelogs;
                                    }
                                    #endregion

                                    #region//JobChange JobLogs JobComments
                                    if (joblog.JobComments != null && joblog.JobComments.Count > 0)
                                    {
                                        int jobcommentscnt = 0;
                                        _WA.Mapper.v2.Job.JobComment1[] proxyjobcomments = new _WA.Mapper.v2.Job.JobComment1[joblog.JobComments.Count];
                                        foreach (JobComment jobcomment in joblog.JobComments)
                                        {
                                            _WA.Mapper.v2.Job.JobComment1 proxyjobcomment = new _WA.Mapper.v2.Job.JobComment1();
                                            proxyjobcomment.ActualWorkHour = jobcomment.ActualWorkHour;
                                            proxyjobcomment.SubStatus = jobcomment.SubStatus;
                                            proxyjobcomments[jobcommentscnt] = proxyjobcomment;
                                            jobcommentscnt++;
                                        }
                                        proxyjoblog.JobComments = proxyjobcomments;
                                    }
                                    #endregion

                                    proxyjoblogs[joblogsscnt] = proxyjoblog;
                                    joblogsscnt++;
                                }
                                proxyjobchange.JobLogs = proxyjoblogs;
                            }
                            #endregion
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _WA.Mapper.v2.Job.JobChangeResponse proxyresponse = proxyws.JobChange(proxyrequest);

                        //Mapping with Standard Interface Specification Object
                        if (proxyresponse != null)
                        {
                            if (proxyresponse.TransactionHeader != null)
                            {
                                #region//TransactionHeader Set
                                TransactionHeader transactionheader = new TransactionHeader();
                                transactionheader.CountryID = proxyresponse.TransactionHeader.CountryID;
                                transactionheader.DealerID = proxyresponse.TransactionHeader.DealerID;
                                transactionheader.DistributorID = proxyresponse.TransactionHeader.DistributorID;
                                transactionheader.DMSCode = proxyresponse.TransactionHeader.DMSCode;
                                transactionheader.DMSServerUrl = proxyresponse.TransactionHeader.DMSServerUrl;
                                transactionheader.DMSVersion = proxyresponse.TransactionHeader.DMSVersion;
                                transactionheader.DocumentVersion = proxyresponse.TransactionHeader.DocumentVersion;
                                transactionheader.GroupID = proxyresponse.TransactionHeader.GroupID;
                                transactionheader.IneterfaceID = proxyresponse.TransactionHeader.IneterfaceID;
                                transactionheader.Password = proxyresponse.TransactionHeader.Password;
                                transactionheader.PollingToken = proxyresponse.TransactionHeader.PollingToken;
                                transactionheader.RequestPollingToken = proxyresponse.TransactionHeader.RequestPollingToken;
                                transactionheader.RequestType = proxyresponse.TransactionHeader.RequestType;
                                transactionheader.TransactionId = proxyresponse.TransactionHeader.TransactionId;
                                transactionheader.TransactionDateTimeLocal = proxyresponse.TransactionHeader.TransactionDateTimeLocal;
                                transactionheader.TransactionDateTimeUTC = proxyresponse.TransactionHeader.TransactionDateTimeUTC;
                                transactionheader.TransactionType = proxyresponse.TransactionHeader.TransactionType;
                                transactionheader.Username = proxyresponse.TransactionHeader.Username;
                                transactionheader.VenderTrackingCode = proxyresponse.TransactionHeader.VenderTrackingCode;
                                response.TransactionHeader = transactionheader;
                                #endregion
                            }

                            //ResultMessage Set
                            if (proxyresponse.ResultMessage != null)
                            {
                                response.ResultMessage = GetResultMessageData(proxyresponse.ResultMessage.Code, proxyresponse.ResultMessage.Message);
                            }

                            if (proxyresponse.Errors != null)
                            {
                                //Error List Set
                                foreach (_WA.Mapper.v2.Job.Error1 proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region//JobGetResponse Set

                                //if (proxyresponse.Job != null)
                                //{
                                //_WA.Mapper.v2.Job.Job2 proxyjob = proxyresponse.Job;

                                //#region//Job Header
                                //Job job = new Job();
                                //job.ActualHours = proxyjob.ActualHours;
                                //job.DMSJobNo = proxyjob.DMSJobNo;
                                //job.DMSJobNo = proxyjob.DMSJobNo;
                                //job.DMSRONo = proxyjob.DMSRONo;
                                //job.ServiceLineNumber = proxyjob.ServiceLineNumber;
                                //job.SkillLevel = proxyjob.SkillLevel;
                                //#endregion

                                //#region //Job ManagementFields
                                //if (proxyjob.ManagementFields != null)
                                //{
                                //    ManagementFields managementfields = new ManagementFields();
                                //    managementfields.CreateDateTimeUTC = proxyjob.ManagementFields.CreateDateTimeUTC;
                                //    managementfields.LastModifiedDateTimeUTC = proxyjob.ManagementFields.LastModifiedDateTimeUTC;
                                //    job.ManagementFields = managementfields;
                                //}
                                //#endregion

                                //#region//Job Comments
                                //if (proxyjob.Comments != null && proxyjob.Comments.Length > 0)
                                //{
                                //    job.Comments = new List<Comment>();
                                //    foreach (_WA.Mapper.v2.Job.Comment2 proxycomment in proxyjob.Comments)
                                //    {
                                //        Comment comment = new Comment();
                                //        comment.DescriptionComment = proxycomment.DescriptionComment;
                                //        comment.SequenceNumber = proxycomment.SequenceNumber;
                                //        job.Comments.Add(comment);
                                //    }
                                //}
                                //#endregion

                                //#region//Job Descriptions
                                //if (proxyjob.Descriptions != null && proxyjob.Descriptions.Length > 0)
                                //{
                                //    job.Descriptions = new List<Description>();
                                //    foreach (_WA.Mapper.v2.Job.Description2 proxydescription in proxyjob.Descriptions)
                                //    {
                                //        Description description = new Description();
                                //        description.DescriptionComment = proxydescription.DescriptionComment;
                                //        description.SequenceNumber = proxydescription.SequenceNumber;
                                //        job.Descriptions.Add(description);
                                //    }
                                //}
                                //#endregion

                                //#region//Job Causes
                                //if (proxyjob.Causes != null && proxyjob.Causes.Length > 0)
                                //{
                                //    job.Causes = new List<Cause>();
                                //    foreach (_WA.Mapper.v2.Job.Cause2 proxycause in proxyjob.Causes)
                                //    {
                                //        Cause cause = new Cause();
                                //        cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                //        cause.Comment = proxycause.Comment;
                                //        cause.SequenceNumber = proxycause.SequenceNumber;
                                //        job.Causes.Add(cause);
                                //    }
                                //}
                                //#endregion

                                //#region//Job Corrections
                                //if (proxyjob.Corrections != null && proxyjob.Corrections.Length > 0)
                                //{
                                //    job.Corrections = new List<Correction>();
                                //    foreach (_WA.Mapper.v2.Job.Correction2 proxycorrection in proxyjob.Corrections)
                                //    {
                                //        Correction cause = new Correction();
                                //        cause.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                //        cause.Comment = proxycorrection.Comment;
                                //        cause.SequenceNumber = proxycorrection.SequenceNumber;
                                //        job.Corrections.Add(cause);
                                //    }
                                //}
                                //#endregion

                                //#region//Job OPCodes
                                //if (proxyjob.OPCodes != null && proxyjob.OPCodes.Length > 0)
                                //{
                                //    job.OPCodes = new List<Data.v2.Common.Job.OPCode>();
                                //    foreach (_WA.Mapper.v2.Job.OPCode2 proxyopcode in proxyjob.OPCodes)
                                //    {
                                //        #region//Job OPCode Header
                                //        Data.v2.Common.Job.OPCode opcode = new Data.v2.Common.Job.OPCode();
                                //        opcode.ActualHours = proxyopcode.ActualHours;
                                //        opcode.Code = proxyopcode.Code;
                                //        opcode.Description = proxyopcode.Description;
                                //        opcode.EstimatedHours = proxyopcode.EstimatedHours;
                                //        opcode.SkillLevel = proxyopcode.SkillLevel;
                                //        #endregion

                                //        #region//Job OPCode Comments
                                //        if (proxyopcode.Comments != null && proxyopcode.Comments.Length > 0)
                                //        {
                                //            opcode.Comments = new List<Comment>();
                                //            foreach (_WA.Mapper.v2.Job.Comment2 proxycomment in proxyopcode.Comments)
                                //            {
                                //                Comment comment = new Comment();
                                //                comment.DescriptionComment = proxycomment.DescriptionComment;
                                //                comment.SequenceNumber = proxycomment.SequenceNumber;
                                //                opcode.Comments.Add(comment);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Job OPCode Descriptions
                                //        if (proxyopcode.Descriptions != null && proxyopcode.Descriptions.Length > 0)
                                //        {
                                //            opcode.Descriptions = new List<Description>();
                                //            foreach (_WA.Mapper.v2.Job.Description2 proxydescription in proxyopcode.Descriptions)
                                //            {
                                //                Description description = new Description();
                                //                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                opcode.Descriptions.Add(description);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Job OPCode Causes
                                //        if (proxyopcode.Causes != null && proxyopcode.Causes.Length > 0)
                                //        {
                                //            opcode.Causes = new List<Cause>();
                                //            foreach (_WA.Mapper.v2.Job.Cause2 proxycause in proxyopcode.Causes)
                                //            {
                                //                Cause cause = new Cause();
                                //                cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                //                cause.Comment = proxycause.Comment;
                                //                cause.SequenceNumber = proxycause.SequenceNumber;
                                //                opcode.Causes.Add(cause);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Job OPCode Corrections
                                //        if (proxyopcode.Corrections != null && proxyopcode.Corrections.Length > 0)
                                //        {
                                //            opcode.Corrections = new List<Correction>();
                                //            foreach (_WA.Mapper.v2.Job.Correction2 proxycorrection in proxyopcode.Corrections)
                                //            {
                                //                Correction correction = new Correction();
                                //                correction.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                //                correction.Comment = proxycorrection.Comment;
                                //                correction.SequenceNumber = proxycorrection.SequenceNumber;
                                //                opcode.Corrections.Add(correction);
                                //            }
                                //        }
                                //        #endregion

                                //        job.OPCodes.Add(opcode);
                                //    }
                                //}
                                //#endregion

                                //#region//Job JobLogs
                                //if (proxyjob.JobLogs != null && proxyjob.JobLogs.Length > 0)
                                //{
                                //    job.JobLogs = new List<JobLog>();
                                //    foreach (_WA.Mapper.v2.Job.JobLog2 proxyjoblog in proxyjob.JobLogs)
                                //    {
                                //        #region//Job JobLogs Header
                                //        JobLog joblog = new JobLog();
                                //        joblog.DMSJobStatus = proxyjoblog.DMSJobStatus;
                                //        joblog.EstimatedLaborHour = proxyjoblog.EstimatedLaborHour;
                                //        joblog.LogType = proxyjoblog.LogType;
                                //        joblog.ScheduledDateTimeFromLocal = proxyjoblog.ScheduledDateTimeFromLocal;
                                //        joblog.ScheduledDateTimeToLocal = proxyjoblog.ScheduledDateTimeToLocal;
                                //        joblog.Stall = proxyjoblog.Stall;
                                //        #endregion

                                //        #region//Job Technicians
                                //        if (proxyjoblog.Technicians != null && proxyjoblog.Technicians.Length > 0)
                                //        {
                                //            joblog.Technicians = new List<Technician>();
                                //            foreach (_WA.Mapper.v2.Job.Technician2 proxytechnician in proxyjoblog.Technicians)
                                //            {
                                //                Technician technician = new Technician();
                                //                technician.TCEmployeeID = proxytechnician.TCEmployeeID;
                                //                technician.TCEmployeeName = proxytechnician.TCEmployeeName;
                                //                joblog.Technicians.Add(technician);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Job ActualTimeLogs
                                //        if (proxyjoblog.ActualTimeLogs != null && proxyjoblog.ActualTimeLogs.Length > 0)
                                //        {
                                //            joblog.ActualTimeLogs = new List<ActualTimeLog>();
                                //            foreach (_WA.Mapper.v2.Job.ActualTimeLog2 proxyactualtimelog in proxyjoblog.ActualTimeLogs)
                                //            {
                                //                ActualTimeLog actualtimelog = new ActualTimeLog();
                                //                actualtimelog.EndDateTimeLocal = proxyactualtimelog.EndDateTimeLocal;
                                //                actualtimelog.PauseReasonCode = proxyactualtimelog.PauseReasonCode;
                                //                actualtimelog.PauseReasonComment = proxyactualtimelog.PauseReasonComment;
                                //                actualtimelog.StartDateTimeLocal = proxyactualtimelog.StartDateTimeLocal;
                                //                actualtimelog.Status = proxyactualtimelog.Status;
                                //                actualtimelog.TCEmployeeID = proxyactualtimelog.TCEmployeeID;
                                //                actualtimelog.TCEmployeeName = proxyactualtimelog.TCEmployeeName;
                                //                joblog.ActualTimeLogs.Add(actualtimelog);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Job JobComments
                                //        if (proxyjoblog.JobComments != null && proxyjoblog.JobComments.Length > 0)
                                //        {
                                //            joblog.JobComments = new List<JobComment>();
                                //            foreach (_WA.Mapper.v2.Job.JobComment2 proxyjobcomment in proxyjoblog.JobComments)
                                //            {
                                //                JobComment jobcomment = new JobComment();
                                //                jobcomment.ActualWorkHour = proxyjobcomment.ActualWorkHour;
                                //                jobcomment.SubStatus = proxyjobcomment.SubStatus;
                                //                joblog.JobComments.Add(jobcomment);
                                //            }
                                //        }
                                //        #endregion

                                //        job.JobLogs.Add(joblog);
                                //    }
                                //}
                                //#endregion

                                //response.Job = job;
                                //}
                                #endregion
                            }
                        }
                        else
                        {
                            if (response.Errors != null)
                                response.Errors.Add(GetErrorData(ResponseCode.Fail, ResponseMessage.Fail));
                            else
                                response.Errors = GetErrorDataList(ResponseCode.Fail, ResponseMessage.Fail);
                        }
                        #endregion
                    }
                    break;
                case "v2.HMCIS.1C.v4":
                    {
                        #region v2.HMCIS.1C.v4 - RTR (Proxy Class Dll Name : _1C.v4)

                        #region JobChange Request Set

                        //Create proxy credential
                        NetworkCredential proxycredential = new NetworkCredential(request.TransactionHeader.Username, request.TransactionHeader.Password);

                        //Create proxy web service from dms web service with credential
                        _1C.v4.Job.Job proxyws = new _1C.v4.Job.Job(request.TransactionHeader.DMSServerUrl);
                        proxyws.Credentials = proxycredential;

                        //Create proxy request with jobchange and transaction
                        _1C.v4.Job.JobChangeRequest proxyrequest = new _1C.v4.Job.JobChangeRequest();

                        //Create proxy transaction
                        _1C.v4.Job.TransactionHeader2 proxytransactionheader = new _1C.v4.Job.TransactionHeader2();
                        if (request.TransactionHeader != null)
                        {
                            #region//TransactionHeader Set
                            proxytransactionheader.CountryID = request.TransactionHeader.CountryID;
                            proxytransactionheader.DealerID = request.TransactionHeader.DealerID;
                            proxytransactionheader.DistributorID = request.TransactionHeader.DistributorID;
                            proxytransactionheader.DMSCode = request.TransactionHeader.DMSCode;
                            proxytransactionheader.DMSServerUrl = request.TransactionHeader.DMSServerUrl;
                            proxytransactionheader.DMSVersion = request.TransactionHeader.DMSVersion;
                            proxytransactionheader.DocumentVersion = request.TransactionHeader.DocumentVersion;
                            proxytransactionheader.GroupID = request.TransactionHeader.GroupID;
                            proxytransactionheader.IneterfaceID = request.TransactionHeader.IneterfaceID;
                            proxytransactionheader.Password = request.TransactionHeader.Password;
                            proxytransactionheader.PollingToken = request.TransactionHeader.PollingToken;
                            proxytransactionheader.RequestPollingToken = request.TransactionHeader.RequestPollingToken;
                            proxytransactionheader.RequestType = request.TransactionHeader.RequestType;
                            proxytransactionheader.TransactionId = request.TransactionHeader.TransactionId;
                            proxytransactionheader.TransactionDateTimeLocal = request.TransactionHeader.TransactionDateTimeLocal;
                            proxytransactionheader.TransactionDateTimeUTC = request.TransactionHeader.TransactionDateTimeUTC;
                            proxytransactionheader.TransactionType = request.TransactionHeader.TransactionType;
                            proxytransactionheader.Username = request.TransactionHeader.Username;
                            proxytransactionheader.VenderTrackingCode = request.TransactionHeader.VenderTrackingCode;
                            proxyrequest.TransactionHeader = proxytransactionheader;
                            #endregion
                        }

                        //Create proxy jobchange
                        _1C.v4.Job.JobChange proxyjobchange = new _1C.v4.Job.JobChange();
                        if (request.JobChange != null)
                        {
                            #region//JobChange Header
                            proxyjobchange.ActualHours = request.JobChange.ActualHours;
                            proxyjobchange.DMSJobNo = request.JobChange.DMSJobNo;
                            proxyjobchange.DMSJobNo = request.JobChange.DMSJobNo;
                            proxyjobchange.DMSRONo = request.JobChange.DMSRONo;
                            proxyjobchange.EstimatedHours = request.JobChange.EstimatedHours;
                            proxyjobchange.ServiceLineNumber = request.JobChange.ServiceLineNumber;
                            proxyjobchange.SkillLevel = request.JobChange.SkillLevel;
                            #endregion

                            #region//JobChange Comments
                            if (request.JobChange.Comments != null && request.JobChange.Comments.Count > 0)
                            {
                                int commentscnt = 0;
                                _1C.v4.Job.Comment1[] proxycomments = new _1C.v4.Job.Comment1[request.JobChange.Comments.Count];
                                foreach (Comment Comment in request.JobChange.Comments)
                                {
                                    _1C.v4.Job.Comment1 proxycomment = new _1C.v4.Job.Comment1();
                                    proxycomment.DescriptionComment = Comment.DescriptionComment;
                                    proxycomment.SequenceNumber = Comment.SequenceNumber;
                                    proxycomments[commentscnt] = proxycomment;
                                    commentscnt++;
                                }
                                proxyjobchange.Comments = proxycomments;
                            }
                            #endregion

                            #region//JobChange Descriptions
                            if (request.JobChange.Descriptions != null && request.JobChange.Descriptions.Count > 0)
                            {
                                int descriptionscnt = 0;
                                _1C.v4.Job.Description1[] proxydescriptions = new _1C.v4.Job.Description1[request.JobChange.Descriptions.Count];
                                foreach (Description description in request.JobChange.Descriptions)
                                {
                                    _1C.v4.Job.Description1 proxydescription = new _1C.v4.Job.Description1();
                                    proxydescription.DescriptionComment = description.DescriptionComment;
                                    proxydescription.SequenceNumber = description.SequenceNumber;
                                    proxydescriptions[descriptionscnt] = proxydescription;
                                    descriptionscnt++;
                                }
                                proxyjobchange.Descriptions = proxydescriptions;
                            }
                            #endregion

                            #region//JobChange Causes
                            if (request.JobChange.Causes != null && request.JobChange.Causes.Count > 0)
                            {
                                int causescnt = 0;
                                _1C.v4.Job.Cause1[] proxycauses = new _1C.v4.Job.Cause1[request.JobChange.Causes.Count];
                                foreach (Cause cause in request.JobChange.Causes)
                                {
                                    _1C.v4.Job.Cause1 proxycause = new _1C.v4.Job.Cause1();
                                    proxycause.CauseLaborOpCode = cause.CauseLaborOpCode;
                                    proxycause.Comment = cause.Comment;
                                    proxycause.SequenceNumber = cause.SequenceNumber;
                                    proxycauses[causescnt] = proxycause;
                                    causescnt++;
                                }
                                proxyjobchange.Causes = proxycauses;
                            }
                            #endregion

                            #region//JobChange Corrections
                            if (request.JobChange.Corrections != null && request.JobChange.Corrections.Count > 0)
                            {
                                int correctionscnt = 0;
                                _1C.v4.Job.Correction1[] proxycorrections = new _1C.v4.Job.Correction1[request.JobChange.Corrections.Count];
                                foreach (Correction correction in request.JobChange.Corrections)
                                {
                                    _1C.v4.Job.Correction1 proxycorrection = new _1C.v4.Job.Correction1();
                                    proxycorrection.CorrectionLaborOpCode = correction.CorrectionLaborOpCode;
                                    proxycorrection.Comment = correction.Comment;
                                    proxycorrection.SequenceNumber = correction.SequenceNumber;
                                    proxycorrections[correctionscnt] = proxycorrection;
                                    correctionscnt++;
                                }
                                proxyjobchange.Corrections = proxycorrections;
                            }
                            #endregion

                            #region//JobChange OPCodes
                            if (request.JobChange.OPCodes != null && request.JobChange.OPCodes.Count > 0)
                            {
                                int opcodescnt = 0;
                                _1C.v4.Job.OPCode1[] proxyopcodes = new _1C.v4.Job.OPCode1[request.JobChange.OPCodes.Count];
                                foreach (WA.Standard.IF.Data.v2.Common.Job.OPCode opcode in request.JobChange.OPCodes)
                                {
                                    #region//JobChange OPCode Header
                                    _1C.v4.Job.OPCode1 proxyopcode = new _1C.v4.Job.OPCode1();
                                    proxyopcode.ActualHours = opcode.ActualHours;
                                    proxyopcode.Code = opcode.Code;
                                    proxyopcode.Description = opcode.Description;
                                    proxyopcode.EstimatedHours = opcode.EstimatedHours;
                                    proxyopcode.SkillLevel = opcode.SkillLevel;
                                    #endregion

                                    #region//JobChange OPCode Comments
                                    if (opcode.Comments != null && opcode.Comments.Count > 0)
                                    {
                                        int commentscnt = 0;
                                        _1C.v4.Job.Comment1[] proxycomments = new _1C.v4.Job.Comment1[opcode.Comments.Count];
                                        foreach (Comment comment in opcode.Comments)
                                        {
                                            _1C.v4.Job.Comment1 proxycomment = new _1C.v4.Job.Comment1();
                                            proxycomment.DescriptionComment = comment.DescriptionComment;
                                            proxycomment.SequenceNumber = comment.SequenceNumber;
                                            proxycomments[commentscnt] = proxycomment;
                                            commentscnt++;
                                        }
                                        proxyopcode.Comments = proxycomments;
                                    }
                                    #endregion

                                    #region//JobChange OPCode Descriptions
                                    if (opcode.Descriptions != null && opcode.Descriptions.Count > 0)
                                    {
                                        int descriptionscnt = 0;
                                        _1C.v4.Job.Description1[] proxydescriptions = new _1C.v4.Job.Description1[opcode.Descriptions.Count];
                                        foreach (Description description in opcode.Descriptions)
                                        {
                                            _1C.v4.Job.Description1 proxydescription = new _1C.v4.Job.Description1();
                                            proxydescription.DescriptionComment = description.DescriptionComment;
                                            proxydescription.SequenceNumber = description.SequenceNumber;
                                            proxydescriptions[descriptionscnt] = proxydescription;
                                            descriptionscnt++;
                                        }
                                        proxyopcode.Descriptions = proxydescriptions;
                                    }
                                    #endregion

                                    #region//JobChange OPCode Causes
                                    if (opcode.Causes != null && opcode.Causes.Count > 0)
                                    {
                                        int causescnt = 0;
                                        _1C.v4.Job.Cause1[] proxycauses = new _1C.v4.Job.Cause1[opcode.Causes.Count];
                                        foreach (Cause cause in opcode.Causes)
                                        {
                                            _1C.v4.Job.Cause1 proxycause = new _1C.v4.Job.Cause1();
                                            proxycause.CauseLaborOpCode = cause.CauseLaborOpCode;
                                            proxycause.Comment = cause.Comment;
                                            proxycause.SequenceNumber = cause.SequenceNumber;
                                            proxycauses[causescnt] = proxycause;
                                            causescnt++;
                                        }
                                        proxyopcode.Causes = proxycauses;
                                    }
                                    #endregion

                                    #region//JobChange OPCode Corrections
                                    if (opcode.Corrections != null && opcode.Corrections.Count > 0)
                                    {
                                        int correctionscnt = 0;
                                        _1C.v4.Job.Correction1[] proxycorrections = new _1C.v4.Job.Correction1[opcode.Corrections.Count];
                                        foreach (Correction correction in opcode.Corrections)
                                        {
                                            _1C.v4.Job.Correction1 proxycorrection = new _1C.v4.Job.Correction1();
                                            proxycorrection.CorrectionLaborOpCode = correction.CorrectionLaborOpCode;
                                            proxycorrection.Comment = correction.Comment;
                                            proxycorrection.SequenceNumber = correction.SequenceNumber;
                                            proxycorrections[correctionscnt] = proxycorrection;
                                            correctionscnt++;
                                        }
                                        proxyopcode.Corrections = proxycorrections;
                                    }
                                    #endregion

                                    proxyopcodes[opcodescnt] = proxyopcode;
                                    opcodescnt++;
                                }
                                proxyjobchange.OPCodes = proxyopcodes;
                            }
                            #endregion

                            #region//JobChange JobLogs
                            if (request.JobChange.JobLogs != null && request.JobChange.JobLogs.Count > 0)
                            {
                                int joblogsscnt = 0;
                                _1C.v4.Job.JobLog1[] proxyjoblogs = new _1C.v4.Job.JobLog1[request.JobChange.JobLogs.Count];
                                foreach (WA.Standard.IF.Data.v2.Common.Job.JobLog joblog in request.JobChange.JobLogs)
                                {
                                    #region//JobChange JobLogs Header
                                    _1C.v4.Job.JobLog1 proxyjoblog = new _1C.v4.Job.JobLog1();
                                    proxyjoblog.DMSJobStatus = joblog.DMSJobStatus;
                                    proxyjoblog.EstimatedLaborHour = joblog.EstimatedLaborHour;
                                    proxyjoblog.LogType = joblog.LogType;
                                    proxyjoblog.ScheduledDateTimeFromLocal = joblog.ScheduledDateTimeFromLocal;
                                    proxyjoblog.ScheduledDateTimeToLocal = joblog.ScheduledDateTimeToLocal;
                                    proxyjoblog.Stall = joblog.Stall;
                                    #endregion

                                    #region//JobChange JobLogs Technicians
                                    if (joblog.Technicians != null && joblog.Technicians.Count > 0)
                                    {
                                        int technicianscnt = 0;
                                        _1C.v4.Job.Technician1[] proxytechnicians = new _1C.v4.Job.Technician1[joblog.Technicians.Count];
                                        foreach (Technician technician in joblog.Technicians)
                                        {
                                            _1C.v4.Job.Technician1 proxytechnician = new _1C.v4.Job.Technician1();
                                            proxytechnician.TCEmployeeID = technician.TCEmployeeID;
                                            proxytechnician.TCEmployeeName = technician.TCEmployeeName;
                                            proxytechnicians[technicianscnt] = proxytechnician;
                                            technicianscnt++;
                                        }
                                        proxyjoblog.Technicians = proxytechnicians;
                                    }
                                    #endregion

                                    #region//JobChange JobLogs ActualTimeLogs
                                    if (joblog.ActualTimeLogs != null && joblog.ActualTimeLogs.Count > 0)
                                    {
                                        int actualtimelogscnt = 0;
                                        _1C.v4.Job.ActualTimeLog1[] proxyactualtimelogs = new _1C.v4.Job.ActualTimeLog1[joblog.ActualTimeLogs.Count];
                                        foreach (ActualTimeLog actualtimelog in joblog.ActualTimeLogs)
                                        {
                                            _1C.v4.Job.ActualTimeLog1 proxyactualtimelog = new _1C.v4.Job.ActualTimeLog1();
                                            proxyactualtimelog.EndDateTimeLocal = actualtimelog.EndDateTimeLocal;
                                            proxyactualtimelog.PauseReasonCode = actualtimelog.PauseReasonCode;
                                            proxyactualtimelog.PauseReasonComment = actualtimelog.PauseReasonComment;
                                            proxyactualtimelog.StartDateTimeLocal = actualtimelog.StartDateTimeLocal;
                                            proxyactualtimelog.Status = actualtimelog.Status;
                                            proxyactualtimelog.TCEmployeeID = actualtimelog.TCEmployeeID;
                                            proxyactualtimelog.TCEmployeeName = actualtimelog.TCEmployeeName;
                                            proxyactualtimelogs[actualtimelogscnt] = proxyactualtimelog;
                                            actualtimelogscnt++;
                                        }
                                        proxyjoblog.ActualTimeLogs = proxyactualtimelogs;
                                    }
                                    #endregion

                                    #region//JobChange JobLogs JobComments
                                    if (joblog.JobComments != null && joblog.JobComments.Count > 0)
                                    {
                                        int jobcommentscnt = 0;
                                        _1C.v4.Job.JobComment1[] proxyjobcomments = new _1C.v4.Job.JobComment1[joblog.JobComments.Count];
                                        foreach (JobComment jobcomment in joblog.JobComments)
                                        {
                                            _1C.v4.Job.JobComment1 proxyjobcomment = new _1C.v4.Job.JobComment1();
                                            proxyjobcomment.ActualWorkHour = jobcomment.ActualWorkHour;
                                            proxyjobcomment.SubStatus = jobcomment.SubStatus;
                                            proxyjobcomments[jobcommentscnt] = proxyjobcomment;
                                            jobcommentscnt++;
                                        }
                                        proxyjoblog.JobComments = proxyjobcomments;
                                    }
                                    #endregion

                                    proxyjoblogs[joblogsscnt] = proxyjoblog;
                                    joblogsscnt++;
                                }
                                proxyjobchange.JobLogs = proxyjoblogs;
                            }
                            #endregion
                        }
                        #endregion

                        //Run proxy web method with proxy request
                        _1C.v4.Job.JobChangeResponse proxyresponse = proxyws.JobChange(proxyrequest);

                        //Mapping with Standard Interface Specification Object
                        if (proxyresponse != null)
                        {
                            if (proxyresponse.TransactionHeader != null)
                            {
                                #region//TransactionHeader Set
                                TransactionHeader transactionheader = new TransactionHeader();
                                transactionheader.CountryID = proxyresponse.TransactionHeader.CountryID;
                                transactionheader.DealerID = proxyresponse.TransactionHeader.DealerID;
                                transactionheader.DistributorID = proxyresponse.TransactionHeader.DistributorID;
                                transactionheader.DMSCode = proxyresponse.TransactionHeader.DMSCode;
                                transactionheader.DMSServerUrl = proxyresponse.TransactionHeader.DMSServerUrl;
                                transactionheader.DMSVersion = proxyresponse.TransactionHeader.DMSVersion;
                                transactionheader.DocumentVersion = proxyresponse.TransactionHeader.DocumentVersion;
                                transactionheader.GroupID = proxyresponse.TransactionHeader.GroupID;
                                transactionheader.IneterfaceID = proxyresponse.TransactionHeader.IneterfaceID;
                                transactionheader.Password = proxyresponse.TransactionHeader.Password;
                                transactionheader.PollingToken = proxyresponse.TransactionHeader.PollingToken;
                                transactionheader.RequestPollingToken = proxyresponse.TransactionHeader.RequestPollingToken;
                                transactionheader.RequestType = proxyresponse.TransactionHeader.RequestType;
                                transactionheader.TransactionId = proxyresponse.TransactionHeader.TransactionId;
                                transactionheader.TransactionDateTimeLocal = proxyresponse.TransactionHeader.TransactionDateTimeLocal;
                                transactionheader.TransactionDateTimeUTC = proxyresponse.TransactionHeader.TransactionDateTimeUTC;
                                transactionheader.TransactionType = proxyresponse.TransactionHeader.TransactionType;
                                transactionheader.Username = proxyresponse.TransactionHeader.Username;
                                transactionheader.VenderTrackingCode = proxyresponse.TransactionHeader.VenderTrackingCode;
                                response.TransactionHeader = transactionheader;
                                #endregion
                            }

                            //ResultMessage Set
                            if (proxyresponse.ResultMessage != null)
                            {
                                response.ResultMessage = GetResultMessageData(proxyresponse.ResultMessage.Code, proxyresponse.ResultMessage.Message);
                            }

                            if (proxyresponse.Errors != null)
                            {
                                //Error List Set
                                foreach (_1C.v4.Job.Error1 proxyerror in proxyresponse.Errors)
                                {
                                    if (response.Errors != null)
                                        response.Errors.Add(GetErrorData(proxyerror.Code, proxyerror.Message));
                                    else
                                        response.Errors = GetErrorDataList(proxyerror.Code, proxyerror.Message);
                                }
                            }
                            else
                            {
                                #region//JobGetResponse Set

                                //if (proxyresponse.Job != null)
                                //{
                                //_1C.v4.Job.Job2 proxyjob = proxyresponse.Job;

                                //#region//Job Header
                                //Job job = new Job();
                                //job.ActualHours = proxyjob.ActualHours;
                                //job.DMSJobNo = proxyjob.DMSJobNo;
                                //job.DMSJobNo = proxyjob.DMSJobNo;
                                //job.DMSRONo = proxyjob.DMSRONo;
                                //job.ServiceLineNumber = proxyjob.ServiceLineNumber;
                                //job.SkillLevel = proxyjob.SkillLevel;
                                //#endregion

                                //#region //Job ManagementFields
                                //if (proxyjob.ManagementFields != null)
                                //{
                                //    ManagementFields managementfields = new ManagementFields();
                                //    managementfields.CreateDateTimeUTC = proxyjob.ManagementFields.CreateDateTimeUTC;
                                //    managementfields.LastModifiedDateTimeUTC = proxyjob.ManagementFields.LastModifiedDateTimeUTC;
                                //    job.ManagementFields = managementfields;
                                //}
                                //#endregion

                                //#region//Job Comments
                                //if (proxyjob.Comments != null && proxyjob.Comments.Length > 0)
                                //{
                                //    job.Comments = new List<Comment>();
                                //    foreach (_1C.v4.Job.Comment2 proxycomment in proxyjob.Comments)
                                //    {
                                //        Comment comment = new Comment();
                                //        comment.DescriptionComment = proxycomment.DescriptionComment;
                                //        comment.SequenceNumber = proxycomment.SequenceNumber;
                                //        job.Comments.Add(comment);
                                //    }
                                //}
                                //#endregion

                                //#region//Job Descriptions
                                //if (proxyjob.Descriptions != null && proxyjob.Descriptions.Length > 0)
                                //{
                                //    job.Descriptions = new List<Description>();
                                //    foreach (_1C.v4.Job.Description2 proxydescription in proxyjob.Descriptions)
                                //    {
                                //        Description description = new Description();
                                //        description.DescriptionComment = proxydescription.DescriptionComment;
                                //        description.SequenceNumber = proxydescription.SequenceNumber;
                                //        job.Descriptions.Add(description);
                                //    }
                                //}
                                //#endregion

                                //#region//Job Causes
                                //if (proxyjob.Causes != null && proxyjob.Causes.Length > 0)
                                //{
                                //    job.Causes = new List<Cause>();
                                //    foreach (_1C.v4.Job.Cause2 proxycause in proxyjob.Causes)
                                //    {
                                //        Cause cause = new Cause();
                                //        cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                //        cause.Comment = proxycause.Comment;
                                //        cause.SequenceNumber = proxycause.SequenceNumber;
                                //        job.Causes.Add(cause);
                                //    }
                                //}
                                //#endregion

                                //#region//Job Corrections
                                //if (proxyjob.Corrections != null && proxyjob.Corrections.Length > 0)
                                //{
                                //    job.Corrections = new List<Correction>();
                                //    foreach (_1C.v4.Job.Correction2 proxycorrection in proxyjob.Corrections)
                                //    {
                                //        Correction cause = new Correction();
                                //        cause.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                //        cause.Comment = proxycorrection.Comment;
                                //        cause.SequenceNumber = proxycorrection.SequenceNumber;
                                //        job.Corrections.Add(cause);
                                //    }
                                //}
                                //#endregion

                                //#region//Job OPCodes
                                //if (proxyjob.OPCodes != null && proxyjob.OPCodes.Length > 0)
                                //{
                                //    job.OPCodes = new List<Data.v2.Common.Job.OPCode>();
                                //    foreach (_1C.v4.Job.OPCode2 proxyopcode in proxyjob.OPCodes)
                                //    {
                                //        #region//Job OPCode Header
                                //        Data.v2.Common.Job.OPCode opcode = new Data.v2.Common.Job.OPCode();
                                //        opcode.ActualHours = proxyopcode.ActualHours;
                                //        opcode.Code = proxyopcode.Code;
                                //        opcode.Description = proxyopcode.Description;
                                //        opcode.EstimatedHours = proxyopcode.EstimatedHours;
                                //        opcode.SkillLevel = proxyopcode.SkillLevel;
                                //        #endregion

                                //        #region//Job OPCode Comments
                                //        if (proxyopcode.Comments != null && proxyopcode.Comments.Length > 0)
                                //        {
                                //            opcode.Comments = new List<Comment>();
                                //            foreach (_1C.v4.Job.Comment2 proxycomment in proxyopcode.Comments)
                                //            {
                                //                Comment comment = new Comment();
                                //                comment.DescriptionComment = proxycomment.DescriptionComment;
                                //                comment.SequenceNumber = proxycomment.SequenceNumber;
                                //                opcode.Comments.Add(comment);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Job OPCode Descriptions
                                //        if (proxyopcode.Descriptions != null && proxyopcode.Descriptions.Length > 0)
                                //        {
                                //            opcode.Descriptions = new List<Description>();
                                //            foreach (_1C.v4.Job.Description2 proxydescription in proxyopcode.Descriptions)
                                //            {
                                //                Description description = new Description();
                                //                description.DescriptionComment = proxydescription.DescriptionComment;
                                //                description.SequenceNumber = proxydescription.SequenceNumber;
                                //                opcode.Descriptions.Add(description);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Job OPCode Causes
                                //        if (proxyopcode.Causes != null && proxyopcode.Causes.Length > 0)
                                //        {
                                //            opcode.Causes = new List<Cause>();
                                //            foreach (_1C.v4.Job.Cause2 proxycause in proxyopcode.Causes)
                                //            {
                                //                Cause cause = new Cause();
                                //                cause.CauseLaborOpCode = proxycause.CauseLaborOpCode;
                                //                cause.Comment = proxycause.Comment;
                                //                cause.SequenceNumber = proxycause.SequenceNumber;
                                //                opcode.Causes.Add(cause);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Job OPCode Corrections
                                //        if (proxyopcode.Corrections != null && proxyopcode.Corrections.Length > 0)
                                //        {
                                //            opcode.Corrections = new List<Correction>();
                                //            foreach (_1C.v4.Job.Correction2 proxycorrection in proxyopcode.Corrections)
                                //            {
                                //                Correction correction = new Correction();
                                //                correction.CorrectionLaborOpCode = proxycorrection.CorrectionLaborOpCode;
                                //                correction.Comment = proxycorrection.Comment;
                                //                correction.SequenceNumber = proxycorrection.SequenceNumber;
                                //                opcode.Corrections.Add(correction);
                                //            }
                                //        }
                                //        #endregion

                                //        job.OPCodes.Add(opcode);
                                //    }
                                //}
                                //#endregion

                                //#region//Job JobLogs
                                //if (proxyjob.JobLogs != null && proxyjob.JobLogs.Length > 0)
                                //{
                                //    job.JobLogs = new List<JobLog>();
                                //    foreach (_1C.v4.Job.JobLog2 proxyjoblog in proxyjob.JobLogs)
                                //    {
                                //        #region//Job JobLogs Header
                                //        JobLog joblog = new JobLog();
                                //        joblog.DMSJobStatus = proxyjoblog.DMSJobStatus;
                                //        joblog.EstimatedLaborHour = proxyjoblog.EstimatedLaborHour;
                                //        joblog.LogType = proxyjoblog.LogType;
                                //        joblog.ScheduledDateTimeFromLocal = proxyjoblog.ScheduledDateTimeFromLocal;
                                //        joblog.ScheduledDateTimeToLocal = proxyjoblog.ScheduledDateTimeToLocal;
                                //        joblog.Stall = proxyjoblog.Stall;
                                //        #endregion

                                //        #region//Job Technicians
                                //        if (proxyjoblog.Technicians != null && proxyjoblog.Technicians.Length > 0)
                                //        {
                                //            joblog.Technicians = new List<Technician>();
                                //            foreach (_1C.v4.Job.Technician2 proxytechnician in proxyjoblog.Technicians)
                                //            {
                                //                Technician technician = new Technician();
                                //                technician.TCEmployeeID = proxytechnician.TCEmployeeID;
                                //                technician.TCEmployeeName = proxytechnician.TCEmployeeName;
                                //                joblog.Technicians.Add(technician);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Job ActualTimeLogs
                                //        if (proxyjoblog.ActualTimeLogs != null && proxyjoblog.ActualTimeLogs.Length > 0)
                                //        {
                                //            joblog.ActualTimeLogs = new List<ActualTimeLog>();
                                //            foreach (_1C.v4.Job.ActualTimeLog2 proxyactualtimelog in proxyjoblog.ActualTimeLogs)
                                //            {
                                //                ActualTimeLog actualtimelog = new ActualTimeLog();
                                //                actualtimelog.EndDateTimeLocal = proxyactualtimelog.EndDateTimeLocal;
                                //                actualtimelog.PauseReasonCode = proxyactualtimelog.PauseReasonCode;
                                //                actualtimelog.PauseReasonComment = proxyactualtimelog.PauseReasonComment;
                                //                actualtimelog.StartDateTimeLocal = proxyactualtimelog.StartDateTimeLocal;
                                //                actualtimelog.Status = proxyactualtimelog.Status;
                                //                actualtimelog.TCEmployeeID = proxyactualtimelog.TCEmployeeID;
                                //                actualtimelog.TCEmployeeName = proxyactualtimelog.TCEmployeeName;
                                //                joblog.ActualTimeLogs.Add(actualtimelog);
                                //            }
                                //        }
                                //        #endregion

                                //        #region//Job JobComments
                                //        if (proxyjoblog.JobComments != null && proxyjoblog.JobComments.Length > 0)
                                //        {
                                //            joblog.JobComments = new List<JobComment>();
                                //            foreach (_1C.v4.Job.JobComment2 proxyjobcomment in proxyjoblog.JobComments)
                                //            {
                                //                JobComment jobcomment = new JobComment();
                                //                jobcomment.ActualWorkHour = proxyjobcomment.ActualWorkHour;
                                //                jobcomment.SubStatus = proxyjobcomment.SubStatus;
                                //                joblog.JobComments.Add(jobcomment);
                                //            }
                                //        }
                                //        #endregion

                                //        job.JobLogs.Add(joblog);
                                //    }
                                //}
                                //#endregion

                                //response.Job = job;
                                //}
                                #endregion
                            }
                        }
                        else
                        {
                            if (response.Errors != null)
                                response.Errors.Add(GetErrorData(ResponseCode.Fail, ResponseMessage.Fail));
                            else
                                response.Errors = GetErrorDataList(ResponseCode.Fail, ResponseMessage.Fail);
                        }
                        #endregion
                    }
                    break;
                default: response.Errors = new List<Error>() { new Error() { Code = ResponseCode.NoMatchedProxy, Message = ResponseMessage.NoMatchedProxy } };
                    break;
            }

            return response;
        }
    }
}
