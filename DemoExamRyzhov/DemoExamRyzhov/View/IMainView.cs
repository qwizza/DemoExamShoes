using DemoExamRyzhov.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoExamRyzhov.View
{
    public interface IMainView
    {
        // Данные фильтров
        string SearchText { get; }
        string SelectedCategory { get; }
        string SelectedManufacturer { get; }
        string SelectedSort { get; }

        // События товаров
        event EventHandler FilterChanged;
        event EventHandler AddProductClicked;
        event EventHandler EditProductClicked;
        event EventHandler DeleteProductClicked;

        // События заказов
        event EventHandler AddOrderClicked;
        event EventHandler EditOrderClicked;
        event EventHandler DeleteOrderClicked;

        // События ПВЗ
        event EventHandler AddPointClicked;
        event EventHandler EditPointClicked;
        event EventHandler DeletePointClicked;

        // События пользователей
        event EventHandler AddUserClicked;
        event EventHandler EditUserClicked;
        event EventHandler DeleteUserClicked;

        // Методы для передачи данных в форму
        void ApplyAccessRights(UserRole role);
        void FillFilterComboboxes(List<string> categories, List<string> manufacturers);
        void SetProducts(DataTable dt);
        void SetOrders(DataTable dt);
        void SetDeliveryPoints(DataTable dt);
        void SetUsers(DataTable dt);
        void ShowMessage(string message);
    }
}
