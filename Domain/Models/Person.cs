using Colors.Domain.Common;
using Domain.Exceptions;
using Domain.Models.Common;
using System.Collections.Generic;
using System.Linq;
using static Colors.Domain.Common.ModelConstants;

namespace Domain.Models
{
    public class Person : Entity<int>, IAggregateRoot
    {
        private static readonly IEnumerable<Color> AllColors
            = new ColorData().GetData().Cast<Color>();

        public string FirstName { get;  private set; }
        public string LastName { get; private set; }
        public string Zipcode { get; private set; }
        public string City { get; private set; }
        public int ColorId { get; private set; }
        //public string Color { get; private set; }

        public Person(
            string firstName,
            string lastName,
            string zipcode,
            string city,
            int colorId)
        {
            this.ValidateInput(
                firstName,
                lastName,
                zipcode,
                city);

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Zipcode = zipcode;
            this.City = city;
            this.ColorId = colorId;

            //this.ValidateColor(this.ColorId);
        }

        public void ValidateInput(
            string firstName,
            string lastName,
            string zipcode,
            string city)
        {
            this.ValidateFirstName(firstName);
            this.ValidateLastName(lastName);
            this.ValidateZipcode(zipcode);
            this.ValidateCity(city);
        }

        public void ValidateFirstName(string firstName)
            => Guard.ForStringLength<InvalidPersonException>(
                firstName,
                NameMinLength,
                NameMaxLength,
                nameof(firstName));

        public void ValidateLastName(string lastName)
            => Guard.ForStringLength<InvalidPersonException>(
                lastName,
                NameMinLength,
                NameMaxLength,
                nameof(lastName));

        private void ValidateZipcode(string zipcode)
            => Guard.ForValidZipcode<InvalidPersonException>(
                zipcode,
                nameof(zipcode));

        private void ValidateCity(string city)
            => Guard.ForStringLength<InvalidPersonException>(
                city,
                CityMinLength,
                CityMaxLength,
                nameof(city));

        //private void ValidateColor(int colorId)
        //{
        //    var color = AllColors.FirstOrDefault(c => c.Id == colorId);

        //    if (!string.IsNullOrEmpty(color.Name))
        //    {
        //        this.Color = color.Name;
        //        return;
        //    }

        //    var allowedColors = string.Join(", ", AllColors.Select(c => $"'{c.Name}'"));

        //    throw new InvalidPersonException($"'{color.Name}' is not a valid category. Allowed values are: {allowedColors}.");
        //}
    }
}
