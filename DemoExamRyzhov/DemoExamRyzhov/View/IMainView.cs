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
        void SetProducts(DataTable dt);
        void SetOrders(DataTable dt);
        void SetDeliveryPoints(DataTable dt);
        void SetUsers(DataTable dt);

        string SearchText { get; }
        string SelectedCategory { get; }
        string SelectedManufacturer { get; }
        string SelectedSort { get; }

        void FillFilterComboboxes(List<string> categories, List<string> manufacturers);

        event EventHandler FilterChanged;
        event EventHandler AddProductClicked;
        event EventHandler EditProductClicked;
        event EventHandler DeleteProductClicked;

        // Заменили Models.UserRole на чистый UserRole, так как using мы прописали сверху
        void ApplyAccessRights(UserRole role);
        void ShowMessage(string message);
    }
}
