﻿using HighSchoolStudents.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HighSchoolStudents.Utilities
{
    class CustomSort : IComparer<KetQuaDuLieuHocSinh>
    {
        public int Compare([AllowNull] KetQuaDuLieuHocSinh x, [AllowNull] KetQuaDuLieuHocSinh y)
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
