using Domain.Concrete.Entities.VCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers.VCard
{
    public static class VCardHelper
    {
        public static string CreateVCard(UserVCard userVCard)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(VCardEntities.Header);
            stringBuilder.AppendLine(VCardEntities.NewLine);

            if (!string.IsNullOrEmpty(userVCard.FirstName) && !string.IsNullOrEmpty(userVCard.LastName))
            {
                stringBuilder.Append(VCardEntities.Name);
                stringBuilder.Append(userVCard.LastName);
                stringBuilder.Append(VCardEntities.Separator);
                stringBuilder.Append(userVCard.FirstName);
                stringBuilder.Append(VCardEntities.Separator);
                stringBuilder.AppendLine(VCardEntities.NewLine);
            }
            if (!string.IsNullOrEmpty(userVCard.FormattedName))
            {
                stringBuilder.Append(VCardEntities.FormattedName);
                stringBuilder.Append(userVCard.FormattedName);
                stringBuilder.Append(VCardEntities.NewLine);
            }
            if (!string.IsNullOrEmpty(userVCard.Organization))
            {
                stringBuilder.Append(VCardEntities.OrganizationName);
                stringBuilder.Append(userVCard.Organization);
                stringBuilder.Append(VCardEntities.NewLine);

            }
            if (!string.IsNullOrEmpty(userVCard.Title))
            {
                stringBuilder.Append(VCardEntities.TitlePrefix);
                stringBuilder.Append(userVCard.Title);
                stringBuilder.Append(VCardEntities.NewLine);
            }
            foreach (var item in userVCard.UserVCardPhones)
            {

                stringBuilder.Append(VCardEntities.PhonePrefix);
                if (item.Type == "work")
                {
                    stringBuilder.Append(VCardEntities.WorkType);
                    stringBuilder.Append(VCardEntities.PhoneSubPrefix);
                    stringBuilder.Append(item.PhoneNumber);
                    stringBuilder.Append(VCardEntities.NewLine);
                }
                if (item.Type == "cell")
                {
                    stringBuilder.Append(VCardEntities.CellType);
                    stringBuilder.Append(VCardEntities.PhoneSubPrefix);
                    stringBuilder.Append(item.PhoneNumber);
                    stringBuilder.Append(VCardEntities.NewLine);
                }

                stringBuilder.Append(VCardEntities.NewLine);
            }
            foreach (var item in userVCard.UserVCardAddresses)
            {

                stringBuilder.Append(VCardEntities.AddressPrefix);
                if (item.Type == "work")
                {
                    stringBuilder.Append(VCardEntities.WorkType);
                    stringBuilder.Append(VCardEntities.AddressSubPrefix);
                    stringBuilder.Append(item.AddressName);
                    stringBuilder.Append(VCardEntities.NewLine);

                }
                if (item.Type == "home")
                {
                    stringBuilder.Append(VCardEntities.HomeType);
                    stringBuilder.Append(VCardEntities.AddressSubPrefix);
                    stringBuilder.Append(item.AddressName);
                    stringBuilder.Append(VCardEntities.NewLine);
                }

                stringBuilder.Append(VCardEntities.NewLine);
            }
            foreach (var item in userVCard.UserVCardEmails)
            {

                stringBuilder.Append(VCardEntities.EmailPrefix);
                if (item.Type == "work")
                {
                    stringBuilder.Append(VCardEntities.WorkType);
                    stringBuilder.Append(VCardEntities.EmailSubPrefix);
                    stringBuilder.Append(item.Email);
                    stringBuilder.Append(VCardEntities.NewLine);
                }
                if (item.Type == "home")
                {
                    stringBuilder.Append(VCardEntities.HomeType);
                    stringBuilder.Append(VCardEntities.EmailSubPrefix);
                    stringBuilder.Append(item.Email);
                    stringBuilder.Append(VCardEntities.NewLine);
                }
                stringBuilder.Append(VCardEntities.NewLine);
            }

            stringBuilder.Append(VCardEntities.Footer);
            return stringBuilder.ToString();
        }
    }
}
