using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSchoole.Configuration
{
    internal class MusicSchoolConfiguration
    {
        public static string musicSchoolPath = Path.Combine(
            Directory.GetCurrentDirectory(), "musicschool.xml");
    }
}
