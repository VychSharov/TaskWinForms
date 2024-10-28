using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWinForms
{
    public class OrderManager
    {
        public List<Order> Orders { get; private set; } = new List<Order>();

        public bool LoadOrders(string filePath)
        {
            try
            {
                Orders.Clear();
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    if (Order.TryParse(line, out Order order))
                    {
                        Orders.Add(order);
                    }
                    else
                    {
                        Logger.LogError($"Ошибка при разборе строки: {line}");
                    }
                }

                Logger.Log("Данные успешно загружены.");
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при загрузке данных: {ex.Message}");
                return false;
            }
        }

        public List<string> GetDistricts()
        {
            return Orders.Select(o => o.District).Distinct().ToList();
        }

        public List<Order> FilterOrders(string district, DateTime firstDeliveryTime)
        {
            DateTime endTime = firstDeliveryTime.AddMinutes(30);

            // фильтр по времени
            var filteredOrders = Orders
        .Where(o => o.DeliveryTime >= firstDeliveryTime && o.DeliveryTime <= endTime);

            if (!string.IsNullOrEmpty(district) && district != "Все районы")
            {
                // фильтр по району
                filteredOrders = filteredOrders.Where(o => o.District == district);
            }

            // сортировка по времени
            filteredOrders = filteredOrders.OrderBy(o => o.DeliveryTime);

            if (string.IsNullOrEmpty(district) || district == "Все районы")
            {
                filteredOrders = filteredOrders
                    .GroupBy(o => o.District)
                    .OrderByDescending(g => g.Count())
                    .SelectMany(g => g.OrderBy(o => o.DeliveryTime));
            }

            Logger.Log("Выполнена фильтрация заказов.");

            return filteredOrders.ToList();
        }

        public bool SaveOrders(string filePath, List<Order> ordersToSave)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var order in ordersToSave)
                    {
                        writer.WriteLine($"{order.OrderNumber},{order.Weight.ToString(CultureInfo.InvariantCulture)},{order.District},{order.DeliveryTime.ToString("yyyy-MM-dd HH:mm:ss")}");
                    }
                }

                Logger.Log("Результаты успешно сохранены.");
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при сохранении результатов: {ex.Message}");
                return false;
            }
        }
    }
}
