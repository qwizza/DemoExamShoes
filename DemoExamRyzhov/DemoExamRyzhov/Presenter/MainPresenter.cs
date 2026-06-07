using DemoExamRyzhov.Model;
using DemoExamRyzhov.View;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoExamRyzhov.Presenter
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly MainRepository _repository;
        private readonly UserRole _currentRole;

        public MainPresenter(IMainView view, MainRepository repository, UserRole role)
        {
            _view = view;
            _repository = repository;
            _currentRole = role;

            _view.ApplyAccessRights(_currentRole);

            // Подписка на фильтры и CRUD товаров
            _view.FilterChanged += OnFilterChanged;
            _view.AddProductClicked += OnAddProduct;
            _view.EditProductClicked += OnEditProduct;
            _view.DeleteProductClicked += OnDeleteProduct;

            // ПОДПИСКА НА КНОПКИ ЗАКАЗОВ
            _view.AddOrderClicked += OnAddOrder;
            _view.EditOrderClicked += OnEditOrder;
            _view.DeleteOrderClicked += OnDeleteOrder;

            // ПОДПИСКА НА КНОПКИ ПВЗ
            _view.AddPointClicked += OnAddPoint;
            _view.EditPointClicked += OnEditPoint;
            _view.DeletePointClicked += OnDeletePoint;

            // ПОДПИСКА НА КНОПКИ ПОЛЬЗОВАТЕЛЕЙ
            _view.AddUserClicked += OnAddUser;
            _view.EditUserClicked += OnEditUser;
            _view.DeleteUserClicked += OnDeleteUser;

            // Первая загрузка данных
            LoadAllData();
        }

        private void LoadAllData()
        {
            // Метод обновляет все таблицы на форме актуальными данными из БД
            _view.SetProducts(_repository.GetFilteredProducts(_view.SearchText, _view.SelectedCategory, _view.SelectedManufacturer, _view.SelectedSort));
            _view.SetOrders(_repository.GetOrders());
            _view.SetDeliveryPoints(_repository.GetDeliveryPoints());
            _view.SetUsers(_repository.GetUsers());
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            _view.SetProducts(_repository.GetFilteredProducts(_view.SearchText, _view.SelectedCategory, _view.SelectedManufacturer, _view.SelectedSort));
        }

        // ЛОГИКА УДАЛЕНИЯ ЗАКАЗА
        private void OnDeleteOrder(object sender, EventArgs e)
        {
            var dgv = (sender as MainForm)?.Controls["tabControl"]?.Controls["tabOrders"]?.Controls["dgvOrders"] as DataGridView;
            if (dgv?.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgv.CurrentRow.Cells["order_number"].Value);
                if (MessageBox.Show($"Вы уверены, что хотите удалить заказ №{id}?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        _repository.DeleteOrder(id);
                        _view.ShowMessage("Заказ успешно удален из базы данных!");
                        _view.SetOrders(_repository.GetOrders());
                    }
                    catch (Exception ex) { _view.ShowMessage("Ошибка удаления (возможно, есть связанные данные): " + ex.Message); }
                }
            }
        }

        // ЛОГИКА УДАЛЕНИЯ ПВЗ
        private void OnDeletePoint(object sender, EventArgs e)
        {
            var dgv = (sender as MainForm)?.Controls["tabControl"]?.Controls["tabPoints"]?.Controls["dgvPoints"] as DataGridView;
            if (dgv?.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
                if (MessageBox.Show($"Удалить пункт выдачи №{id}?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        _repository.DeleteDeliveryPoint(id);
                        _view.ShowMessage("Пункт выдачи удален!");
                        _view.SetDeliveryPoints(_repository.GetDeliveryPoints());
                    }
                    catch (Exception ex) { _view.ShowMessage("Ошибка: " + ex.Message); }
                }
            }
        }

        // ЛОГИКА УДАЛЕНИЯ ПОЛЬЗОВАТЕЛЯ
        private void OnDeleteUser(object sender, EventArgs e)
        {
            var dgv = (sender as MainForm)?.Controls["tabControl"]?.Controls["tabUsers"]?.Controls["dgvUsers"] as DataGridView;
            if (dgv?.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
                string login = dgv.CurrentRow.Cells["login"].Value.ToString();
                if (MessageBox.Show($"Удалить пользователя {login}?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        _repository.DeleteUser(id);
                        _view.ShowMessage("Пользователь стерт из системы!");
                        _view.SetUsers(_repository.GetUsers());
                    }
                    catch (Exception ex) { _view.ShowMessage("Ошибка: " + ex.Message); }
                }
            }
        }

        private void OnAddPoint(object sender, EventArgs e)
        {
            using (var form = new PointForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _repository.AddDeliveryPoint(form.AddressText);
                        _view.ShowMessage("Пункт выдачи успешно добавлен!");
                        _view.SetDeliveryPoints(_repository.GetDeliveryPoints());
                    }
                    catch (Exception ex) { _view.ShowMessage("Ошибка добавления: " + ex.Message); }
                }
            }
        }

        private void OnEditPoint(object sender, EventArgs e)
        {
            var dgv = (sender as MainForm)?.Controls["tabControl"]?.Controls["tabPoints"]?.Controls["dgvPoints"] as DataGridView;

            if (dgv?.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
                string currentAddress = dgv.CurrentRow.Cells["address"].Value.ToString();

                using (var form = new PointForm(id, currentAddress))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            _repository.UpdateDeliveryPoint(id, form.AddressText);
                            _view.ShowMessage("Данные пункта выдачи обновлены!");
                            _view.SetDeliveryPoints(_repository.GetDeliveryPoints());
                        }
                        catch (Exception ex) { _view.ShowMessage("Ошибка обновления: " + ex.Message); }
                    }
                }
            }
            else
            {
                _view.ShowMessage("Пожалуйста, выберите строку для редактирования.");
            }
        }

        private void OnAddUser(object sender, EventArgs e)
        {
            var roles = _repository.GetRoleNames();
            using (var form = new UserForm(roles))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _repository.AddUser(form.FullNameText, form.LoginText, form.SelectedRole);
                        _view.ShowMessage("Пользователь успешно добавлен!");
                        _view.SetUsers(_repository.GetUsers());
                    }
                    catch (Exception ex) { _view.ShowMessage("Ошибка добавления: " + ex.Message); }
                }
            }
        }

        private void OnEditUser(object sender, EventArgs e)
        {
            var dgv = (sender as MainForm)?.Controls["tabControl"]?.Controls["tabUsers"]?.Controls["dgvUsers"] as DataGridView;
            if (dgv?.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value);
                string fullName = dgv.CurrentRow.Cells["full_name"].Value.ToString();
                string login = dgv.CurrentRow.Cells["login"].Value.ToString();
                string currentRole = dgv.CurrentRow.Cells["role_name"].Value.ToString();

                var roles = _repository.GetRoleNames();
                using (var form = new UserForm(id, fullName, login, currentRole, roles))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            _repository.UpdateUser(id, form.FullNameText, form.LoginText, form.SelectedRole);
                            _view.ShowMessage("Данные пользователя обновлены!");
                            _view.SetUsers(_repository.GetUsers());
                        }
                        catch (Exception ex) { _view.ShowMessage("Ошибка обновления: " + ex.Message); }
                    }
                }
            }
            else
            {
                _view.ShowMessage("Пожалуйста, выберите пользователя для редактирования.");
            }
        }

        private void OnAddProduct(object sender, EventArgs e)
        {
            var cats = _repository.GetCategories();
            var mans = _repository.GetManufacturers();

            using (var form = new ProductForm(cats, mans))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _repository.AddProduct(form.ArticleText, form.NameText, form.UnitText, form.PriceValue,
                                               form.SupplierText, form.SelectedManufacturer, form.SelectedCategory,
                                               form.DiscountValue, form.StockValue, form.DescriptionText);
                        _view.ShowMessage("Товар добавлен успешно!");
                        OnFilterChanged(null, null);
                    }
                    catch (Exception ex) { _view.ShowMessage("Ошибка добавления товара: " + ex.Message); }
                }
            }
        }

        private void OnEditProduct(object sender, EventArgs e)
        {
            var dgv = (sender as MainForm)?.Controls["tabControl"]?.Controls["tabProducts"]?.Controls["dgvProducts"] as DataGridView;

            if (dgv?.CurrentRow != null)
            {
                var row = ((System.Data.DataRowView)dgv.CurrentRow.DataBoundItem).Row;

                var cats = _repository.GetCategories();
                var mans = _repository.GetManufacturers();

                using (var form = new ProductForm(row, cats, mans))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            _repository.UpdateProduct(form.ArticleText, form.NameText, form.UnitText, form.PriceValue,
                                                      form.SupplierText, form.SelectedManufacturer, form.SelectedCategory,
                                                      form.DiscountValue, form.StockValue, form.DescriptionText);
                            _view.ShowMessage("Товар обновлен успешно!");
                            OnFilterChanged(null, null);
                        }
                        catch (Exception ex) { _view.ShowMessage("Ошибка обновления товара: " + ex.Message); }
                    }
                }
            }
            else
            {
                _view.ShowMessage("Пожалуйста, выберите товар из списка для изменения.");
            }
        }

        private void OnDeleteProduct(object sender, EventArgs e)
        {
            var dgv = (sender as MainForm)?.Controls["tabControl"]?.Controls["tabProducts"]?.Controls["dgvProducts"] as DataGridView;

            if (dgv?.CurrentRow != null)
            {
                string article = dgv.CurrentRow.Cells["article"].Value.ToString();
                string name = dgv.CurrentRow.Cells["name"].Value.ToString();

                if (MessageBox.Show($"Вы уверены, что хотите удалить товар \"{name}\" (Артикул: {article})?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _repository.DeleteProduct(article);
                        _view.ShowMessage("Товар успешно удален!");
                        OnFilterChanged(null, null);
                    }
                    catch (Exception ex)
                    {
                        _view.ShowMessage("Ошибка удаления (возможно, товар оформлен в заказах): " + ex.Message);
                    }
                }
            }
            else
            {
                _view.ShowMessage("Пожалуйста, выберите товар для удаления.");
            }
        }

        private void OnAddOrder(object sender, EventArgs e)
        {
            var points = new List<string>();
            var dtPoints = _repository.GetDeliveryPoints();
            foreach (System.Data.DataRow r in dtPoints.Rows) points.Add(r["address"].ToString());

            // Получаем список клиентов из базы
            var clients = _repository.GetClients();
            var statuses = _repository.GetOrderStatuses();

            using (var form = new OrderForm(points, clients, statuses))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Прокидываем выбранного клиента в репозиторий
                        _repository.AddOrder(form.OrderDateValue, form.DeliveryDateValue, form.SelectedPoint, form.SelectedClient, form.SelectedStatus);
                        _view.ShowMessage("Заказ успешно сформирован!");
                        _view.SetOrders(_repository.GetOrders());
                    }
                    catch (Exception ex) { _view.ShowMessage("Ошибка создания заказа: " + ex.Message); }
                }
            }
        }

        private void OnEditOrder(object sender, EventArgs e)
        {
            var dgv = (sender as MainForm)?.Controls["tabControl"]?.Controls["tabOrders"]?.Controls["dgvOrders"] as DataGridView;

            if (dgv?.CurrentRow != null)
            {
                int orderNumber = Convert.ToInt32(dgv.CurrentRow.Cells["order_number"].Value);

                // ДОБАВИЛИ: Вытаскиваем дату заказа из таблицы, чтобы она существовала в контексте
                DateTime orderDate = Convert.ToDateTime(dgv.CurrentRow.Cells["order_date"].Value);
                DateTime deliveryDate = Convert.ToDateTime(dgv.CurrentRow.Cells["delivery_date"].Value);

                string currentPoint = dgv.CurrentRow.Cells["order_point_address"].Value.ToString();
                string currentClient = dgv.CurrentRow.Cells["client"].Value.ToString(); // Вытаскиваем текущего клиента
                string currentStatus = dgv.CurrentRow.Cells["status"].Value.ToString();

                var points = new List<string>();
                var dtPoints = _repository.GetDeliveryPoints();
                foreach (System.Data.DataRow r in dtPoints.Rows) points.Add(r["address"].ToString());

                var clients = _repository.GetClients();
                var statuses = _repository.GetOrderStatuses();

                // ИСПРАВИЛИ: Передаем orderDate вместо несуществующей date
                using (var form = new OrderForm(orderNumber, orderDate, deliveryDate, currentPoint, currentClient, currentStatus, points, clients, statuses))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // Для апдейта передаем все измененные параметры в репозиторий
                            _repository.UpdateOrder(orderNumber, form.OrderDateValue, form.DeliveryDateValue, form.SelectedPoint, form.SelectedClient, form.SelectedStatus);
                            _view.ShowMessage("Заказ успешно обновлен!");
                            _view.SetOrders(_repository.GetOrders());
                        }
                        catch (Exception ex) { _view.ShowMessage("Ошибка обновления заказа: " + ex.Message); }
                    }
                }
            }
        }
    }
}
