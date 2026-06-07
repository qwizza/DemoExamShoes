using DemoExamRyzhov.Model;
using DemoExamRyzhov.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExamRyzhov.Presenter
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly MainRepository _repository;

        public MainPresenter(IMainView view, MainRepository repository)
        {
            _view = view;
            _repository = repository;

            // Подписка на события представления
            _view.FilterChanged += OnFilterChanged;

            // Загружаем начальные настройки прав доступа
            _view.ApplyAccessRights(UserSession.CurrentRole);

            // Инициализация фильтров в интерфейсе
            _view.FillFilterComboboxes(_repository.GetCategories(), _repository.GetManufacturers());

            // Первая загрузка данных на экраны
            LoadAllData();
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            // Перезагружаем только товары с учетом новых фильтров
            var dtProducts = _repository.GetFilteredProducts(
                _view.SearchText,
                _view.SelectedCategory,
                _view.SelectedManufacturer,
                _view.SelectedSort
            );
            _view.SetProducts(dtProducts);
        }

        private void LoadAllData()
        {
            // Загружаем товары с пустыми фильтрами по умолчанию
            _view.SetProducts(_repository.GetFilteredProducts("", "Все категории", "Все производители", "Без сортировки"));

            // Остальные данные загружаем только если роль позволяет их смотреть, чтобы не гонять зря запросы к БД
            if (UserSession.CurrentRole == UserRole.Manager || UserSession.CurrentRole == UserRole.Admin)
            {
                _view.SetOrders(_repository.GetOrders());
                _view.SetDeliveryPoints(_repository.GetDeliveryPoints());
            }

            if (UserSession.CurrentRole == UserRole.Admin)
            {
                _view.SetUsers(_repository.GetUsers());
            }
        }
    }
}
