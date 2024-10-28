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

                    Orders.Columns["OrderNumber"].HeaderText = "����� ������";
                    Orders.Columns["Weight"].HeaderText = "��� (��)";
                    Orders.Columns["District"].HeaderText = "�����";
                    Orders.Columns["DeliveryTime"].HeaderText = "����� ��������";

                    district.Items.Clear();
                    district.Items.Add("��� ������");
                    district.Items.AddRange(orderManager.GetDistricts().ToArray());
                    district.SelectedIndex = 0;

                    statusLabel.Text = "������ ���������.";
                }
                else
                {
                    MessageBox.Show("������ ��� �������� ������. ��������� ��� ��� ������������.");
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
                statusLabel.Text = "���������� ���������.";
            }
            else
            {
                MessageBox.Show("��� �������, ��������������� �������� ���������.");
                statusLabel.Text = "���������� �� ���� �����������.";
            }
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            if (filteredOrders == null || filteredOrders.Count == 0)
            {
                MessageBox.Show("��� ������ ��� ����������.");
                return;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (orderManager.SaveOrders(saveFileDialog.FileName, filteredOrders))
                {
                    MessageBox.Show("���������� ������� ���������.");
                    statusLabel.Text = "���������� ���������.";
                }
                else
                {
                    MessageBox.Show("������ ��� ���������� �����������. ��������� ��� ��� ������������.");
                }
            }
        }
    }
}
