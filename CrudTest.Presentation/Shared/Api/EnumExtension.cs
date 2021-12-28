using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CrudTest.Presentation.Shared.Api
{
    public static class EnumExtension
    {
        public static string ToDisplay(this Enum value, DisplayProperty property = DisplayProperty.Name)
        {
            //Assert.NotNull(value, nameof(value));

            var attribute = value.GetType().GetField(value.ToString())
                .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();

            if (attribute == null)
                return value.ToString();

            var propValue = attribute.GetType().GetProperty(property.ToString()).GetValue(attribute, null);
            return propValue.ToString();
        }

        public enum DisplayProperty
        {
            Description,
            GroupName,
            Name,
            Prompt,
            ShortName,
            Order
        }
    }
}