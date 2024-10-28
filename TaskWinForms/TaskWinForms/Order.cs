using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWinForms
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public double Weight { get; set; }
        public string District { get; set; }
        public DateTime DeliveryTime { get; set; }

        public static bool TryParse(string csvLine, out Order order)
        {
            order = null;
            var values = csvLine.Split(',');

            if (values.Length != 4)
                return false;

            try
            {
                string orderNumber = values[0].Trim();
                string weightStr = values[1].Trim();
                string district = values[2].Trim();
                string deliveryTimeStr = values[3].Trim();

                //валидация
                if (string.IsNullOrEmpty(orderNumber))
                {
                    Logger.LogError($"Пустой номер заказа в строке: {csvLine}");
                    return false;
                }

                if (!double.TryParse(weightStr.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double weight))
                {
                    Logger.LogError($"Ошибка парсинга веса '{weightStr}' в строке: {csvLine}");
                    return false;
                }

                if (weight <= 0)
                {
                    Logger.LogError($"Вес заказа должен быть положительным числом в строке: {csvLine}");
                    return false;
                }

                if (string.IsNullOrEmpty(district))
                {
                    Logger.LogError($"Пустой район в строке: {csvLine}");
                    return false;
                }

                if (!DateTime.TryParseExact(deliveryTimeStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime deliveryTime))
                {
                    Logger.LogError($"Ошибка парсинга даты и времени '{deliveryTimeStr}' в строке: {csvLine}");
                    return false;
                }

                order = new Order
                {
                    OrderNumber = orderNumber,
                    Weight = weight,
                    District = district,
                    DeliveryTime = deliveryTime
                };

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Неизвестная ошибка при разборе строки: {csvLine}. Сообщение: {ex.Message}");
                return false;
            }
        }
    }
}
