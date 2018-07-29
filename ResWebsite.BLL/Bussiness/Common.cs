using ResWebsite.BLL.Bussiness;
using ResWebsite.DAL.Entity;
using ResWebsite.DAL.ObjectModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.BLL.Home
{
    public class Common
    {
        PlaceBLL placebll = new PlaceBLL();
        ReservationContractDetailBLL detailbll = new ReservationContractDetailBLL();
        ReservationContractBLL contractBLL = new ReservationContractBLL();
        ReservationBillBLL billbll = new ReservationBillBLL();
        MealDrinkBLL mealbll = new MealDrinkBLL();
        ServiceBLL servicebll = new ServiceBLL();
        MealDrinkBLL mealdrinkbll = new MealDrinkBLL();
        CustomerBLL cusbll = new CustomerBLL();

        public void SaveChangeData()
        {
            RestaurantDbContext db = new RestaurantDbContext();
            db.SaveChanges();
        }
        public List<Object> ReturnMessage(string message, string status, object obj)
        {
            var data = new List<Object>();
            data.Add(message);
            data.Add(status);
            data.Add(obj);
            return data;
        }
        public void SendMail(ReservationContract contract, string to, string subject)
        {
            try
            {
                var mailMessage = new MailMessage();
                mailMessage.To.Add(to);
                mailMessage.Subject = subject;
                Place place = placebll.GetPlaceByIdBLL(contract.PlaceId);
                Customer cus = cusbll.FindCustomer(contract.CustomerId);
                decimal? price = place.Price * CountTableQuantity((int)contract.CountCustomer);
                string content = "<h4 style='color:blue'>Chúc mừng bạn đã đăng kí đặt trước thành công tại Red Velvet Restaurant của chúng tôi</h4>" +
                    "<h2> HỢP ĐỒNG ĐẶT TRƯỚC</h2>" +
                    "<p>Mã đơn đặt trước: " + contract.ReservationContractId.ToString() + "</p>" +
                    "<p>Loại đơn đặt trước: " + contract.ReservationContractName.ToString() + "</p>" +
                    "<p>Loại sảnh: " + place.PlaceName + "</p>" +
                    "<p>Ngày tạo đơn đặt trước: " + contract.CreateDate + " </p>" +
                    "<p>Ngày tổ chức: " + contract.EffectDate + " </p>" +
                    "<p>Số lượng bàn:  " + contract.Note + " </p>" +
                    "<p style='color:red'>Giá đặt chỗ: " + place.Price + "*" + contract.Note +
                    "=" + price +
                    "</p>";
                List<ItemObject> mealdrink = new List<ItemObject>();
                foreach (var i in detailbll.GetAllReservationMealDrinkDetailByContractIdBLL(contract.ReservationContractId))
                {
                    ItemObject item = new ItemObject();
                    item.id = i.MealDrinkId;
                    item.Name = mealdrinkbll.GetMealById(i.MealDrinkId).Name;
                    item.note = i.Note;
                    item.Price = (decimal)i.Price;
                    item.Quantity = (int)i.Quantity;
                    mealdrink.Add(item);
                }
                if (mealdrink.Count != 0)
                {
                    content += "<h3 style='color:blue'>Danh sách món ăn đã được đặt</h3>" +
                      "<table class='table table-striped' style='color:black'>" +
                        "<thead>" +
                          "<tr>" +
                            "<th>Tên món</th>" +
                            "<th>Giá</th>" +
                            "<th>Số lượng</th>" + 
                          "</tr>" +
                        "</thead>" +
                        "<tbody>";
                    foreach (ItemObject i in mealdrink)
                    {
                        content += "<tr>" +
                          "<td>" + i.Name + "</td>" +
                          "<td>" + i.Price + " VND</td>" +
                          "<td>" + i.Quantity + "</td>" +
                        "</tr>";
                    }
                    content += "<tr><td style='color:blue'><h3>Tổng thanh toán thực đơn: "
                        + mealbll.GetTotalOfMealListBLL(contract.ReservationContractId, (int)contract.CountCustomer) 
                        + "000 VND</h3></td></tr>" +
                        "</tbody>" +
                   "</table>";
                }
                List<ItemObject> service = new List<ItemObject>();
                foreach (var i in detailbll.GetAllServiceDetailByContractIdBLL(contract.ReservationContractId))
                {
                    ItemObject item = new ItemObject();
                    item.id = i.ServiceId;
                    item.Name = servicebll.GetServiceById(i.ServiceId).ServiceName;
                    item.note = i.Note;
                    item.Price = (decimal)i.Price;
                    item.Quantity = (int)i.Quantity;
                    service.Add(item);
                }
                if (service.Count != 0)
                {
                    content += "<h3 style='color:blue'>Danh sách dịch vụ đã chọn</h3>" +
                          "<table class='table table-striped' style='color:black'>" +
                            "<thead>" +
                              "<tr>" +
                                "<th>Tên dịch vụ</th>" +
                                "<th>Giá</th>" +
                                "<th>Note</th>" +
                              "</tr>" +
                            "</thead>" +
                            "<tbody>";

                    foreach (ItemObject i in service)
                    {
                        content +=
                        "<tr>" +
                              "<td>" + i.Name + "</td>" +
                              "<td>" + i.Price + " VND</td>" +
                              "<td>" + i.note + "</td>" +
                            "</tr>";
                    }
                        content += "<tr><td style='color:blue'><h3>Tổng thanh toán dịch vụ: "
                        + servicebll.GetTotalOfServiceListBLL(contract.ReservationContractId, (int)contract.CountCustomer)
                        + "000 VND</h3></td></tr>" +
                          "</tbody>" +
                        "</table>";
                }
                    content += "<hr>";
                double total = (double)price + servicebll.GetTotalOfServiceListBLL(contract.ReservationContractId, (int)contract.CountCustomer) +
                    mealbll.GetTotalOfMealListBLL(contract.ReservationContractId, (int)contract.CountCustomer);

                content += "<h3 style='color:red'>TỔNG THANH TOÁN: " + total + "000 VND </h3>";
                ReservationBill bill = billbll.GetBillById(contract.ReservationContractId);
                content += "<h4 style='color:black'>Số tiền trả trước: " + bill.PrePay + " VND </h4>";
                decimal? pay = bill.TotalPay - bill.PrePay;
                content += "<h4 style='color:blue'>Số tiền còn lại: " + pay + " VND </h4>";
                content += "</hr><p style='color:black'>Khách hàng vui lòng đến trực tiếp quầy tiếp tân của nhà hàng để xác nhận hợp đồng đặt trước và thanh toán số tiền còn lại" +
                    " trước ngày " + contract.ExpireDate + ". Nếu sau ngày trên, chúng tôi không nhận được thông tin liên lạc của khách hàng về đơn đặt trước này." +
                    " Chúng tôi xin phép hủy đơn đặt trước của khách hàng. Xin chân thành cảm ơn vì đã chọn lựa nhà hàng chúng tôi!</p>";
                content += "<hr><hr><h5 style='color:blue'>Điều khoản thanh toán:</h5>" +
                    "- Khách hàng có thể dời thanh toán số còn lại sau khi tiệc tổ chức tối đa 3 ngày.<br>" +
                    "- Khi đi xác nhận hợp đồng vui lòng mang theo CMND hoặc hộ khẩu đã được công chứng để hoàn tất.<br>" +
                    "- Đối với tiệc cưới, chi phí in ấn thực đơn được tặng hoàn toàn.<br>";

                mailMessage.Body = content;
                    mailMessage.IsBodyHtml = true;
                        Trace.WriteLine("-----send--mail-----");
                        var smtpClient = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("redvelvets.restaurant@gmail.com", "redvelvet2018")
                    };
                    smtpClient.Send(mailMessage);
            }catch(Exception e)
            {
                Trace.WriteLine("-----error-------" + e.Message);
            }
        }
        public int CountTableQuantity(int quantity)
        {
            int table;
            if (quantity % 10 != 0)
                table = quantity / 10 + 1;
            else
                table = quantity / 10;
            return table;
        }

        public double GetTotal(int contractId)
        {
            ReservationContract contract = contractBLL.GetContractByContractId(contractId);
            int quanityClient = CountTableQuantity((int)contract.CountCustomer);
            Trace.WriteLine((double)placebll.GetPlaceByIdBLL(contract.PlaceId).Price * quanityClient + "-"
                + mealbll.GetTotalOfMealListBLL(contractId, quanityClient) + "-"
                + servicebll.GetTotalOfServiceListBLL(contractId, quanityClient));

            return (double)placebll.GetPlaceByIdBLL(contract.PlaceId).Price +
                mealbll.GetTotalOfMealListBLL(contractId, quanityClient) +
                servicebll.GetTotalOfServiceListBLL(contractId, quanityClient);
        }
    }
}
