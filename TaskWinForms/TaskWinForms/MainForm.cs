namespace TaskWinForms
{
    public partial class MainForm : Form
    {
        private OrderManager orderManager = new OrderManager();
        private List<Order> filteredOrders = new List<Order>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadData_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (orderManager.LoadOrders(openFileDialog.FileName))
                {
                    Orders.DataSource = orderManager.Orders;

                    Orders.Columns["OrderNumber"].HeaderText = "Номер заказа";
                    Orders.Columns["Weight"].HeaderText = "Вес (кг)";
                    Orders.Columns["District"].HeaderText = "Район";
                    Orders.Columns["DeliveryTime"].HeaderText = "Время доставки";

                    district.Items.Clear();
                    district.Items.Add("Все районы");
                    district.Items.AddRange(orderManager.GetDistricts().ToArray());
                    district.SelectedIndex = 0;

                    statusLabel.Text = "Данные загружены.";
                }
                else
                {
                    MessageBox.Show("Ошибка при загрузке данных. Проверьте лог для подробностей.");
                }
            }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            string district = this.district.SelectedItem?.ToString();

            DateTime FirstDeliveryTime = firstDeliveryTime.Value;

            filteredOrders = orderManager.FilterOrders(district, FirstDeliveryTime);

            if (filteredOrders.Count > 0)
            {
                Orders.DataSource = null;
                Orders.DataSource = filteredOrders;
                statusLabel.Text = "Фильтрация выполнена.";
            }
            else
            {
                MessageBox.Show("Нет заказов, соответствующих заданным критериям.");
                statusLabel.Text = "Фильтрация не дала результатов.";
            }
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            if (filteredOrders == null || filteredOrders.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения.");
                return;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (orderManager.SaveOrders(saveFileDialog.FileName, filteredOrders))
                {
                    MessageBox.Show("Результаты успешно сохранены.");
                    statusLabel.Text = "Результаты сохранены.";
                }
                else
                {
                    MessageBox.Show("Ошибка при сохранении результатов. Проверьте лог для подробностей.");
                }
            }
        }
    }
}
