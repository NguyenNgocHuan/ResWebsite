using ResWebsite.BLL;
using ResWebsite.BLL.Bussiness;
using System;
using System.ServiceProcess;
using System.Timers;
using EmailComponent;
using System.Configuration;
using System.Data;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
        private Timer scheduleTimer = null;
        private DateTime lastRun;
        private bool flag;
        ReservationContractBLL bll = new ReservationContractBLL();
        GetEmailIdsFromDB proc;
        public Service1()
        {
            InitializeComponent();
            proc = new GetEmailIdsFromDB();
            proc.connectionString = ConfigurationManager.ConnectionStrings["RestaurantDbContext"].ConnectionString;

            if (!System.Diagnostics.EventLog.SourceExists("EmailSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource("EmailSource", "EmailLog");
            }
            eventLogEmail.Source = "EmailSource";
            eventLogEmail.Log = "EmailLog";

            scheduleTimer = new Timer();
            scheduleTimer.Interval = 1 * 1 * 60 * 1000;
            scheduleTimer.Elapsed += new ElapsedEventHandler(scheduleTimer_Elapsed);
        }
        protected override void OnStart(string[] args)
        {
            flag = true;
            lastRun = DateTime.Now;
            scheduleTimer.Start();
            eventLogEmail.WriteEntry("Started");
           
        }

        protected void scheduleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (flag == true)
            {
                ServiceEmailMethod();
                lastRun = DateTime.Now;
                flag = false;
            }
            else if (flag == false)
            {
                if (lastRun.Date < DateTime.Now.Date)
                {
                    ServiceEmailMethod();
                }
            }
            proc.storedProcName = "closeContract";
            System.Data.DataSet list = proc.GetCustomerLateContract();
        }
        private void ServiceEmailMethod()
        {
            try {
                Email email = new Email();
                email.fromEmail = "redvelvets.restaurant@gmail.com";
                email.fromName = "Red velvet Restaurant";
                email.subject = "Thanh toán đặt trước";
                email.smtpServer = "smtp.gmail.com";
                email.smtpCredentials = new System.Net.NetworkCredential("redvelvets.restaurant@gmail.com",
                    "redvelvet2018");
                
                proc.storedProcName = "getLateContract";
                System.Data.DataSet ds = proc.GetCustomerLateContract();
               

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    eventLogEmail.WriteEntry("Start send mail " + dr["email"].ToString());

                    eventLogEmail.WriteEntry("email: " + dr["email"].ToString());
                    email.messageBody = "<h4>Xin chào " + dr["Name"].ToString() + " </h4><br/>" +
                                        "<h3>Đơn đặt trước của bạn săp hết hạn</h3><br/>" +
                                        "<h4>Ngày tạo đơn đặt trước " + dr["CreateDate"].ToString() + "</h4><br/>" +
                                        "<h4>Ngày hết hạn để kí hợp đồng " + dr["ExpireDate"].ToString() + "</h4><br/>" +
                                        "<h4>Ngày tổ chức " + dr["EffectDate"].ToString() + "</h4><br/>" +
                                        "<h4>Ngày hết hạn để kí hợp đồng </h4><br/>" +
                                        "<h4>Vui lòng đến quầy tiếp tân tại nhà hàng để kí hợp đồng và tiến hành đặt cọc để tiếp tục đơn đặt trước</h4><br/>" +
                                        "<h4>Nếu hết ngày " + dr["ExpireDate"].ToString() + " chúng tôi không nhận được thông tin phản hồi về việc này, đơn đặt trước sẽ bị hủy theo điều lệ trong hợp động tạm thời.<h4><br/>" +
                                        "<h4>Thanks</h4>";
                    bool result = email.SendEmailAsync(dr["email"].ToString(), dr["Name"].ToString());

                    if (result == true)
                    {
                        eventLogEmail.WriteEntry("Message Sent SUCCESS to "+ dr["email"].ToString());
                    }
                    else
                    {
                        eventLogEmail.WriteEntry("Message Sent FAILED to" + dr["email"].ToString());
                    }

                    
                }
                

            }
            catch (Exception e)
            {
                eventLogEmail.WriteEntry(e.Message);
            }
            
        }
        protected override void OnStop()
        {
            scheduleTimer.Stop();
            eventLogEmail.WriteEntry("Stopped");
        }
        protected override void OnPause()
        {
            scheduleTimer.Stop();
            eventLogEmail.WriteEntry("Paused");
        }
        protected override void OnContinue()
        {
            scheduleTimer.Start(); ;
            eventLogEmail.WriteEntry("Continuing");
        }
        protected override void OnShutdown()
        {
            scheduleTimer.Stop();
            eventLogEmail.WriteEntry("ShutDowned");
        }
    }
    

}
