using HighSchoolStudents.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HighSchoolStudents.Utilities
{
    class CustomSort : IComparer<DuLieuHocSinhDauRa>
    {
        public int Compare([AllowNull] DuLieuHocSinhDauRa x, [AllowNull] DuLieuHocSinhDauRa y)
        {
            if (x.DiemTrungBinh < y.DiemTrungBinh)
                return 1;
            else if (x.DiemTrungBinh == y.DiemTrungBinh)
                return 0;
            else
                return -1;
        }
    }
}
