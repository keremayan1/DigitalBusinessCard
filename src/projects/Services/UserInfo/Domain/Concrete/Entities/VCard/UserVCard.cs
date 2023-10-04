using Core.Persistance.Repositories.EntityFramework;
using SharpCompress.Compressors.PPMd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Entities.VCard
{
    public class UserVCard
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FormattedName { get; set; }
        public string Organization { get; set; }
        public List<UserVCardEmail> UserVCardEmails { get; set; }
        public string Title { get; set; }
        public List<UserVCardPhone> UserVCardPhones { get; set; }
        public List<UserVCardAddress> UserVCardAddresses { get; set; }

    }

}
