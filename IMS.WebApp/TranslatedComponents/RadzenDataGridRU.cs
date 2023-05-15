using Microsoft.AspNetCore.Components;
using Radzen.Blazor;

namespace IMS.WebApp.TranslatedComponents
{   
    public class RadzenDataGridRU<TItem> : RadzenDataGrid<TItem>
    {
        public RadzenDataGridRU() : base()
        {

            base.AndOperatorText = "И";
            base.EqualsText = "Равен";
            base.NotEqualsText = "Не равен";
            base.LessThanText = "Меньше чем";
            base.LessThanOrEqualsText = "Меньше чем или равен";
            base.GreaterThanText = "Больше чем";
            base.GreaterThanOrEqualsText = "Больше чем или равен";
            base.IsNullText = "Равен NULL";
            base.IsNotNullText = "Не равен NULL";
            base.AndOperatorText = "И";
            base.OrOperatorText = "Или";
            base.ContainsText = "Содержит";
            base.DoesNotContainText = "Не содержит";
            base.StartsWithText = "Начинается с";
            base.EndsWithText = "Заканчивается на";
            base.ClearFilterText = "Сброс";
            base.ApplyFilterText = "✔";
            base.FilterText = "Фильтр 🔎";

            base.PagingSummaryFormat = "Страница {0} из {1} (Элементов: {2})";
        }
    }
}
