using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WA.Standard.IF.Data.v2.Common.Common;
using WA.Standard.IF.Data.v2.Common.Message;
using System.Data;
using WA.Standard.IF.Dac.v2.Common;

namespace WA.Standard.IF.Biz.v2.Common
{
    public class Message_Biz : WA.Standard.IF.Biz.v2.Base.BaseBiz
    {
        public MessageSendResponse MessageSend(MessageSendRequest request)
        {
            MessageSendResponse response = new MessageSendResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process
                WA.Standard.IF.Proxy.v2.Common.Message_Proxy proxy = new Proxy.v2.Common.Message_Proxy();
                response = proxy.MessageSend(request);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;
               
                #region For XML Process
                response.ResultMessage = GetResultMessageData(ResponseCode.Success, ResponseMessage.Success);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.DBDMS))
            {
                #region For DB Process - Not Yet
                response.ResultMessage = GetResultMessageData(ResponseCode.Success, ResponseMessage.Success);
                #endregion
            }

            return response;
        }

        public MessageReceiveResponse MessageReceive(MessageReceiveRequest request)
        {
            MessageReceiveResponse response = new MessageReceiveResponse();

            if (base.RunningMode.Equals(Base.RunningMode.Mapper))
            {
                #region For Mapper Process

                switch (request.MessageReceive.MessageType)
                {
                    case "Appointment":
                        WA.Standard.IF.Biz.v2.Common.Appointment_Biz biz = new Appointment_Biz();
                        
                    //Get Appointment By AppointmentNo
                        break;
                    case "Employee": //Get Employee By EmployeeNo
                        break;
                    case "Job": //Get Job By JobNo
                        break;
                    case "RepairOrder"://Get RepairOrder By RepairOrderNo
                        break;
                    default:
                        break;
                }

                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.XMLDMS))
            {
                response.TransactionHeader = request.TransactionHeader;
                
                #region For XML Process
                response.ResultMessage = GetResultMessageData(ResponseCode.Success, ResponseMessage.Success);
                #endregion
            }
            else if (base.RunningMode.Equals(Base.RunningMode.DBDMS))
            {
                #region For DB Process - Not Yet
                response.ResultMessage = GetResultMessageData(ResponseCode.Success, ResponseMessage.Success);
                #endregion
            }

            return response;
        }
    }
}
